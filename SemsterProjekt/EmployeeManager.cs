using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemsterProjekt
{
    internal class EmployeeManager
    {
        private List<Employee> _employeeList = new List<Employee>();

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
            DateOnly exitDate,
            string privateAddress,
            int privatePostalCode,
            string residence,
            string businessAddress,
            int businessPostalCode,
            string nationality,
            bool trainee,
            out List<string> errors)
        {
            Employee newEmployee = new Employee();
            errors = new List<string>();

            try { newEmployee.FirstName = firstName; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { newEmployee.LastName = lastName; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { newEmployee.BirthDate = birthDate; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { newEmployee.MobilePhone = mobilePhone; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { newEmployee.Email = email; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { newEmployee.BusinessPhone = businessPhone; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { newEmployee.Job = job; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { newEmployee.ManagementLevel = managementLevel; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { newEmployee.AhvNumber = ahvNumber; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { newEmployee.Employment = employment; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { newEmployee.EntryDate = entryDate; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { newEmployee.ExitDate = exitDate; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { newEmployee.PrivateAddress = privateAddress; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { newEmployee.PrivatePostalCode = privatePostalCode; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { newEmployee.Residence = residence; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { newEmployee.BusinessAddress = businessAddress; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { newEmployee.BusinessPostalCode = businessPostalCode; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { newEmployee.Nationality = nationality; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { newEmployee.Trainee = trainee; } catch (ArgumentException ex) { errors.Add(ex.Message); }

            if (errors.Count > 0)
            {
                return null;
            }

            _employeeList.Add(newEmployee);
            return newEmployee;
        }

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
            out List<string> errors)
        {
            errors = new List<string>();

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
                errors.Add(ex.Message);
            }

            try
            {
                employee.LastName = lastName;
            }
            catch (ArgumentException ex)
            {
                errors.Add(ex.Message);
            }

            try
            {
                employee.BirthDate = birthDate;
            }
            catch (ArgumentException ex)
            {
                errors.Add(ex.Message);
            }

            try
            {
                employee.MobilePhone = mobilePhone;
            }
            catch (ArgumentException ex)
            {
                errors.Add(ex.Message);
            }

            try
            {
                employee.Email = email;
            }
            catch (ArgumentException ex)
            {
                errors.Add(ex.Message);
            }

            try
            {
                employee.BusinessPhone = businessPhone;
            }
            catch (ArgumentException ex)
            {
                errors.Add(ex.Message);
            }

            try
            {
                employee.AhvNumber = ahvNumber;
            }
            catch (ArgumentException ex)
            {
                errors.Add(ex.Message);
            }

            try
            {
                employee.Employment = employment;
            }
            catch (ArgumentException ex)
            {
                errors.Add(ex.Message);
            }

            try
            {
                employee.EntryDate = entryDate;
            }
            catch (ArgumentException ex)
            {
                errors.Add(ex.Message);
            }

            try
            {
                employee.ExitDate = exitDate;
            }
            catch (ArgumentException ex)
            {
                errors.Add(ex.Message);
            }

            try
            {
                employee.PrivateAddress = privateAddress;
            }
            catch (ArgumentException ex)
            {
                errors.Add(ex.Message);
            }

            try
            {
                employee.PrivatePostalCode = privatePostalCode;
            }
            catch (ArgumentException ex)
            {
                errors.Add(ex.Message);
            }

            try
            {
                employee.Residence = residence;
            }
            catch (ArgumentException ex)
            {
                errors.Add(ex.Message);
            }

            try
            {
                employee.BusinessAddress = businessAddress;
            }
            catch (ArgumentException ex)
            {
                errors.Add(ex.Message);
            }

            try
            {
                employee.BusinessPostalCode = businessPostalCode;
            }
            catch (ArgumentException ex)
            {
                errors.Add(ex.Message);
            }

            try
            {
                employee.Nationality = nationality;
            }
            catch (ArgumentException ex)
            {
                errors.Add(ex.Message);
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

        public List<Employee> GetAll()
        {
            return _employeeList;
        }

        public List<Employee> GetAllActive()
        {
            return _employeeList.Where(m => !m.IsDeleted).ToList();
        }

        public void ReplaceAll(List<Employee> employees)
        {
            _employeeList.Clear(); //löscht 
            _employeeList.AddRange(employees);
        }
    }
}
