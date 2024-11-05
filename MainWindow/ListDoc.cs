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
    public partial class ListDoc : Form
    {
        public ListDoc()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            try
            {
                string settingFile = Directory.GetCurrentDirectory() + "\\setting"; //файл с настройками
                WorkMySQL conn = new WorkMySQL(settingFile);

                if (conn.Connect())
                {
                    string DateFrom = dateTimeFrom.Value.Date.Year.ToString() + "-" +
                                      dateTimeFrom.Value.Date.Month.ToString() + "-" +
                                      dateTimeFrom.Value.Date.Day.ToString();

                    string DateBy = dateTimeBy.Value.Date.Year.ToString() + "-" +
                                    dateTimeBy.Value.Date.Month.ToString() + "-" +
                                    dateTimeBy.Value.Date.Day.ToString();

                    string sqlDate = " WHERE date >= \"" + DateFrom + "\" AND date <= \"" + DateBy + "\"  ORDER BY count_sn DESC;";

                    List<SNClass> listDoc = conn.SerchDoc(sqlDate);



                    //какая информация о документах нужна?
                    //1. Номер документа
                    //2. Наименование документа
                    //3. Исполнитель
                    //4. Дата


                    //string pathTemp = Path.GetTempPath() + "\\Документы от " + dateTimeFrom.Value.ToShortDateString() + " по " + dateTimeBy.Value.ToShortDateString() + ".docx";

                    MessageFilter.Register();

                    //Создаем вордовский файл в видимом режиме
                    WorkWord doc = new WorkWord(true);

                    //создаем файл в памяти
                    doc.CreateDoc();

                    //количество документов = количеству строк
                    int count = listDoc.Count + 1; //Плюс один для наименование строк

                    //создаем таблицу из 4 столбцов и count строк
                    doc.AddTable(count, 4);

                    //устанавливаем шируну столбцов
                    doc.SetColumnWidth(1, 120);
                    doc.SetColumnWidth(2, 180);
                    doc.SetColumnWidth(3, 80);
                    doc.SetColumnWidth(4, 65);

                    //Создаем оглавление таблицы
                    doc.WriteDateInTable(1, 1, "Номер документа");
                    doc.WriteDateInTable(1, 2, "Название документа");
                    doc.WriteDateInTable(1, 3, "Исполнитель");
                    doc.WriteDateInTable(1, 4, "Дата");


                    int i = 2; //указатель текущей строки. Первой строкой будет наименование строк

                    foreach (var document in listDoc)
                    {

                        doc.WriteDateInTable(i, 1, document.mark);

                        doc.WriteDateInTable(i, 2, document.name);

                        doc.WriteDateInTable(i, 3, document.performer.Initials());
                        
                        doc.WriteDateInTable(i, 4, document.date.ToShortDateString()); //DateTime.Parse(document.date)

                        i++;
                    }

                    MessageFilter.Revoke();

                    //записываем данные
                    //doc.WriteData();
                    conn.Disconnect();
                }
                else
                {
                    MessageBox.Show("Нет подключения к БД", "Ошибка");
                }             
            }
            catch
            {
                MessageBox.Show("Возникло исключение при формировании списка документов", "Исключение");
            }

            this.Close();
        }
    }
}
