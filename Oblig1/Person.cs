using System;
using System.Collections.Generic;
using System.Text;

namespace Oblig1
{
    public class Person
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
        public Person Father { get; set; }
        public Person Mother { get; set; }

        private string getContent(string pre, object value, string after = null)
        {
            return value == null ? string.Empty : $"{pre}{value}{after ?? string.Empty}";
        }
        public string getDescription()
        {
            return getContent("", FirstName, " ") +
                   getContent("", LastName, " ") +
                   getContent("(Id=", Id, ")") +
                   getContent(" Født: ", BirthYear, " ") +
                   getContent("Død: ", DeathYear, " ") +
                   getContent("Far: ", Father, "") +
                   getContent(" Mor: ", Mother, "");
        }

        public override string ToString()
        {
            if (Id != null)
            {
                return $"{FirstName ?? ""} {LastName ?? ""}(Id={Id})".Trim();
            }
            return $"{FirstName ?? ""} {LastName ?? ""}".Trim();
        }
    }
}

//string output = string.Empty;
//if (FirstName == null && LastName == null && BirthYear == 0 && DeathYear == 0 && Mother == null && Father == null)
//{
//    output += $"(Id={Id})";
//    return output;
//}
//else if (FirstName != null)
//{
//    output += FirstName + " ";
//    if (LastName != null)
//    {
//        output += LastName + " ";
//    }
//    if (Id != 0)
//    {
//        output += $"(Id={Id}) ";
//    }
//    if (BirthYear != 0)
//    {
//        output += $"Født: {BirthYear} ";
//    }
//    if (DeathYear != 0)
//    {
//        output += $"Død: {DeathYear} ";
//    }
//    if (Father != null)
//    {
//        output += "Far: ";
//        if (Father.FirstName != null)
//        {
//            output += $"{Father.FirstName} ";
//        }
//        if (Father.Id != 0)
//        {
//            output += $"(Id={Father.Id}) ";
//        }
//    }

//    if (Mother != null)
//    {
//        output += "Mor: ";
//        if (Mother.FirstName != null)
//        {
//            output += $"{Mother.FirstName} ";
//        }
//        if (Mother.Id != 0)
//        {
//            output += $"(Id={Mother.Id})";
//        }
//    }
//    return output;
//}

//else
//{
//    output += $"{FirstName} {LastName} (Id={Id}) Født: {BirthYear} Død: {DeathYear} Far: {Father.FirstName} (Id={Father.Id}) Mor: {Mother.FirstName} (Id={Mother.Id})";
//    return output;
//}
