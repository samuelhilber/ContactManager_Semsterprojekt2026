using System;
using System.Collections.Generic;
using System.Text;

namespace SemsterProjekt
{
    internal class ContactData // Klasse um Kunden und Mitarbeiter zu speichern
    {
        public List<Employee> Employees {  get; set; } = new List<Employee>(); //Property entält alle Mitarbeiter

        public List<Customer> Customers { get; set; } = new List<Customer>(); //Property entält alle Kunden
    }
}
