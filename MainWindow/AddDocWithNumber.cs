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
    public partial class AddDocWithNumber : Form
    {

        List<Destination> destList = new List<Destination>();

        List<Performer> performList = new List<Performer>();

        SNClass doc = new SNClass();

        string settingFile = Directory.GetCurrentDirectory() + "\\setting"; //файл с настройками

        WorkMySQL conn = null;

        public AddDocWithNumber()
        {
            InitializeComponent();

            conn = new WorkMySQL(settingFile);

            rdBtnCreate.Checked = true;


            try
            {
                if (conn.Connect())
                {
                    performList = conn.GetAllPerformeres(comboBoxPerformer);
                    destList = conn.GetAllDestination(comboBoxDestin);

                    Performer currentUser = conn.GetPerformer();

                    comboBoxPerformer.SelectedIndex = comboBoxPerformer.FindString(currentUser.Initials());

                    comboBoxPerformer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboBoxPerformer.AutoCompleteSource = AutoCompleteSource.ListItems;

                    comboBoxDestin.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboBoxDestin.AutoCompleteSource = AutoCompleteSource.ListItems;

                    conn.Disconnect();
                }
                else
                {
                    MessageBox.Show("Не получается подключиться к серверу");
                    this.DialogResult = DialogResult.Cancel;
                    return;
                }                
            }
            catch
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void AddBaseFile_Click(object sender, EventArgs e)
        {
            //здесь возможно нужно поставить фильтр только на doc/docx файлы

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Все документы Word (*.doc; *.docx)|*.doc;*.docx|Документы Word (*.docx)|*.docx|Документы Word 97-2003 (*.doc)|*.doc";

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBoxBaseFile.Text = openFileDialog.FileName;
            }           
                
        }        

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (rdBtnAttached.Checked)
            {
                AttachedDocFile();
            }
            else if (rdBtnCreate.Checked)
            {
                //создаем word-файл
                CreateDocFile();
            }

            //создаем папку
            //копируем "основной" файл. При этом изменяем его имя
            //пытаемся открыть и сохранить его в pdf в невидимом режиме
            //записываем данные в БД
            //?
            //закрываем форму

            
            this.Close();
        }

        private void AttachedDocFile()
        {
            try
            {
                if (conn.Connect())
                {
                    Destination dest = null;

                    if (comboBoxDestin.SelectedIndex >= 0)
                    {
                        dest = destList[comboBoxDestin.SelectedIndex];
                    }
                    else
                    {
                        dest = new Destination();
                    }

                    Performer perform = null;

                    if (comboBoxPerformer.SelectedIndex >= 0)
                    {
                        perform = performList[comboBoxPerformer.SelectedIndex];
                    }
                    else
                    {
                        perform = new Performer();
                    }


                    string id_doc = conn.SetNumberDoc(numberDoc.Text, perform);
                    if (id_doc != null)
                    {

                        //Ссылка на папку где будут храниться документы
                        string path = conn.GetVariable("pathHead");  // данную директорию нужно проверять. может она не существует в текущий момент

                        if (Directory.Exists(path))
                        {                            

                            string markDoc = "195-95-30-" + perform.department + "-" + numberDoc.Text;

                            //Нужно копировать номер СЗ в буфер обмена
                            Clipboard.SetDataObject(markDoc, true);

                            //Создаем папку для документа
                            string pathDirectory = new CommonClass().MCreateDirectory(Path.Combine(path, markDoc));

                            //Наименование файла служебной записки
                            string nameFile = markDoc + " _ " + textBoxNameDoc.Text + " (исп. " + perform.Initials() + ", адр. " + dest.Initials() + ")";

                            //Относительный путь к служебной записки
                            doc.pathRelative = markDoc + @"\" + nameFile;
                            doc.name = textBoxNameDoc.Text;
                            doc.summary = textBoxSummary.Text;
                            doc.destination = dest; //Выбранный адресат
                            doc.number = numberDoc.Text;
                            doc.mark = markDoc;
                            doc.date = dateTimePicker.Value.Date;
                            doc.performer = perform;

                            if (File.Exists(textBoxBaseFile.Text))
                            {
                                string exten = Path.GetExtension(textBoxBaseFile.Text);

                                string fullFileName = Path.Combine(pathDirectory, nameFile + exten); //полный путь к файлу                                        

                                //Копируем файл и переименовываем
                                File.Copy(textBoxBaseFile.Text, fullFileName);

                                //Теперь откроем его в ворде и сохраним его в pdf
                                MessageFilter.Register();

                                //сохраняем в pdf (невидимый режим)
                                WorkWord word = new WorkWord();
                                word.SavePDFInvisible(fullFileName);
                                MessageFilter.Revoke();
                            }



                            conn.UpdateSN(doc);

                            //conn.LastNNumberSN(10);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Данный номер задан некорректно или уже занят");
                        return;
                    }
                    conn.Disconnect();
                }
            }
            catch
            {
                MessageBox.Show("Исключение");
            }
        }

        private void CreateDocFile()
        {
            try
            {
                if (conn.Connect())
                {
                    Destination dest = null;

                    if (comboBoxDestin.SelectedIndex >= 0)
                    {
                        dest = destList[comboBoxDestin.SelectedIndex];
                    }
                    else
                    {
                        dest = new Destination();
                    }

                    Performer perform = null;

                    if (comboBoxPerformer.SelectedIndex >= 0)
                    {
                        perform = performList[comboBoxPerformer.SelectedIndex];
                    }
                    else
                    {
                        perform = new Performer();
                    }

                    string id_doc = conn.SetNumberDoc(numberDoc.Text, perform);
                    if (id_doc != null)
                    {
                        //Ссылка на папку где будут храниться документы
                        string path = conn.GetVariable("pathHead");  // данную директорию нужно проверять. может она не существует в текущий момент

                        if (Directory.Exists(path))
                        {                            

                            string markDoc = "195-95-30-" + perform.department + "-" + numberDoc.Text;

                            //Нужно копировать номер СЗ в буфер обмена
                            Clipboard.SetDataObject(markDoc, true);

                            //Создаем папку для документа
                            string pathDirectory = new CommonClass().MCreateDirectory(Path.Combine(path, markDoc));

                            //Наименование файла служебной записки
                            string nameFile = markDoc + " _ " + textBoxNameDoc.Text + " (исп. " + perform.Initials() + ", адр. " + dest.Initials() + ")";

                            doc.id = id_doc;
                            //Относительный путь к служебной записки
                            doc.pathRelative = markDoc + @"\" + nameFile;
                            doc.name = textBoxNameDoc.Text;
                            doc.summary = textBoxSummary.Text;
                            doc.destination = dest; //Выбранный адресат
                            doc.number = numberDoc.Text;
                            doc.mark = markDoc;
                            doc.date = dateTimePicker.Value.Date;
                            doc.performer = perform;

                            Txt txt = new Txt();

                            if (txt.SetPathToFile(settingFile))
                            {
                                string pathToPatternes = txt.Select("<pathToPatternes>", "</pathToPatternes>");
                                if (Directory.Exists(pathToPatternes))
                                {
                                    //создаем форму и передаем путь к папке с шаблонами. В данной форме пользователь сможет выбрать шаблон документа 
                                    CreateDocFromPattern selector = new CreateDocFromPattern(pathToPatternes);
                                    selector.ShowDialog();

                                    if(selector.DialogResult != DialogResult.Cancel)
                                    {
                                        string pathPattern = selector.pathPattern;

                                        //если ссылка задана, то создаем файл
                                        if (pathPattern != null)
                                        {
                                            new CommonClass().CreateDoc(pathPattern, doc);
                                        }
                                    }
                                    else
                                    {
                                        conn.DeleteSN(doc);
                                    }                                    
                                }
                            }

                            conn.UpdateSN(doc);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Данный номер задан некорректно или уже занят");
                        return;
                    }

                    conn.Disconnect();
                }                                
            }
            catch
            {

            }            
        }

        private void rdBtnAttached_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBtnAttached.Checked)
            {
                comboBoxPerformer.Enabled = true;
                AddBaseFile.Enabled = true;
                textBoxBaseFile.Enabled = true;
                lableFileDoc.Enabled = true;
            }
            else
            {
                comboBoxPerformer.Enabled = false;
                AddBaseFile.Enabled = false;
                textBoxBaseFile.Enabled = false;
                lableFileDoc.Enabled = false;
            }
            
        }
    }
}
