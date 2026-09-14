using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace SemsterProjekt
{
    /// <summary>
    /// Repräsentiert einen Mitarbeiter. Erbt die Personendaten von <see cref="Person"/> und
    /// ergänzt sie um Anstellungs-, Adress- und Lehrlingsdaten.
    /// </summary>
    internal class Employee : Person
    {

        private static int _nextEmployeeNumber = 1;

        /// <summary>
        /// Legt fest, welche Mitarbeiternummer als Nächstes vergeben wird.
        /// </summary>
        /// <remarks>
        /// Wird nur einmal beim Programmstart nach dem Laden der gespeicherten Daten aufgerufen,
        /// damit die Nummerierung nicht wieder bei 1 beginnt.
        /// </remarks>
        /// <param name="nextNumber">Die nächste zu vergebende Mitarbeiternummer.</param>
        public static void SetNextEmployeeNumber(int nextNumber)
        {
            _nextEmployeeNumber = nextNumber;
        }

        /// <summary>
        /// Vergibt die nächste Mitarbeiternummer und zählt den internen Zähler dabei um 1 hoch.
        /// </summary>
        /// <remarks>
        /// Wird erst nach erfolgreicher Validierung aufgerufen, damit fehlgeschlagene Erfassungen
        /// keine Nummer verbrauchen.
        /// </remarks>
        /// <returns>Die vergebene Mitarbeiternummer.</returns>
        public static int GetNextEmployeeNumber()
        {
            return _nextEmployeeNumber++;
        }

        private string _ahvNumber;
        private string _nationality;
        private int _employment;
        private DateOnly _entryDate;
        private DateOnly? _exitDate;
        private string _privateAddress;
        private int _privatePostalCode;
        private string _residence;
        private string _businessAddress;
        private int _businessPostalCode;

        /// <summary>
        /// Gibt die eindeutige Mitarbeiternummer zurück oder legt sie fest.
        /// </summary>
        /// <remarks>
        /// Wird nicht im Konstruktor, sondern erst in <see cref="EmployeeManager.AddEmployee"/> nach
        /// erfolgreicher Validierung über <see cref="GetNextEmployeeNumber"/> vergeben.
        /// </remarks>
        public int EmployeeNumber { get; set; }

        /// <summary>
        /// Gibt die Abteilung des Mitarbeiters zurück oder legt sie fest.
        /// </summary>
        /// <remarks>
        /// Wird über ein Dropdown mit den festen Werten aus <see cref="SemsterProjekt.Job"/> gesetzt
        /// und benötigt deshalb keine Validierung.
        /// </remarks>
        public Job Job { get; set; }

        /// <summary>
        /// Gibt die Kaderstufe des Mitarbeiters zurück oder legt sie fest.
        /// </summary>
        /// <remarks>
        /// Wird über ein Dropdown mit den festen Werten 0 bis 5 gesetzt und benötigt deshalb keine Validierung.
        /// </remarks>
        public int ManagementLevel { get; set; } = 0;

        /// <summary>
        /// Gibt an, ob der Mitarbeiter ein Lehrling (Auszubildender) ist, oder legt dies fest.
        /// </summary>
        /// <remarks>
        /// Wird über eine Checkbox gesetzt und benötigt deshalb keine Validierung.
        /// </remarks>
        public bool Trainee { get; set; } = false;

        /// <summary>
        /// Gibt die AHV-Nummer (Schweizer Sozialversicherungsnummer) zurück oder legt sie fest.
        /// </summary>
        /// <remarks>
        /// Erwartet wird das Format "756.XXXX.XXXX.XX". Leerzeichen zwischen den Blöcken werden beim
        /// Setzen durch Punkte ersetzt, z.B. wird "756 1234 5678 97" zu "756.1234.5678.97".
        /// </remarks>
        /// <exception cref="ArgumentException">
        /// Wird ausgelöst, wenn die AHV-Nummer leer ist oder nicht dem erwarteten Format entspricht.
        /// </exception>
        public string AhvNumber
        {
            get => _ahvNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("AHV Nummer muss ausgefüllt werden");
                }
                string preclean = Regex.Replace(value, @"\s+", "."); // formatiert die Inputs für den Format check.
                if (!Regex.IsMatch(preclean, @"^756\.\d{4}\.\d{4}\.\d{2}$")) // checked den Prefix 756, checket ob 2x 4 Ziffern und 1x 2 Ziffern verwendet werden alles getrennt von Punkten (das vor Formatierte AHV Format
                {
                    throw new ArgumentException("Die AHV Nummer ist nicht im Korrekten Format!");
                }
                _ahvNumber = preclean;
            }
        }

        /// <summary>
        /// Gibt die Nationalität zurück oder legt sie fest.
        /// </summary>
        /// <remarks>
        /// Beim Setzen werden Ziffern entfernt sowie Leerzeichen am Anfang und Ende abgeschnitten,
        /// da Nationalitäten keine Zahlen enthalten.
        /// </remarks>
        /// <exception cref="ArgumentException">
        /// Wird ausgelöst, wenn die Nationalität nach der Bereinigung leer ist.
        /// </exception>
        public string Nationality
        {
            get => _nationality;
            set
            {
                string cleaned = Regex.Replace(value, @"[1-9]", "").Trim(); // Es gibt keine Nummern in Länder Namen / Nationalitäten
                if (string.IsNullOrWhiteSpace(cleaned))
                {
                    throw new ArgumentException("Die Nationalität muss ausgefüllt werden");
                }
                _nationality = cleaned;
            }
        }

        /// <summary>
        /// Gibt den Anstellungsgrad in Prozent zurück oder legt ihn fest.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Wird ausgelöst, wenn der Wert nicht zwischen 1 und 100 liegt. Bei einem Anstellungsgrad
        /// von 0 % soll der Mitarbeiter stattdessen deaktiviert oder gelöscht werden.
        /// </exception>
        public int Employment
        {
            get => _employment;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Falls der Anstellungsgrad 0 ist, bitte den Mitarbetier deaktivieren oder löschen");
                }
                if (value > 100)
                {
                    throw new ArgumentException("Anstellungsgrad kann nicht über 100% sein");
                }
                _employment = value;
            }
        }

        /// <summary>
        /// Gibt das Eintrittsdatum zurück oder legt es fest.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Wird ausgelöst, wenn das Eintrittsdatum in der Zukunft liegt.
        /// </exception>
        public DateOnly EntryDate // übernommen von Geburstdatum in Person
        {
            get => _entryDate;
            set
            {
                if (value > DateOnly.FromDateTime(DateTime.Today))
                {
                    throw new ArgumentException("Eintritts Datum darf nicht in der Zukunft liegen");
                }
                _entryDate = value;
            }
        }

        /// <summary>
        /// Gibt das Austrittsdatum zurück oder legt es fest.
        /// </summary>
        /// <remarks>
        /// Darf <see langword="null"/> sein: Der Mitarbeiter ist dann noch angestellt und ein Austritt ist
        /// nicht bekannt. Bei Lehrlingen entspricht das Austrittsdatum dem letzten Tag der Lehre.
        /// </remarks>
        /// <exception cref="ArgumentException">
        /// Wird ausgelöst, wenn das Austrittsdatum vor dem <see cref="EntryDate"/> liegt.
        /// </exception>
        public DateOnly? ExitDate // übernommen von Geburtsdatum in Person
        {
            get => _exitDate;
            set
            {
                if (value == null)
                {
                    _exitDate = null;
                    return;
                }


                if (value.Value < EntryDate) // Austritt darf nicht vor dem Eintritt liegen
                {
                    throw new ArgumentException("Austrittsdatum darf nicht vor dem Eintrittsdatum liegen");
                }
                _exitDate = value;
            }
        }

        /// <summary>
        /// Gibt die Privatadresse (Strasse und Hausnummer) zurück oder legt sie fest.
        /// </summary>
        /// <remarks>
        /// Mehrere aufeinanderfolgende Leerzeichen werden beim Setzen zu einem zusammengefasst.
        /// </remarks>
        /// <exception cref="ArgumentException">
        /// Wird ausgelöst, wenn die Privatadresse leer ist.
        /// </exception>
        public string PrivateAddress
        {
            get => _privateAddress;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Die Privat Adresse muss ausgefüllt werden!");
                }
                string cleaned = Regex.Replace(value, @"\s+", " ");
                _privateAddress = cleaned;
            }
        }

        /// <summary>
        /// Gibt die Postleitzahl der Privatadresse zurück oder legt sie fest.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Wird ausgelöst, wenn keine gültige vierstellige Schweizer Postleitzahl (1000 bis 9999) angegeben wird.
        /// </exception>
        public int PrivatePostalCode
        {
            get => _privatePostalCode;
            set
            {
                try
                {
                    if (value > 9999) // Schweizer PLZ sind immer 4-stellig, also zwischen 1000 und 9999
                    {
                        throw new ArgumentException("Bitte geben sie eine gültige Schweizer Postleit Zahl ein.");
                    }
                    else if (value <= 999)
                    {
                        throw new ArgumentException("Bitte geben sie eine gültige Schweizer Postleit Zahl ein.");
                    }
                    _privatePostalCode = value;
                }
                catch (FormatException)
                {
                    throw new ArgumentException("Bitte geben sie eine gültige Schweizer Postleit Zahl ein.");
                }
            }
        }

        /// <summary>
        /// Gibt den Wohnort zurück oder legt ihn fest.
        /// </summary>
        /// <remarks>
        /// Leerzeichen am Anfang und Ende werden beim Setzen entfernt.
        /// </remarks>
        /// <exception cref="ArgumentException">
        /// Wird ausgelöst, wenn der Wohnort leer ist.
        /// </exception>
        public string Residence
        {
            get => _residence;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Der Wohnort muss ausgefüllt werden");
                }
                _residence = value.Trim();
            }
        }

        /// <summary>
        /// Gibt die Geschäftsadresse zurück oder legt sie fest.
        /// </summary>
        /// <remarks>
        /// Optionale Angabe: Ein leerer Wert wird als <see langword="null"/> gespeichert. Mehrere
        /// aufeinanderfolgende Leerzeichen werden zu einem zusammengefasst und Leerzeichen am Anfang
        /// und Ende entfernt.
        /// </remarks>
        public string BusinessAddress
        {
            get => _businessAddress;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _businessAddress = null;
                    return;
                }
                string cleaned = Regex.Replace(value, @"\s+", " ").Trim();
                _businessAddress = cleaned;
            }
        }

        /// <summary>
        /// Gibt die Postleitzahl der Geschäftsadresse zurück oder legt sie fest.
        /// </summary>
        /// <remarks>
        /// Optionale Angabe: Der Wert 0 bedeutet, dass keine Postleitzahl für die Geschäftsadresse angegeben ist.
        /// </remarks>
        /// <exception cref="ArgumentException">
        /// Wird ausgelöst, wenn ein Wert ungleich 0 keine gültige vierstellige Schweizer Postleitzahl
        /// (1000 bis 9999) ist.
        /// </exception>
        public int BusinessPostalCode
        {
            get => _businessPostalCode;
            set
            {
                if (value == 0) // 0 heisst: kein Firmensitz angegeben - im Gegensatz zur Privatadresse ist das hier optional
                {
                    _businessPostalCode = 0;
                    return;
                }
                try
                {
                    if (value > 9999) // Schweizer PLZ sind immer 4-stellig, also zwischen 1000 und 9999
                    {
                        throw new ArgumentException("Bitte geben sie eine gültige Schweizer Postleit Zahl ein.");
                    }
                    else if (value <= 999)
                    {
                        throw new ArgumentException("Bitte geben sie eine gültige Schweizer Postleit Zahl ein.");
                    }
                    _businessPostalCode = value;
                }
                catch (FormatException)
                {
                    throw new ArgumentException("Bitte geben sie eine gültige Schweizer Postleit Zahl ein.");
                }

            }

        }

        /// <summary>
        /// Berechnet die Dauer der Lehre in Lehrjahren, z.B. 3 oder 4.
        /// </summary>
        /// <remarks>
        /// Gerechnet wird vom <see cref="EntryDate"/> bis zum <see cref="ExitDate"/>, das bei Lehrlingen
        /// dem letzten Tag der Lehre entspricht.
        /// </remarks>
        /// <returns>Die Anzahl Lehrjahre.</returns>
        /// <exception cref="InvalidOperationException">
        /// Wird ausgelöst, wenn der Mitarbeiter kein Lehrling ist oder kein Austrittsdatum gesetzt ist.
        /// </exception>
        public int ApprenticeshipYears()
        {
            if (!Trainee)
            {
                throw new InvalidOperationException("Nur für Lehrlinge berechenbar.");
            }
            if (ExitDate == null)
            {
                throw new InvalidOperationException("Kein Austrittsdatum vorhanden");
            }
            return ApprenticeshipYearOn(ExitDate.Value); // das Lehrjahr am letzten Tag der Lehre entspricht der Anzahl Lehrjahre
        }

        /// <summary>
        /// Ermittelt, in welchem Lehrjahr sich der Lehrling heute befindet.
        /// </summary>
        /// <returns>
        /// Das aktuelle Lehrjahr (beginnend bei 1) oder <see langword="null"/>, wenn die Lehre bereits
        /// beendet ist, also das <see cref="ExitDate"/> in der Vergangenheit liegt.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Wird ausgelöst, wenn der Mitarbeiter kein Lehrling ist.
        /// </exception>
        public int? CurrentApprenticeshipYear()
        {
            if (!Trainee)
            {
                throw new InvalidOperationException("Nur für Lehrlinge berechenbar.");
            }

            DateOnly today = DateOnly.FromDateTime(DateTime.Today);

            if (ExitDate != null && today > ExitDate.Value)
            {
                return null;
            }
            return ApprenticeshipYearOn(today);
        }

        // berechnet in welchem Lehrjahr ein bestimmter Tag liegt. Gerechnet wird mit echten Kalenderjahren statt Tage / 365, sonst stimmt das Resultat wegen den Schaltjahren nicht
        private int ApprenticeshipYearOn(DateOnly date)
        {
            int fullYears = date.Year - EntryDate.Year;
            if (date < EntryDate.AddYears(fullYears)) // Jahrestag des Eintritts ist in diesem Jahr noch nicht erreicht
            {
                fullYears--;
            }
            return fullYears + 1; // +1 weil man im 1. Lehrjahr startet und nicht im 0.
        }

        /// <summary>
        /// Gibt eine mehrzeilige Textdarstellung des Mitarbeiters zurück, bestehend aus den
        /// Personendaten und den mitarbeiterspezifischen Angaben.
        /// </summary>
        /// <returns>Die Mitarbeiterdaten, eine Angabe pro Zeile.</returns>
        public override string ToString()
        {
            return base.ToString() + "\r\n" +
                   $"Mitarbeiternummer: {EmployeeNumber}\r\n" +
                   $"Job: {Job}\r\n" +
                   $"Abteilung/Kaderstufe: {ManagementLevel}\r\n" +
                   $"AHV Nummer: {AhvNumber}\r\n" +
                   $"Nationalität: {Nationality}\r\n" +
                   $"Anstellungsgrad: {Employment}\r\n" +
                   $"Eintrittsdatum: {EntryDate}\r\n" +
                   $"Austrittsdatum: {ExitDate}\r\n" +
                   $"Lehrling: {Trainee}\r\n" +
                   $"Privatadresse: {PrivateAddress}\r\n" +
                   $"PLZ Privat: {PrivatePostalCode}\r\n" +
                   $"Wohnort: {Residence}\r\n" +
                   $"Geschäftsadresse: {BusinessAddress}\r\n" +
                   $"PLZ Geschäft: {BusinessPostalCode}";
        }
    }

    /// <summary>
    /// Mögliche Abteilungen bzw. Anstellungen eines Mitarbeiters für die Dropdown-Auswahl.
    /// </summary>
    public enum Job
    {
        /// <summary>
        /// Abteilung Spedition (Versand und Logistik).
        /// </summary>
        Spedition,

        /// <summary>
        /// Abteilung Backoffice (Administration und Innendienst).
        /// </summary>
        Backoffice,

        /// <summary>
        /// Abteilung Marketing.
        /// </summary>
        Marketing,

        /// <summary>
        /// Abteilung IT (Informatik).
        /// </summary>
        It,

        /// <summary>
        /// Abteilung Fertigung (Produktion).
        /// </summary>
        Fertigung,

        /// <summary>
        /// Abteilung Aussendienst (Betreuung der Kunden vor Ort).
        /// </summary>
        Aussendienst
    }


}
