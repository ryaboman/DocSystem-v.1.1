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
    public partial class FormForCreateDoc : Form
    {
        List<Destination> destList = new List<Destination>();

        SNClass serviceNote = new SNClass();

        //Ссылка на шаблон для служебных записок
        string pathPattern = string.Empty;



        public FormForCreateDoc(string pathPattern)
        {            
            InitializeComponent();

            //данный файл нужно проверять. он может не существовать в текущий момет
            this.pathPattern = pathPattern;           

            try
            {
                string settingFile = Directory.GetCurrentDirectory() + "\\setting"; //файл с настройками

                WorkMySQL conn = new WorkMySQL(settingFile);
                
                if (conn.Connect())
                {
                    serviceNote.performer = conn.GetPerformer();
                    comboBoxPerformer.Text = serviceNote.performer.InitialsPhone();
                    destList = conn.GetAllDestination(comboBoxDestin);
                    conn.Disconnect();
                }
                else
                {
                    MessageBox.Show("Не получается подключиться к серверу");
                    this.DialogResult = DialogResult.Cancel;
                }

            }
            catch
            {                
                MessageBox.Show("Исключение");
                this.DialogResult = DialogResult.Cancel;
            }
            
        }

        //Создание СЗ
        private void CreateDoc_Click(object sender, EventArgs e)
        {
            this.Close(); //При нажатии кнопки "создать" - закрываем форму

            try
            {                

                string settingFile = Directory.GetCurrentDirectory() + "\\setting"; //файл с настройками

                WorkMySQL conn = new WorkMySQL(settingFile);

                if(conn.Connect())
                {
                    //Ссылка на папку где будут храниться документы
                    string path = conn.GetVariable("pathHead");  // данную директорию нужно проверять. может она не существует в текущий момент

                    if (Directory.Exists(path))
                    {
                        string dateDMY = DateTime.Today.ToShortDateString();

                        //Если не указан адресат? Будет исключение
                        int i = comboBoxDestin.Items.IndexOf(comboBoxDestin.Text);

                        Destination dest = null;

                        if (i >= 0)
                        {
                            dest = destList[comboBoxDestin.SelectedIndex];
                        }
                        else
                        {
                            dest = new Destination();                            
                        }
                        

                        Performer perform = serviceNote.performer;                        


                        string numberSN = conn.GetNumberDoc().ToString();  //Номер служебной записки

                        string markSN = "195-95-30-3631-" + numberSN;

                        //Нужно копировать номер СЗ в буфер обмена
                        Clipboard.SetDataObject(markSN, true);

                        string pathDirectory = new CommonClass().MCreateDirectory(Path.Combine(path, markSN)); //Создаем папку для СЗ

                        //Наименование файла служебной записки
                        string nameFile = markSN + " _ " + textNameSN.Text + " (исп. " + perform.Initials() + ", адр. " + dest.Initials() + ")";

                        //Относительный путь к служебной записки
                        serviceNote.pathRelative = markSN + @"\" + nameFile;
                        serviceNote.name = textNameSN.Text;
                        serviceNote.summary = textSN.Text;
                        serviceNote.destination = dest; //Выбранный адресат
                        serviceNote.number = numberSN;
                        serviceNote.mark = markSN;
                        serviceNote.date = DateTime.Today;

                        string fullFileName = Path.Combine(pathDirectory, nameFile); //полный путь к файлу            


                        MessageFilter.Register();

                        //создадим 
                        WorkWord word = new WorkWord();
                        word.DocFromPattern(pathPattern, fullFileName);
                        word.BookmarkWrite(dateDMY, "date");
                        word.BookmarkWrite("№ " + markSN, "markDoc"); //А что если нет такой закладки?
                        word.BookmarkWrite(textSN.Text, "text");                        
                        word.BookmarkWrite(serviceNote.destination.genitiveForm, "destination"); //Здесь нужна форма обращения, а не фамилия и должность

                        word.BookmarkWrite(comboBoxPerformer.Text, "performer");
                        word.BookmarkWrite(serviceNote.performer.InitialsNPS(), "initPerformer");
                        word.BookmarkWrite(serviceNote.performer.Initials(), "performerInit");
                        word.BookmarkWrite(serviceNote.performer.phone, "performerPhone");
                        word.BookmarkWrite(serviceNote.performer.post, "performerPost");  


                        MessageFilter.Revoke();

                        conn.UpdateSN(serviceNote);

                        conn.LastNNumberSN(10);

                        //Закрываем соединение с БД
                        conn.Disconnect();
                    }                    
                }
            
                
            }
            catch
            {
                MessageBox.Show("Исключение");
            }
                        
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
