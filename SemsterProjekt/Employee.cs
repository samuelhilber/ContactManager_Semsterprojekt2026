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

        public int EmployeeNumber { get; init; }  // nur bei der Erstellung setzbar
        public Job Job { get; set; } // via Dropdown Auswahl ist Fest und braucht keine Validierung, Greift auf Enums Job zu
        public string _AhvNumber;
        public int ManagmentLevel { get; set; } = 0; // via Dropdown Auswahl ist und Fest braucht keine Validierung
        private string _Nationality;
        private int _Employment;
        private DateOnly _EntryDate;
        private DateOnly? _ExitDate;
        public bool Trainee { get; set; } = false; // via Checkbox True/False Bools benötigen dadruch keine Validierung
        public string Adressprivat { get; set; } = string.Empty;
        public int Plzprivat { get; set; }
        public string Residance { get; set; } = string.Empty;
        public string? Adressbuisness { get; set; } = string.Empty;
        public int? PlzBuisness { get; set; }

        public Employee() // mit dem Konstruktor wird jedesmal die Mitarbeiter nummer hochgezählt
        {
            EmployeeNumber = _nextEmployeeNumber++; // wenn ich das Programm neustarte geht dieser verloren auch wenn die anderen Daten gesichert sind muss ich noch irgendwie fixen warten auf Marin seine persistenz
        }

        public string AhvNumber
        {
            get => _AhvNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("AHV Nummer muss ausgefüllt werden");
                }
                string preclean = Regex.Replace(value, @"\s+", "."); // formatiert die Inputs für den Format check.
                if (Regex.IsMatch(preclean, @"^756\.\d{4}\.\d{4}\.\d{2}$")) // checked den Prefix 756, checket ob 2x 4 Ziffern und 1x 2 Ziffern verwendet werden alles getrennt von Punkten (das vor Formatierte AHV Format
                throw new ArgumentException("Die AHV Nummer sit nicht im Korrekten Format!");
                 
            }
        }
        public string Nationality
        {
            get => _Nationality;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Die Nationalität muss ausgefüllt werden");
                }
                string cleaned = Regex.Replace(value, @"1-9", ""); // Es gibt keinne Nummern in Länder Namen / Nationalitäten
                _Nationality = cleaned;
            }
        }

        public int Employment
        {
            get => _Employment;
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
                
            }
        }

        public DateOnly EntryDate // übernommen von Geburstdatum in Person
        {

            get => _EntryDate;
            set
            {
                if (value > DateOnly.FromDateTime(DateTime.Today))
                {
                    throw new ArgumentException("Eintritts Datum darf nicht in der Zukunft liegen");
                }
                _EntryDate = value;
            }
        }

        public DateOnly? ExitDate // übernommen von Geburstdatum in Person + darf 0 sein Angstellte werden ja nicht 5 Jahre davor wissen wasn sie kündingen
        {

            get => _ExitDate;
            set
            {
                if (value == null)
                {
                    _ExitDate = null;
                    return;
                }

                if (value < DateOnly.FromDateTime(DateTime.Today)) // 
                {
                    throw new ArgumentException("Austritts Datum darf nicht in der Verganenheit liegen");
                }
                _ExitDate = value;
            }
        }



        public double LehrJahr() // berechnen von angezeigten Lehrjahre für die Lehrlinge
        {
            if (ExitDate == null)
            {
                throw new InvalidOperationException("Kein Austrissdatum vorhanden");
            }
            if (!Trainee)
            {
                throw new InvalidOperationException("Nur für Lehrlinge berechenbar.");

            }
            double tage = ExitDate.Value.DayNumber - EntryDate.DayNumber;
            double jahre = tage / 365;
            return Math.Floor(jahre);
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

