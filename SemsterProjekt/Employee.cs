using System;
using System.Collections.Generic;
using System.Text;

namespace SemsterProjekt
{
    internal class Employee : Person
    {
        public int EmployeeNumber { get; init; }  // nur bei der Erstellung setzbar
        public Job Job { get; set; }
        public string AhvNumber { get; set; } = string.Empty;
        public int ManagmentLevel { get; set; } = 0;
        public string Nationality { get; set; } = string.Empty;
        public int Employment { get; set; } = 100;
        public DateOnly EntryDate { get; set; }
        public DateOnly? ExitDate { get; set; }
        public bool Trainee { get; set; } = false;
        public string Adressprivat { get; set; } = string.Empty;
        public int Plzprivat { get; set; }
        public string Residance { get; set; } = string.Empty;
        public string? Adressbuisness { get; set; } = string.Empty;
        public int? PlzBuisness { get; set; }
    }

    public enum Job
    {
        Spedition,
        Backoffice,
        Marketing,
        It,
        Fertigung,
        Aussendienst
    }
}
