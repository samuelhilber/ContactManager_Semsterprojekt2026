using System;
using System.Collections.Generic;
using System.Text;

namespace SemsterProjekt
{
    internal class ContactData // Klasse um Kunden und Mitarbeiter zu speichern
    {
        public List<Employee> Employees {  get; set; } = new List<Employee>(); //Property enthält alle Mitarbeiter

        public List<Customer> Customers { get; set; } = new List<Customer>(); //Property enthält alle Kunden
    }
}
