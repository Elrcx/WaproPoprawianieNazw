using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;

namespace WaproMagPoprawienieNazwy
{
    public partial class Form1 : Form
    {
        private List<string[]> Products = new List<string[]>();
        private List<string> ProductTypeDictionary = new List<string>();

        private List<string[]> ProductsFixed = new List<string[]>();
        private List<string[]> ProductsFixedToCheck = new List<string[]>();

        private string OriginalFileLocation;
        private string CustomBrandName;

        public Form1()
        {
            InitializeComponent();
            FillProductTypeDictionary();
        }

        private void FillProductTypeDictionary()
        {
            List<string> products = new List<string>();
            products.Clear();

            string line;
            int counter = 0;

            string namefile = AppDomain.CurrentDomain.BaseDirectory + @"/nazwy.txt";
            if (File.Exists(namefile))
            {
                StreamReader file = new StreamReader(namefile);
                while ((line = file.ReadLine()) != null)
                {
                    products.Add(line.ToLower());
                    counter++;
                }

                lNameDatabase.Text = "Nazwy produktów w bazie: " + counter;
                file.Close();
            }
            else MessageBox.Show("Nie znaleziono pliku nazwy.txt w katalogu programu.\nAby aplikacja działała poprawnie utwórz plik o nazwie 'nazwy.txt' w miejscu w którym znajduje się program.\n\nW pliku możesz wpisywać nazwy produktów (jedna nazwa na linijkę) które będą używane przez aplikacje do rozróżnienia artykułów z pliku.");
            products.Sort();

            ProductTypeDictionary.Clear();
            ProductTypeDictionary = products.Distinct().ToList();
        }

        private void bOpenCsvFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Plik CSV (*.csv)|*.csv|Wszystkie pliki (*.*)|*.*";
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    OriginalFileLocation = Path.GetDirectoryName(ofd.FileName);
                    ReadAndConvertTextFile(ofd.FileName);

