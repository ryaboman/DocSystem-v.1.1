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
    public partial class EditDestination : Form
    {
        List<Destination> destList = new List<Destination>();

        public EditDestination()
        {
            InitializeComponent();

            try
            {
                string settingFile = Directory.GetCurrentDirectory() + "\\setting"; //файл с настройками

                WorkMySQL conn = new WorkMySQL(settingFile);

                if (conn.Connect())
                {
                    destList = conn.GetAllDestination(comboBoxDest);
                    conn.Disconnect();
                }
                else
                {
                    MessageBox.Show("Не получается подключиться к серверу");
                    return;
                }
                this.ShowDialog();

            }
            catch
            {
                MessageBox.Show("Исключение");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            
            try
            {
                int i = comboBoxDest.Items.IndexOf(comboBoxDest.Text);

                if (i >= 0)
                {
                    Destination dest = destList[i];

                    string settingFile = Directory.GetCurrentDirectory() + "\\setting"; //файл с настройками

                    WorkMySQL conn = new WorkMySQL(settingFile);

                    if (conn.Connect())
                    {
                        bool result = conn.DeleteDestination(dest); //Получаем индекс выбранного адресата и передаем его для удаления
                        if (result) //Если удалить получилось, то удалаем из выпадающего меню и списка адресатов
                        {
                            comboBoxDest.Items.Remove(comboBoxDest.Text);
                            destList.Remove(dest);
                        }

                        conn.Disconnect();
                    }
                    else
                    {
                        MessageBox.Show("Не получается подключиться к серверу");
                    }
                }
                else
                {
                    MessageBox.Show("Выберите адресата");
                }
            }
            catch
            {
                return;
            }            
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int i = comboBoxDest.Items.IndexOf(comboBoxDest.Text);

                if (i >= 0)
                {
                    Destination dest = destList[i];

                    FormAddDestination editor = new FormAddDestination(dest);
                    editor.ShowDialog();

                    string settingFile = Directory.GetCurrentDirectory() + "\\setting"; //файл с настройками

                    WorkMySQL conn = new WorkMySQL(settingFile);

                    if (conn.Connect())
                    {
                        comboBoxDest.Text = "";
                        destList = conn.GetAllDestination(comboBoxDest);
                        conn.Disconnect();
                    }
                    else
                    {
                        MessageBox.Show("Не получается подключиться к серверу");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Выберите адресата");
                }                               

                
            }
            catch
            {              
                return;
            }

            

         }
    }
}
