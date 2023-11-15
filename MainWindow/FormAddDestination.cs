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
    public partial class FormAddDestination : Form
    {
        Destination dest = null;
        public FormAddDestination()
        {
            InitializeComponent();
            buttonAddDest.Text = "Добавить";
        }

        public FormAddDestination(Destination dest)
        {
            InitializeComponent();
            buttonAddDest.Text = "Обновить";

            textBoxSurname.Text = dest.surname;
            textBoxName.Text = dest.name;
            textBoxPatronymic.Text = dest.patronymic;
            textBoxPost.Text = dest.post;
            textBoxGenitiveForm.Text = dest.genitiveForm;

            this.dest = dest;

        }

        private void buttonAddDest_Click(object sender, EventArgs e)
        {
            if(dest == null) //Если ноль, то добавляем. Иначе редактируем
            {
                //Добавляем
                dest = new Destination();

                dest.surname = textBoxSurname.Text;
                dest.name = textBoxName.Text;
                dest.patronymic = textBoxPatronymic.Text;
                dest.post = textBoxPost.Text;
                dest.genitiveForm = textBoxGenitiveForm.Text;

                try
                {
                    string settingFile = Directory.GetCurrentDirectory() + "\\setting"; //файл с настройками

                    WorkMySQL conn = new WorkMySQL(settingFile);

                    if (conn.Connect())
                    {
                        conn.AddDestination(dest); //обращаемся к БД и просим ее добавить адресата
                        conn.Disconnect();          // Отключаемся от БД
                    }
                    else
                    {
                        dest = null;
                        MessageBox.Show("Нет подключения к БД.");
                        return;
                    }
                }
                catch
                {

                }
            }
            else
            {
                //Редактируем
                dest.surname = textBoxSurname.Text;
                dest.name = textBoxName.Text;
                dest.patronymic = textBoxPatronymic.Text;
                dest.post = textBoxPost.Text;
                dest.genitiveForm = textBoxGenitiveForm.Text;

                try
                {
                    string settingFile = Directory.GetCurrentDirectory() + "\\setting"; //файл с настройками

                    WorkMySQL conn = new WorkMySQL(settingFile);

                    if (conn.Connect())
                    {
                        conn.UpdateDestination(dest); //обращаемся к БД и просим ее добавить адресата
                        conn.Disconnect();          // Отключаемся от БД
                    }
                    else
                    {
                        MessageBox.Show("Нет подключения к БД.");
                        return;
                    }
                }
                catch
                {

                }
                
            }
            

            this.Close();

        }
    }
}
