using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.FirstName = "Roman";
            person.LastName = "Kowalski";
            person.IsWoman = false;
            person.BirthDate = new DateTime(2000, 1, 1);
            var cloned = person.Clone();
            cloned.FirstName = "Krzysztof";
            Console.WriteLine(person);
            Console.WriteLine(cloned);
            //Wynik RomanEmployee
            //Imiê: Roman, Nazwisko: Kowalski, P³eæ: M, Data urodzenia 01.01.2000
            //Imiê: Krzysztof, Nazwisko: Kowalski, P³eæ: M, Data urodzenia 01.01.2000
            //Bonus
            Person defaultPerson = new Person();
            Console.WriteLine(defaultPerson);
            //Wynik
            //Imiê: Kazimierz, Nazwisko: Nowak, P³eæ: M, Data urodzenia 01.02.1950
            
            Console.Read();
        }
    }

    internal class Person 
    {
        public string FirstName { get; internal set; }  = ConfigurationManager.AppSettings["FirstName"];
        public string LastName { get; internal set; } = ConfigurationManager.AppSettings["LastName"];
        public bool IsWoman { get; internal set; } = Convert.ToBoolean(ConfigurationManager.AppSettings["IsWoman"]);
        public DateTime BirthDate { get; internal set; } = Convert.ToDateTime(ConfigurationManager.AppSettings["BirthDate"]);

        internal Person Clone()
        {
            Person person = new Person();
            person.FirstName = FirstName;
            person.LastName = LastName;
            person.IsWoman = IsWoman;
            person.BirthDate = BirthDate;

            return person;
        }

        public override string ToString()
        {
            string resultSex = IsWoman == false ? "M" : "K";
            return $"Imiê: {FirstName} , Nazwisko: {LastName} , P³eæ = {resultSex} , Urodziny : {BirthDate.ToShortDateString()} ";
        }

    }
}
