namespace MainWindow
{
    partial class FormForCreateDoc
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
            this.comboBoxDestin = new System.Windows.Forms.ComboBox();
            this.textNameSN = new System.Windows.Forms.TextBox();
            this.textSN = new System.Windows.Forms.TextBox();
            this.comboBoxPerformer = new System.Windows.Forms.ComboBox();
            this.CreateSN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxDestin
            // 
            this.comboBoxDestin.FormattingEnabled = true;
            this.comboBoxDestin.Location = new System.Drawing.Point(211, 25);
            this.comboBoxDestin.Name = "comboBoxDestin";
            this.comboBoxDestin.Size = new System.Drawing.Size(185, 21);
            this.comboBoxDestin.TabIndex = 1;
            // 
            // textNameSN
            // 
            this.textNameSN.Location = new System.Drawing.Point(14, 26);
            this.textNameSN.MaxLength = 45;
            this.textNameSN.Name = "textNameSN";
            this.textNameSN.Size = new System.Drawing.Size(184, 20);
            this.textNameSN.TabIndex = 0;
            // 
            // textSN
            // 
            this.textSN.AccessibleDescription = "";
            this.textSN.AccessibleName = "";
            this.textSN.Location = new System.Drawing.Point(12, 67);
            this.textSN.MaxLength = 256;
            this.textSN.Multiline = true;
            this.textSN.Name = "textSN";
            this.textSN.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textSN.Size = new System.Drawing.Size(384, 101);
            this.textSN.TabIndex = 2;
            this.textSN.Tag = "";
            // 
            // comboBoxPerformer
            // 
            this.comboBoxPerformer.Enabled = false;
            this.comboBoxPerformer.FormattingEnabled = true;
            this.comboBoxPerformer.Location = new System.Drawing.Point(14, 199);
            this.comboBoxPerformer.Name = "comboBoxPerformer";
            this.comboBoxPerformer.Size = new System.Drawing.Size(185, 21);
            this.comboBoxPerformer.TabIndex = 1;
            // 
            // CreateSN
            // 
            this.CreateSN.Location = new System.Drawing.Point(321, 197);
            this.CreateSN.Name = "CreateSN";
            this.CreateSN.Size = new System.Drawing.Size(75, 23);
            this.CreateSN.TabIndex = 2;
            this.CreateSN.Text = "Создать";
            this.CreateSN.UseVisualStyleBackColor = true;
            this.CreateSN.Click += new System.EventHandler(this.CreateDoc_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Наименование документа";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Адресат документа";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Исполнитель";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Краткое содержание (не более 256 символов)";
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(231, 197);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 7;
            this.Cancel.Text = "Отмена";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // FormForCreateDoc
            // 
            this.AcceptButton = this.CreateSN;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(409, 241);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CreateSN);
            this.Controls.Add(this.comboBoxPerformer);
            this.Controls.Add(this.comboBoxDestin);
            this.Controls.Add(this.textSN);
            this.Controls.Add(this.textNameSN);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(425, 280);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(425, 280);
            this.Name = "FormForCreateDoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание документа";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxDestin;
        private System.Windows.Forms.TextBox textNameSN;
        private System.Windows.Forms.TextBox textSN;
        private System.Windows.Forms.ComboBox comboBoxPerformer;
        private System.Windows.Forms.Button CreateSN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Cancel;
    }
}