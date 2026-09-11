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
        public bool IsActive { get; set; } = true; // wird via Checkbox gesetzt und braucht dadurch keine Validierung
        public bool IsDeleted { get; set; } = false; // gleich wie IsActive

        public string FirstName
        {
            get => _firstName;
            set
            {
                string cleaned = Regex.Replace(value, @"[0-9]", "").Trim(); // sucht den string nach den value hier 0-9 und weil wir "" machen ersetzt es durch nichts also werden sämtliche Zahlen rausgefiltert
                if (string.IsNullOrWhiteSpace(cleaned)) // wie im Name wird zuerst geprüft ob es Null ist und dann vor und nach folgende Leerzeichen hat
                {
                    throw new ArgumentException("Vorname ist leer oder falsch");
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
                    throw new ArgumentException("Nachname ist leer oder falsch");
                }
                _lastName = cleaned;
            }
        }

        public DateOnly BirthDate
        {

            get => _birthDate;
            set
            {
                if (value > DateOnly.FromDateTime(DateTime.Today)) // niemand kann in der Zukunft geboren sein
                {
                    throw new ArgumentException("Geburtsdatum darf nicht in der Zukunft liegen");
                }
                _birthDate = value;
            }
        }

        public string MobilePhone // 079 123 45 67
        {
            get => _mobilePhone;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Mobiletelefonnummer darf nicht leer bleiben.");
                }

                _mobilePhone = FormatPhoneNumber(value, "Ungültige Mobiltelefonnummer (z.B. 079 123 45 67)");
            }
        }

        public string BusinessPhone // 044 123 45 67
        {
            get => _businessPhone;
            set
            {
                _businessPhone = FormatPhoneNumber(value, "Ungültige Firmentelefonnummer (z.B. 044 123 45 67)");
            }
        }

        // zählt nur die Ziffern statt der Stringlänge, dadurch sind "0791234567", "079 123 45 67", "+41 79 123 45 67" und "0041 79 123 45 67" alle gültig
        // gespeichert wird immer im einheitlichen Format "079 123 45 67"
        private static string FormatPhoneNumber(string value, string errorMessage)
        {
            string digits = Regex.Replace(value ?? string.Empty, @"\D", ""); // entfernt alles was keine Ziffer ist (Leerzeichen, +, Buchstaben usw.)

            if (digits.StartsWith("0041")) // 0041 79 ... -> 079 ...
            {
                digits = "0" + digits.Substring(4);
            }
            else if (digits.StartsWith("41") && digits.Length == 11) // +41 79 ... -> 079 ...
            {
                digits = "0" + digits.Substring(2);
            }

            if (digits.Length != 10) // eine Nummer ohne Vorwahl ins Ausland hat immer 10 Ziffern
            {
                throw new ArgumentException(errorMessage);
            }

            return $"{digits.Substring(0, 3)} {digits.Substring(3, 3)} {digits.Substring(6, 2)} {digits.Substring(8, 2)}";
        }

        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) // wichtig: auf leeren String prüfen, nicht nur auf null - sonst würde MailAddress unten mit einer eigenen, unpassenden Exception abbrechen
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
