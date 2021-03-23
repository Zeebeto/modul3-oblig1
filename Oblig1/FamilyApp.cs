using System;
using System.Collections.Generic;
using System.Text;

namespace Oblig1
{
    public class FamilyApp
    {
        public static bool Running = true;
        public string WelcomeMessage = "FamilyApp v1.0.1a";
        public string CommandPrompt = "Pleasse type out a command: (help, list, show <number>, exit) \n";
        public static List<Person> People;

        public FamilyApp(params Person[] family)
        {
            People = new List<Person>(family);
        }

        public string HandleCommand(string command)
        {
            if (command == null) return CommandPrompt;
            if (command == "HELP") return CommandPrompt;
            if (command == "LIST") return GetList();
            if (command == "EXIT") { Running = false; return "Shutting down... Bye bye =)"; }
            if (command == "SHOW") return CommandPrompt;
            if (command.Contains("SHOW")) return ShowPersonById(command);
            return "INVALID INPUT! use command (help) for help";
        }

        private string GetList()
        {
            string list = string.Empty;
            for (int i = 0; i < People.Count; i++)
            {
                list += People[i].getDescription() + "\n";
            }

            return list;
        }
        private static string ShowPersonById(string command)
        {
            var split = command.Substring(5).Split(" ");
            var index = int.Parse(split[0]);
            string output = string.Empty;
            List<string> kids = new List<string>();
            for (int i = 0; i < People.Count; i++)
            {
                if (People[i].Id == index)
                {
                    output += People[i].getDescription() + "\n";
                }
                if (People[i].Mother != null)
                {
                    if (People[i].Mother.Id == index)
                    {
                        kids.Add(People[i].FirstName +
                                 " (Id=" + People[i].Id +
                                 ") Født: " +
                                 People[i].BirthYear);
                    }
                }
                if (People[i].Father != null)
                {
                    if (People[i].Father.Id == index)
                    {
                        kids.Add(People[i].FirstName +
                                 " (Id=" + People[i].Id +
                                 ") Født: " +
                                 People[i].BirthYear);
                    }
                }
            }

            if (kids.Count == 0)
            {
                return output;
            }
            else
            {
                output += " " + " Barn:\n";
                for (int k = 0; k < kids.Count; k++)
                {
                    if (k == kids.Count - 1)
                    {
                        output += "    " + kids[k] + "\n";
                    }
                    else
                    {
                        output += "    " + kids[k] + "\n";
                    }
                }
            }
            return output;
        }
    }
}