                    bFixNames.Enabled = true;
                    lFileStatus.Text = string.Format("Wczytano plik z {0} artykułami.", Products.Count - 1);
                }
            }
        }

        private void ReadAndConvertTextFile(string fileLocation)
        {
            string line;
            Products.Clear();

            StreamReader file = new StreamReader(fileLocation, Encoding.UTF8);
            while ((line = file.ReadLine()) != null)
            {
                string[] values = line.Split(';');
                Products.Add(values);
            }
        }

        private void bFixNames_Click(object sender, EventArgs e)
        {
            bwFixNames.RunWorkerAsync();
        }

        private void FixNames()
        {
            gbControls.BeginInvoke((Action)delegate() { gbControls.Enabled = false; });
            string[] clothesSizes = { "xxs", "xs", "s", "m", "l", "xl", "xxl", "xxxl", "xxxxl", "2xl", "3xl", "4xl", "5xl", "6xl" };
            ProductsFixed.Clear();
            ProductsFixedToCheck.Clear();
            bool getBrandFromCategorySkipQuestion = false;

            int id = 0;
            foreach (string[] product in Products.Skip(1))
            {
                id++;
                bwFixNames.ReportProgress((int)((float)((float)id/(float)Products.Count)*100));
                bool problem = false;
                string productName = product[0];
                string productName2 = product[1];
                string productBrand = product[25].ToUpper();
                string productIndex = product[9];

                if (!getBrandFromCategorySkipQuestion && string.IsNullOrEmpty(productBrand))
                {
                    DialogResult resultCustom = MessageBox.Show("Niektóre produkty nie mają ustawionego producenta.\n\nChcesz wpisać nazwę producenta ręcznie?\n\nZostanie ona zastosowana do wszystkich produktów bez określonego producenta.\n\nPo wybraniu 'nie' pole to zostanie pozostawione puste.", "Brak producenta", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (resultCustom == DialogResult.Yes)
                    {
                        using (EnterCustomBrandDialog dialog = new EnterCustomBrandDialog())
                        {
                            DialogResult dr = new DialogResult();
                            dialog.SetExample(product[3]);
                            dr = dialog.ShowDialog();
                            if (dialog.DialogResult == DialogResult.OK) CustomBrandName = dialog.NewBrandName;
                        }
                    }
                    getBrandFromCategorySkipQuestion = true;
                    if (resultCustom == DialogResult.Cancel) break;
                }
                if (string.IsNullOrEmpty(productBrand) && !string.IsNullOrEmpty(CustomBrandName)) productBrand = CustomBrandName;

                List<string> foundTypes = new List<string>();
                foreach (string type in ProductTypeDictionary)
                {
                    string productNameLower = RemoveDiacritics(productName.ToLower());
                    if (productNameLower.Contains(RemoveDiacritics(type))) foundTypes.Add(type);
                    //if (Regex.IsMatch(productNameLower, RemoveDiacritics(type))) foundTypes.Add(type);
                }

                string selectedType = " ";
                foreach (string type in foundTypes)
                    if (type.Length > selectedType.Length) selectedType = type;

                string newProductName = string.Format("{0} {1} {2}", productBrand, selectedType.ToUpper(), productIndex);
                string newProductName2 = string.Format("{0} | {1}", productName2, productName);
                if (string.IsNullOrWhiteSpace(productName2)) newProductName2 = productName;
                if (productName == productName2) newProductName2 = productName;

                if (string.IsNullOrEmpty(productBrand)) problem = true;
                if (foundTypes.Count == 0) problem = true;
                if (selectedType == " ") problem = true;
                if (foundTypes.Count > 1)
                {
                    foreach (string type in foundTypes)
                    {
                        if (selectedType.Substring(0, 2) != type.Substring(0, 2))
                        {
                            if (selectedType.Contains(type)) break;
                            problem = true;
                            break;
                        }
                    }
                }

                // Clothes size detection.
                string fullOldName = productName.ToLower() + " " + productName2.ToLower() + " ";
                string detectedSize = "";

                for (int i = 0; i < clothesSizes.Length; i++)
                {
                    if (fullOldName.Contains(" " + clothesSizes[i] + " ")) detectedSize = clothesSizes[i];
                    if (fullOldName.Contains("." + clothesSizes[i] + " ")) detectedSize = clothesSizes[i];
                    if (fullOldName.Contains("-" + clothesSizes[i] + " ")) detectedSize = clothesSizes[i];
                    if (!string.IsNullOrEmpty(detectedSize)) break;
                }
                if (string.IsNullOrEmpty(detectedSize))
                {
                    if (fullOldName.Contains("roz") || fullOldName.Contains("rozm") || fullOldName.Contains("rozmiar"))
                    {
                        detectedSize = Regex.Match(fullOldName, @"\d+").Value;
                    }
                }

                if (!string.IsNullOrEmpty(detectedSize)) newProductName = string.Format("{0} {1} {2} {3}", productBrand, selectedType.ToUpper(), detectedSize.ToUpper(), productIndex);

                //

                if (newProductName.Length > 40)
                {
                    problem = true;
                    newProductName = newProductName.Insert(0, "[! " + newProductName.Length + " !] ");
                }

                if (problem)
                {
                    ProductsFixedToCheck.Add(product);
                    int newItem = ProductsFixedToCheck.Count - 1;
                    ProductsFixedToCheck[newItem][0] = newProductName;
                    ProductsFixedToCheck[newItem][1] = newProductName2;
                    if (string.IsNullOrWhiteSpace(ProductsFixedToCheck[newItem][25]) && !string.IsNullOrWhiteSpace(CustomBrandName)) ProductsFixedToCheck[newItem][25] = CustomBrandName;
                }
                else
                {
                    ProductsFixed.Add(product);
                    int newItem = ProductsFixed.Count - 1;
                    ProductsFixed[newItem][0] = newProductName;
                    ProductsFixed[newItem][1] = newProductName2;
                    if (string.IsNullOrWhiteSpace(ProductsFixed[newItem][25]) && !string.IsNullOrWhiteSpace(CustomBrandName)) ProductsFixed[newItem][25] = CustomBrandName;
                }
            }

            ProductsFixed.Insert(0, Products[0]);
            ProductsFixedToCheck.Insert(0, Products[0]);

            SaveCsvFile();
            gbControls.BeginInvoke((Action)delegate () { gbControls.Enabled = true; });
        }

        private void SaveCsvFile()
        {
            using (TextWriter tw = new StreamWriter(new FileStream(OriginalFileLocation + @"\artykulPoprawione.csv", FileMode.Create, FileAccess.ReadWrite), Encoding.UTF8))
            {
                foreach (String[] s in ProductsFixed)
                    {
                        string data = "";
                        foreach (string str in s) data += str + ";";
                        tw.WriteLine(data);
                    }
            }
            if (ProductsFixedToCheck.Count > 1)
            {
                using (TextWriter tw = new StreamWriter(new FileStream(OriginalFileLocation + @"\artykulPoprawioneDoSprawdzenia.csv", FileMode.Create, FileAccess.ReadWrite), Encoding.UTF8))
                {
                    foreach (String[] s in ProductsFixedToCheck)
                    {
                        string data = "";
                        foreach (string str in s) data += str + ";";
                        tw.WriteLine(data);
                    }
                }
                MessageBox.Show("Zapisano poprawione nazwy do pliku artykulPoprawione.csv\n\nDodatkowo został utworzony plik artykulPoprawioneDoSprawdzenia.csv w którym znajdują się artykuły których aplikacja nie potrafiła poprawnie poprawić lub podejrzewa że popełniła błąd.\n\nArtukyły które mają zbyt długą nazwę (ponad 40 znaków) zostały oznaczone znakiem [! # !] (gdzie # to ilość znaków).");
            }
            else
            {
                MessageBox.Show("Zapisano poprawione nazwy do pliku artykulPoprawione.csv");
            }
        }


        public string RemoveDiacritics(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            text = text.Normalize(NormalizationForm.FormD);
            var chars = text.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray();
            string word = new string(chars).Normalize(NormalizationForm.FormC);
            string newword = word.Replace('ł', 'l');
            return newword;
        }

        private void bwFixNames_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            FixNames();
        }

        private void bwFixNames_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            pbFixProgress.Value = e.ProgressPercentage;
        }
    }
}
