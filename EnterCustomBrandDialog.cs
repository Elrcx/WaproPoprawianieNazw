using System;
using System.Windows.Forms;

namespace WaproMagPoprawienieNazwy
{
    public partial class EnterCustomBrandDialog : Form
    {
        public string NewBrandName = string.Empty;

        public EnterCustomBrandDialog()
        {
            InitializeComponent();
        }

        public void SetExample(string text)
        {
            tbBrandName.Text = text;
        }

        private void bAccept_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbBrandName.Text))
            {
                NewBrandName = tbBrandName.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else MessageBox.Show("Wpisz prawidłową nazwę producenta!");
        }
    }
}
