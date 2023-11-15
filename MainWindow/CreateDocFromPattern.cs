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
    public partial class CreateDocFromPattern : Form
    {
        public string pathPattern = null;
        public CreateDocFromPattern()
        {
            InitializeComponent();
        }

        public CreateDocFromPattern(string path)
        {
            InitializeComponent();


            if (Directory.Exists(path))
            {
                TreeNode list = new TreeNode();
                list.Text = "Шаблоны для документов";
                list.Tag = path;
                list.ImageIndex = 0;
                list.SelectedImageIndex = 0;

                new CommonClass().FileСonductorTreeView(path, list);
                list.Expand(); //разворачиваем узел
                treeViewFileConduc.Nodes.Add(list);                
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butCreate_Click(object sender, EventArgs e)
        {
            //будем создавать документы
            try
            {
                if(treeViewFileConduc.SelectedNode != null)
                {
                    //Если файл, то открываем
                    string pathFile = treeViewFileConduc.SelectedNode.Tag.ToString();

                    if (new CommonClass().IsFile(pathFile))
                    {
                        pathPattern = pathFile;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }                           
            }
            catch
            {
                MessageBox.Show("Исключение");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            
            //createSN.ShowDialog()  происходит при инициализации
        }


        //создаем папку
        private void MenuItemCreateFolder_Click(object sender, EventArgs e)
        {
            treeViewFileConduc.LabelEdit = true;

            TreeNode node = treeViewFileConduc.SelectedNode;

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
                    treeViewFileConduc.SelectedNode = list;
                    //редактируем текст элемента
                    list.BeginEdit();
                }
            }
        }

        //Обрабатываем событие по переименованию
        private void treeViewFileConduc_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeNode node = treeViewFileConduc.SelectedNode;

            if (node != null)
            {
                string path = node.Tag.ToString();

                if (e.Label != node.Text && e.Label != null)
                {
                    if (treeViewFileConduc.TopNode != node)
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

        //удаляем файл или папку
        private void MenuItemDeleteElement_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode node = treeViewFileConduc.SelectedNode;

                if (node != null)
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
                                if (treeViewFileConduc.TopNode != node)
                                {
                                    Directory.Delete(path, true);
                                    treeViewFileConduc.Nodes.Remove(node);
                                }
                                else
                                {
                                    MessageBox.Show("Указанную директорию нельзя удалить");
                                }

                            }
                            else if (new CommonClass().IsFile(path))
                            {
                                File.Delete(path);
                                treeViewFileConduc.Nodes.Remove(node);
                            }
                        }
                    }
                }

            }
            catch
            {

            }
        }

        //Добавляем файл
        private void MenuItemAddFile_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode node = treeViewFileConduc.SelectedNode;

                if (node != null)
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

            }
            catch
            {

            }
        }

        //редактируем файл
        private void StripMenuItemEditFile_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode node = treeViewFileConduc.SelectedNode;

                if (node != null)
                {
                    //Если файл, то открываем
                    string pathFile = treeViewFileConduc.SelectedNode.Tag.ToString();

                    if (new CommonClass().IsFile(pathFile)) //возможно здесь нужно проверить ссылку на файл это или папка
                    {
                        if (File.Exists(pathFile))
                            System.Diagnostics.Process.Start(pathFile);
                    }
                }

            }
            catch
            {

            }
        }

        private void treeViewFileConduc_KeyDown(object sender, KeyEventArgs e)
        {           
            switch (e.KeyCode)
            {
                case Keys.F2:
                    TreeNode node = treeViewFileConduc.SelectedNode;
                    node.BeginEdit();
                    break;
                default:
                    break;
            }
        }
    }
}
