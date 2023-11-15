using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainWindow
{

    public class SNClass
    {
        public string id { get; set; }
        public string number { get; set; }
        public string mark { get; set; }        
        public string name { get; set; }

        public Destination destination { get; set; } 
        public Performer performer { get; set; }
        public DateTime date { get; set; } ///????
        public string summary { get; set; }
        public string pathRelative { get; set; }

        public SNClass()
        {
            id = null;
            number = null;
            mark = null;
            name = null;
            destination = new Destination();
            performer = new Performer();
            date = new DateTime();
            summary = null;
            pathRelative = null;
        }
    }

    public class Destination
    {
        public string id { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public string post { get; set; }
        public string genitiveForm { get; set; }

        public Destination()
        {
            id = null;
            surname = null;
            name = null;
            patronymic = null;
            post = null;
            genitiveForm = null;
        }

        public string InitialsDest() // Получить "Фамилия И.О. должность"
        {
            // Фамилия И.О. должность //Вылечили исключение добавлением двух символов.. возможно нужно как-то подругому
            return surname + " " + (name + "  ").Remove(1) + "." + (patronymic + "  ").Remove(1) + ". " + post;
        }

        public string Initials() // Получить "Фамилия И.О. должность"
        {
            // Фамилия И.О. должность //Вылечили исключение добавлением двух символов.. возможно нужно как-то подругому
            return surname + " " + (name + "  ").Remove(1) + "." + (patronymic + "  ").Remove(1);
        }

    }

    public class Performer
    {
        public string id { get; set; }
        public string PCName { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public string department { get; set; }        
        public string post { get; set; }
        public string phone { get; set; }
        public bool IsUserRoot { get; set; }

        public Performer()
        {
            id = null;
            PCName = null;
            surname = null;
            name = null;
            patronymic = null;
            department = "0";
            post = null;
            phone = null;
            IsUserRoot = false;
        }

        public string InitialsPhone()
        {
            return surname + " " + (name + "  ").Remove(1) + "." + (patronymic + "  ").Remove(1) + ". " + phone;
        }

        public string InitialsPost()
        {
            return surname + " " + (name + "  ").Remove(1) + "." + (patronymic + "  ").Remove(1) + ". " + post;
        }

        public string SNP()
        {
            return surname + " " + name + " " + patronymic ;
        }

        public string Initials()
        {
            return surname + " " + (name + "  ").Remove(1) + "." + (patronymic + "  ").Remove(1) + ". ";
        }

        public string InitialsNPS()
        {
            return (name + "  ").Remove(1) + "." + (patronymic + "  ").Remove(1) + ". " + surname;
        }
    }
}
