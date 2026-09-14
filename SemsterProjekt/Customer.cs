using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemsterProjekt
{
    /// <summary>
    /// Repräsentiert einen Kunden. Erbt die Personendaten von <see cref="Person"/> und
    /// ergänzt sie um Anrede, Geschlecht und akademischen Titel.
    /// </summary>
    internal class Customer : Person
    {
        private Salutation _salutation;
        private Gender _gender { get; set; } // Dropdown ohne None Option, dadurch immer ein gültiger Wert und braucht keine Validierung

        /// <summary>
        /// Gibt den akademischen Titel zurück oder legt ihn fest.
        /// </summary>
        /// <remarks>
        /// <see cref="Title.None"/> ist hier ein gültiger Wert (kein akademischer Titel vorhanden),
        /// deshalb wird nicht validiert.
        /// </remarks>
        public Title Title { get; set; }

        /// <summary>
        /// Gibt die Anrede zurück oder legt sie fest.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Wird ausgelöst, wenn <see cref="Salutation.None"/> gesetzt wird. Die Anrede ist ein Pflichtfeld;
        /// <see cref="Salutation.None"/> steht nur für die noch nicht getroffene Auswahl im Dropdown.
        /// </exception>
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

        /// <summary>
        /// Gibt das Geschlecht zurück oder legt es fest.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Wird ausgelöst, wenn <see cref="Gender.None"/> gesetzt wird. Das Geschlecht ist ein Pflichtfeld;
        /// <see cref="Gender.None"/> steht nur für die noch nicht getroffene Auswahl im Dropdown.
        /// </exception>
        public Gender Gender
        {
            get => _gender;
            set
            {
                if (value == Gender.None) // Geschlecht ist Pflicht, None ist nur der nicht ausgewählte Default im Dropdown
                {
                    throw new ArgumentException("Bitte ein Geschlecht auswählen.");
                }
                _gender = value;
            }
        }
    }

    /// <summary>
    /// Mögliche Anreden eines Kunden für die Dropdown-Auswahl.
    /// </summary>
    public enum Salutation
    {
        /// <summary>
        /// Keine Anrede ausgewählt (Standardwert im Dropdown). Beim Speichern eines Kunden nicht zulässig.
        /// </summary>
        None,

        /// <summary>
        /// Anrede "Herr".
        /// </summary>
        Herr,

        /// <summary>
        /// Anrede "Frau".
        /// </summary>
        Frau,

        /// <summary>
        /// Geschlechtsneutrale Anrede (weder "Herr" noch "Frau").
        /// </summary>
        Divers
    }

    /// <summary>
    /// Mögliche Geschlechter eines Kunden für die Dropdown-Auswahl.
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// Kein Geschlecht ausgewählt (Standardwert im Dropdown). Beim Speichern eines Kunden nicht zulässig.
        /// </summary>
        None,

        /// <summary>
        /// Geschlecht männlich.
        /// </summary>
        Mann,

        /// <summary>
        /// Geschlecht weiblich.
        /// </summary>
        Frau,

        /// <summary>
        /// Geschlecht divers (weder männlich noch weiblich).
        /// </summary>
        Divers
    }

    /// <summary>
    /// Mögliche akademische Titel eines Kunden für die Dropdown-Auswahl.
    /// </summary>
    public enum Title
    {
        /// <summary>
        /// Kein akademischer Titel vorhanden. Gültiger Standardwert.
        /// </summary>
        None,

        /// <summary>
        /// Titel "Professor".
        /// </summary>
        Professor,

        /// <summary>
        /// Titel "Doktor".
        /// </summary>
        Doktor
    }
}
