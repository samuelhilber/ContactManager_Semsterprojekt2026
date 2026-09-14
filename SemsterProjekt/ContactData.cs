using System;
using System.Collections.Generic;
using System.Text;

namespace SemsterProjekt
{
    /// <summary>
    /// Fasst alle Mitarbeiter und Kunden zusammen, damit sie gemeinsam gespeichert und geladen werden können.
    /// </summary>
    /// <remarks>
    /// Wird von <see cref="DataStorage"/> als Ganzes in eine JSON-Datei geschrieben bzw. daraus gelesen.
    /// </remarks>
    internal class ContactData
    {
        /// <summary>
        /// Gibt die Liste aller Mitarbeiter zurück oder legt sie fest.
        /// </summary>
        /// <remarks>
        /// Enthält auch Mitarbeiter, die als gelöscht markiert sind (<see cref="Person.IsDeleted"/>).
        /// </remarks>
        public List<Employee> Employees {  get; set; } = new List<Employee>();

        /// <summary>
        /// Gibt die Liste aller Kunden zurück oder legt sie fest.
        /// </summary>
        /// <remarks>
        /// Enthält auch Kunden, die als gelöscht markiert sind (<see cref="Person.IsDeleted"/>).
        /// </remarks>
        public List<Customer> Customers { get; set; } = new List<Customer>();
    }
}
