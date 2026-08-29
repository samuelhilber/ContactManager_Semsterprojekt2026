using System;
using System.Collections.Generic;
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

            if (errors.Count > 0)
            {
                return null;
            }

            _employeeList.Add(newEmployee);
            return newEmployee;
        }

        public List<Employee> GetAll()
        {
            return _employeeList;
        }
    }
}
