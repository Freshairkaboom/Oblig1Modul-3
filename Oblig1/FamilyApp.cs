using System;
using System.Collections.Generic;

namespace Oblig1
{
    public class FamilyApp
    {
        private List<Person> _people;
        public string WelcomeMessage { get; internal set; } = "Velkommen til familietre-appen.";
        public string CommandPrompt { get; internal set; } = "Skriv inn \"hjelp\" for en liste av tilgjengelige kommandoer.\n";

        public FamilyApp(params Person[] people)
        {
            _people = new List<Person>(people);
        }

        public string HandleCommand(string command)
        {
            string result;

            if (command == "hjelp")
            {
                return "\"hjelp\": Viser en hjelpetekst for alle kommandoene.\n"
                       +  "\"liste\": Lister alle personer med id, fornavn, fødselsår, dødsår og navn og id på mor og far om det finnes registrert. \n"
                       +  "\"vis <id>\": Viser en bestemt person med mor, far og barn.";
            }

            if (command == "liste")
            {
                string returnResult = "";
                foreach (Person person in _people)
                {
                    returnResult += person.GetDescription();
                    returnResult += "\n";
                }

                return returnResult;
            }

            foreach (Person person in _people)
            {
                if (command.ToLower() == "vis " + person.Id)
                {
                    result = person.GetDescription();
                    result += person.GetChildren(_people);
                    return result;
                }
            }

            return null;
        }
    }
}