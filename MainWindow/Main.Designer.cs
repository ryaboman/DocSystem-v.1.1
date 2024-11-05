namespace MainWindow
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.radioButtonSummary = new System.Windows.Forms.RadioButton();
            this.radioButtonPerformer = new System.Windows.Forms.RadioButton();
            this.radioButtonDocNumber = new System.Windows.Forms.RadioButton();
            this.radioButtonDestination = new System.Windows.Forms.RadioButton();
            this.radioButtonDocName = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.search_button = new System.Windows.Forms.Button();
            this.textBoxMainSerch = new System.Windows.Forms.TextBox();
            this.listBoxSN = new System.Windows.Forms.ListBox();
            this.contextMenuListBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RefreshData = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuItemDeleteSN = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPagePDFReader = new System.Windows.Forms.TabPage();
            this.axAcroPDF_main = new AxAcroPDFLib.AxAcroPDF();
            this.tabPageInformation = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxBaseFile = new System.Windows.Forms.TextBox();
            this.browse = new System.Windows.Forms.Button();
            this.treeViewAuxiliaryFiles = new System.Windows.Forms.TreeView();
            this.contextMenuAuxiliaryFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenFileDirectoryItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuAuxiliaryFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.dateicker = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxDest = new System.Windows.Forms.ComboBox();
            this.comboBoxPerform = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveDocInfo = new System.Windows.Forms.Button();
            this.textBoxSummary = new System.Windows.Forms.TextBox();
            this.textBoxNameDoc = new System.Windows.Forms.TextBox();
            this.textBoxNumberDoc = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.StripMenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAddDocWithNumber = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuItemCloseApp = new System.Windows.Forms.ToolStripMenuItem();
            this.сервисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDestination = new System.Windows.Forms.ToolStripMenuItem();
            this.AddDestinationItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemPerformer = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAddPerform = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuEditPerformer = new System.Windows.Forms.ToolStripMenuItem();
            this.Setting = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshBasket = new System.Windows.Forms.ToolStripMenuItem();
            this.ListDocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutAplication = new System.Windows.Forms.ToolStripMenuItem();
            this.руководствоПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.contextMenuListBox.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPagePDFReader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF_main)).BeginInit();
            this.tabPageInformation.SuspendLayout();
            this.contextMenuAuxiliaryFiles.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControlMain);
            this.splitContainer1.Size = new System.Drawing.Size(794, 438);
            this.splitContainer1.SplitterDistance = 264;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.linkLabel);
            this.splitContainer2.Panel1.Controls.Add(this.radioButtonSummary);
            this.splitContainer2.Panel1.Controls.Add(this.radioButtonPerformer);
            this.splitContainer2.Panel1.Controls.Add(this.radioButtonDocNumber);
            this.splitContainer2.Panel1.Controls.Add(this.radioButtonDestination);
            this.splitContainer2.Panel1.Controls.Add(this.radioButtonDocName);
            this.splitContainer2.Panel1.Controls.Add(this.label7);
            this.splitContainer2.Panel1.Controls.Add(this.search_button);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxMainSerch);
            this.splitContainer2.Panel1MinSize = 110;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listBoxSN);
            this.splitContainer2.Panel2MinSize = 250;
            this.splitContainer2.Size = new System.Drawing.Size(264, 438);
            this.splitContainer2.SplitterDistance = 110;
            this.splitContainer2.TabIndex = 1;
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Location = new System.Drawing.Point(12, 85);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(93, 13);
            this.linkLabel.TabIndex = 9;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "Сложный запрос";
            this.linkLabel.Click += new System.EventHandler(this.lableSerch_Click);
            // 
            // radioButtonSummary
            // 
            this.radioButtonSummary.AutoSize = true;
            this.radioButtonSummary.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButtonSummary.Location = new System.Drawing.Point(200, 60);
            this.radioButtonSummary.Name = "radioButtonSummary";
            this.radioButtonSummary.Size = new System.Drawing.Size(40, 17);
            this.radioButtonSummary.TabIndex = 8;
            this.radioButtonSummary.TabStop = true;
            this.radioButtonSummary.Text = "Sm";
            this.toolTip.SetToolTip(this.radioButtonSummary, "Краткое содержание");
            this.radioButtonSummary.UseVisualStyleBackColor = true;
            // 
            // radioButtonPerformer
            // 
            this.radioButtonPerformer.AutoSize = true;
            this.radioButtonPerformer.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButtonPerformer.Location = new System.Drawing.Point(54, 59);
            this.radioButtonPerformer.Name = "radioButtonPerformer";
            this.radioButtonPerformer.Size = new System.Drawing.Size(38, 17);
            this.radioButtonPerformer.TabIndex = 7;
            this.radioButtonPerformer.TabStop = true;
            this.radioButtonPerformer.Text = "Prf";
            this.toolTip.SetToolTip(this.radioButtonPerformer, "Исполнитель документа");
            this.radioButtonPerformer.UseVisualStyleBackColor = true;
            // 
            // radioButtonDocNumber
            // 
            this.radioButtonDocNumber.AutoSize = true;
            this.radioButtonDocNumber.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButtonDocNumber.Location = new System.Drawing.Point(152, 60);
            this.radioButtonDocNumber.Name = "radioButtonDocNumber";
            this.radioButtonDocNumber.Size = new System.Drawing.Size(39, 17);
            this.radioButtonDocNumber.TabIndex = 6;
            this.radioButtonDocNumber.TabStop = true;
            this.radioButtonDocNumber.Text = "Nb";
            this.toolTip.SetToolTip(this.radioButtonDocNumber, "Номер документа (короткий)");
            this.radioButtonDocNumber.UseVisualStyleBackColor = true;
            // 
            // radioButtonDestination
            // 
            this.radioButtonDestination.AutoSize = true;
            this.radioButtonDestination.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButtonDestination.Location = new System.Drawing.Point(10, 59);
            this.radioButtonDestination.Name = "radioButtonDestination";
            this.radioButtonDestination.Size = new System.Drawing.Size(38, 17);
            this.radioButtonDestination.TabIndex = 5;
            this.radioButtonDestination.TabStop = true;
            this.radioButtonDestination.Text = "Ad";
            this.toolTip.SetToolTip(this.radioButtonDestination, "Адресат документа");
            this.radioButtonDestination.UseVisualStyleBackColor = true;
            // 
            // radioButtonDocName
            // 
            this.radioButtonDocName.AutoSize = true;
            this.radioButtonDocName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButtonDocName.Location = new System.Drawing.Point(102, 59);
            this.radioButtonDocName.Name = "radioButtonDocName";
            this.radioButtonDocName.Size = new System.Drawing.Size(41, 17);
            this.radioButtonDocName.TabIndex = 4;
            this.radioButtonDocName.TabStop = true;
            this.radioButtonDocName.Text = "Nm";
            this.toolTip.SetToolTip(this.radioButtonDocName, "Наименование документа");
            this.radioButtonDocName.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Поиск по адресату";
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(167, 28);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(75, 23);
            this.search_button.TabIndex = 1;
            this.search_button.Text = "Поиск";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // textBoxMainSerch
            // 
            this.textBoxMainSerch.Location = new System.Drawing.Point(12, 30);
            this.textBoxMainSerch.Name = "textBoxMainSerch";
            this.textBoxMainSerch.Size = new System.Drawing.Size(134, 20);
            this.textBoxMainSerch.TabIndex = 0;
            // 
            // listBoxSN
            // 
            this.listBoxSN.ContextMenuStrip = this.contextMenuListBox;
            this.listBoxSN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxSN.FormattingEnabled = true;
            this.listBoxSN.HorizontalScrollbar = true;
            this.listBoxSN.Location = new System.Drawing.Point(0, 0);
            this.listBoxSN.Name = "listBoxSN";
            this.listBoxSN.Size = new System.Drawing.Size(264, 324);
            this.listBoxSN.TabIndex = 0;
            this.listBoxSN.SelectedIndexChanged += new System.EventHandler(this.listBoxSN_SelectedIndexChanged);
            this.listBoxSN.DoubleClick += new System.EventHandler(this.listBoxSN_DoubleClick);
            this.listBoxSN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxSN_KeyDown);
            // 
            // contextMenuListBox
            // 
            this.contextMenuListBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefreshData,
            this.ToolStripMenuItemEdit,
            this.StripMenuItemDeleteSN});
            this.contextMenuListBox.Name = "contextMenuListBox";
            this.contextMenuListBox.Size = new System.Drawing.Size(155, 70);
            // 
            // RefreshData
            // 
            this.RefreshData.Name = "RefreshData";
            this.RefreshData.Size = new System.Drawing.Size(154, 22);
            this.RefreshData.Text = "Обновить";
            this.RefreshData.Click += new System.EventHandler(this.RefreshData_Click);
            // 
            // ToolStripMenuItemEdit
            // 
            this.ToolStripMenuItemEdit.Name = "ToolStripMenuItemEdit";
            this.ToolStripMenuItemEdit.Size = new System.Drawing.Size(154, 22);
            this.ToolStripMenuItemEdit.Text = "Редактировать";
            this.ToolStripMenuItemEdit.Click += new System.EventHandler(this.ToolStripMenuItemEdit_Click);
            // 
            // StripMenuItemDeleteSN
            // 
            this.StripMenuItemDeleteSN.Name = "StripMenuItemDeleteSN";
            this.StripMenuItemDeleteSN.Size = new System.Drawing.Size(154, 22);
            this.StripMenuItemDeleteSN.Text = "Удалить";
            this.StripMenuItemDeleteSN.Click += new System.EventHandler(this.StripMenuItemDeleteDoc_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPagePDFReader);
            this.tabControlMain.Controls.Add(this.tabPageInformation);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(526, 438);
            this.tabControlMain.TabIndex = 1;
            // 
            // tabPagePDFReader
            // 
            this.tabPagePDFReader.Controls.Add(this.axAcroPDF_main);
            this.tabPagePDFReader.Location = new System.Drawing.Point(4, 22);
            this.tabPagePDFReader.Name = "tabPagePDFReader";
            this.tabPagePDFReader.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePDFReader.Size = new System.Drawing.Size(518, 401);
            this.tabPagePDFReader.TabIndex = 0;
            this.tabPagePDFReader.Text = "Вторичное представление";
            this.tabPagePDFReader.UseVisualStyleBackColor = true;
            // 
            // axAcroPDF_main
            // 
            this.axAcroPDF_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axAcroPDF_main.Enabled = true;
            this.axAcroPDF_main.Location = new System.Drawing.Point(3, 3);
            this.axAcroPDF_main.Name = "axAcroPDF_main";
            this.axAcroPDF_main.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF_main.OcxState")));
            this.axAcroPDF_main.Size = new System.Drawing.Size(512, 395);
            this.axAcroPDF_main.TabIndex = 0;
            // 
            // tabPageInformation
            // 
            this.tabPageInformation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageInformation.Controls.Add(this.groupBox1);
            this.tabPageInformation.Location = new System.Drawing.Point(4, 22);
            this.tabPageInformation.Name = "tabPageInformation";
            this.tabPageInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInformation.Size = new System.Drawing.Size(518, 412);
            this.tabPageInformation.TabIndex = 1;
            this.tabPageInformation.Text = "Информация";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Основной файл";
            // 
            // textBoxBaseFile
            // 
            this.textBoxBaseFile.Location = new System.Drawing.Point(6, 111);
            this.textBoxBaseFile.Name = "textBoxBaseFile";
            this.textBoxBaseFile.ReadOnly = true;
            this.textBoxBaseFile.Size = new System.Drawing.Size(414, 20);
            this.textBoxBaseFile.TabIndex = 26;
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(428, 109);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(75, 23);
            this.browse.TabIndex = 25;
            this.browse.Text = "Заменить";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // treeViewAuxiliaryFiles
            // 
            this.treeViewAuxiliaryFiles.ContextMenuStrip = this.contextMenuAuxiliaryFiles;
            this.treeViewAuxiliaryFiles.ImageIndex = 0;
            this.treeViewAuxiliaryFiles.ImageList = this.imageList;
            this.treeViewAuxiliaryFiles.LabelEdit = true;
            this.treeViewAuxiliaryFiles.Location = new System.Drawing.Point(6, 252);
            this.treeViewAuxiliaryFiles.Name = "treeViewAuxiliaryFiles";
            this.treeViewAuxiliaryFiles.SelectedImageIndex = 0;
            this.treeViewAuxiliaryFiles.Size = new System.Drawing.Size(497, 145);
            this.treeViewAuxiliaryFiles.TabIndex = 24;
            this.treeViewAuxiliaryFiles.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewAuxiliaryFiles_AfterLabelEdit);
            this.treeViewAuxiliaryFiles.DoubleClick += new System.EventHandler(this.treeViewAuxiliaryFiles_DoubleClick);
            // 
            // contextMenuAuxiliaryFiles
            // 
            this.contextMenuAuxiliaryFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFileDirectoryItem,
            this.CreateDirectory,
            this.StripMenuAuxiliaryFiles,
            this.удалитьToolStripMenuItem});
            this.contextMenuAuxiliaryFiles.Name = "contextMenuAuxiliaryFiles";
            this.contextMenuAuxiliaryFiles.Size = new System.Drawing.Size(159, 92);
            // 
            // OpenFileDirectoryItem
            // 
            this.OpenFileDirectoryItem.Name = "OpenFileDirectoryItem";
            this.OpenFileDirectoryItem.Size = new System.Drawing.Size(158, 22);
            this.OpenFileDirectoryItem.Text = "Открыть";
            this.OpenFileDirectoryItem.Click += new System.EventHandler(this.OpenFileDirectoryItem_Click);
            // 
            // CreateDirectory
            // 
            this.CreateDirectory.Name = "CreateDirectory";
            this.CreateDirectory.Size = new System.Drawing.Size(158, 22);
            this.CreateDirectory.Text = "Создать папку";
            this.CreateDirectory.Click += new System.EventHandler(this.CreateDirectory_Click);
            // 
            // StripMenuAuxiliaryFiles
            // 
            this.StripMenuAuxiliaryFiles.Name = "StripMenuAuxiliaryFiles";
            this.StripMenuAuxiliaryFiles.Size = new System.Drawing.Size(158, 22);
            this.StripMenuAuxiliaryFiles.Text = "Добавить файл";
            this.StripMenuAuxiliaryFiles.Click += new System.EventHandler(this.AddAuxiliaryFiles_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.DeleteAuxiliaryFiles_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "opened_folder-512.png");
            this.imageList.Images.SetKeyName(1, "Filetype-Docs-icon.png");
            this.imageList.Images.SetKeyName(2, "images.png");
            // 
            // dateicker
            // 
            this.dateicker.Enabled = false;
            this.dateicker.Location = new System.Drawing.Point(366, 28);
            this.dateicker.Name = "dateicker";
            this.dateicker.Size = new System.Drawing.Size(137, 20);
            this.dateicker.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Вспомогательные файлы";
            // 
            // comboBoxDest
            // 
            this.comboBoxDest.FormattingEnabled = true;
            this.comboBoxDest.Location = new System.Drawing.Point(6, 70);
            this.comboBoxDest.Name = "comboBoxDest";
            this.comboBoxDest.Size = new System.Drawing.Size(241, 21);
            this.comboBoxDest.TabIndex = 19;
            this.comboBoxDest.SelectedIndexChanged += new System.EventHandler(this.comboBoxDest_SelectedIndexChanged);
            // 
            // comboBoxPerform
            // 
            this.comboBoxPerform.FormattingEnabled = true;
            this.comboBoxPerform.Location = new System.Drawing.Point(278, 70);
            this.comboBoxPerform.Name = "comboBoxPerform";
            this.comboBoxPerform.Size = new System.Drawing.Size(225, 21);
            this.comboBoxPerform.TabIndex = 18;
            this.comboBoxPerform.SelectedIndexChanged += new System.EventHandler(this.comboBoxPerform_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(242, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Краткое содержание (не более 256 символов)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(363, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Дата";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Исполнитель";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Адресат";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Наименование документа";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Номер документа";
            // 
            // SaveDocInfo
            // 
            this.SaveDocInfo.Location = new System.Drawing.Point(428, 216);
            this.SaveDocInfo.Name = "SaveDocInfo";
            this.SaveDocInfo.Size = new System.Drawing.Size(75, 23);
            this.SaveDocInfo.TabIndex = 7;
            this.SaveDocInfo.Text = "Сохранить";
            this.SaveDocInfo.UseVisualStyleBackColor = true;
            this.SaveDocInfo.Click += new System.EventHandler(this.SaveDocInfo_Click);
            // 
            // textBoxSummary
            // 
            this.textBoxSummary.Location = new System.Drawing.Point(6, 155);
            this.textBoxSummary.MaxLength = 255;
            this.textBoxSummary.Multiline = true;
            this.textBoxSummary.Name = "textBoxSummary";
            this.textBoxSummary.Size = new System.Drawing.Size(497, 55);
            this.textBoxSummary.TabIndex = 5;
            this.textBoxSummary.TextChanged += new System.EventHandler(this.textBoxSummary_TextChanged);
            // 
            // textBoxNameDoc
            // 
            this.textBoxNameDoc.Location = new System.Drawing.Point(162, 28);
            this.textBoxNameDoc.MaxLength = 45;
            this.textBoxNameDoc.Name = "textBoxNameDoc";
            this.textBoxNameDoc.Size = new System.Drawing.Size(177, 20);
            this.textBoxNameDoc.TabIndex = 1;
            this.textBoxNameDoc.TextChanged += new System.EventHandler(this.textBoxNameDoc_TextChanged);
            // 
            // textBoxNumberDoc
            // 
            this.textBoxNumberDoc.Location = new System.Drawing.Point(6, 28);
            this.textBoxNumberDoc.Name = "textBoxNumberDoc";
            this.textBoxNumberDoc.ReadOnly = true;
            this.textBoxNumberDoc.Size = new System.Drawing.Size(134, 20);
            this.textBoxNumberDoc.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripMenuFile,
            this.сервисToolStripMenuItem,
            this.StripMenuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(794, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // StripMenuFile
            // 
            this.StripMenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateDoc,
            this.MenuItemAddDocWithNumber,
            this.StripMenuItemCloseApp});
            this.StripMenuFile.Name = "StripMenuFile";
            this.StripMenuFile.Size = new System.Drawing.Size(48, 20);
            this.StripMenuFile.Text = "Файл";
            // 
            // CreateDoc
            // 
            this.CreateDoc.Name = "CreateDoc";
            this.CreateDoc.Size = new System.Drawing.Size(271, 22);
            this.CreateDoc.Text = "Создать документ";
            this.CreateDoc.Click += new System.EventHandler(this.CreateDoc_Click);
            // 
            // MenuItemAddDocWithNumber
            // 
            this.MenuItemAddDocWithNumber.Name = "MenuItemAddDocWithNumber";
            this.MenuItemAddDocWithNumber.Size = new System.Drawing.Size(271, 22);
            this.MenuItemAddDocWithNumber.Text = "Добавить существующий документ";
            this.MenuItemAddDocWithNumber.Click += new System.EventHandler(this.StripMenuSelfAppointed_Click);
            // 
            // StripMenuItemCloseApp
            // 
            this.StripMenuItemCloseApp.Name = "StripMenuItemCloseApp";
            this.StripMenuItemCloseApp.Size = new System.Drawing.Size(271, 22);
            this.StripMenuItemCloseApp.Text = "Закрыть программу";
            this.StripMenuItemCloseApp.Click += new System.EventHandler(this.CloseApp);
            // 
            // сервисToolStripMenuItem
            // 
            this.сервисToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemDestination,
            this.MenuItemPerformer,
            this.Setting,
            this.RefreshBasket,
            this.ListDocToolStripMenuItem});
            this.сервисToolStripMenuItem.Name = "сервисToolStripMenuItem";
            this.сервисToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.сервисToolStripMenuItem.Text = "Сервис";
            // 
            // MenuItemDestination
            // 
            this.MenuItemDestination.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddDestinationItem,
            this.MenuItemEdit});
            this.MenuItemDestination.Name = "MenuItemDestination";
            this.MenuItemDestination.Size = new System.Drawing.Size(268, 22);
            this.MenuItemDestination.Text = "Адресат";
            // 
            // AddDestinationItem
            // 
            this.AddDestinationItem.Name = "AddDestinationItem";
            this.AddDestinationItem.Size = new System.Drawing.Size(154, 22);
            this.AddDestinationItem.Text = "Добавить";
            this.AddDestinationItem.Click += new System.EventHandler(this.AddDestinationItem_Click);
            // 
            // MenuItemEdit
            // 
            this.MenuItemEdit.Name = "MenuItemEdit";
            this.MenuItemEdit.Size = new System.Drawing.Size(154, 22);
            this.MenuItemEdit.Text = "Редактировать";
            this.MenuItemEdit.Click += new System.EventHandler(this.MenuItemEdit_Click);
            // 
            // MenuItemPerformer
            // 
            this.MenuItemPerformer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemAddPerform,
            this.StripMenuEditPerformer});
            this.MenuItemPerformer.Enabled = false;
            this.MenuItemPerformer.Name = "MenuItemPerformer";
            this.MenuItemPerformer.Size = new System.Drawing.Size(268, 22);
            this.MenuItemPerformer.Text = "Исполнитель";
            // 
            // MenuItemAddPerform
            // 
            this.MenuItemAddPerform.Name = "MenuItemAddPerform";
            this.MenuItemAddPerform.Size = new System.Drawing.Size(154, 22);
            this.MenuItemAddPerform.Text = "Добавить";
            this.MenuItemAddPerform.Click += new System.EventHandler(this.MenuItemAddPerform_Click);
            // 
            // StripMenuEditPerformer
            // 
            this.StripMenuEditPerformer.Name = "StripMenuEditPerformer";
            this.StripMenuEditPerformer.Size = new System.Drawing.Size(154, 22);
            this.StripMenuEditPerformer.Text = "Редактировать";
            this.StripMenuEditPerformer.Click += new System.EventHandler(this.StripMenuEditPerformer_Click);
            // 
            // Setting
            // 
            this.Setting.Name = "Setting";
            this.Setting.Size = new System.Drawing.Size(268, 22);
            this.Setting.Text = "Настройки";
            this.Setting.Click += new System.EventHandler(this.Setting_Click);
            // 
            // RefreshBasket
            // 
            this.RefreshBasket.Enabled = false;
            this.RefreshBasket.Name = "RefreshBasket";
            this.RefreshBasket.Size = new System.Drawing.Size(268, 22);
            this.RefreshBasket.Text = "Очистить стек номеров";
            this.RefreshBasket.Click += new System.EventHandler(this.RefreshBasket_Click);
            // 
            // ListDocToolStripMenuItem
            // 
            this.ListDocToolStripMenuItem.Name = "ListDocToolStripMenuItem";
            this.ListDocToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.ListDocToolStripMenuItem.Text = "Сформировать список документов";
            this.ListDocToolStripMenuItem.Click += new System.EventHandler(this.ListDocToolStripMenuItem_Click);
            // 
            // StripMenuHelp
            // 
            this.StripMenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutAplication,
            this.руководствоПользователяToolStripMenuItem});
            this.StripMenuHelp.Name = "StripMenuHelp";
            this.StripMenuHelp.Size = new System.Drawing.Size(65, 20);
            this.StripMenuHelp.Text = "Справка";
            // 
            // AboutAplication
            // 
            this.AboutAplication.Name = "AboutAplication";
            this.AboutAplication.Size = new System.Drawing.Size(221, 22);
            this.AboutAplication.Text = "О программе";
            this.AboutAplication.Click += new System.EventHandler(this.AboutAplication_Click);
            // 
            // руководствоПользователяToolStripMenuItem
            // 
            this.руководствоПользователяToolStripMenuItem.Enabled = false;
            this.руководствоПользователяToolStripMenuItem.Name = "руководствоПользователяToolStripMenuItem";
            this.руководствоПользователяToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.руководствоПользователяToolStripMenuItem.Text = "Руководство пользователя";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeViewAuxiliaryFiles);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBoxNumberDoc);
            this.groupBox1.Controls.Add(this.textBoxBaseFile);
            this.groupBox1.Controls.Add(this.textBoxNameDoc);
            this.groupBox1.Controls.Add(this.browse);
            this.groupBox1.Controls.Add(this.textBoxSummary);
            this.groupBox1.Controls.Add(this.SaveDocInfo);
            this.groupBox1.Controls.Add(this.dateicker);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxDest);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxPerform);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(509, 403);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // Main
            // 
            this.AcceptButton = this.search_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 462);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MinimumSize = new System.Drawing.Size(810, 501);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Внутренний документооборот 1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.contextMenuListBox.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabPagePDFReader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF_main)).EndInit();
            this.tabPageInformation.ResumeLayout(false);
            this.contextMenuAuxiliaryFiles.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF axAcroPDF_main;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.TextBox textBoxMainSerch;
        private System.Windows.Forms.ToolStripMenuItem StripMenuHelp;
        private System.Windows.Forms.ToolStripMenuItem StripMenuFile;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem StripMenuItemCloseApp;
        public System.Windows.Forms.ListBox listBoxSN;
        private System.Windows.Forms.ToolStripMenuItem CreateDoc;
        private System.Windows.Forms.ContextMenuStrip contextMenuListBox;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem StripMenuItemDeleteSN;
        private System.Windows.Forms.ToolStripMenuItem сервисToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPagePDFReader;
        private System.Windows.Forms.TabPage tabPageInformation;
        private System.Windows.Forms.TextBox textBoxSummary;
        private System.Windows.Forms.TextBox textBoxNameDoc;
        private System.Windows.Forms.TextBox textBoxNumberDoc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveDocInfo;
        private System.Windows.Forms.ComboBox comboBoxDest;
        private System.Windows.Forms.ComboBox comboBoxPerform;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateicker;
        private System.Windows.Forms.TreeView treeViewAuxiliaryFiles;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ContextMenuStrip contextMenuAuxiliaryFiles;
        private System.Windows.Forms.ToolStripMenuItem OpenFileDirectoryItem;
        private System.Windows.Forms.ToolStripMenuItem StripMenuAuxiliaryFiles;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateDirectory;
        private System.Windows.Forms.ToolStripMenuItem Setting;
        private System.Windows.Forms.ToolStripMenuItem AboutAplication;
        private System.Windows.Forms.ToolStripMenuItem руководствоПользователяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAddDocWithNumber;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDestination;
        private System.Windows.Forms.ToolStripMenuItem AddDestinationItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemPerformer;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAddPerform;
        private System.Windows.Forms.ToolStripMenuItem StripMenuEditPerformer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButtonDocName;
        private System.Windows.Forms.RadioButton radioButtonDestination;
        private System.Windows.Forms.RadioButton radioButtonPerformer;
        private System.Windows.Forms.RadioButton radioButtonDocNumber;
        private System.Windows.Forms.RadioButton radioButtonSummary;
        private System.Windows.Forms.ToolStripMenuItem RefreshBasket;
        private System.Windows.Forms.ToolStripMenuItem RefreshData;
        private System.Windows.Forms.ToolStripMenuItem ListDocToolStripMenuItem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxBaseFile;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

