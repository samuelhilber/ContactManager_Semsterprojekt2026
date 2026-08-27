using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemsterProjekt
{
    internal class Employee : Person // die Klasse welche die Mitarbeiter Erstellt, erbt von Person
    {
        private static int _nextEmployeeNumber = 1;

        public int EmployeeNumber { get; init; }  // nur bei der Erstellung setzbar
        public Job Job { get; set; }
        public string AhvNumber { get; set; } = string.Empty;
        public int ManagmentLevel { get; set; } = 0;
        public string Nationality { get; set; } = string.Empty;
        public int Employment { get; set; } = 100;
        private DateOnly _EntryDate;
        private DateOnly? _ExitDate;
        public bool Trainee { get; set; } = false;
        public string Adressprivat { get; set; } = string.Empty;
        public int Plzprivat { get; set; }
        public string Residance { get; set; } = string.Empty;
        public string? Adressbuisness { get; set; } = string.Empty;
        public int? PlzBuisness { get; set; }

        public Employee() // mit dem Konstruktor wird jedesmal die Mitarbeiter nummer hochgezählt
        {
            EmployeeNumber = _nextEmployeeNumber++; // wenn ich das Programm neustarte geht dieser verloren auch wenn die anderen Daten gesichert sind muss ich noch irgendwie fixen warten auf Marin seine persistenz
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

