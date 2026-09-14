using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemsterProjekt
{
    /// <summary>
    /// Verwaltet die Mitarbeiter: Erfassen, Bearbeiten, Suchen und Bereitstellen der Mitarbeiterliste.
    /// </summary>
    internal class EmployeeManager
    {
        private List<Employee> _employeeList = new List<Employee>();

        /// <summary>
        /// Erstellt einen neuen Mitarbeiter, validiert alle Angaben und fügt ihn bei Erfolg der
        /// Mitarbeiterliste hinzu.
        /// </summary>
        /// <remarks>
        /// Es werden immer alle Felder geprüft, damit sämtliche Fehler auf einmal zurückgegeben und in der
        /// Oberfläche den betroffenen Eingabefeldern zugeordnet werden können. Die Mitarbeiternummer wird erst
        /// nach erfolgreicher Validierung vergeben, damit fehlgeschlagene Versuche keine Nummer verbrauchen.
        /// </remarks>
        /// <param name="firstName">Der Vorname des Mitarbeiters.</param>
        /// <param name="lastName">Der Nachname des Mitarbeiters.</param>
        /// <param name="birthDate">Das Geburtsdatum des Mitarbeiters.</param>
        /// <param name="mobilePhone">Die Mobiltelefonnummer des Mitarbeiters.</param>
        /// <param name="email">Die E-Mail-Adresse des Mitarbeiters.</param>
        /// <param name="businessPhone">Die geschäftliche Telefonnummer des Mitarbeiters.</param>
        /// <param name="job">Die Abteilung des Mitarbeiters.</param>
        /// <param name="managementLevel">Die Kaderstufe des Mitarbeiters (0 bis 5).</param>
        /// <param name="ahvNumber">Die AHV-Nummer im Format "756.XXXX.XXXX.XX".</param>
        /// <param name="employment">Der Anstellungsgrad in Prozent (1 bis 100).</param>
        /// <param name="entryDate">Das Eintrittsdatum.</param>
        /// <param name="exitDate">Das Austrittsdatum oder <see langword="null"/>, wenn der Mitarbeiter noch angestellt ist.</param>
        /// <param name="privateAddress">Die Privatadresse (Strasse und Hausnummer).</param>
        /// <param name="privatePostalCode">Die Postleitzahl der Privatadresse.</param>
        /// <param name="residence">Der Wohnort.</param>
        /// <param name="businessAddress">Die Geschäftsadresse (optional, darf leer sein).</param>
        /// <param name="businessPostalCode">Die Postleitzahl der Geschäftsadresse (optional, 0 = keine Angabe).</param>
        /// <param name="nationality">Die Nationalität.</param>
        /// <param name="trainee"><see langword="true"/>, wenn der Mitarbeiter ein Lehrling ist; andernfalls <see langword="false"/>.</param>
        /// <param name="errors">
        /// Gibt die Validierungsfehler zurück. Der Schlüssel ist der Name der betroffenen Eigenschaft
        /// (z.B. "AhvNumber"), der Wert die Fehlermeldung. Leer, wenn alle Angaben gültig sind.
        /// </param>
        /// <returns>
        /// Der neu erstellte Mitarbeiter oder <see langword="null"/>, wenn mindestens eine Angabe ungültig ist.
        /// </returns>
        public Employee? AddEmployee(
            string firstName,
            string lastName,
            DateOnly birthDate,
            string mobilePhone,
            string email,
            string businessPhone,
            Job job,
            int managementLevel,
            string ahvNumber,
            int employment,
            DateOnly entryDate,
            DateOnly? exitDate, // null = noch angestellt
            string privateAddress,
            int privatePostalCode,
            string residence,
            string businessAddress,
            int businessPostalCode,
            string nationality,
            bool trainee,
            out Dictionary<string, string> errors)
        {
            Employee newEmployee = new Employee();
            errors = new Dictionary<string, string>(); // war mal eine List, neu aber Dict damit die Fehler den Fehldern zugewiesen werden können. So kann man die Felder auch beleuchten. 

            try { newEmployee.FirstName = firstName; } catch (ArgumentException ex) { errors["FirstName"] = ex.Message; }
            try { newEmployee.LastName = lastName; } catch (ArgumentException ex) { errors["LastName"] = ex.Message; }
            try { newEmployee.BirthDate = birthDate; } catch (ArgumentException ex) { errors["BirthDate"] = ex.Message; }
            try { newEmployee.MobilePhone = mobilePhone; } catch (ArgumentException ex) { errors["MobilePhone"] = ex.Message; }
            try { newEmployee.Email = email; } catch (ArgumentException ex) { errors["Email"] = ex.Message; }
            try { newEmployee.BusinessPhone = businessPhone; } catch (ArgumentException ex) { errors["BusinessPhone"] = ex.Message; }
            try { newEmployee.Job = job; } catch (ArgumentException ex) { errors["Job"] = ex.Message; }
            try { newEmployee.ManagementLevel = managementLevel; } catch (ArgumentException ex) { errors["ManagementLevel"] = ex.Message; }
            try { newEmployee.AhvNumber = ahvNumber; } catch (ArgumentException ex) { errors["AhvNumber"] = ex.Message; }
            try { newEmployee.Employment = employment; } catch (ArgumentException ex) { errors["Employment"] = ex.Message; }
            try { newEmployee.EntryDate = entryDate; } catch (ArgumentException ex) { errors["EntryDate"] = ex.Message; }
            try { newEmployee.ExitDate = exitDate; } catch (ArgumentException ex) { errors["ExitDate"] = ex.Message; }
            try { newEmployee.PrivateAddress = privateAddress; } catch (ArgumentException ex) { errors["PrivateAddress"] = ex.Message; }
            try { newEmployee.PrivatePostalCode = privatePostalCode; } catch (ArgumentException ex) { errors["PrivatePostalCode"] = ex.Message; }
            try { newEmployee.Residence = residence; } catch (ArgumentException ex) { errors["Residence"] = ex.Message; }
            try { newEmployee.BusinessAddress = businessAddress; } catch (ArgumentException ex) { errors["BusinessAddress"] = ex.Message; }
            try { newEmployee.BusinessPostalCode = businessPostalCode; } catch (ArgumentException ex) { errors["BusinessPostalCode"] = ex.Message; }
            try { newEmployee.Nationality = nationality; } catch (ArgumentException ex) { errors["Nationality"] = ex.Message; }
            try { newEmployee.Trainee = trainee; } catch (ArgumentException ex) { errors["Trainee"] = ex.Message; }

            if (errors.Count > 0)
            {
                return null;
            }

            newEmployee.EmployeeNumber = Employee.GetNextEmployeeNumber(); // vor diesem Code wurde auch bei fallsinput die Zahl hochgezählt
            _employeeList.Add(newEmployee);
            return newEmployee;
        }

        /// <summary>
        /// Aktualisiert einen bestehenden Mitarbeiter mit den übergebenen Angaben.
        /// </summary>
        /// <remarks>
        /// Die bisherigen Werte werden vorher gesichert. Ist mindestens eine Angabe ungültig, werden alle
        /// Änderungen rückgängig gemacht, sodass der Mitarbeiter unverändert bleibt.
        /// Die Mitarbeiternummer wird nicht verändert.
        /// </remarks>
        /// <param name="employee">Der zu bearbeitende Mitarbeiter.</param>
        /// <param name="firstName">Der neue Vorname.</param>
        /// <param name="lastName">Der neue Nachname.</param>
        /// <param name="birthDate">Das neue Geburtsdatum.</param>
        /// <param name="mobilePhone">Die neue Mobiltelefonnummer.</param>
        /// <param name="email">Die neue E-Mail-Adresse.</param>
        /// <param name="businessPhone">Die neue geschäftliche Telefonnummer.</param>
        /// <param name="job">Die neue Abteilung.</param>
        /// <param name="managementLevel">Die neue Kaderstufe (0 bis 5).</param>
        /// <param name="ahvNumber">Die neue AHV-Nummer im Format "756.XXXX.XXXX.XX".</param>
        /// <param name="employment">Der neue Anstellungsgrad in Prozent (1 bis 100).</param>
        /// <param name="entryDate">Das neue Eintrittsdatum.</param>
        /// <param name="exitDate">Das neue Austrittsdatum oder <see langword="null"/>, wenn der Mitarbeiter noch angestellt ist.</param>
        /// <param name="privateAddress">Die neue Privatadresse (Strasse und Hausnummer).</param>
        /// <param name="privatePostalCode">Die neue Postleitzahl der Privatadresse.</param>
        /// <param name="residence">Der neue Wohnort.</param>
        /// <param name="businessAddress">Die neue Geschäftsadresse (optional, darf leer sein).</param>
        /// <param name="businessPostalCode">Die neue Postleitzahl der Geschäftsadresse (optional, 0 = keine Angabe).</param>
        /// <param name="nationality">Die neue Nationalität.</param>
        /// <param name="trainee"><see langword="true"/>, wenn der Mitarbeiter ein Lehrling ist; andernfalls <see langword="false"/>.</param>
        /// <param name="isActive"><see langword="true"/>, wenn der Mitarbeiter aktiv ist; andernfalls <see langword="false"/>.</param>
        /// <param name="errors">
        /// Gibt die Validierungsfehler zurück (Schlüssel = Name der Eigenschaft, Wert = Fehlermeldung).
        /// Leer, wenn alle Angaben gültig sind.
        /// </param>
        /// <returns>
        /// <see langword="true"/>, wenn der Mitarbeiter aktualisiert wurde; <see langword="false"/>, wenn
        /// mindestens eine Angabe ungültig ist.
        /// </returns>
        public bool UpdateEmployee(
            Employee employee,
            string firstName,
            string lastName,
            DateOnly birthDate,
            string mobilePhone,
            string email,
            string businessPhone,
            Job job,
            int managementLevel,
            string ahvNumber,
            int employment,
            DateOnly entryDate,
            DateOnly? exitDate,
            string privateAddress,
            int privatePostalCode,
            string residence,
            string businessAddress,
            int businessPostalCode,
            string nationality,
            bool trainee,
            bool isActive,
            out Dictionary<string, string> errors)
        {
            errors = new Dictionary<string, string>(); // same wie beim erstellen für Fehlerzuweisung wurde ein dict verwendet

            // Ursprüngliche Werte für den Fall eines Fehlers sichern
            string oldFirstName = employee.FirstName;
            string oldLastName = employee.LastName;
            DateOnly oldBirthDate = employee.BirthDate;
            string oldMobilePhone = employee.MobilePhone;
            string oldEmail = employee.Email;
            string oldBusinessPhone = employee.BusinessPhone;
            string oldAhvNumber = employee.AhvNumber;
            int oldEmployment = employee.Employment;
            DateOnly oldEntryDate = employee.EntryDate;
            DateOnly? oldExitDate = employee.ExitDate;
            string oldPrivateAddress = employee.PrivateAddress;
            int oldPrivatePostalCode = employee.PrivatePostalCode;
            string oldResidence = employee.Residence;
            string oldBusinessAddress = employee.BusinessAddress;
            int oldBusinessPostalCode = employee.BusinessPostalCode;
            string oldNationality = employee.Nationality;

            try
            {
                employee.FirstName = firstName;
            }
            catch (ArgumentException ex)
            {
                errors["FirstName"] = ex.Message;
            }

            try
            {
                employee.LastName = lastName;
            }
            catch (ArgumentException ex)
            {
                errors["LastName"] = ex.Message;
            }

            try
            {
                employee.BirthDate = birthDate;
            }
            catch (ArgumentException ex)
            {
                errors["BirthDate"] = ex.Message;
            }

            try
            {
                employee.MobilePhone = mobilePhone;
            }
            catch (ArgumentException ex)
            {
                errors["MobilePhone"] = ex.Message;
            }

            try
            {
                employee.Email = email;
            }
            catch (ArgumentException ex)
            {
                errors["Email"] = ex.Message;
            }

            try
            {
                employee.BusinessPhone = businessPhone;
            }
            catch (ArgumentException ex)
            {
                errors["BusinessPhone"] = ex.Message;
            }

            try
            {
                employee.AhvNumber = ahvNumber;
            }
            catch (ArgumentException ex)
            {
                errors["AhvNumber"] = ex.Message;
            }

            try
            {
                employee.Employment = employment;
            }
            catch (ArgumentException ex)
            {
                errors["Employment"] = ex.Message;
            }

            try
            {
                employee.EntryDate = entryDate;
            }
            catch (ArgumentException ex)
            {
                errors["EntryDate"] = ex.Message;
            }

            try
            {
                employee.ExitDate = exitDate;
            }
            catch (ArgumentException ex)
            {
                errors["ExitDate"] = ex.Message;
            }

            try
            {
                employee.PrivateAddress = privateAddress;
            }
            catch (ArgumentException ex)
            {
                errors["PrivateAddress"] = ex.Message;
            }

            try
            {
                employee.PrivatePostalCode = privatePostalCode;
            }
            catch (ArgumentException ex)
            {
                errors["PrivatePostalCode"] = ex.Message;
            }

            try
            {
                employee.Residence = residence;
            }
            catch (ArgumentException ex)
            {
                errors["Residence"] = ex.Message;
            }

            try
            {
                employee.BusinessAddress = businessAddress;
            }
            catch (ArgumentException ex)
            {
                errors["BusinessAddress"] = ex.Message;
            }

            try
            {
                employee.BusinessPostalCode = businessPostalCode;
            }
            catch (ArgumentException ex)
            {
                errors["BusinessPostalCode"] = ex.Message;
            }

            try
            {
                employee.Nationality = nationality;
            }
            catch (ArgumentException ex)
            {
                errors["Nationality"] = ex.Message;
            }

            if (errors.Count > 0)
            {
                // Bei einem Fehler alle Änderungen rückgängig machen
                employee.FirstName = oldFirstName;
                employee.LastName = oldLastName;
                employee.BirthDate = oldBirthDate;
                employee.MobilePhone = oldMobilePhone;
                employee.Email = oldEmail;
                employee.BusinessPhone = oldBusinessPhone;
                employee.AhvNumber = oldAhvNumber;
                employee.Employment = oldEmployment;
                employee.EntryDate = oldEntryDate;
                employee.ExitDate = oldExitDate;
                employee.PrivateAddress = oldPrivateAddress;
                employee.PrivatePostalCode = oldPrivatePostalCode;
                employee.Residence = oldResidence;
                employee.BusinessAddress = oldBusinessAddress;
                employee.BusinessPostalCode = oldBusinessPostalCode;
                employee.Nationality = oldNationality;

                return false;
            }

            // Diese Properties benötigen keine zusätzliche Validierung
            employee.Job = job;
            employee.ManagementLevel = managementLevel;
            employee.Trainee = trainee;
            employee.IsActive = isActive;

            return true;
        }

        /// <summary>
        /// Gibt alle Mitarbeiter zurück, auch die als gelöscht markierten.
        /// </summary>
        /// <remarks>
        /// Wird zum Speichern verwendet. Zurückgegeben wird die interne Liste, keine Kopie.
        /// </remarks>
        /// <returns>Die Liste aller Mitarbeiter.</returns>
        public List<Employee> GetAll()
        {
            return _employeeList;
        }

        /// <summary>
        /// Gibt alle Mitarbeiter zurück, die nicht als gelöscht markiert sind.
        /// </summary>
        /// <remarks>
        /// Inaktive Mitarbeiter (<see cref="Person.IsActive"/> ist <see langword="false"/>) sind ebenfalls enthalten.
        /// </remarks>
        /// <returns>Eine neue Liste mit allen nicht gelöschten Mitarbeitern.</returns>
        public List<Employee> GetAllActive()
        {
            return _employeeList.Where(m => !m.IsDeleted).ToList();
        }

        /// <summary>
        /// Durchsucht alle nicht gelöschten Mitarbeiter nach dem Suchtext aus dem Suchfeld.
        /// </summary>
        /// <remarks>
        /// Gesucht wird ohne Beachtung der Gross- und Kleinschreibung in Vorname, Nachname,
        /// vollständigem Namen, Mitarbeiternummer, E-Mail-Adresse und Mobiltelefonnummer.
        /// </remarks>
        /// <param name="searchText">Der Suchtext. Leerzeichen am Anfang und Ende werden ignoriert.</param>
        /// <returns>
        /// Die passenden Mitarbeiter oder alle nicht gelöschten Mitarbeiter, wenn der Suchtext leer ist.
        /// </returns>
        public List<Employee> Search(string searchText)
        {
            List<Employee> employees = GetAllActive();

            if (string.IsNullOrWhiteSpace(searchText)) //Falls Suchfeld leer
            {
                return employees;
            }

            string searchTerm = searchText.Trim();

            return employees
                .Where(employee =>
                    employee.FirstName.Contains(
                        searchTerm,
                        StringComparison.OrdinalIgnoreCase) || //OrdinalIgnoreCase ignoriert gross klein schreibung

                    employee.LastName.Contains(
                        searchTerm,
                        StringComparison.OrdinalIgnoreCase) ||

                    $"{employee.FirstName} {employee.LastName}".Contains(
                        searchTerm,
                        StringComparison.OrdinalIgnoreCase) ||

                    employee.EmployeeNumber
                        .ToString()
                        .Contains(searchTerm) ||

                    employee.Email.Contains(
                        searchTerm,
                        StringComparison.OrdinalIgnoreCase) ||

                    employee.MobilePhone.Contains(
                        searchTerm,
                        StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        /// <summary>
        /// Ersetzt alle vorhandenen Mitarbeiter durch die übergebenen Mitarbeiter, z.B. nach dem Laden
        /// aus der Datei.
        /// </summary>
        /// <param name="employees">Die Mitarbeiter, welche die bisherige Mitarbeiterliste ersetzen.</param>
        public void ReplaceAll(List<Employee> employees)
        {
            _employeeList.Clear(); //löscht 
            _employeeList.AddRange(employees);
        }
    }
}
