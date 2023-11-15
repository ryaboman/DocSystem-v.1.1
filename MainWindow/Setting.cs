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
    public partial class Setting : Form
    {
        Txt txt = null;
        string settingFile = string.Empty;

        public Setting()
        {
            InitializeComponent();
            this.ShowDialog();
        }

        public Setting(string settingFile)
        {
            InitializeComponent();

            try
            {
                //создаем объект для работы с файлом настроек

                if (File.Exists(settingFile)) //Если файл существует
                {
                    txt = new Txt();
                    //инициализируем объект данными из файла
                    if (txt.SetPathToFile(settingFile)) //вернуть true если удалось инициализировать
                    {
                        server.Text = txt.Select("<server>", "</server>");    //получаем сервер
                        database.Text = txt.Select("<database>", "</database>"); //получаем базу данных
                        user.Text = txt.Select("<user>", "</user>");        //получаем пользователя
                        password.Text = txt.Select("<password>", "</password>"); //получаем пароль
                        pathToPatternes.Text = txt.Select("<pathToPatternes>", "</pathToPatternes>"); //путь к шаблонам документов
                    }                    
                }
                this.settingFile = settingFile;
            }
            catch
            {

            }

            this.ShowDialog();
        }


        private void butAttachDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();

            DialogResult result;

            result = folder.ShowDialog();
            if(result == DialogResult.OK)
            {
                pathToPatternes.Text = folder.SelectedPath;
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            txt.text = string.Empty; //"обнулим" текс

            txt.text += "<server>" + server.Text + "</server>";
            txt.text += "\n\n";
            txt.text += "<database>" + database.Text + "</database>";
            txt.text += "\n\n";
            txt.text += "<user>" + user.Text + "</user>";
            txt.text += "\n\n";
            txt.text += "<password>" + password.Text + "</password>";
            txt.text += "\n\n";
            txt.text += "<pathToPatternes>" + pathToPatternes.Text + "</pathToPatternes>";

            if (File.Exists(settingFile)) //если файл существует перезапишим его
            {
                txt.RewriteFile();
            }
            else //Иначе создадим его
            {
                if (txt.CreateFile(settingFile)) //Если удалось создать файл
                {                    
                    txt.WriteBlock();
                }
            }

            this.Close();

        }

        private void checkConnect_Click(object sender, EventArgs e)
        {
            string settingFile = Directory.GetCurrentDirectory() + "\\setting"; //файл с настройками

            WorkMySQL conn = new WorkMySQL();

            conn.server = server.Text;    //получаем сервер
            conn.database = database.Text; //получаем базу данных
            conn.user = user.Text;        //получаем пользователя
            conn.password = password.Text; //получаем пароль 

            if (conn.Connect())
            {
                conn.Disconnect();
                MessageBox.Show("Успешно подключились к БД");
            }
            else
            {
                MessageBox.Show("Не получилось подключиться к БД. Возможно не верное введены данные");
            }
        }
    }
}
