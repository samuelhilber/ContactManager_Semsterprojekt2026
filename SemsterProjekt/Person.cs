using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace SemsterProjekt
{
    /// <summary>
    /// Repräsentiert eine Person im System. Dient als Basisklasse, von der
    /// <see cref="Employee"/> und <see cref="Customer"/> die gemeinsamen Personendaten erben.
    /// </summary>
    /// <remarks>
    /// Name, Geburtsdatum, Telefonnummern und E-Mail-Adresse werden beim Setzen geprüft.
    /// Ungültige Werte werden mit einer <see cref="ArgumentException"/> abgelehnt, deren Meldung
    /// direkt in der Oberfläche angezeigt werden kann.
    /// </remarks>
    internal class Person
    {
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private DateOnly _birthDate;
        private string _mobilePhone = string.Empty;
        private string _businessPhone = string.Empty;
        private string _email = string.Empty;

        /// <summary>
        /// Gibt an, ob die Person aktiv ist, oder legt dies fest.
        /// </summary>
        /// <remarks>
        /// Wird über eine Checkbox gesetzt und benötigt deshalb keine Validierung.
        /// Standardwert ist <see langword="true"/>.
        /// </remarks>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Gibt an, ob die Person als gelöscht markiert ist, oder legt dies fest.
        /// </summary>
        /// <remarks>
        /// Gelöschte Personen werden nicht aus der Datei entfernt, sondern nur markiert und in
        /// Listen und Suchergebnissen ausgeblendet. Benötigt wie <see cref="IsActive"/> keine Validierung.
        /// </remarks>
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// Gibt den Vornamen zurück oder legt ihn fest.
        /// </summary>
        /// <remarks>
        /// Beim Setzen werden alle Ziffern entfernt sowie Leerzeichen am Anfang und Ende abgeschnitten.
        /// </remarks>
        /// <exception cref="ArgumentException">
        /// Wird ausgelöst, wenn der Vorname nach der Bereinigung leer ist.
        /// </exception>
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

        /// <summary>
        /// Gibt den Nachnamen zurück oder legt ihn fest.
        /// </summary>
        /// <remarks>
        /// Beim Setzen werden alle Ziffern entfernt sowie Leerzeichen am Anfang und Ende abgeschnitten.
        /// </remarks>
        /// <exception cref="ArgumentException">
        /// Wird ausgelöst, wenn der Nachname nach der Bereinigung leer ist.
        /// </exception>
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

        /// <summary>
        /// Gibt das Geburtsdatum zurück oder legt es fest.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Wird ausgelöst, wenn das Geburtsdatum in der Zukunft liegt.
        /// </exception>
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

        /// <summary>
        /// Gibt die Mobiltelefonnummer zurück oder legt sie fest.
        /// </summary>
        /// <remarks>
        /// Pflichtfeld. Akzeptiert werden verschiedene Schreibweisen, z.B. "0791234567",
        /// "+41 79 123 45 67" oder "0041 79 123 45 67". Gespeichert wird immer im
        /// einheitlichen Format "079 123 45 67".
        /// </remarks>
        /// <exception cref="ArgumentException">
        /// Wird ausgelöst, wenn die Nummer leer ist oder ohne Ländervorwahl nicht genau 10 Ziffern hat.
        /// </exception>
        public string MobilePhone
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

        /// <summary>
        /// Gibt die geschäftliche Telefonnummer zurück oder legt sie fest.
        /// </summary>
        /// <remarks>
        /// Es gelten dieselben Schreibweisen wie bei <see cref="MobilePhone"/>. Gespeichert wird
        /// immer im einheitlichen Format "044 123 45 67".
        /// </remarks>
        /// <exception cref="ArgumentException">
        /// Wird ausgelöst, wenn die Nummer ohne Ländervorwahl nicht genau 10 Ziffern hat.
        /// Eine leere Eingabe wird ebenfalls abgelehnt.
        /// </exception>
        public string BusinessPhone
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

        /// <summary>
        /// Gibt die E-Mail-Adresse zurück oder legt sie fest.
        /// </summary>
        /// <remarks>
        /// Pflichtfeld. Das Format wird mit der Klasse <see cref="MailAddress"/> geprüft.
        /// </remarks>
        /// <exception cref="ArgumentException">
        /// Wird ausgelöst, wenn die E-Mail-Adresse leer ist oder kein gültiges Format hat.
        /// </exception>
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

        /// <summary>
        /// Gibt eine mehrzeilige Textdarstellung der Person mit allen Personendaten zurück.
        /// </summary>
        /// <returns>Die Personendaten, eine Angabe pro Zeile.</returns>
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
