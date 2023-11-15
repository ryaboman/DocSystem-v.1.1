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
    public partial class AddEditPerformer : Form
    {
        Performer performer = null;

        public AddEditPerformer()
        {
            InitializeComponent();
            Add_Edit.Text = "Добавить";
            textBoxPCName.Text = Environment.UserName;
            this.ShowDialog();
        }

        public AddEditPerformer(Performer performer)
        {
            InitializeComponent();
            Add_Edit.Text = "Обновить";

            textBoxSurname.Text = performer.surname;
            textBoxName.Text = performer.name;
            textBoxPatronymic.Text = performer.patronymic;
            textBoxPhone.Text = performer.phone;
            textBoxPCName.Text = performer.PCName;
            textBoxPost.Text = performer.post;
            textBoxDepartment.Text = performer.department;

            this.performer = performer;

            this.ShowDialog();
        }

        private void Add_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (performer == null)
                {
                    //Добавляем исполнителя
                    performer = new Performer();

                    performer.surname = textBoxSurname.Text;
                    performer.name = textBoxName.Text;
                    performer.patronymic = textBoxPatronymic.Text;
                    performer.phone = textBoxPhone.Text;
                    performer.PCName = textBoxPCName.Text;
                    performer.post = textBoxPost.Text;
                    performer.department = textBoxDepartment.Text;

                    string settingFile = Directory.GetCurrentDirectory() + "\\setting"; //файл с настройками

                    WorkMySQL conn = new WorkMySQL(settingFile);

                    if (conn.Connect())
                    {
                        if (!conn.AddPerformer(performer))
                        {
                            MessageBox.Show("Не удалось добавть исполнителя. Возможно имя учетной записи уже существует в БД");
                            conn.Disconnect();
                            return;
                        }
                        conn.Disconnect();
                    }
                    else
                    {
                        performer = null; //нужно обнулить, т.к. если не было подключения, то уже существует объект
                        MessageBox.Show("Нет подключения к БД.");
                    }

                }
                else
                {
                    //Обновляем исполнителя
                    performer.surname = textBoxSurname.Text;
                    performer.name = textBoxName.Text;
                    performer.patronymic = textBoxPatronymic.Text;
                    performer.phone = textBoxPhone.Text;
                    performer.PCName = textBoxPCName.Text;
                    performer.post = textBoxPost.Text;
                    performer.department = textBoxDepartment.Text;

                    string settingFile = Directory.GetCurrentDirectory() + "\\setting"; //файл с настройками

                    WorkMySQL conn = new WorkMySQL(settingFile);

                    if (conn.Connect())
                    {
                        if (!conn.UpdatePerformer(performer)) //Здесь нужна другая функция
                        {
                            MessageBox.Show("Не удалось обновить данные исполнителя");
                            conn.Disconnect();
                            return;
                        }
                        conn.Disconnect();                        
                    }
                    else
                    {
                        MessageBox.Show("Нет подключения к БД.");
                    }
                }
                this.Close();
            }
            catch
            {

            }
        }       
    }
}
