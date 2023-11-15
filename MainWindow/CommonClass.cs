using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace MainWindow
{
    class CommonClass
    {
        public string MCreateDirectory(string path)  //Создаем папку по указанному пути и все другие верхнии папки из пути если они не созданные
        {
            Console.WriteLine("Пытаемся создать папку");
            // Specify the directory you want to manipulate.

            try
            {
                // Determine whether the directory exists.

                if (Directory.Exists(path))
                {
                    MDeleteCharToString(ref path);
                    return path;
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(path);
                return di.FullName;
                //Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));

                // Delete the directory.
                //di.Delete();
                //Console.WriteLine("The directory was deleted successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
                return "";
            }
            finally { }
        }

        void MDeleteCharToString(ref string path)  //Функция удаляет пробелы из строк в конце
        {
            while (path.Last() == ' ')
            {
                path = path.Remove(path.Length - 1);
            }

        }

        //Древовидный файловый проводник
        public void FileСonductorTreeView(string path, TreeNode node)
        {
            //Получаем все директории, находящиеся в указанной директории
            string[] dirs = Directory.GetDirectories(path);

            foreach (var dir in dirs)
            {
                TreeNode list = new TreeNode();
                list.Text = Path.GetFileName(dir);
                list.Tag = dir;
                list.ImageIndex = 0;
                list.SelectedImageIndex = 0;

                FileСonductorTreeView(dir, list);

                node.Nodes.Add(list);
            }

            string[] files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                TreeNode list = new TreeNode();
                list.Text = Path.GetFileName(file);
                list.Tag = file;
                list.ImageIndex = 1;
                list.SelectedImageIndex = 1;                

                node.Nodes.Add(list);
            }
        }

        //Файл?
        public bool IsFile(string path)
        {
            //возвращает true если это файл
            //если это папка или просто строка, то вернет false          
            if (File.Exists(path))
            {
                return true;
            }
           
            return false;
        }

        //Папка?
        public bool IsDirectory(string path)
        {
            //возвращает true если это папка
            //если это файл или просто строка, то вернет false          
            if (Directory.Exists(path))
            {
                return true;
            }

            return false;
        }        

        public void CreateDoc(string pathPattern, SNClass dataDoc)
        {
            try
            {

                string settingFile = Directory.GetCurrentDirectory() + "\\setting"; //файл с настройками

                WorkMySQL conn = new WorkMySQL(settingFile);

                if (conn.Connect())
                {
                    //Ссылка на папку где будут храниться документы
                    string path = conn.GetVariable("pathHead");  // данную директорию нужно проверять. может она не существует в текущий момент

                    if (Directory.Exists(path))
                    {
                        string dateDMY = dataDoc.date.ToShortDateString();
                        
                        //день
                        string day = dataDoc.date.Day.ToString();
                        //месяц
                        string month = dataDoc.date.Month.ToString();
                        //год
                        string year = dataDoc.date.Year.ToString();

                        //Нужно копировать номер СЗ в буфер обмена
                        Clipboard.SetDataObject(dataDoc.mark, true);

                        string pathDirectory = new CommonClass().MCreateDirectory(Path.Combine(path, dataDoc.mark)); //Создаем папку для СЗ

                        //Наименование файла служебной записки
                        string nameFile = dataDoc.mark + " _ " + dataDoc.name + " (исп. " + dataDoc.performer.Initials() + ", адр. " + dataDoc.destination.Initials() + ")";

                        //Относительный путь к служебной записки
                        dataDoc.pathRelative = dataDoc.mark + @"\" + nameFile;

                        string fullFileName = Path.Combine(pathDirectory, nameFile); //полный путь к файлу            

                        MessageFilter.Register();

                        //создадим 
                        WorkWord word = new WorkWord();
                        word.DocFromPattern(pathPattern, fullFileName);
                        word.BookmarkWrite(dateDMY, "date");
                        word.BookmarkWrite("№ " + dataDoc.mark, "markDoc"); //А что если нет такой закладки?
                        word.BookmarkWrite(dataDoc.summary, "text");
                        word.BookmarkWrite(dataDoc.destination.genitiveForm, "destination"); //Здесь нужна форма обращения, а не фамилия и должность

                        word.BookmarkWrite(dataDoc.performer.InitialsPhone(), "performer");
                        word.BookmarkWrite(dataDoc.performer.InitialsNPS(), "initPerformer");
                        word.BookmarkWrite(dataDoc.performer.Initials(), "performerInit");
                        word.BookmarkWrite(dataDoc.performer.phone, "performerPhone");
                        word.BookmarkWrite(dataDoc.performer.post, "performerPost");


                        MessageFilter.Revoke();

                        conn.UpdateSN(dataDoc);

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

        
    }
}
