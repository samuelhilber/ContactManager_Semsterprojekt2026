using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemsterProjekt
{
    internal class Customer : Person // die Klasse welche die Kunden erstellt, erbt von Person
    {
        private Salutation _salutation;
        private Gender _gender { get; set; } // Dropdown ohne None Option, dadurch immer ein gültiger Wert und braucht keine Validierung
        public Title Title { get; set; } // None ist hier ein gültiger Wert (kein akademischer Titel vorhanden), braucht dadurch keine Validierung
    

    public Salutation Salutation
        {
            get => _salutation;
            set
            {
                if (value == Salutation.None) // Anrede ist Pflicht, None ist nur der nicht ausgewählte Default im Dropdown
                {
                    throw new ArgumentException("Bitte eine Anrede auswählen.");
                }
                _salutation = value;
            }
        }
     public Gender Gender
        {
            get => _gender;
            set
            {
                if (value == Gender.None) // Geschlecht ist Pflicht, None ist nur der nicht ausgewählte Default im Dropdown
                {
                    throw new ArgumentException("Bitte eine Geschlecht auswählen.");
                }
                _gender = value;
            }
        }
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
        None,
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
