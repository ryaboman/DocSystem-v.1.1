namespace MainWindow
{
    partial class AddDocWithNumber
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
            this.numberDoc = new System.Windows.Forms.TextBox();
            this.textBoxNameDoc = new System.Windows.Forms.TextBox();
            this.comboBoxPerformer = new System.Windows.Forms.ComboBox();
            this.AddBaseFile = new System.Windows.Forms.Button();
            this.textBoxBaseFile = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lableFileDoc = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxDestin = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxSummary = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rdBtnCreate = new System.Windows.Forms.RadioButton();
            this.rdBtnAttached = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // numberDoc
            // 
            this.numberDoc.Location = new System.Drawing.Point(8, 26);
            this.numberDoc.Name = "numberDoc";
            this.numberDoc.Size = new System.Drawing.Size(58, 20);
            this.numberDoc.TabIndex = 0;
            // 
            // textBoxNameDoc
            // 
            this.textBoxNameDoc.Location = new System.Drawing.Point(118, 26);
            this.textBoxNameDoc.Name = "textBoxNameDoc";
            this.textBoxNameDoc.Size = new System.Drawing.Size(185, 20);
            this.textBoxNameDoc.TabIndex = 1;
            // 
            // comboBoxPerformer
            // 
            this.comboBoxPerformer.Enabled = false;
            this.comboBoxPerformer.FormattingEnabled = true;
            this.comboBoxPerformer.Location = new System.Drawing.Point(8, 217);
            this.comboBoxPerformer.Name = "comboBoxPerformer";
            this.comboBoxPerformer.Size = new System.Drawing.Size(141, 21);
            this.comboBoxPerformer.TabIndex = 2;
            // 
            // AddBaseFile
            // 
            this.AddBaseFile.Enabled = false;
            this.AddBaseFile.Location = new System.Drawing.Point(217, 48);
            this.AddBaseFile.Name = "AddBaseFile";
            this.AddBaseFile.Size = new System.Drawing.Size(85, 23);
            this.AddBaseFile.TabIndex = 4;
            this.AddBaseFile.Text = "Прикрепить";
            this.AddBaseFile.UseVisualStyleBackColor = true;
            this.AddBaseFile.Click += new System.EventHandler(this.AddBaseFile_Click);
            // 
            // textBoxBaseFile
            // 
            this.textBoxBaseFile.Enabled = false;
            this.textBoxBaseFile.Location = new System.Drawing.Point(7, 50);
            this.textBoxBaseFile.Name = "textBoxBaseFile";
            this.textBoxBaseFile.Size = new System.Drawing.Size(185, 20);
            this.textBoxBaseFile.TabIndex = 5;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(228, 358);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "ОК";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(8, 358);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 8;
            this.Cancel.Text = "Отмена";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Номер документа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Наименование документа";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Исполнитель";
            // 
            // lableFileDoc
            // 
            this.lableFileDoc.AutoSize = true;
            this.lableFileDoc.Enabled = false;
            this.lableFileDoc.Location = new System.Drawing.Point(4, 34);
            this.lableFileDoc.Name = "lableFileDoc";
            this.lableFileDoc.Size = new System.Drawing.Size(93, 13);
            this.lableFileDoc.TabIndex = 12;
            this.lableFileDoc.Text = "Файл документа";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(164, 218);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(139, 20);
            this.dateTimePicker.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(161, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Дата";
            // 
            // comboBoxDestin
            // 
            this.comboBoxDestin.DropDownWidth = 300;
            this.comboBoxDestin.FormattingEnabled = true;
            this.comboBoxDestin.Location = new System.Drawing.Point(8, 72);
            this.comboBoxDestin.Name = "comboBoxDestin";
            this.comboBoxDestin.Size = new System.Drawing.Size(185, 21);
            this.comboBoxDestin.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Адресат";
            // 
            // textBoxSummary
            // 
            this.textBoxSummary.Location = new System.Drawing.Point(8, 122);
            this.textBoxSummary.MaxLength = 256;
            this.textBoxSummary.Multiline = true;
            this.textBoxSummary.Name = "textBoxSummary";
            this.textBoxSummary.Size = new System.Drawing.Size(295, 71);
            this.textBoxSummary.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(242, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Краткое содержание (не более 256 символов)";
            // 
            // rdBtnCreate
            // 
            this.rdBtnCreate.AutoSize = true;
            this.rdBtnCreate.Location = new System.Drawing.Point(7, 11);
            this.rdBtnCreate.Name = "rdBtnCreate";
            this.rdBtnCreate.Size = new System.Drawing.Size(122, 17);
            this.rdBtnCreate.TabIndex = 20;
            this.rdBtnCreate.TabStop = true;
            this.rdBtnCreate.Text = "Создать word-файл";
            this.rdBtnCreate.UseVisualStyleBackColor = true;
            // 
            // rdBtnAttached
            // 
            this.rdBtnAttached.AutoSize = true;
            this.rdBtnAttached.Location = new System.Drawing.Point(161, 11);
            this.rdBtnAttached.Name = "rdBtnAttached";
            this.rdBtnAttached.Size = new System.Drawing.Size(141, 17);
            this.rdBtnAttached.TabIndex = 21;
            this.rdBtnAttached.TabStop = true;
            this.rdBtnAttached.Text = "Прикрепить word-файл";
            this.rdBtnAttached.UseVisualStyleBackColor = true;
            this.rdBtnAttached.CheckedChanged += new System.EventHandler(this.rdBtnAttached_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numberDoc);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxNameDoc);
            this.groupBox1.Controls.Add(this.textBoxSummary);
            this.groupBox1.Controls.Add(this.comboBoxPerformer);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxDestin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dateTimePicker);
            this.groupBox1.Location = new System.Drawing.Point(4, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 247);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdBtnCreate);
            this.groupBox2.Controls.Add(this.AddBaseFile);
            this.groupBox2.Controls.Add(this.rdBtnAttached);
            this.groupBox2.Controls.Add(this.textBoxBaseFile);
            this.groupBox2.Controls.Add(this.lableFileDoc);
            this.groupBox2.Location = new System.Drawing.Point(4, 255);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(311, 79);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            // 
            // AddDocWithNumber
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(319, 397);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.buttonOK);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(335, 436);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(335, 436);
            this.Name = "AddDocWithNumber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить документ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox numberDoc;
        private System.Windows.Forms.TextBox textBoxNameDoc;
        private System.Windows.Forms.ComboBox comboBoxPerformer;
        private System.Windows.Forms.Button AddBaseFile;
        private System.Windows.Forms.TextBox textBoxBaseFile;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lableFileDoc;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxDestin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxSummary;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdBtnCreate;
        private System.Windows.Forms.RadioButton rdBtnAttached;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}