using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int BirthYear { get; set; }

        public int DeathYear { get; set; }

        public Person Father { get; set; }

        public Person Mother { get; set; }

        public string GetDescription()
        {
            string result = ReturnPersonDescription(false);

            return result.Trim();
        }

        private string ReturnPersonDescription(bool ranOnce)
        {
            string result = "";

            if (FirstName != null) result += FirstName + " ";
            if (LastName != null) result += LastName + " ";
            if (Id > 0) result += $"(Id={Id})" + " ";
            if (ranOnce == false)
            {
                if (BirthYear > 0) result += $"Født: {BirthYear}" + " ";
                if (DeathYear > 0) result += $"Død: {DeathYear}" + " ";
            
                if (Father != null) result += $"Far: {Father.ReturnPersonDescription(true)}";
                if (Mother != null) result += $"Mor: {Mother.ReturnPersonDescription(true)}" + " ";
            }

            return result;
        }

        public string GetChildren(List<Person> _people)
        {
            string result = "\n  Barn:\n";
            List<Person> listOfChildren = new List<Person>();

            foreach (Person person in _people)
            {
                var fatherFirstName = person.Father == null ? null : person.Father.FirstName;
                var motherFirstName = person.Mother == null ? null : person.Mother.FirstName;

                if (FirstName == fatherFirstName || FirstName == motherFirstName) listOfChildren.Add(person);

            }

            foreach (Person child in listOfChildren) result += $"    {child.FirstName} (Id={child.Id}) Født: {child.BirthYear}\n";

            return listOfChildren.Count < 1 ? null : result;
        }
    }
}
