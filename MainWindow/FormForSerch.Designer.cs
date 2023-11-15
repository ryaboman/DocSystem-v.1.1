namespace MainWindow
{
    partial class FormForSerch
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
            this.buttonForSerch = new System.Windows.Forms.Button();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.dateBy = new System.Windows.Forms.DateTimePicker();
            this.textDestination = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textPerformer = new System.Windows.Forms.TextBox();
            this.textNameSN = new System.Windows.Forms.TextBox();
            this.textNumberSN = new System.Windows.Forms.TextBox();
            this.textSummary = new System.Windows.Forms.TextBox();
            this.checkDestination = new System.Windows.Forms.CheckBox();
            this.checkPerformer = new System.Windows.Forms.CheckBox();
            this.checkNameSN = new System.Windows.Forms.CheckBox();
            this.checkNumberSN = new System.Windows.Forms.CheckBox();
            this.checkSummary = new System.Windows.Forms.CheckBox();
            this.checkDate = new System.Windows.Forms.CheckBox();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonForSerch
            // 
            this.buttonForSerch.Location = new System.Drawing.Point(176, 364);
            this.buttonForSerch.Name = "buttonForSerch";
            this.buttonForSerch.Size = new System.Drawing.Size(75, 23);
            this.buttonForSerch.TabIndex = 7;
            this.buttonForSerch.Text = "Поиск";
            this.buttonForSerch.UseVisualStyleBackColor = true;
            this.buttonForSerch.Click += new System.EventHandler(this.buttonForSerch_Click);
            // 
            // dateFrom
            // 
            this.dateFrom.Checked = false;
            this.dateFrom.Location = new System.Drawing.Point(110, 292);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(141, 20);
            this.dateFrom.TabIndex = 5;
            // 
            // dateBy
            // 
            this.dateBy.Location = new System.Drawing.Point(110, 318);
            this.dateBy.Name = "dateBy";
            this.dateBy.Size = new System.Drawing.Size(141, 20);
            this.dateBy.TabIndex = 6;
            // 
            // textDestination
            // 
            this.textDestination.Location = new System.Drawing.Point(110, 29);
            this.textDestination.Name = "textDestination";
            this.textDestination.Size = new System.Drawing.Size(141, 20);
            this.textDestination.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Адресат";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Исполнитель";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Наименование";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Содержание";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Номер СЗ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(74, 298);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "СЗ с";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(85, 324);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "по";
            // 
            // textPerformer
            // 
            this.textPerformer.Location = new System.Drawing.Point(110, 75);
            this.textPerformer.Name = "textPerformer";
            this.textPerformer.Size = new System.Drawing.Size(141, 20);
            this.textPerformer.TabIndex = 1;
            // 
            // textNameSN
            // 
            this.textNameSN.Location = new System.Drawing.Point(110, 125);
            this.textNameSN.Name = "textNameSN";
            this.textNameSN.Size = new System.Drawing.Size(141, 20);
            this.textNameSN.TabIndex = 2;
            // 
            // textNumberSN
            // 
            this.textNumberSN.Location = new System.Drawing.Point(110, 174);
            this.textNumberSN.Name = "textNumberSN";
            this.textNumberSN.Size = new System.Drawing.Size(141, 20);
            this.textNumberSN.TabIndex = 3;
            // 
            // textSummary
            // 
            this.textSummary.Location = new System.Drawing.Point(110, 219);
            this.textSummary.Multiline = true;
            this.textSummary.Name = "textSummary";
            this.textSummary.Size = new System.Drawing.Size(141, 44);
            this.textSummary.TabIndex = 4;
            // 
            // checkDestination
            // 
            this.checkDestination.AutoSize = true;
            this.checkDestination.Location = new System.Drawing.Point(256, 32);
            this.checkDestination.Name = "checkDestination";
            this.checkDestination.Size = new System.Drawing.Size(15, 14);
            this.checkDestination.TabIndex = 7;
            this.checkDestination.TabStop = false;
            this.checkDestination.UseVisualStyleBackColor = true;
            this.checkDestination.CheckedChanged += new System.EventHandler(this.checkNumberSN_CheckedChanged);
            // 
            // checkPerformer
            // 
            this.checkPerformer.AutoSize = true;
            this.checkPerformer.Location = new System.Drawing.Point(256, 78);
            this.checkPerformer.Name = "checkPerformer";
            this.checkPerformer.Size = new System.Drawing.Size(15, 14);
            this.checkPerformer.TabIndex = 8;
            this.checkPerformer.TabStop = false;
            this.checkPerformer.UseVisualStyleBackColor = true;
            this.checkPerformer.CheckedChanged += new System.EventHandler(this.checkNumberSN_CheckedChanged);
            // 
            // checkNameSN
            // 
            this.checkNameSN.AutoSize = true;
            this.checkNameSN.Location = new System.Drawing.Point(256, 128);
            this.checkNameSN.Name = "checkNameSN";
            this.checkNameSN.Size = new System.Drawing.Size(15, 14);
            this.checkNameSN.TabIndex = 9;
            this.checkNameSN.TabStop = false;
            this.checkNameSN.UseVisualStyleBackColor = true;
            this.checkNameSN.CheckedChanged += new System.EventHandler(this.checkNumberSN_CheckedChanged);
            // 
            // checkNumberSN
            // 
            this.checkNumberSN.AutoSize = true;
            this.checkNumberSN.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkNumberSN.Location = new System.Drawing.Point(256, 177);
            this.checkNumberSN.Name = "checkNumberSN";
            this.checkNumberSN.Size = new System.Drawing.Size(15, 14);
            this.checkNumberSN.TabIndex = 10;
            this.checkNumberSN.TabStop = false;
            this.checkNumberSN.UseVisualStyleBackColor = true;
            this.checkNumberSN.CheckedChanged += new System.EventHandler(this.checkNumberSN_CheckedChanged);
            // 
            // checkSummary
            // 
            this.checkSummary.AutoSize = true;
            this.checkSummary.Location = new System.Drawing.Point(256, 233);
            this.checkSummary.Name = "checkSummary";
            this.checkSummary.Size = new System.Drawing.Size(15, 14);
            this.checkSummary.TabIndex = 11;
            this.checkSummary.TabStop = false;
            this.checkSummary.UseVisualStyleBackColor = true;
            this.checkSummary.CheckedChanged += new System.EventHandler(this.checkNumberSN_CheckedChanged);
            // 
            // checkDate
            // 
            this.checkDate.AutoSize = true;
            this.checkDate.Location = new System.Drawing.Point(256, 307);
            this.checkDate.Name = "checkDate";
            this.checkDate.Size = new System.Drawing.Size(15, 14);
            this.checkDate.TabIndex = 12;
            this.checkDate.TabStop = false;
            this.checkDate.UseVisualStyleBackColor = true;
            this.checkDate.CheckedChanged += new System.EventHandler(this.checkNumberSN_CheckedChanged);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(29, 364);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 13;
            this.cancel.Text = "Отмена";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // FormForSerch
            // 
            this.AcceptButton = this.buttonForSerch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(283, 411);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.checkDate);
            this.Controls.Add(this.checkSummary);
            this.Controls.Add(this.checkNumberSN);
            this.Controls.Add(this.checkNameSN);
            this.Controls.Add(this.checkPerformer);
            this.Controls.Add(this.checkDestination);
            this.Controls.Add(this.textSummary);
            this.Controls.Add(this.textNumberSN);
            this.Controls.Add(this.textNameSN);
            this.Controls.Add(this.textPerformer);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textDestination);
            this.Controls.Add(this.dateBy);
            this.Controls.Add(this.dateFrom);
            this.Controls.Add(this.buttonForSerch);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(299, 450);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(299, 450);
            this.Name = "FormForSerch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Сложный запрос";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonForSerch;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.DateTimePicker dateBy;
        private System.Windows.Forms.TextBox textDestination;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textPerformer;
        private System.Windows.Forms.TextBox textSummary;
        private System.Windows.Forms.TextBox textNumberSN;
        private System.Windows.Forms.TextBox textNameSN;
        private System.Windows.Forms.CheckBox checkDestination;
        private System.Windows.Forms.CheckBox checkPerformer;
        private System.Windows.Forms.CheckBox checkNameSN;
        private System.Windows.Forms.CheckBox checkNumberSN;
        private System.Windows.Forms.CheckBox checkSummary;
        private System.Windows.Forms.CheckBox checkDate;
        private System.Windows.Forms.Button cancel;
    }
}