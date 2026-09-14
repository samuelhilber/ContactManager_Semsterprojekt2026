using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemsterProjekt
{
    /// <summary>
    /// Verwaltet die Kunden: Erfassen, Bearbeiten, Suchen und Bereitstellen der Kundenliste.
    /// </summary>
    internal class CustomerManager
    {
        private List<Customer> _customerList = new List<Customer>();

        /// <summary>
        /// Erstellt einen neuen Kunden, validiert alle Angaben und fügt ihn bei Erfolg der Kundenliste hinzu.
        /// </summary>
        /// <remarks>
        /// Es werden immer alle Felder geprüft, damit sämtliche Fehler auf einmal zurückgegeben und in der
        /// Oberfläche den betroffenen Eingabefeldern zugeordnet werden können.
        /// </remarks>
        /// <param name="firstName">Der Vorname des Kunden.</param>
        /// <param name="lastName">Der Nachname des Kunden.</param>
        /// <param name="birthDate">Das Geburtsdatum des Kunden.</param>
        /// <param name="mobilePhone">Die Mobiltelefonnummer des Kunden.</param>
        /// <param name="email">Die E-Mail-Adresse des Kunden.</param>
        /// <param name="buisnessPhone">Die geschäftliche Telefonnummer des Kunden.</param>
        /// <param name="salutaion">Die Anrede des Kunden.</param>
        /// <param name="gender">Das Geschlecht des Kunden.</param>
        /// <param name="title">Der akademische Titel des Kunden.</param>
        /// <param name="errors">
        /// Gibt die Validierungsfehler zurück. Der Schlüssel ist der Name der betroffenen Eigenschaft
        /// (z.B. "FirstName"), der Wert die Fehlermeldung. Leer, wenn alle Angaben gültig sind.
        /// </param>
        /// <returns>
        /// Der neu erstellte Kunde oder <see langword="null"/>, wenn mindestens eine Angabe ungültig ist.
        /// </returns>
        public Customer? AddCustomer(
            string firstName,
            string lastName,
            DateOnly birthDate,
            string mobilePhone,
            string email,
            string buisnessPhone,
            Salutation salutaion,
            Gender gender,
            Title title,
            out Dictionary<string, string> errors)
        {
            Customer newCustomer = new Customer();
            errors = new Dictionary<string, string>(); // same wie in Employee

            try { newCustomer.FirstName = firstName; } catch (ArgumentException ex) { errors["FirstName"] = ex.Message; }
            try { newCustomer.LastName = lastName; } catch (ArgumentException ex) { errors["LastName"] = ex.Message; }
            try { newCustomer.BirthDate = birthDate; } catch (ArgumentException ex) { errors["BirthDate"] = ex.Message; }
            try { newCustomer.MobilePhone = mobilePhone; } catch (ArgumentException ex) { errors["MobilePhone"] = ex.Message; }
            try { newCustomer.Email = email; } catch (ArgumentException ex) { errors["Email"] = ex.Message; }
            try { newCustomer.BusinessPhone = buisnessPhone; } catch (ArgumentException ex) { errors["BusinessPhone"] = ex.Message; }
            try { newCustomer.Salutation = salutaion; } catch (ArgumentException ex) { errors["Salutation"] = ex.Message; }
            try { newCustomer.Gender = gender; } catch (ArgumentException ex) { errors["Gender"] = ex.Message; }
            try { newCustomer.Title = title; } catch (ArgumentException ex) { errors["Title"] = ex.Message; }

            if (errors.Count > 0)
            {
                return null;
            }

            _customerList.Add(newCustomer);
            return newCustomer;
        }

        /// <summary>
        /// Aktualisiert einen bestehenden Kunden mit den übergebenen Angaben.
        /// </summary>
        /// <remarks>
        /// Die neuen Werte werden zuerst auf einer Kopie validiert. Nur wenn alle Angaben gültig sind,
        /// werden sie auf den bestehenden Kunden übertragen. Bei einem Fehler bleibt der Kunde unverändert.
        /// </remarks>
        /// <param name="customer">Der zu bearbeitende Kunde.</param>
        /// <param name="firstName">Der neue Vorname.</param>
        /// <param name="lastName">Der neue Nachname.</param>
        /// <param name="birthDate">Das neue Geburtsdatum.</param>
        /// <param name="mobilePhone">Die neue Mobiltelefonnummer.</param>
        /// <param name="email">Die neue E-Mail-Adresse.</param>
        /// <param name="businessPhone">Die neue geschäftliche Telefonnummer.</param>
        /// <param name="salutation">Die neue Anrede.</param>
        /// <param name="gender">Das neue Geschlecht.</param>
        /// <param name="title">Der neue akademische Titel.</param>
        /// <param name="isActive"><see langword="true"/>, wenn der Kunde aktiv ist; andernfalls <see langword="false"/>.</param>
        /// <param name="errors">
        /// Gibt die Validierungsfehler zurück (Schlüssel = Name der Eigenschaft, Wert = Fehlermeldung).
        /// Leer, wenn alle Angaben gültig sind.
        /// </param>
        /// <returns>
        /// <see langword="true"/>, wenn der Kunde aktualisiert wurde; <see langword="false"/>, wenn mindestens
        /// eine Angabe ungültig ist.
        /// </returns>
        public bool UpdateCustomer(
            Customer customer,
            string firstName,
            string lastName,
            DateOnly birthDate,
            string mobilePhone,
            string email,
            string businessPhone,
            Salutation salutation,
            Gender gender,
            Title title,
            bool isActive,
            out Dictionary<string, string> errors)
        {
            Customer updatedCustomer = new Customer(); // Änderungen werden zuerst auf dieser Kopie geprüft, damit der echte Kunde bei einem Fehler unverändert bleibt
            errors = new Dictionary<string, string>();

            try
            {
                updatedCustomer.FirstName = firstName;
            }
            catch (ArgumentException ex)
            {
                errors["FirstName"] = ex.Message;
            }
            try
            {
                updatedCustomer.LastName = lastName;
            }
            catch (ArgumentException ex)
            {
                errors["LastName"] = ex.Message;
            }
            try
            {
                updatedCustomer.BirthDate = birthDate;
            }
            catch (ArgumentException ex)
            {
                errors["BirthDate"] = ex.Message;
            }
            try
            {
                updatedCustomer.MobilePhone = mobilePhone;
            }
            catch (ArgumentException ex)
            {
                errors["MobilePhone"] = ex.Message;
            }
            try
            {
                updatedCustomer.Email = email;
            }
            catch (ArgumentException ex)
            {
                errors["Email"] = ex.Message;
            }
            try
            {
                updatedCustomer.BusinessPhone = businessPhone;
            }
            catch (ArgumentException ex)
            {
                errors["BusinessPhone"] = ex.Message;
            }
            try
            {
                updatedCustomer.Salutation = salutation;
            }
            catch (ArgumentException ex)
            {
                errors["Salutation"] = ex.Message;
            }

            try
            {
                updatedCustomer.Gender = gender;
            }
            catch (ArgumentException ex)
            {
                errors["Gender"] = ex.Message;
            }

            updatedCustomer.Title = title;
            updatedCustomer.IsActive = isActive;

            if (errors.Count > 0)
            {
                return false;
            }

            customer.FirstName = updatedCustomer.FirstName;
            customer.LastName = updatedCustomer.LastName;
            customer.BirthDate = updatedCustomer.BirthDate;
            customer.MobilePhone = updatedCustomer.MobilePhone;
            customer.Email = updatedCustomer.Email;
            customer.BusinessPhone = updatedCustomer.BusinessPhone;
            customer.Salutation = updatedCustomer.Salutation;
            customer.Gender = updatedCustomer.Gender;
            customer.Title = updatedCustomer.Title;
            customer.IsActive = updatedCustomer.IsActive;

            return true;
        }


        /// <summary>
        /// Gibt alle Kunden zurück, auch die als gelöscht markierten.
        /// </summary>
        /// <remarks>
        /// Wird zum Speichern verwendet. Zurückgegeben wird die interne Liste, keine Kopie.
        /// </remarks>
        /// <returns>Die Liste aller Kunden.</returns>
        public List<Customer> GetAll()
        {
            return _customerList;
        }

        /// <summary>
        /// Ersetzt alle vorhandenen Kunden durch die übergebenen Kunden, z.B. nach dem Laden aus der Datei.
        /// </summary>
        /// <param name="customers">Die Kunden, welche die bisherige Kundenliste ersetzen.</param>
        public void ReplaceAll(List<Customer> customers)
        {
            _customerList.Clear();
            _customerList.AddRange(customers);
        }

        /// <summary>
        /// Gibt alle Kunden zurück, die nicht als gelöscht markiert sind.
        /// </summary>
        /// <remarks>
        /// Inaktive Kunden (<see cref="Person.IsActive"/> ist <see langword="false"/>) sind ebenfalls enthalten.
        /// </remarks>
        /// <returns>Eine neue Liste mit allen nicht gelöschten Kunden.</returns>
        public List<Customer> GetAllActive()
        {
            return _customerList.Where(c => !c.IsDeleted).ToList();
        }

        /// <summary>
        /// Durchsucht alle nicht gelöschten Kunden nach dem Suchtext aus dem Suchfeld.
        /// </summary>
        /// <remarks>
        /// Gesucht wird ohne Beachtung der Gross- und Kleinschreibung in Vorname, Nachname,
        /// vollständigem Namen, E-Mail-Adresse und Mobiltelefonnummer.
        /// </remarks>
        /// <param name="searchText">Der Suchtext. Leerzeichen am Anfang und Ende werden ignoriert.</param>
        /// <returns>
        /// Die passenden Kunden oder alle nicht gelöschten Kunden, wenn der Suchtext leer ist.
        /// </returns>
        public List<Customer> Search(string searchText)
        {
            List<Customer> customers = GetAllActive();

            if (string.IsNullOrWhiteSpace(searchText)) //Falls nichts im Suchfeld
            {
                return customers;
            }

            string searchTerm = searchText.Trim();

            return customers
                .Where(customer =>
                    customer.FirstName.Contains(
                        searchTerm,
                        StringComparison.OrdinalIgnoreCase) ||

                    customer.LastName.Contains(
                        searchTerm,
                        StringComparison.OrdinalIgnoreCase) ||

                    $"{customer.FirstName} {customer.LastName}".Contains(
                        searchTerm,
                        StringComparison.OrdinalIgnoreCase) ||

                    customer.Email.Contains(
                        searchTerm,
                        StringComparison.OrdinalIgnoreCase) ||

                    customer.MobilePhone.Contains(
                        searchTerm,
                        StringComparison.OrdinalIgnoreCase))
                .ToList();
        }



    }
}
