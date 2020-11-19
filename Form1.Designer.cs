namespace WaproMagPoprawienieNazwy
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.bOpenCsvFile = new System.Windows.Forms.Button();
            this.gbControls = new System.Windows.Forms.GroupBox();
            this.lFixProgress = new System.Windows.Forms.Label();
            this.lFileStatus = new System.Windows.Forms.Label();
            this.bFixNames = new System.Windows.Forms.Button();
            this.lNameDatabase = new System.Windows.Forms.Label();
            this.bwFixNames = new System.ComponentModel.BackgroundWorker();
            this.pbFixProgress = new System.Windows.Forms.ProgressBar();
            this.gbControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // bOpenCsvFile
            // 
            this.bOpenCsvFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bOpenCsvFile.Location = new System.Drawing.Point(6, 19);
            this.bOpenCsvFile.Name = "bOpenCsvFile";
            this.bOpenCsvFile.Size = new System.Drawing.Size(263, 46);
            this.bOpenCsvFile.TabIndex = 0;
            this.bOpenCsvFile.Text = "Plik .csv";
            this.bOpenCsvFile.UseVisualStyleBackColor = true;
            this.bOpenCsvFile.Click += new System.EventHandler(this.bOpenCsvFile_Click);
            // 
            // gbControls
            // 
            this.gbControls.Controls.Add(this.lFileStatus);
            this.gbControls.Controls.Add(this.bFixNames);
            this.gbControls.Controls.Add(this.bOpenCsvFile);
            this.gbControls.Location = new System.Drawing.Point(12, 12);
            this.gbControls.Name = "gbControls";
            this.gbControls.Size = new System.Drawing.Size(274, 151);
            this.gbControls.TabIndex = 1;
            this.gbControls.TabStop = false;
            // 
            // lFixProgress
            // 
            this.lFixProgress.Location = new System.Drawing.Point(159, 166);
            this.lFixProgress.Name = "lFixProgress";
            this.lFixProgress.Size = new System.Drawing.Size(127, 23);
            this.lFixProgress.TabIndex = 3;
            this.lFixProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lFileStatus
            // 
            this.lFileStatus.Location = new System.Drawing.Point(5, 69);
            this.lFileStatus.Name = "lFileStatus";
            this.lFileStatus.Size = new System.Drawing.Size(173, 23);
            this.lFileStatus.TabIndex = 2;
            this.lFileStatus.Text = "Wczytaj plik csv.";
            this.lFileStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bFixNames
            // 
            this.bFixNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bFixNames.Enabled = false;
            this.bFixNames.Location = new System.Drawing.Point(5, 95);
            this.bFixNames.Name = "bFixNames";
            this.bFixNames.Size = new System.Drawing.Size(263, 47);
            this.bFixNames.TabIndex = 1;
            this.bFixNames.Text = "Popraw nazwy";
            this.bFixNames.UseVisualStyleBackColor = true;
            this.bFixNames.Click += new System.EventHandler(this.bFixNames_Click);
            // 
            // lNameDatabase
            // 
            this.lNameDatabase.AutoSize = true;
            this.lNameDatabase.Location = new System.Drawing.Point(9, 172);
            this.lNameDatabase.Name = "lNameDatabase";
            this.lNameDatabase.Size = new System.Drawing.Size(143, 13);
            this.lNameDatabase.TabIndex = 3;
            this.lNameDatabase.Text = "Nazwy produktów w bazie: 0";
            // 
            // bwFixNames
            // 
            this.bwFixNames.WorkerReportsProgress = true;
            this.bwFixNames.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwFixNames_DoWork);
            this.bwFixNames.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwFixNames_ProgressChanged);
            // 
            // pbFixProgress
            // 
            this.pbFixProgress.Location = new System.Drawing.Point(12, 195);
            this.pbFixProgress.Name = "pbFixProgress";
            this.pbFixProgress.Size = new System.Drawing.Size(274, 23);
            this.pbFixProgress.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 230);
            this.Controls.Add(this.pbFixProgress);
            this.Controls.Add(this.lFixProgress);
            this.Controls.Add(this.lNameDatabase);
            this.Controls.Add(this.gbControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Poprawienie nazw Wapro Mag";
            this.gbControls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bOpenCsvFile;
        private System.Windows.Forms.GroupBox gbControls;
        private System.Windows.Forms.Button bFixNames;
        private System.Windows.Forms.Label lFileStatus;
        private System.Windows.Forms.Label lNameDatabase;
        private System.Windows.Forms.Label lFixProgress;
        private System.ComponentModel.BackgroundWorker bwFixNames;
        private System.Windows.Forms.ProgressBar pbFixProgress;
    }
}

