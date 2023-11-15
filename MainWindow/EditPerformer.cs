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
    public partial class EditPerformer : Form
    {
        List<Performer> performList = new List<Performer>();

        public EditPerformer()
        {
            InitializeComponent();

            try
            {
                string settingFile = Directory.GetCurrentDirectory() + "\\setting"; //файл с настройками

                WorkMySQL conn = new WorkMySQL(settingFile);

                if (conn.Connect())
                {
                    performList = conn.GetAllPerformeres(comboBoxPerform);
                    conn.Disconnect();

                    comboBoxPerform.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboBoxPerform.AutoCompleteSource = AutoCompleteSource.ListItems;
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
                int i = comboBoxPerform.Items.IndexOf(comboBoxPerform.Text);

                if (i >= 0)
                {
                    Performer perform = performList[i];

                    string settingFile = Directory.GetCurrentDirectory() + "\\setting"; //файл с настройками

                    WorkMySQL conn = new WorkMySQL(settingFile);

                    if (conn.Connect())
                    {
                        bool result = conn.DeletePerformer(perform); //Получаем индекс выбранного исполнителя и передаем его для удаления
                        if (result) //Если удалить получилось, то удалаем из выпадающего меню и списка исполнителей
                        {
                            comboBoxPerform.Items.Remove(comboBoxPerform.Text);
                            performList.Remove(perform);
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
                    MessageBox.Show("Выберите исполнителя");
                }
                this.Close();
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
                int i = comboBoxPerform.Items.IndexOf(comboBoxPerform.Text);

                if (i >= 0)
                {
                    Performer perform = performList[i];

                    AddEditPerformer editor = new AddEditPerformer(perform);

                    string settingFile = Directory.GetCurrentDirectory() + "\\setting"; //файл с настройками

                    WorkMySQL conn = new WorkMySQL(settingFile);

                    if (conn.Connect())
                    {
                        comboBoxPerform.Text = "";
                        performList = conn.GetAllPerformeres(comboBoxPerform);
                        conn.Disconnect();
                    }
                    else
                    {
                        MessageBox.Show("Не получается подключиться к серверу");
                        
                    }
                }
                else
                {
                    MessageBox.Show("Выберите исполнителя");
                }

                this.Close();

            }
            catch
            {
                return;
            }
        }
    }
}
