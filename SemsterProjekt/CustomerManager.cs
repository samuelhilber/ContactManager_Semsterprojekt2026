using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemsterProjekt
{
    internal class CustomerManager
    {
        private List<Customer> _customerList = new List<Customer>();

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
            Customer updatedCustomer = new Customer();
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


        public List<Customer> GetAll()
        {
            return _customerList;
        }

        public void ReplaceAll(List<Customer> customers)
        {
            _customerList.Clear();
            _customerList.AddRange(customers);
        }

        public List<Customer> GetAllActive()
        {
            return _customerList.Where(c => !c.IsDeleted).ToList();
        }

        
        
    }
}
