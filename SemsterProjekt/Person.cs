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
        private string _FirstName = string.Empty;
        private string _LastName = string.Empty;
        private DateOnly _BirthDate;
        private string _MobilePhone = string.Empty;
        private string _BusinessPhone = string.Empty;
        private string _Email = string.Empty;
        public bool IsActive { get; set; } = true; // wird via Checkbox gesetzt und braucht dadruch keine Validierung
        public bool IsDeleted { get; set; } = false; // gleich wie IsActive

        public string FirstName
        {
            get => _FirstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) // wie im Name wird zuerst geprüft ob es Null ist und dann vor und nach folgende Leerzeichen hat 
                {
                    throw new ArgumentException("Vorname darf nicht leer sein.");
                }
                string cleaned = Regex.Replace(value, @"[0-9]", ""); // sucht den string nach den value hier 0-9 und weil wir "" machen ersetzt es durch nichts also werden sämtliche Zahlen rausgefiltert
                _FirstName = cleaned.Trim();
            }
        }

        public string LastName
        {
            get => _LastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) // wie im Name wird zuerst geprüft ob es Null ist und dann vor und nach folgende Leerzeichen hat 
                {
                    throw new ArgumentException("Vorname darf nicht leer sein.");
                }
                string cleaned = Regex.Replace(value, @"[0-9]", ""); // sucht den string nach den value hier 0-9 und weil wir "" machen ersetzt es durch nichts also werden sämtliche Zahlen rausgefiltert 
                _LastName = cleaned.Trim();
            }
        }

        public DateOnly BirthDate
        {
            
            get => _BirthDate;
            set
            {
                if (value > DateOnly.FromDateTime(DateTime.Today))
                {
                    throw new ArgumentException("Geburtsdarum darf nicht in der Zukunft liegen");
                }
                _BirthDate = value;
            }
        }

        public string MobilePhone // 089 123 12 12
        {
            get => _MobilePhone;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) 
                {
                    throw new ArgumentException("Mobiletelefonnummer darf nicht leer bleiben.");
                }

                string cleanedone = Regex.Replace(value, @"A-Z", ""); // Entfernt Buchstaben          
                string cleaned = Regex.Replace(cleanedone, @"\s+", " ").Trim(); // ersetzt zuerst mehrere Leerzeichen und ersetzt diese druch ein leerzeichen und trim schneidet den start und das ende ab so ist eine Telefon Nummer nicht länger als 13
                

                if (cleaned.Length > 13 )
                {
                    throw new ArgumentException("Zu viele Ziffern verwendet");
                }
                _MobilePhone = cleaned;
            }
        }

        public string BusinessPhone // 089 123 12 12
        {
            get => _BusinessPhone;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) //da diese Angabe Optional ist wird geschaut ob ausversehen ein leerzeichen gesetzt wird, ist das der fall wird der String.Empty gesetzt dadruch kann der Rest übersprungen werden 
                {
                    _BusinessPhone = string.Empty;
                    return;
                }

                string cleanedone = Regex.Replace(value, @"a-zA-Z", ""); // Entfernt Buchstaben          
                string cleaned = Regex.Replace(cleanedone, @"\s+", " ").Trim(); // ersetzt zuerst mehrere Leerzeichen und ersetzt diese druch ein leerzeichen und trim schneidet den start und das ende ab so ist eine Telefon Nummer nicht länger als 13


                if (cleaned.Length > 13)
                {
                    throw new ArgumentException("Zu viele Ziffern verwendet");
                }
                _BusinessPhone = cleaned;
            }
        }

        public string Email
        {
            get => _Email;
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

                _Email = value;
            }
        }
    }
}
