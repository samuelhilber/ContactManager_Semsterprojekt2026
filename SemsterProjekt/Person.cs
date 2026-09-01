using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace SemsterProjekt
{
    internal class Person //ist die Father class wovon Employee und Customer die selben Daten erben
    {
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private DateOnly _birthDate;
        private string _mobilePhone = string.Empty;
        private string _businessPhone = string.Empty;
        private string _email = string.Empty;
        public bool IsActive { get; set; } = true; // wird via Checkbox gesetzt und braucht dadruch keine Validierung
        public bool IsDeleted { get; set; } = false; // gleich wie IsActive

        public string FirstName
        {
            get => _firstName;
            set
            {
                string cleaned = Regex.Replace(value, @"[0-9]", "").Trim(); // sucht den string nach den value hier 0-9 und weil wir "" machen ersetzt es durch nichts also werden sämtliche Zahlen rausgefiltert
                if (string.IsNullOrWhiteSpace(cleaned)) // wie im Name wird zuerst geprüft ob es Null ist und dann vor und nach folgende Leerzeichen hat
                {
                    throw new ArgumentException("Vorname ist leer oder flasch");
                }
                _firstName = cleaned;

            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                string cleaned = Regex.Replace(value, @"[0-9]", "").Trim(); // sucht den string nach den value hier 0-9 und weil wir "" machen ersetzt es durch nichts also werden sämtliche Zahlen rausgefiltert
                if (string.IsNullOrWhiteSpace(cleaned)) // wie im Name wird zuerst geprüft ob es Null ist und dann vor und nach folgende Leerzeichen hat
                {
                    throw new ArgumentException("Nachname ist leer oder flasch");
                }
                _lastName = cleaned;
            }
        }

        public DateOnly BirthDate
        {

            get => _birthDate;
            set
            {
                if (value > DateOnly.FromDateTime(DateTime.Today))
                {
                    throw new ArgumentException("Geburtsdarum darf nicht in der Zukunft liegen");
                }
                _birthDate = value;
            }
        }

        public string MobilePhone // 089 123 12 12
        {
            get => _mobilePhone;
            set
            {
                string cleanedOne = Regex.Replace(value, @"[a-zA-Z]", ""); // Entfernt Buchstaben
                string cleaned = Regex.Replace(cleanedOne, @"\s+", " ").Trim(); // ersetzt zuerst mehrere Leerzeichen und ersetzt diese druch ein leerzeichen und trim schneidet den start und das ende ab so ist eine Telefon Nummer nicht länger als 13

                if (string.IsNullOrWhiteSpace(cleaned))
                {
                    throw new ArgumentException("Mobiletelefonnummer darf nicht leer bleiben.");
                }

                if (cleaned.Length != 13)
                {
                    throw new ArgumentException("Ungültige Mobiltelefonnummer");
                }

                _mobilePhone = cleaned;
            }
        }

        public string BusinessPhone // 089 123 12 12
        {
            get => _businessPhone;
            set
            {
                string cleanedone = Regex.Replace(value, @"[a-zA-Z]", ""); // Entfernt Buchstaben
                string cleaned = Regex.Replace(cleanedone, @"\s+", " ").Trim(); // ersetzt zuerst mehrere Leerzeichen und ersetzt diese druch ein leerzeichen und trim schneidet den start und das ende ab so ist eine Telefon Nummer nicht länger als 13

                if (cleaned.Length != 13)
                {
                    throw new ArgumentException("Ungültige Firmentelefonnummer");
                }
                _businessPhone = cleaned;
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (value == null) // Basic check ob es leer bleibt
                {
                    throw new ArgumentException("Email darf nicht leer bleiben");
                }

                try // mit der Class MailAddress wird von c# die validierung übernommen mit diesem try catch wird sicher gestellt das überhaupt etwas eingegeben werden darf darum zuerst ein String und erst danach der vergleich
                {
                    var mail = new MailAddress(value);

                }
                catch (FormatException)
                {
                    throw new ArgumentException("Ungültiges E-Mail Format.");
                }

                _email = value;
            }
        }

        public override string ToString()
        {
            string text = "Vorname: " + FirstName + "\r\n";
            text += "Nachname: " + LastName + "\r\n";
            text += "Geburtsdatum: " + BirthDate + "\r\n";
            text += "Mobiltelefon: " + MobilePhone + "\r\n";
            text += "Telefon Geschäft: " + BusinessPhone + "\r\n";
            text += "Email: " + Email + "\r\n";
            text += "Aktiv: " + IsActive;
            return text;
        }
    }
}
