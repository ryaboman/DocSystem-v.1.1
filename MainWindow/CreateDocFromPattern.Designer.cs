namespace MainWindow
{
    partial class CreateDocFromPattern
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateDocFromPattern));
            this.butCancel = new System.Windows.Forms.Button();
            this.butCreate = new System.Windows.Forms.Button();
            this.treeViewFileConduc = new System.Windows.Forms.TreeView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemCreateFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAddFile = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuItemEditFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDeleteElement = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(12, 221);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 1;
            this.butCancel.Text = "Отмена";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butCreate
            // 
            this.butCreate.Location = new System.Drawing.Point(197, 221);
            this.butCreate.Name = "butCreate";
            this.butCreate.Size = new System.Drawing.Size(75, 23);
            this.butCreate.TabIndex = 2;
            this.butCreate.Text = "Создать";
            this.butCreate.UseVisualStyleBackColor = true;
            this.butCreate.Click += new System.EventHandler(this.butCreate_Click);
            // 
            // treeViewFileConduc
            // 
            this.treeViewFileConduc.ContextMenuStrip = this.contextMenuStrip;
            this.treeViewFileConduc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewFileConduc.ImageIndex = 0;
            this.treeViewFileConduc.ImageList = this.imageList;
            this.treeViewFileConduc.LabelEdit = true;
            this.treeViewFileConduc.Location = new System.Drawing.Point(0, 0);
            this.treeViewFileConduc.Name = "treeViewFileConduc";
            this.treeViewFileConduc.SelectedImageIndex = 0;
            this.treeViewFileConduc.Size = new System.Drawing.Size(284, 255);
            this.treeViewFileConduc.TabIndex = 3;
            this.treeViewFileConduc.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewFileConduc_AfterLabelEdit);
            this.treeViewFileConduc.DoubleClick += new System.EventHandler(this.butCreate_Click);
            this.treeViewFileConduc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeViewFileConduc_KeyDown);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemCreateFolder,
            this.MenuItemAddFile,
            this.StripMenuItemEditFile,
            this.MenuItemDeleteElement});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(159, 92);
            // 
            // MenuItemCreateFolder
            // 
            this.MenuItemCreateFolder.Name = "MenuItemCreateFolder";
            this.MenuItemCreateFolder.Size = new System.Drawing.Size(158, 22);
            this.MenuItemCreateFolder.Text = "Создать папку";
            this.MenuItemCreateFolder.Click += new System.EventHandler(this.MenuItemCreateFolder_Click);
            // 
            // MenuItemAddFile
            // 
            this.MenuItemAddFile.Name = "MenuItemAddFile";
            this.MenuItemAddFile.Size = new System.Drawing.Size(158, 22);
            this.MenuItemAddFile.Text = "Добавить файл";
            this.MenuItemAddFile.Click += new System.EventHandler(this.MenuItemAddFile_Click);
            // 
            // StripMenuItemEditFile
            // 
            this.StripMenuItemEditFile.Name = "StripMenuItemEditFile";
            this.StripMenuItemEditFile.Size = new System.Drawing.Size(158, 22);
            this.StripMenuItemEditFile.Text = "Редактировать";
            this.StripMenuItemEditFile.Click += new System.EventHandler(this.StripMenuItemEditFile_Click);
            // 
            // MenuItemDeleteElement
            // 
            this.MenuItemDeleteElement.Name = "MenuItemDeleteElement";
            this.MenuItemDeleteElement.Size = new System.Drawing.Size(158, 22);
            this.MenuItemDeleteElement.Text = "Удалить";
            this.MenuItemDeleteElement.Click += new System.EventHandler(this.MenuItemDeleteElement_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "opened_folder-512.png");
            this.imageList.Images.SetKeyName(1, "Filetype-Docs-icon.png");
            // 
            // CreateDocFromPattern
            // 
            this.AcceptButton = this.butCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(284, 255);
            this.Controls.Add(this.treeViewFileConduc);
            this.Controls.Add(this.butCreate);
            this.Controls.Add(this.butCancel);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 294);
            this.Name = "CreateDocFromPattern";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Создание документа";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butCreate;
        private System.Windows.Forms.TreeView treeViewFileConduc;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAddFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCreateFolder;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDeleteElement;
        private System.Windows.Forms.ToolStripMenuItem StripMenuItemEditFile;
    }
}