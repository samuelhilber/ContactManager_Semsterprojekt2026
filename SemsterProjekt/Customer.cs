using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemsterProjekt
{
    internal class Customer : Person // die Klasse welche die Kunden erstellt, erbt von Person
    {
        public Salutation Salutation { get; set; }
        public Gender Gender { get; set; }
        public Title Title { get; set; }
    }

    public enum Salutation //Enum für Dropdown Anderde
    {
        None,
        Herr,
        Frau,
        Divers
    }

    public enum Gender //Enum für Dropdown Geschlecht
    {
        Mann,
        Frau,
        Divers
    }

    public enum Title//Enum für Dropdown Titel
    {
        None,
        Professor,
        Doktor
    }
}
