using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SemsterProjekt
{
    internal class Employee : Person // die Klasse welche die Mitarbeiter Erstellt, erbt von Person
    {
        private static int _nextEmployeeNumber = 1;

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

        public Employee() // mit dem Konstruktor wird jedesmal die Mitarbeiter nummer hochgezählt
        {
            EmployeeNumber = _nextEmployeeNumber++; // wenn ich das Programm neustarte geht dieser verloren auch wenn die anderen Daten gesichert sind muss ich noch irgendwie fixen warten auf Marin seine persistenz
        }

        public int EmployeeNumber { get; init; }  // nur bei der Erstellung setzbar
        public Job Job { get; set; } // via Dropdown Auswahl ist Fest und braucht keine Validierung, Greift auf Enums Job zu
        public int ManagementLevel { get; set; } = 0; // via Dropdown Auswahl ist und Fest braucht keine Validierung
        public bool Trainee { get; set; } = false; // via Checkbox True/False Bools benötigen dadruch keine Validierung

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

        public string Nationality
        {
            get => _nationality;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Die Nationalität muss ausgefüllt werden");
                }
                string cleaned = Regex.Replace(value, @"1-9", "").Trim(); // Es gibt keinne Nummern in Länder Namen / Nationalitäten
                _nationality = cleaned;
            }
        }

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

        public DateOnly? ExitDate // übernommen von Geburstdatum in Person + darf 0 sein Angstellte werden ja nicht 5 Jahre davor wissen wasn sie kündingen
        {
            get => _exitDate;
            set
            {
                if (value == null)
                {
                    _exitDate = null;
                    return;
                }

                if (value < DateOnly.FromDateTime(DateTime.Today)) //
                {
                    throw new ArgumentException("Austritts Datum darf nicht in der Verganenheit liegen");
                }
                _exitDate = value;
            }
        }

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

        public int PrivatePostalCode
        {
            get => _privatePostalCode;
            set
            {
                try
                {
                    if (value > 9999)
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

        public int BusinessPostalCode
        {
            get => _businessPostalCode;
            set
            {
                if (value == 0)
                {
                    return;
                }
                try
                {
                    if (value > 9999)
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

        public int ApprenticeshipYear() // berechnen von angezeigten Lehrjahre für die Lehrlinge
        {
            if (ExitDate == null)
            {
                throw new InvalidOperationException("Kein Austrissdatum vorhanden");
            }
            if (!Trainee)
            {
                throw new InvalidOperationException("Nur für Lehrlinge berechenbar.");

            }
            int tage = ExitDate.Value.DayNumber - EntryDate.DayNumber;
            int jahre = tage / 365;
            return jahre;
        }

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

    public enum Job //Enum für Dropdown Abteilung/Anstellung
    {
        Spedition,
        Backoffice,
        Marketing,
        It,
        Fertigung,
        Aussendienst
    }
}
