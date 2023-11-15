using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MainWindow
{
    public partial class Main : Form
    {
        //public для обращения из формы с поиском
        public List<SNClass> listDoc = new List<SNClass>();
        string pathHead = null;
        string settingFile = Directory.GetCurrentDirectory() + "\\setting"; //файл с настройками

        List<Destination> destList = new List<Destination>();  //Возможно нужно перенести в саму функцию

        List<Performer> performList = new List<Performer>();   //Возможно нужно перенести в саму функцию

        public WorkMySQL conn = null;

        Performer currentUser = null;

        string department = null;



        public Main()
        {
            InitializeComponent(); //А если pdf или word не установлем

            radioButtonDestination.Checked = true;

            SaveDocInfo.Enabled = false;

            try
            {                
                conn = new WorkMySQL(settingFile);

                if (conn.Connect())
                {

                    comboBoxPerform.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboBoxPerform.AutoCompleteSource = AutoCompleteSource.ListItems;

                    comboBoxDest.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboBoxDest.AutoCompleteSource = AutoCompleteSource.ListItems;

                    pathHead = conn.GetVariable("pathHead"); //головная часть пути                     

                    currentUser = conn.GetPerformer();
                    department = " AND department = '" + currentUser.department + "'";

                    if (currentUser.IsUserRoot)
                    {
                        //department = "";
                        StripMenuItemDeleteSN.Enabled = true;

                        //Меню добавления исполнителя
                        MenuItemPerformer.Enabled = true;

                        CreateDoc.Enabled = true;
                    }

                    listDoc = conn.LastNNumberSN(55, department);
                    AddListBox();

                    switch (currentUser.department)
                    {
                        case "3630":
                            checkBox3630.Checked = true;
                            break;
                        case "3631":
                            checkBox3631.Checked = true;
                            break;
                        case "3632":
                            checkBox3632.Checked = true;
                            break;
                        case "3633":
                            checkBox3633.Checked = true;
                            break;
                        default:
                            break;
                    }

                    conn.Disconnect();
                    this.Show();
                }
                else
                {                    

                    CreateDoc.Enabled = false;
                    MenuItemAddDocWithNumber.Enabled = false;
                    MenuItemDestination.Enabled = false;
                    MenuItemPerformer.Enabled = false;
                    ListDocToolStripMenuItem.Enabled = false;
                    SaveDocInfo.Enabled = false;
                    browse.Enabled = false;
                    comboBoxDest.Enabled = false;
                    textBoxNameDoc.Enabled = false;
                    comboBoxPerform.Enabled = false;
                    textBoxSummary.Enabled = false;
                    treeViewAuxiliaryFiles.Enabled = false;
                    textBoxNumberDoc.Enabled = false;
                    textBoxBaseFile.Enabled = false;
                    contextMenuListBox.Enabled = false;
                    search_button.Enabled = false;
                    linkLabel.Enabled = false;

                    radioButtonDestination.Enabled = false;
                    radioButtonPerformer.Enabled = false;
                    radioButtonDocName.Enabled = false;
                    radioButtonDocNumber.Enabled = false;
                    radioButtonSummary.Enabled = false;

                    textBoxMainSerch.Enabled = false;

                    this.Show();
                    MessageBox.Show("Неудалось подключиться к серверу", "Ошибка");

                }

                

            }
            catch
            {
                MessageBox.Show("Возникло исключение", "Ошибка");

                CreateDoc.Enabled = false;
                MenuItemAddDocWithNumber.Enabled = false;
                MenuItemDestination.Enabled = false;
                MenuItemPerformer.Enabled = false;
            }
            

            //Нужно считать из файла пути к шаблону и к СЗ
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            //Организовать самый востребованный поиск (по адресату)
            try
            {
                string settingFile = Directory.GetCurrentDirectory() + "\\setting"; //файл с настройками

                WorkMySQL conn = new WorkMySQL(settingFile);

                if (conn.Connect())
                {
                    string sqlQ = string.Empty;

                    if (radioButtonDestination.Checked)
                    {
                        sqlQ = " WHERE destination IN (SELECT id_destination FROM destination WHERE dest_surname LIKE \"%" +
                               textBoxMainSerch.Text + "%\")";
                    }

                    if (radioButtonPerformer.Checked)
                    {
                        sqlQ = " WHERE user = (SELECT id_user FROM performer WHERE surname LIKE \"%" +
                               textBoxMainSerch.Text + "%\")";
                    }

                    if (radioButtonDocName.Checked)
                    {
                        sqlQ = " WHERE name_sn LIKE \"%" + textBoxMainSerch.Text + "%\"";
                    }

                    if (radioButtonDocNumber.Checked)
                    {
                        sqlQ = " WHERE count_sn = \"" + textBoxMainSerch.Text + "\"";
                    }

                    if (radioButtonSummary.Checked)
                    {
                        sqlQ = " WHERE summary LIKE \"%" + textBoxMainSerch.Text + "%\"";
                    }

                    sqlQ += department;

                    sqlQ += " ORDER BY count_sn DESC;";

                    listDoc = conn.SerchDoc(sqlQ);
                    AddListBox(); //Добавляем найденные в ListBox

                    conn.Disconnect();
                }
                else
                {
                    MessageBox.Show("Нет подключения к БД.");
                }
            }
            catch
            {
                MessageBox.Show("Исключение");
            }
        }

        private void CreateDoc_Click(object sender, EventArgs e)
        {
            
            Txt txt = new Txt();

            if (txt.SetPathToFile(settingFile))
            {
                string path = txt.Select("<pathToPatternes>", "</pathToPatternes>");
                if (Directory.Exists(path))
                {
                    //создаем форму и передаем путь к папке с шаблонами. В данной форме пользователь сможет выбрать шаблон документа 
                    CreateDocFromPattern selector = new CreateDocFromPattern(path);
                    selector.ShowDialog();

                    string pathPattern = selector.pathPattern;

                    if (pathPattern != null)
                    {
                        FormForCreateDoc createSN = new FormForCreateDoc(pathPattern);
                        if(createSN.DialogResult != DialogResult.Cancel)
                        {
                            createSN.ShowDialog();
                        }
                        
                    }                    
                }
                else
                {
                    MessageBox.Show("Неверный путь к шаблонам. Откройти Сервис -> Настройки", "Ошибка создания документа");
                }
            }
            else
            {
                MessageBox.Show("Необходимо задать настройки. Для этого откройти Сервис -> Настройки", "Ошибка создания документа");
            }

            if (conn.Connect())
            {
                listDoc = conn.LastNNumberSN(55, department);
                AddListBox();                
                conn.Disconnect();
            }

        }

        private void CloseApp(object sender, EventArgs e)
        {
            this.Close();
        }


        //Поиск по сложному запросу
        private void lableSerch_Click(object sender, EventArgs e)
        {
            FormForSerch SerchDoc = new FormForSerch();
            SerchDoc.Owner = this;
            SerchDoc.department = department;
            SerchDoc.ShowDialog(); //Данный оператор нельзя переносить внутрь функции. Т.к. оператор SerchDoc.Owner = this; в таком случае не выполниться
        }


        //Функция заполнения служебными записками ListBox (поля для отображения списка СЗ)
        public void AddListBox()
        {
            listBoxSN.Items.Clear(); //Очистим поле

            //Начинаем заполнять
            foreach (var serviceNote in listDoc)
            {
                listBoxSN.Items.Add(serviceNote.mark + " _ " + serviceNote.name);
            }
                        
        }


        //двойной клик по листбокс
        private void listBoxSN_DoubleClick(object sender, EventArgs e)
        {
            
            try
            {
                int i = listBoxSN.SelectedIndex;

                if (i >= 0)
                {
                    string pathDoc = Path.Combine(pathHead, listDoc[i].pathRelative + ".pdf");

                    FillFieldInformation(i);                    

                    //Здесь нужно проверить существует ли файл по ссылки pathSN
                    if (File.Exists(pathDoc))
                    {
                        //axAcroPDF_main.;
                        axAcroPDF_main.LoadFile(pathDoc);
                    }
                    else
                    {
                        if (tabControlMain.SelectedIndex == 0)
                        {
                            //говорим, что не существует pdf-представления документа
                            MessageBox.Show("Для данного документа не существует pdf-представления");
                        }
                        
                    }
                    
                }                                
            }
            catch
            {

            }
                      

        }

        //Добавить адресата
        private void AddDestinationItem_Click(object sender, EventArgs e)
        {
            //Вызываем форму для добавления адресата
            FormAddDestination adder = new FormAddDestination();
            adder.Owner = this;
            adder.ShowDialog();
        }

        private void MenuItemEdit_Click(object sender, EventArgs e)
        {
            EditDestination editor = new EditDestination();
        }

        private void MenuItemAddPerform_Click(object sender, EventArgs e)
        {
            AddEditPerformer adder = new AddEditPerformer();            
        }

        //редактировать документ word
        private void ToolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int i = listBoxSN.SelectedIndex;
                if(i >= 0)
                {

                    string pathDoc = Path.Combine(pathHead, listDoc[i].pathRelative + ".doc");
                    string pathDocx = Path.Combine(pathHead, listDoc[i].pathRelative + ".docx");

                    //Здесь нужно проверить существует ли файл по ссылки pathSN
                    if (File.Exists(pathDoc))
                    {
                        MessageFilter.Register();

                        WorkWord word = new WorkWord();
                        word.OpenDocForEdit(pathDoc);

                        MessageFilter.Revoke();
                    }
                    else if(File.Exists(pathDocx))
                    {
                        MessageFilter.Register();

                        WorkWord word = new WorkWord();
                        word.OpenDocForEdit(pathDocx);

                        MessageFilter.Revoke();                        
                    }
                    else
                    {
                        //говорим, что не существует файла
                        MessageBox.Show("Файл не существует. Возможно он был удален.");
                    }
                }
                else
                {
                    MessageBox.Show("Нет выбранных элементов.");
                }
            }
            catch
            {
                MessageBox.Show("Исключение");
            }
            
        }

        //Удаление документа
        private void StripMenuItemDeleteDoc_Click(object sender, EventArgs e)
        {
            try
            {

                int i = listBoxSN.SelectedIndex;

                if (i >= 0)
                {

                    if (conn.Connect())
                    {                        

                        DialogResult result = MessageBox.Show("Удалить документ?", "Удаление документа", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Удаляем
                            conn.DeleteSN(listDoc[i]);

                            string pathDoc = Path.GetDirectoryName(Path.Combine(pathHead, listDoc[i].pathRelative));
                            if (Directory.Exists(pathDoc) && pathDoc != pathHead && pathDoc != Path.GetDirectoryName(pathHead)) //на всякий случай. Чтобы не удалить основной католог
                            {
                                Directory.Delete(pathDoc, true);
                            }
                            
                            listDoc = conn.LastNNumberSN(55, department);
                            AddListBox();
                        }
                                                
                        conn.Disconnect();
                    }
                    else
                    {
                        MessageBox.Show("Не удается подключиться к серверу");
                    }
                }
                else
                {
                    MessageBox.Show("Нет выбранных элементов.");
                }                
                               
            }
            catch
            {
                MessageBox.Show("Исключение");
            }
        }

        private void StripMenuEditPerformer_Click(object sender, EventArgs e)
        {
            EditPerformer editor = new EditPerformer();
        }

        //Самоназначенный номер документа
        private void StripMenuSelfAppointed_Click(object sender, EventArgs e)
        {
            AddDocWithNumber attach = new AddDocWithNumber();
            if(attach.DialogResult != DialogResult.Cancel)
                attach.ShowDialog();

            if (conn.Connect())
            {
                listDoc = conn.LastNNumberSN(55, department);
                AddListBox();
                conn.Disconnect();
            }
            //Вызываем форму задания самоназначенного номера

            //В форме проверям не занят ли данный номер
            //Если занятый
            //выдаем сообщение - "Указанный номер занят."
            //Если свободный, то нужно "блокировать" БД. 
            //Удалям (занимаем) в таблицу delete_sn все номера между максимальным последним занятым и самоназначенным

        }       

        private void treeViewAuxiliaryFiles_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                TreeNode node = treeViewAuxiliaryFiles.SelectedNode;

                if (node != null)
                {
                    //Если файл, то открываем
                    string pathFile = treeViewAuxiliaryFiles.SelectedNode.Tag.ToString();

                    if (new CommonClass().IsFile(pathFile)) //возможно здесь нужно проверить ссылку на файл это или папка
                    {
                        System.Diagnostics.Process.Start(pathFile);

                    }
                }
                               
            }
            catch
            {

            }
        }


        //Добавление вспомогательных файлов
        private void AddAuxiliaryFiles_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode node = treeViewAuxiliaryFiles.SelectedNode;                

                if(node != null)
                {
                    if (treeViewAuxiliaryFiles.TopNode != node)
                    {
                        //Если папка, то добавляем
                        string pathDirectory = node.Tag.ToString();

                        if (new CommonClass().IsDirectory(pathDirectory)) //возможно здесь нужно проверить ссылку на файл это или папка
                        {
                            OpenFileDialog openFileDialog = new OpenFileDialog();
                            DialogResult result = openFileDialog.ShowDialog();

                            if (result == DialogResult.OK)
                            {
                                //Получаем имя файла                       
                                string fileName = Path.GetFileName(openFileDialog.FileName);

                                //Конечный путь файла с именем
                                string pathFile = Path.Combine(pathDirectory, fileName);

                                //Копируем (из, в)
                                File.Copy(openFileDialog.FileName, pathFile);

                                //обновляем дерево
                                TreeNode list = new TreeNode();
                                list.Text = fileName;
                                list.Tag = pathFile;
                                list.ImageIndex = 1;
                                list.SelectedImageIndex = 1;

                                node.Nodes.Add(list);

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("В данной директории можно только создавать папки");
                    }
                }                

            }
            catch
            {

            }
        }

        //удаление директории и вспомогательного файла
        private void DeleteAuxiliaryFiles_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode node = treeViewAuxiliaryFiles.SelectedNode;

                if(node != null)
                {
                    string path = node.Tag.ToString();

                    if (node != null)
                    {
                        DialogResult result = MessageBox.Show("Удалить выбранный элемент?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Удаляем                                            
                            if (new CommonClass().IsDirectory(path)) //это папка?
                            {
                                if (treeViewAuxiliaryFiles.TopNode != node)
                                {
                                    Directory.Delete(path, true);
                                    treeViewAuxiliaryFiles.Nodes.Remove(node);
                                }
                                else
                                {
                                    MessageBox.Show("Указанную директорию нельзя удалить");
                                }

                            }
                            else if(new CommonClass().IsFile(path))
                            {
                                File.Delete(path);
                                treeViewAuxiliaryFiles.Nodes.Remove(node);
                            }
                        }
                    }
                }

            }
            catch
            {

            }
        }

        //Открываем папки и файлы
        private void OpenFileDirectoryItem_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode node = treeViewAuxiliaryFiles.SelectedNode;
                if(node != null)
                {
                    //открываем
                    string pathFile = node.Tag.ToString();

                    if (File.Exists(pathFile) || Directory.Exists(pathFile))
                        System.Diagnostics.Process.Start(pathFile);
                }

            }
            catch
            {

            }
        }

        //Создать папку для хранения вспомогательных файлов
        private void CreateDirectory_Click(object sender, EventArgs e)
        {
            
            TreeNode node = treeViewAuxiliaryFiles.SelectedNode;

            if (node != null)
            {
                string path = node.Tag.ToString();

                string name = "Новая папка";

                if (Directory.Exists(path))
                {
                    string nameFile = name;
                    int i = 0;
                    while (Directory.Exists(Path.Combine(path, nameFile)))
                    {
                        i++;
                        nameFile = name + " (" + i.ToString() + ")";
                    }

                    TreeNode list = new TreeNode();

                    list.Text = nameFile;
                    //Создаем директорию и возвращаем путь
                    list.Tag = Directory.CreateDirectory(Path.Combine(path, nameFile)).FullName;
                    list.ImageIndex = 0;
                    list.SelectedImageIndex = 0;

                    //добавляем элемент
                    node.Nodes.Add(list);
                    //Выделяем добавленный элемент
                    treeViewAuxiliaryFiles.SelectedNode = list;
                    //редактируем текст элемента
                    list.BeginEdit();
                }                
            }

        }

        //Событие после редактирования вспомогательных файлов //Нужно создать отдельную функцию
        private void treeViewAuxiliaryFiles_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {                   
            TreeNode node = treeViewAuxiliaryFiles.SelectedNode;
                       
            if(node != null)
            {
                string path = node.Tag.ToString();

                if (e.Label != node.Text && e.Label != null)
                {
                    if (treeViewAuxiliaryFiles.TopNode != node)
                    {
                        string pathDirectory = Path.GetDirectoryName(path);

                        if (new CommonClass().IsDirectory(path)) //Если это папка, то
                        {
                            //Полный путь к директории
                            string newFullName = Path.Combine(pathDirectory, e.Label);

                            //Если данная папка существует
                            if (Directory.Exists(newFullName))
                            {
                                //нужно отменить редактирование
                                MessageBox.Show("Папка с таким именем уже существут");
                                e.CancelEdit = true; 
                            }
                            else
                            {
                                try
                                {
                                    //Пытаемся переименовать директорию
                                    Directory.Move(path, newFullName);
                                    node.Tag = newFullName;
                                }
                                catch
                                {
                                    //Если не получится нужно отменить редактирование
                                    MessageBox.Show("Во время переименования произошла ошибка");
                                    e.CancelEdit = true;
                                }

                            }
                        }
                        else if (new CommonClass().IsFile(path))
                        {
                            //расширение старого наименовани
                            string extOldName = Path.GetExtension(path);

                            //Расширение нового наименования
                            string extNewName = Path.GetExtension(e.Label);

                            //Полный путь к файлу
                            string newFullName = string.Empty;

                            //Если пользователь, во время переименования удалил расширение файла, то вернем старое расширение
                            if (extOldName != extNewName)
                            {
                                newFullName = Path.Combine(pathDirectory, Path.GetFileNameWithoutExtension(e.Label) + extOldName);

                                if (newFullName == path)  //если пользователь изменил только расширение
                                {
                                    e.CancelEdit = true;
                                    return;
                                }

                            }
                            //Если расширение файла осталось, то...
                            else
                            {
                                newFullName = Path.Combine(pathDirectory, e.Label);
                            }
                            //Если файл с таким именем существует
                            if (File.Exists(newFullName))
                            {
                                //нужно отменить редактирование
                                MessageBox.Show("Файл с таким именем уже существут");
                                e.CancelEdit = true;
                            }
                            else
                            {
                                try
                                {
                                    File.Move(path, newFullName);
                                    node.Tag = newFullName;
                                }
                                catch
                                {
                                    //нужно отменить редактирование
                                    MessageBox.Show("Во время переименования произошла ошибка. Возможно данный файл открыт в другой программе");
                                    e.CancelEdit = true;
                                }

                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Указанную директорию нельзя переименовать");
                        e.CancelEdit = true;
                    }
                }
            }            
        }

        //Сохранение информации о документе //нужно доделать
        private void SaveDocInfo_Click(object sender, EventArgs e)
        {
            try
            {
                int i = listBoxSN.SelectedIndex;
                if (i >= 0)
                {
                    if (conn.Connect())
                    {
                        SNClass doc = new SNClass();

                        doc = listDoc[i];

                        DateTime date = listDoc[i].date;

                        doc.date = listDoc[i].date;

                        doc.summary = textBoxSummary.Text;                     


                        if (doc.name != textBoxNameDoc.Text ||
                            comboBoxPerform.SelectedIndex != comboBoxPerform.FindString(doc.performer.SNP()) || 
                            comboBoxDest.SelectedIndex != comboBoxDest.FindString(doc.destination.InitialsDest()) ||
                            textBoxBaseFile.Text != "")
                        {
                            doc.name = textBoxNameDoc.Text;

                            if (comboBoxDest.SelectedIndex >= 0)
                            {
                                doc.destination = destList[comboBoxDest.SelectedIndex]; //Если bсполнитель пуст
                            }

                            if (comboBoxPerform.SelectedIndex >= 0) //Если исполнитель пуст
                            {
                                doc.performer = performList[comboBoxPerform.SelectedIndex];
                            }
                            else
                            {
                                doc.performer = new Performer();
                            }

                            //При этом закрыть и открыть pdf-представление
                            axAcroPDF_main.LoadFile(""); //закрываем файл

                            string newNameFile = Path.Combine(doc.mark, doc.mark + " _ " + doc.name + " (исп. " + doc.performer.Initials() + ", адр. " + doc.destination.Initials() + ")");

                            string pathDirectoryDoc = Path.Combine(pathHead, doc.mark);  //Путь до директории документа                        

                            if (Directory.Exists(pathDirectoryDoc))
                            {
                                //Если прикрепляемый путь существует и существует директория документа (она ведь может быть удалена)
                                if (File.Exists(textBoxBaseFile.Text))
                                {
                                    //При этом старые файлы нужно удалить
                                    string[] files = Directory.GetFiles(pathDirectoryDoc);
                                    foreach (var file in files)
                                    {
                                        File.Delete(file);
                                    }

                                    doc.pathRelative = newNameFile; //записы

                                    //Если файл существует, то заменяем

                                    string exten = Path.GetExtension(textBoxBaseFile.Text); //Расширение файла

                                    string fullNewFileName = Path.Combine(pathHead, newNameFile + exten); //полный путь к файлу                                        

                                    if (File.Exists(fullNewFileName))
                                    {
                                        //нужно отменить редактирование
                                        MessageBox.Show("Файл с таким именем уже существут");
                                        return;
                                    }
                                    else  //Если файл не существует то копируем
                                    {
                                        //Копируем файл и переименовываем
                                        File.Copy(textBoxBaseFile.Text, fullNewFileName);


                                        //Теперь откроем его в ворде и сохраним его в pdf
                                        MessageFilter.Register();

                                        //сохраняем в pdf (невидимый режим)
                                        WorkWord word = new WorkWord();
                                        word.SavePDFInvisible(fullNewFileName);
                                        MessageFilter.Revoke();

                                        
                                    }

                                }
                                else
                                {
                                    string[] files = Directory.GetFiles(pathDirectoryDoc);
                                    foreach (var file in files)
                                    {
                                        string ext = Path.GetExtension(file);
                                        //Если файл с таким именем существует
                                        if (File.Exists(newNameFile + ext))
                                        {
                                            //нужно отменить редактирование
                                            MessageBox.Show("Файл с таким именем уже существут");
                                            return;
                                        }
                                        else
                                        {
                                            try
                                            {
                                                File.Move(file, Path.Combine(pathHead, newNameFile + ext));
                                                doc.pathRelative = newNameFile;
                                            }
                                            catch
                                            {
                                                //нужно отменить редактирование
                                                MessageBox.Show("Во время переименования произошла ошибка. Возможно данный файл открыт в другой программе");
                                                return;
                                            }

                                        }
                                    }
                                }

                            }
                        }

                        //Просто обновим данные в базе
                        conn.UpdateSN(doc);
                        RefreshFild();
                        listDoc = conn.LastNNumberSN(55, department);
                        AddListBox();


                        conn.Disconnect();
                    }
                    else
                    {
                        MessageBox.Show("Неудалось подключиться к серверу", "Ошибка");
                    }
                }
            }
            catch
            {

            }
            
            
        }

        private void AboutAplication_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программу разработал Рябов Алексей", "О программе");
        }

        //настройки программы (подключение, шаблоны для документов, путь хранения документов)
        private void Setting_Click(object sender, EventArgs e)
        {
            Setting settin = new Setting(settingFile);            
        }

        //функция заполняет поля информацией
        private void FillFieldInformation(int index)
        {           
            comboBoxPerform.Text = "";
            comboBoxDest.Text = "";            
            try
            {
                string settingFile = Directory.GetCurrentDirectory() + "\\setting"; //файл с настройками

                WorkMySQL conn = new WorkMySQL(settingFile);

                if (conn.Connect())
                {                    
                    performList = conn.GetAllPerformeres(comboBoxPerform);
                    destList = conn.GetAllDestination(comboBoxDest);

                    treeViewAuxiliaryFiles.Nodes.Clear();
                    textBoxSummary.Text = listDoc[index].summary;
                    textBoxNumberDoc.Text = listDoc[index].mark;
                    textBoxNameDoc.Text = listDoc[index].name;
                    comboBoxPerform.SelectedIndex = comboBoxPerform.FindString(listDoc[index].performer.Initials());
                    comboBoxDest.SelectedIndex = comboBoxDest.FindString(listDoc[index].destination.InitialsDest());

                    dateicker.Value = listDoc[index].date;

                    Performer per = listDoc[index].performer;
                    if (conn.GetPerformer().IsUserRoot || per.PCName == Environment.UserName) //Если пользователь обладает супер правами либо он создал данный документ
                    {
                        browse.Enabled = true;
                        //не только чтение
                        textBoxSummary.ReadOnly = false;
                        comboBoxDest.Enabled = true;
                        comboBoxPerform.Enabled = true;
                        //не только чтение
                        textBoxNameDoc.ReadOnly = false;

                        //можно редактировать
                        ToolStripMenuItemEdit.Enabled = true;
                    }
                    else
                    {
                        //нельзя редактировать
                        ToolStripMenuItemEdit.Enabled = false;

                        browse.Enabled = false;
                        //только чтение
                        textBoxSummary.ReadOnly = true;
                        comboBoxDest.Enabled = false;                        
                        comboBoxPerform.Enabled = false;
                        //только чтение
                        textBoxNameDoc.ReadOnly = true;
                    }

                    conn.Disconnect();

                    GetAuxiliaryFiles(index);
                }
                else
                {
                    MessageBox.Show("Не получается подключиться к серверу");
                    return;
                }
               

            }
            catch
            {
                MessageBox.Show("Исключение");
            }
            //Нужен в конце. Иначе не работает
            SaveDocInfo.Enabled = false;
        }

        private void GetAuxiliaryFiles(int index)
        {
            string pathDoc = Path.Combine(pathHead, listDoc[index].pathRelative);

            //Директория документа
            string pathDirectory = Path.GetDirectoryName(pathDoc);

            if (Directory.Exists(pathDirectory) && pathDirectory != Path.GetDirectoryName(pathHead))
            {
                TreeNode root = new TreeNode();
                root.Text = "Вспомогательные файлы документа " + listDoc[index].mark;
                root.Tag = pathDirectory;
                root.ImageIndex = 0;
                root.SelectedImageIndex = 0;

                //Получаем все директории
                string[] dirs = Directory.GetDirectories(pathDirectory);

                foreach (var dir in dirs)
                {
                    TreeNode list = new TreeNode();
                    list.Text = Path.GetFileName(dir);
                    list.Tag = dir;
                    list.ImageIndex = 0;
                    list.SelectedImageIndex = 0;

                    new CommonClass().FileСonductorTreeView(dir, list);
                    root.Nodes.Add(list);
                }
                root.Expand();
                treeViewAuxiliaryFiles.Nodes.Add(root);

                treeViewAuxiliaryFiles.Enabled = true;
            }
            else
            {
                treeViewAuxiliaryFiles.Enabled = false;
            }
        }

        private void listBoxSN_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControlMain.SelectedIndex == 1) //Если выбрана информация
            {
                int i = listBoxSN.SelectedIndex;
                if(i >= 0)
                {                    
                    FillFieldInformation(i);
                }                
            }
        }

        private void listBoxSN_KeyDown(object sender, KeyEventArgs e)
        {
            EventArgs eva = new EventArgs();

            switch (e.KeyCode)
            {                
                case Keys.Enter:                    
                    listBoxSN_DoubleClick(sender, eva);                    
                    break;
                case Keys.Delete:
                    StripMenuItemDeleteDoc_Click(sender, eva);
                    break;
                default:
                    break;
            }
        }


        //обновляем данные
        private void RefreshData_Click(object sender, EventArgs e)
        {           
            if (conn.Connect())
            {
                RefreshFild();
                listDoc = conn.LastNNumberSN(55, department);
                AddListBox(); 
                conn.Disconnect();
            }
            else
            {
                this.Show();
                MessageBox.Show("Неудалось обновить данные. Отсутствует подключение к серверу", "Ошибка");

                CreateDoc.Enabled = false;
                MenuItemAddDocWithNumber.Enabled = false;
                MenuItemDestination.Enabled = false;
                MenuItemPerformer.Enabled = false;
            }
        }

        private void RefreshFild()
        {
            comboBoxPerform.Text = "";
            comboBoxDest.Text = "";
            listBoxSN.Items.Clear();
            textBoxNumberDoc.Clear();
            textBoxNameDoc.Clear();
            //comboBoxDest.Items.Clear();
            //comboBoxPerform.Items.Clear();
            textBoxSummary.Clear();
            treeViewAuxiliaryFiles.Nodes.Clear();
            listDoc.Clear();
            textBoxBaseFile.Clear();
        }

        //Сформировать список занятых номеров в ворде
        private void ListDocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListDoc listDoc = new ListDoc();
            listDoc.department = department;
            listDoc.ShowDialog();
        }

        //Заменить основной файл
        private void browse_Click(object sender, EventArgs e)
        {                        
            //здесь возможно нужно поставить фильтр только на doc/docx файлы

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Все документы Word (*.doc; *.docx)|*.doc;*.docx|Документы Word (*.docx)|*.docx|Документы Word 97-2003 (*.doc)|*.doc";

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBoxBaseFile.Text = openFileDialog.FileName;
                SaveDocInfo.Enabled = true;
            }
        }

        //Если изменили краткое содержание
        private void textBoxSummary_TextChanged(object sender, EventArgs e)
        {
            SaveDocInfo.Enabled = true;
        }

        //Если изменили адресата
        private void comboBoxDest_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveDocInfo.Enabled = true;
        }

        //Если изменили исполнителя
        private void comboBoxPerform_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveDocInfo.Enabled = true;
        }

        //Если изменили наименование документа
        private void textBoxNameDoc_TextChanged(object sender, EventArgs e)
        {
            SaveDocInfo.Enabled = true;
        }

        //Запрещаем удалять корневую папку
        private void treeViewAuxiliaryFiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeViewAuxiliaryFiles.SelectedNode;

            if (treeViewAuxiliaryFiles.TopNode == node)
            {
                StripMenuAuxiliaryFiles.Enabled = false;
                DeleteToolStripMenuItem.Enabled = false;
            }
            else
            {
                StripMenuAuxiliaryFiles.Enabled = true;
                DeleteToolStripMenuItem.Enabled = true;
            }
        }

        private void checkBoxDepartment_CheckedChanged(object sender, EventArgs e)
        {

            department = " AND department IN ('0'";

            if (checkBox3630.Checked)
            {
                department += ", '3630'";
            }
            if (checkBox3631.Checked)
            {
                department += ", '3631'";
            }
            if (checkBox3632.Checked)
            {
                department += ", '3632'";
            }
            if (checkBox3633.Checked)
            {
                department += ", '3633'";
            }

            department += ")";

            RefreshData_Click(sender, e);
        }
    }
}
