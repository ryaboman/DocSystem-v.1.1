namespace MainWindow
{
    partial class Setting
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
            this.server = new System.Windows.Forms.TextBox();
            this.database = new System.Windows.Forms.TextBox();
            this.user = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.pathToPatternes = new System.Windows.Forms.TextBox();
            this.butAttachDirectory = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Ok = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.checkConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // server
            // 
            this.server.Location = new System.Drawing.Point(12, 26);
            this.server.Name = "server";
            this.server.Size = new System.Drawing.Size(168, 20);
            this.server.TabIndex = 0;
            // 
            // database
            // 
            this.database.Location = new System.Drawing.Point(12, 66);
            this.database.Name = "database";
            this.database.Size = new System.Drawing.Size(168, 20);
            this.database.TabIndex = 1;
            // 
            // user
            // 
            this.user.Location = new System.Drawing.Point(12, 106);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(168, 20);
            this.user.TabIndex = 2;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(12, 147);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(168, 20);
            this.password.TabIndex = 3;
            // 
            // pathToPatternes
            // 
            this.pathToPatternes.Location = new System.Drawing.Point(12, 233);
            this.pathToPatternes.Name = "pathToPatternes";
            this.pathToPatternes.Size = new System.Drawing.Size(132, 20);
            this.pathToPatternes.TabIndex = 5;
            // 
            // butAttachDirectory
            // 
            this.butAttachDirectory.Location = new System.Drawing.Point(150, 231);
            this.butAttachDirectory.Name = "butAttachDirectory";
            this.butAttachDirectory.Size = new System.Drawing.Size(30, 23);
            this.butAttachDirectory.TabIndex = 6;
            this.butAttachDirectory.Text = "...";
            this.butAttachDirectory.UseVisualStyleBackColor = true;
            this.butAttachDirectory.Click += new System.EventHandler(this.butAttachDirectory_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Папка с шаблонами";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Сервер";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "База данных";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Пользователь";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Пароль";
            // 
            // Ok
            // 
            this.Ok.Location = new System.Drawing.Point(105, 276);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(75, 23);
            this.Ok.TabIndex = 12;
            this.Ok.Text = "Ок";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(12, 276);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 13;
            this.Cancel.Text = "Отмена";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // checkConnect
            // 
            this.checkConnect.Location = new System.Drawing.Point(105, 177);
            this.checkConnect.Name = "checkConnect";
            this.checkConnect.Size = new System.Drawing.Size(75, 23);
            this.checkConnect.TabIndex = 14;
            this.checkConnect.Text = "Тест";
            this.checkConnect.UseVisualStyleBackColor = true;
            this.checkConnect.Click += new System.EventHandler(this.checkConnect_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 325);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.checkConnect);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butAttachDirectory);
            this.Controls.Add(this.pathToPatternes);
            this.Controls.Add(this.password);
            this.Controls.Add(this.user);
            this.Controls.Add(this.database);
            this.Controls.Add(this.server);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(208, 364);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(208, 364);
            this.Name = "Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox server;
        private System.Windows.Forms.TextBox database;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox pathToPatternes;
        private System.Windows.Forms.Button butAttachDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button checkConnect;
    }
}