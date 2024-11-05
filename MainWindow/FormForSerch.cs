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
    public partial class FormForSerch : Form
    {  
        public FormForSerch()
        {
            InitializeComponent();            
        }

        private void buttonForSerch_Click(object sender, EventArgs e)
        {
            try
            {
                string settingFile = Directory.GetCurrentDirectory() + "\\setting"; //файл с настройками

                WorkMySQL conn = new WorkMySQL(settingFile);

                if (conn.Connect())
                {
                    Main main = this.Owner as Main;

                    string sql = string.Empty;

                    if (main != null)
                    {
                        main.listDoc = conn.SerchDoc(FormSQL());
                        main.AddListBox(); //Добавляем найденные в ListBox
                    }

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

        private void checkNumberSN_CheckedChanged(object sender, EventArgs e)
        {
            //Обработчик, который при выбранном номере СЗ не позволяет выбрать другие атрибуты поиска
            if (checkNumberSN.CheckState == CheckState.Checked)
            {
                checkDestination.CheckState = CheckState.Unchecked;
                checkDate.CheckState = CheckState.Unchecked;
                checkNameSN.CheckState = CheckState.Unchecked;
                checkSummary.CheckState = CheckState.Unchecked;
                checkPerformer.CheckState = CheckState.Unchecked;
            }

        }

        private string FormSQL()
        {
            string sqlDestination = string.Empty;
            string sqlPerformer = string.Empty;
            string sqlNameSN = string.Empty;
            string sqlCountSN = string.Empty;
            string sqlSummary = string.Empty;
            string DateFrom = string.Empty;
            string DateBy = string.Empty;
            string sqlDate = string.Empty;

            string sqlQ = " WHERE id_sn > 0";

            if (checkNumberSN.CheckState == CheckState.Checked)
            {
                sqlCountSN = " AND count_sn = \"" + textNumberSN.Text + "\"";

                sqlQ += sqlCountSN;
            }
            else
            {
                //Запрос выборки по адресату
                if (checkDestination.CheckState == CheckState.Checked)
                {
                    //Для адресата нужно делать возможно подзапрос!
                    sqlDestination = " AND destination = (SELECT id_destination FROM destination WHERE dest_surname = \"" +
                                       textDestination.Text + "\")";

                    sqlQ += sqlDestination; //запрос на выбор по адресату
                }

                //Запрос выборки по исполнителю
                if (checkPerformer.CheckState == CheckState.Checked)
                {
                    sqlPerformer = " AND user = (SELECT id_user FROM performer WHERE surname = \"" +
                                       textPerformer.Text + "\")";

                    sqlQ += sqlPerformer; //запрос на выбор по исполнителю
                }

                //Запрос выборки по НАИМЕНОВАНИЮ СЗ
                if (checkNameSN.CheckState == CheckState.Checked)
                {
                    sqlNameSN = " AND name_sn LIKE \"%" + textNameSN.Text + "%\"";

                    sqlQ += sqlNameSN; //запрос на выбор по исполнителю
                }


                //Запрос выборки по КРАТКОМУ СОДЕРЖАНИЮ
                if (checkSummary.CheckState == CheckState.Checked)
                {
                    sqlSummary = " AND summary LIKE \"%" + textSummary.Text + "%\"";

                    sqlQ += sqlSummary; //запрос на выбор по исполнителю
                }

                //Запрос выборки по ДАТЕ
                if (checkDate.CheckState == CheckState.Checked)
                {
                    DateFrom = dateFrom.Value.Date.Year.ToString() + "-" +
                               dateFrom.Value.Date.Month.ToString() + "-" +
                               dateFrom.Value.Date.Day.ToString();

                    DateBy = dateBy.Value.Date.Year.ToString() + "-" +
                             dateBy.Value.Date.Month.ToString() + "-" +
                             dateBy.Value.Date.Day.ToString();

                    sqlDate = " AND date >= \"" + DateFrom + "\" AND date <= \"" + DateBy + "\"";

                    sqlQ += sqlDate;
                }

                sqlQ += " ORDER BY count_sn DESC;";

            }
            return sqlQ;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
