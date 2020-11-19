namespace WaproMagPoprawienieNazwy
{
    partial class EnterCustomBrandDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbBrandName = new System.Windows.Forms.TextBox();
            this.bAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wpisz własną nazwę producena:";
            // 
            // tbBrandName
            // 
            this.tbBrandName.Location = new System.Drawing.Point(12, 49);
            this.tbBrandName.Name = "tbBrandName";
            this.tbBrandName.Size = new System.Drawing.Size(189, 20);
            this.tbBrandName.TabIndex = 1;
            // 
            // bAccept
            // 
            this.bAccept.Location = new System.Drawing.Point(12, 91);
            this.bAccept.Name = "bAccept";
            this.bAccept.Size = new System.Drawing.Size(189, 23);
            this.bAccept.TabIndex = 2;
            this.bAccept.Text = "Zatwierdź";
            this.bAccept.UseVisualStyleBackColor = true;
            this.bAccept.Click += new System.EventHandler(this.bAccept_Click);
            // 
            // EnterCustomBrandDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 126);
            this.Controls.Add(this.bAccept);
            this.Controls.Add(this.tbBrandName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EnterCustomBrandDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Własna nazwa producenta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBrandName;
        private System.Windows.Forms.Button bAccept;
    }
}