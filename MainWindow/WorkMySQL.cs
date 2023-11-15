using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace MainWindow
{
    public class WorkMySQL
    {
        public string server { get; set; }        
        public string database { get; set; }
        public string user { get; set; }
        public string password { get; set; }

        MySqlConnection conn = null;

        public WorkMySQL()
        {
            server = string.Empty;            
            database = string.Empty;
            user = string.Empty;
            password = string.Empty;                        
        }

        public WorkMySQL(string connectFile)
        {
            Txt txt = new Txt();
            if (txt.SetPathToFile(connectFile))
            {
                server = txt.Select("<server>", "</server>");    //получаем сервер
                database = txt.Select("<database>", "</database>"); //получаем базу данных
                user = txt.Select("<user>", "</user>");        //получаем пользователя
                password = txt.Select("<password>", "</password>"); //получаем пароль                
            }
        }

        public bool Connect()  //функция подключения к базе данных 
        {

            string connStr = "server = " + server + "; " +   
                             "user = " + user + "; " + 
                             "database = " + database + "; " +
                             "password = " + password;

            conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int GetNumberDoc() //функция MySQL для получения номера служебной записки
        {
            MySqlCommand command = new MySqlCommand("GetNumberDoc;", conn);

            int numberSNOut = -1;

            // Настроить вид у Command как StoredProcedure.            
            command.CommandType = CommandType.StoredProcedure;

            //Параметр - номер (обозначение) СЗ
            MySqlParameter number_sn = new MySqlParameter();
            number_sn.ParameterName = "count_sn_out"; //наименование параметра в БД
            number_sn.MySqlDbType = MySqlDbType.Int32;
            number_sn.Value = 0;
            number_sn.Direction = ParameterDirection.Output;
            command.Parameters.Add(number_sn);

            //Параметр - номер (обозначение) СЗ
            MySqlParameter depart = new MySqlParameter();
            depart.ParameterName = "depart"; //наименование параметра в БД
            depart.MySqlDbType = MySqlDbType.VarChar;
            depart.Value = GetPerformer().department;
            depart.Direction = ParameterDirection.Input;
            command.Parameters.Add(depart);

            try
            {
                command.ExecuteNonQuery();

                numberSNOut = ((int)command.Parameters["count_sn_out"].Value);
            }
            catch
            {
                MessageBox.Show("Исключение. Получение №СЗ.");
            }
            

            return numberSNOut;

        }

        public void AddDestination(Destination dest)
        {
            MySqlCommand command = new MySqlCommand("AddDestination;", conn);

            // Настроить вид у Command как StoredProcedure.            
            command.CommandType = CommandType.StoredProcedure;

            //Параметр - 
            MySqlParameter surname = new MySqlParameter();
            surname.ParameterName = "surname"; //наименование параметра в БД
            surname.MySqlDbType = MySqlDbType.VarChar;
            surname.Value = dest.surname;
            //По умолчанию параметры считаются входными, но все же для ясности:
            surname.Direction = ParameterDirection.Input;
            command.Parameters.Add(surname);


            //Параметр - 
            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "destName";
            name.MySqlDbType = MySqlDbType.VarChar;
            name.Value = dest.name;
            name.Direction = ParameterDirection.Input;
            command.Parameters.Add(name);

            //Параметр - 
            MySqlParameter patronymic = new MySqlParameter();
            patronymic.ParameterName = "destPatronymic";
            patronymic.MySqlDbType = MySqlDbType.VarChar;  //Нужно проверить!
            patronymic.Value = dest.patronymic;
            patronymic.Direction = ParameterDirection.Input;
            command.Parameters.Add(patronymic);

            //Параметр - 
            MySqlParameter DesPost = new MySqlParameter();
            DesPost.ParameterName = "destPost";
            DesPost.MySqlDbType = MySqlDbType.VarChar;
            DesPost.Value = dest.post;
            DesPost.Direction = ParameterDirection.Input;
            command.Parameters.Add(DesPost);

            //Параметр - 
            MySqlParameter genitiveForm = new MySqlParameter();
            genitiveForm.ParameterName = "genitivePost";
            genitiveForm.MySqlDbType = MySqlDbType.VarChar;
            genitiveForm.Value = dest.genitiveForm;
            genitiveForm.Direction = ParameterDirection.Input;
            command.Parameters.Add(genitiveForm);

            command.ExecuteNonQuery();
        }

        public bool AddPerformer(Performer perform)
        {
            //Здесь нужно добавить имя пользователя компьютера

            MySqlCommand command = new MySqlCommand("AddPerformer;", conn);

            // Настроить вид у Command как StoredProcedure.            
            command.CommandType = CommandType.StoredProcedure;

            //Параметр - 
            MySqlParameter PCName = new MySqlParameter();
            PCName.ParameterName = "PCName"; //наименование параметра в БД
            PCName.MySqlDbType = MySqlDbType.VarChar;
            PCName.Value = perform.PCName;
            //По умолчанию параметры считаются входными, но все же для ясности:
            PCName.Direction = ParameterDirection.Input;
            command.Parameters.Add(PCName);


            //Параметр - 
            MySqlParameter surnameIN = new MySqlParameter();
            surnameIN.ParameterName = "surnameIN";
            surnameIN.MySqlDbType = MySqlDbType.VarChar;
            surnameIN.Value = perform.surname;
            surnameIN.Direction = ParameterDirection.Input;
            command.Parameters.Add(surnameIN);

            //Параметр - 
            MySqlParameter nameIN = new MySqlParameter();
            nameIN.ParameterName = "nameIN";
            nameIN.MySqlDbType = MySqlDbType.VarChar;  //Нужно проверить!
            nameIN.Value = perform.name;
            nameIN.Direction = ParameterDirection.Input;
            command.Parameters.Add(nameIN);

            //Параметр - 
            MySqlParameter patronymicIN = new MySqlParameter();
            patronymicIN.ParameterName = "patronymicIN";
            patronymicIN.MySqlDbType = MySqlDbType.VarChar;
            patronymicIN.Value = perform.patronymic;
            patronymicIN.Direction = ParameterDirection.Input;
            command.Parameters.Add(patronymicIN);

            //Параметр - 
            MySqlParameter departmentIN = new MySqlParameter();
            departmentIN.ParameterName = "departmentIN";
            departmentIN.MySqlDbType = MySqlDbType.VarChar;
            departmentIN.Value = perform.department;
            departmentIN.Direction = ParameterDirection.Input;
            command.Parameters.Add(departmentIN);

            //Параметр - 
            MySqlParameter postIN = new MySqlParameter();
            postIN.ParameterName = "postIN";
            postIN.MySqlDbType = MySqlDbType.VarChar;
            postIN.Value = perform.post;
            postIN.Direction = ParameterDirection.Input;
            command.Parameters.Add(postIN);

            //Параметр - 
            MySqlParameter phoneIN = new MySqlParameter();
            phoneIN.ParameterName = "phoneIN";
            phoneIN.MySqlDbType = MySqlDbType.VarChar;
            phoneIN.Value = perform.phone;
            phoneIN.Direction = ParameterDirection.Input;
            command.Parameters.Add(phoneIN);


            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }


        public List<Destination> GetAllDestination(ComboBox comboBoxDestin)
        {
            comboBoxDestin.Items.Clear();
            //может необходимо создавать прям запрос???
            //Здесь будем получать всех адресатов, для выпадающего меню

            string sql = "SELECT dest_surname, dest_name, dest_patronymic, emp_position, id_destination, genitive_dest FROM destination ORDER BY dest_surname";

            List<Destination> destList = new List<Destination>();

            MySqlCommand command = new MySqlCommand(sql, conn);

            try
            {
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Destination dest_man = new Destination();
                    dest_man.surname = reader[0].ToString();      //Фамилия
                    dest_man.name = reader[1].ToString();         //Имя 
                    dest_man.patronymic = reader[2].ToString();   //Отчество
                    dest_man.post = reader[3].ToString();      // Должность
                    dest_man.id = reader[4].ToString();    //id_destination
                    dest_man.genitiveForm = reader[5].ToString();     //Форма обращения в СЗ

                    comboBoxDestin.Items.Add(dest_man.InitialsDest());  //Получить "Фамилия И.О. должность"

                    destList.Add(dest_man);
                }
                reader.Close();
            }
            catch
            {
                MessageBox.Show("Исключение");
            }

            
            

            return destList;
        }

        public List<Performer> GetAllPerformeres(ComboBox comboBoxPerform)
        {
            comboBoxPerform.Items.Clear();
            //может необходимо создавать прям запрос???
            //Здесь будем получать всех адресатов, для выпадающего меню

            string sql = "SELECT id_user, user_name, surname, name, patronymic, department, post, number_phone, IsUserRoot FROM performer ORDER BY surname";

            List <Performer> performList = new List<Performer>();


            MySqlCommand command = new MySqlCommand(sql, conn);

            try
            {
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Performer per = new Performer();

                    per.id = reader[0].ToString();    //id
                    per.PCName = reader[1].ToString();     //Учетная запись на компьютере
                    per.surname = reader[2].ToString();      //Фамилия
                    per.name = reader[3].ToString();         //Имя
                    per.patronymic = reader[4].ToString();   //Отчество                
                    per.department = reader[5].ToString();
                    per.post = reader[6].ToString();      // Должность
                    per.phone = reader[7].ToString();

                    if (Int32.Parse(reader[8].ToString()) == 1)
                    {
                        per.IsUserRoot = true;            // исполнитель имеет права рут??
                    }

                    comboBoxPerform.Items.Add(per.Initials());  //Получить "Фамилия И.О. должность"

                    performList.Add(per);
                }
                reader.Close();
            }
            catch
            {

            }
            

            return performList;
        }

        public Destination GetDestination(string id)
        {                       
            string sql = "SELECT dest_surname, dest_name, dest_patronymic, emp_position, id_destination, genitive_dest FROM destination WHERE id_destination = 0";

            sql += id + ";";

            Destination dest_man = new Destination();

            MySqlCommand command = new MySqlCommand(sql, conn);

            

            try
            {
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {                    
                    dest_man.surname = reader[0].ToString();      //Фамилия
                    dest_man.name = reader[1].ToString();         //Имя 
                    dest_man.patronymic = reader[2].ToString();   //Отчество
                    dest_man.post = reader[3].ToString();      // Должность
                    dest_man.id = reader[4].ToString();    //id_destination
                    dest_man.genitiveForm = reader[5].ToString();     //Форма обращения в СЗ
                }
                reader.Close();
            }
            catch
            {
                MessageBox.Show("Исключение");
            }

            return dest_man;
        }

        public Performer GetPerformer()
        {
            Performer per = new Performer();

            string sql = "SELECT id_user, user_name, surname, name, patronymic, department, number_phone, post, IsUserRoot FROM performer WHERE user_name = ";

            sql += '\"' + Environment.UserName + '\"';

            MySqlCommand command = new MySqlCommand(sql, conn);
            //command.
            MySqlDataReader reader = command.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    per.id = reader[0].ToString();     // id_performer - ID исполнителя
                    per.PCName = reader[1].ToString();           // Наименование компьютера исполнителя
                    per.surname = reader[2].ToString();          // Фамилия исполнителя
                    per.name = reader[3].ToString();             // Имя исполнителя
                    per.patronymic = reader[4].ToString();       // Отчество исполнителя
                    per.department = reader[5].ToString();       // КГ исполнителя
                    per.phone = reader[6].ToString();            // телефон исполнителя
                    per.post = reader[7].ToString();            // должность исполнителя

                    if (Int32.Parse(reader[8].ToString()) == 1)
                    {
                        per.IsUserRoot = true;            // исполнитель имеет права рут??
                    }                    
                }
                reader.Close();
            }
            catch
            {

            }

            return per;
        }

        public Performer GetPerformer(string id)
        {
            Performer per = new Performer();

            string sql = "SELECT id_user, user_name, surname, name, patronymic, department, number_phone, post, IsUserRoot  FROM performer WHERE id_user = 0"; //0 нужен для того чтобы ошибки не было

            sql += id + ";";

            MySqlCommand command = new MySqlCommand(sql, conn);
            //command.
            

            try
            {
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    per.id = reader[0].ToString();     // id_performer - ID исполнителя
                    per.PCName = reader[1].ToString();           // Наименование компьютера исполнителя
                    per.surname = reader[2].ToString();          // Фамилия исполнителя
                    per.name = reader[3].ToString();             // Имя исполнителя
                    per.patronymic = reader[4].ToString();       // Отчество исполнителя
                    per.department = reader[5].ToString();       // КГ исполнителя
                    per.phone = reader[6].ToString();            // телефон исполнителя
                    per.post = reader[7].ToString();            // должность исполнителя

                    if (Int32.Parse(reader[8].ToString()) == 1)
                    {
                        per.IsUserRoot = true;            // исполнитель имеет права рут??
                    }
                }
                reader.Close();
            }
            catch
            {

            }

            return per;
        }

        //Функция обновляет данные по номеру СЗ
        public void UpdateSN(SNClass serviceNote)
        {
            MySqlCommand command = new MySqlCommand("UpdateSN;", conn);

            // Настроить вид у Command как StoredProcedure.            
            command.CommandType = CommandType.StoredProcedure;

            //Параметр - номер (обозначение) СЗ
            MySqlParameter numberSN = new MySqlParameter();
            numberSN.ParameterName = "numberSN"; //наименование параметра в БД
            numberSN.MySqlDbType = MySqlDbType.VarChar;
            numberSN.Value = serviceNote.number;                                         //как обновлять это????
            //По умолчанию параметры считаются входными, но все же для ясности:
            numberSN.Direction = ParameterDirection.Input;
            command.Parameters.Add(numberSN);


            //Параметр - наименование СЗ
            MySqlParameter nameSN = new MySqlParameter();
            nameSN.ParameterName = "nameSN";
            nameSN.MySqlDbType = MySqlDbType.VarChar;
            nameSN.Value = serviceNote.name;
            nameSN.Direction = ParameterDirection.Input;
            command.Parameters.Add(nameSN);

            //Параметр - адрессат СЗ
            MySqlParameter destinationSN = new MySqlParameter();
            destinationSN.ParameterName = "destinationSN";
            destinationSN.MySqlDbType = MySqlDbType.Int32;  //Нужно проверить!
            destinationSN.Value = serviceNote.destination.id;
            destinationSN.Direction = ParameterDirection.Input;
            command.Parameters.Add(destinationSN);

            //Параметр - текс СЗ
            MySqlParameter textSN = new MySqlParameter();
            textSN.ParameterName = "textSN";
            textSN.MySqlDbType = MySqlDbType.VarChar;
            textSN.Value = serviceNote.summary;
            textSN.Direction = ParameterDirection.Input;
            command.Parameters.Add(textSN);

            //Параметр - исполнитель СЗ
            MySqlParameter performerSN = new MySqlParameter();
            performerSN.ParameterName = "performerSN";
            performerSN.MySqlDbType = MySqlDbType.Int32;  //Нужно проверить!
            performerSN.Value = serviceNote.performer.id;
            performerSN.Direction = ParameterDirection.Input;
            command.Parameters.Add(performerSN);

            //Параметр - относительная ссылка на СЗ
            MySqlParameter pathSN = new MySqlParameter();
            pathSN.ParameterName = "pathSN";
            pathSN.MySqlDbType = MySqlDbType.VarChar;
            pathSN.Value = serviceNote.pathRelative;
            pathSN.Direction = ParameterDirection.Input;
            command.Parameters.Add(pathSN);

            //Параметр - Обозначение СЗ
            MySqlParameter markSN = new MySqlParameter();
            markSN.ParameterName = "markSN";
            markSN.MySqlDbType = MySqlDbType.VarChar;
            markSN.Value = serviceNote.mark;
            markSN.Direction = ParameterDirection.Input;
            command.Parameters.Add(markSN);



            string date = serviceNote.date.Year.ToString() + "-" + serviceNote.date.Month.ToString() + "-" + serviceNote.date.Day.ToString();

            //Параметр - Обозначение СЗ
            MySqlParameter dateDoc = new MySqlParameter();
            dateDoc.ParameterName = "dateDoc";
            dateDoc.MySqlDbType = MySqlDbType.VarChar;
            dateDoc.Value = date;
            dateDoc.Direction = ParameterDirection.Input;
            command.Parameters.Add(dateDoc);

            MySqlParameter depart = new MySqlParameter();
            depart.ParameterName = "depart";
            depart.MySqlDbType = MySqlDbType.VarChar;
            depart.Value = serviceNote.performer.department;
            depart.Direction = ParameterDirection.Input;
            command.Parameters.Add(depart);


            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
            
        }

        public bool UpdateDestination(Destination dest)
        {
            MySqlCommand command = new MySqlCommand("UpdateDestination;", conn);

            // Настроить вид у Command как StoredProcedure.            
            command.CommandType = CommandType.StoredProcedure;

            //Параметр - 
            MySqlParameter id = new MySqlParameter();
            id.ParameterName = "id"; //наименование параметра в БД
            id.MySqlDbType = MySqlDbType.VarChar;
            id.Value = dest.id;
            //По умолчанию параметры считаются входными, но все же для ясности:
            id.Direction = ParameterDirection.Input;
            command.Parameters.Add(id);

            //Параметр - 
            MySqlParameter surname = new MySqlParameter();
            surname.ParameterName = "surname"; //наименование параметра в БД
            surname.MySqlDbType = MySqlDbType.VarChar;
            surname.Value = dest.surname;
            //По умолчанию параметры считаются входными, но все же для ясности:
            surname.Direction = ParameterDirection.Input;
            command.Parameters.Add(surname);


            //Параметр - 
            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "destName";
            name.MySqlDbType = MySqlDbType.VarChar;
            name.Value = dest.name;
            name.Direction = ParameterDirection.Input;
            command.Parameters.Add(name);

            //Параметр - 
            MySqlParameter patronymic = new MySqlParameter();
            patronymic.ParameterName = "destPatronymic";
            patronymic.MySqlDbType = MySqlDbType.VarChar;  //Нужно проверить!
            patronymic.Value = dest.patronymic;
            patronymic.Direction = ParameterDirection.Input;
            command.Parameters.Add(patronymic);

            //Параметр - 
            MySqlParameter DesPost = new MySqlParameter();
            DesPost.ParameterName = "destPost";
            DesPost.MySqlDbType = MySqlDbType.VarChar;
            DesPost.Value = dest.post;
            DesPost.Direction = ParameterDirection.Input;
            command.Parameters.Add(DesPost);

            //Параметр - 
            MySqlParameter genitiveForm = new MySqlParameter();
            genitiveForm.ParameterName = "genitivePost";
            genitiveForm.MySqlDbType = MySqlDbType.VarChar;
            genitiveForm.Value = dest.genitiveForm;
            genitiveForm.Direction = ParameterDirection.Input;
            command.Parameters.Add(genitiveForm);

            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
           
        }

        public bool UpdatePerformer(Performer perform)
        {

            MySqlCommand command = new MySqlCommand("UpdatePerformer;", conn);

            // Настроить вид у Command как StoredProcedure.            
            command.CommandType = CommandType.StoredProcedure;

            //Параметр - 
            MySqlParameter id = new MySqlParameter();
            id.ParameterName = "id"; //наименование параметра в БД
            id.MySqlDbType = MySqlDbType.VarChar;
            id.Value = perform.id;
            //По умолчанию параметры считаются входными, но все же для ясности:
            id.Direction = ParameterDirection.Input;
            command.Parameters.Add(id);

            //Параметр - 
            MySqlParameter PCName = new MySqlParameter();
            PCName.ParameterName = "PCName"; //наименование параметра в БД
            PCName.MySqlDbType = MySqlDbType.VarChar;
            PCName.Value = perform.PCName;
            //По умолчанию параметры считаются входными, но все же для ясности:
            PCName.Direction = ParameterDirection.Input;
            command.Parameters.Add(PCName);


            //Параметр - 
            MySqlParameter surnameIN = new MySqlParameter();
            surnameIN.ParameterName = "surnameIN";
            surnameIN.MySqlDbType = MySqlDbType.VarChar;
            surnameIN.Value = perform.surname;
            surnameIN.Direction = ParameterDirection.Input;
            command.Parameters.Add(surnameIN);

            //Параметр - 
            MySqlParameter nameIN = new MySqlParameter();
            nameIN.ParameterName = "nameIN";
            nameIN.MySqlDbType = MySqlDbType.VarChar;  //Нужно проверить!
            nameIN.Value = perform.name;
            nameIN.Direction = ParameterDirection.Input;
            command.Parameters.Add(nameIN);

            //Параметр - 
            MySqlParameter patronymicIN = new MySqlParameter();
            patronymicIN.ParameterName = "patronymicIN";
            patronymicIN.MySqlDbType = MySqlDbType.VarChar;
            patronymicIN.Value = perform.patronymic;
            patronymicIN.Direction = ParameterDirection.Input;
            command.Parameters.Add(patronymicIN);

            //Параметр - 
            MySqlParameter departmentIN = new MySqlParameter();
            departmentIN.ParameterName = "departmentIN";
            departmentIN.MySqlDbType = MySqlDbType.VarChar;
            departmentIN.Value = perform.department;
            departmentIN.Direction = ParameterDirection.Input;
            command.Parameters.Add(departmentIN);

            //Параметр - 
            MySqlParameter postIN = new MySqlParameter();
            postIN.ParameterName = "postIN";
            postIN.MySqlDbType = MySqlDbType.VarChar;
            postIN.Value = perform.post;
            postIN.Direction = ParameterDirection.Input;
            command.Parameters.Add(postIN);

            //Параметр - 
            MySqlParameter phoneIN = new MySqlParameter();
            phoneIN.ParameterName = "phoneIN";
            phoneIN.MySqlDbType = MySqlDbType.VarChar;
            phoneIN.Value = perform.phone;
            phoneIN.Direction = ParameterDirection.Input;
            command.Parameters.Add(phoneIN);


            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteDestination(Destination dest)
        {
            string sql = "DELETE FROM destination WHERE id_destination = ";
            sql += dest.id + ";";

            MySqlCommand command = new MySqlCommand(sql, conn);

            try
            {
                command.ExecuteScalar();
                return true;
            }
            catch
            {
                MessageBox.Show("Исключение. Не удалось удалить адресата");
                return false;
            }            
        }

        public bool DeletePerformer(Performer perform)
        {
            string sql = "DELETE FROM performer WHERE id_user = ";
            sql += perform.id + ";";

            MySqlCommand command = new MySqlCommand(sql, conn);

            try
            {
                command.ExecuteScalar(); //Не всегда можно удалить. Так как есть foreing key
                return true;
            }
            catch
            {
                MessageBox.Show("Исключение. Не удалось удалить исполнителя");
                return false;
            }
        }

        public bool DeleteSN(SNClass serviceNote)
        {
            MySqlCommand command = new MySqlCommand("DeleteSN;", conn);

            // Настроить вид у Command как StoredProcedure.            
            command.CommandType = CommandType.StoredProcedure;

            //Параметр - id СЗ
            MySqlParameter id = new MySqlParameter();
            id.ParameterName = "id"; //наименование параметра в БД
            id.MySqlDbType = MySqlDbType.VarChar;
            id.Value = serviceNote.id;                                         //как обновлять это????
            //По умолчанию параметры считаются входными, но все же для ясности:
            id.Direction = ParameterDirection.Input;
            command.Parameters.Add(id);

            //Параметр - номер (обозначение) СЗ
            MySqlParameter numberSN = new MySqlParameter();
            numberSN.ParameterName = "numberSN"; //наименование параметра в БД
            numberSN.MySqlDbType = MySqlDbType.VarChar;
            numberSN.Value = serviceNote.number;                                         //как обновлять это????
            //По умолчанию параметры считаются входными, но все же для ясности:
            numberSN.Direction = ParameterDirection.Input;
            command.Parameters.Add(numberSN);

            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                MessageBox.Show("Не удалось удалить документ");
                return false;
            }
        }

        public string GetPathByDocument(string id_sn)
        {
            string path = string.Empty;
            //Здесь будем получать всех адресатов, для выпадающего меню
            MySqlCommand command = new MySqlCommand("GetPathByDocument;", conn);

            //Настроить вид у Command как StoredProcedure.
            command.CommandType = CommandType.StoredProcedure;

            //Параметр - 
            MySqlParameter idSN = new MySqlParameter();
            idSN.ParameterName = "idSN"; //наименование параметра в БД
            idSN.MySqlDbType = MySqlDbType.Int32;
            idSN.Value = id_sn;
            //По умолчанию параметры считаются входными, но все же для ясности:
            idSN.Direction = ParameterDirection.Input;
            command.Parameters.Add(idSN);

            //Параметр - 
            MySqlParameter pathOut = new MySqlParameter();
            pathOut.ParameterName = "pathOut"; //наименование параметра в БД
            pathOut.MySqlDbType = MySqlDbType.VarChar;
            pathOut.Value = string.Empty;
            //По умолчанию параметры считаются входными, но все же для ясности:
            pathOut.Direction = ParameterDirection.Output;
            command.Parameters.Add(pathOut);

            command.ExecuteNonQuery();

            // Возврат выходного параметра.
            path = ((string)command.Parameters["pathOut"].Value).Trim(); //Trim() - удаляет символы, в данном случае пробелы

            return path;
        }

        //Поиск служебных записок по атрибутам (исполнитель, адресат, дата, содержание, наименование)
        public List<SNClass> SerchDoc(string sqlQ)
        {

            List<SNClass> listDoc = new List<SNClass>();            


            string sql = "SELECT id_sn, count_sn, number_sn, name_sn, destination, user, date, summary, path FROM service_note";

            sql += sqlQ;

            MySqlCommand command = new MySqlCommand(sql, conn);

            try
            {
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    SNClass serviceNote = new SNClass();

                    serviceNote.id = reader[0].ToString();
                    serviceNote.number = reader[1].ToString();
                    serviceNote.mark = reader[2].ToString();
                    serviceNote.name = reader[3].ToString();
                    serviceNote.destination.id = reader[4].ToString();
                    serviceNote.performer.id = reader[5].ToString();
                    serviceNote.date = DateTime.Parse(reader[6].ToString()); 
                    serviceNote.summary = reader[7].ToString();
                    serviceNote.pathRelative = reader[8].ToString();

                    listDoc.Add(serviceNote);
                }
                reader.Close();

                foreach (var doc in listDoc)
                {
                    doc.destination = GetDestination(doc.destination.id);
                    doc.performer = GetPerformer(doc.performer.id);
                }
            }
            catch
            {

            }

            

            return listDoc;
        }

        //N-последних служебных записок //Выводятся при открытии программы //Кроме удаленных
        public List<SNClass> LastNNumberSN(int N, string strSQL)
        {
            List<SNClass> listDoc = new List<SNClass>();

            string sql = "SELECT id_sn, count_sn, number_sn, name_sn, destination, user, date, summary, path FROM service_note WHERE id_sn > 0";

            sql += strSQL;

            sql += "ORDER BY count_sn DESC LIMIT " + N.ToString() + ";";

            MySqlCommand command = new MySqlCommand(sql, conn);

            try
            {
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    SNClass serviceNote = new SNClass();

                    serviceNote.id = reader[0].ToString();
                    serviceNote.number = reader[1].ToString();
                    serviceNote.mark = reader[2].ToString();
                    serviceNote.name = reader[3].ToString();
                    serviceNote.destination.id = reader[4].ToString();
                    serviceNote.performer.id = reader[5].ToString();
                    serviceNote.date = DateTime.Parse(reader[6].ToString());
                    serviceNote.summary = reader[7].ToString();
                    serviceNote.pathRelative = reader[8].ToString();

                    listDoc.Add(serviceNote);
                }
                reader.Close();
                
                foreach(var doc in listDoc)
                {
                    doc.destination = GetDestination(doc.destination.id);
                    doc.performer = GetPerformer(doc.performer.id);
                }

            }
            catch
            {

            }
            

            return listDoc;
        }

        //функция для отключения от БД
        public void Disconnect()
        {

            conn.Close();

            //Нужно возвращать флаг
        }

        public string GetVariable(string varName)
        {
            string sql = "SELECT value FROM variable WHERE var_name = ";
            sql += "\"" + varName + "\";";

            string value = string.Empty;

            MySqlCommand command = new MySqlCommand(sql, conn);            

            try
            {
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    value = reader[0].ToString();
                }
                reader.Close();

                return value;
            }
            catch
            {
                return string.Empty;
            }
        }

        public bool SetVariable(string varName, string value)
        {
            string sql = "UPDATE variable SET value = \"" + value + "\" WHERE var_name = ";
            sql += "\"" + varName + "\";";


            MySqlCommand command = new MySqlCommand(sql, conn);

            try
            {
                command.ExecuteScalar();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public string SetNumberDoc(string numberDoc, Performer performer)
        {
            MySqlCommand command = new MySqlCommand("SetNumberDoc;", conn);

            // Настроить вид у Command как StoredProcedure.            
            command.CommandType = CommandType.StoredProcedure;

            //Параметр - номер входной
            MySqlParameter numberDocIN = new MySqlParameter();
            numberDocIN.ParameterName = "numberDocIN"; //наименование параметра в БД
            numberDocIN.MySqlDbType = MySqlDbType.Int32;
            numberDocIN.Value = numberDoc;
            numberDocIN.Direction = ParameterDirection.Input;
            command.Parameters.Add(numberDocIN);

            //Параметр - номер выходной
            MySqlParameter id_doc = new MySqlParameter();
            id_doc.ParameterName = "id_doc"; //наименование параметра в БД
            id_doc.MySqlDbType = MySqlDbType.Int32;
            id_doc.Value = -1;
            id_doc.Direction = ParameterDirection.Output;
            command.Parameters.Add(id_doc);

            //Параметр - номер выходной
            MySqlParameter depart = new MySqlParameter();
            depart.ParameterName = "depart"; //наименование параметра в БД
            depart.MySqlDbType = MySqlDbType.VarChar;
            depart.Value = "'" + performer.department + "'";
            depart.Direction = ParameterDirection.Input;
            command.Parameters.Add(depart);

            try
            {
                command.ExecuteNonQuery();

                if (id_doc.Value != DBNull.Value)
                {
                    return id_doc.Value.ToString();
                }
                else return null;                   

            }
            catch
            {
                MessageBox.Show("Указанный номер некорректен", "Исключение");
                return null;
            }                        
        }
       

    }
}
