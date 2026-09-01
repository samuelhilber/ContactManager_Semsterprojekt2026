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
            out List<string> errors)
        {
            Customer newCustomer = new Customer();
            errors = new List<string>();

            try { newCustomer.FirstName = firstName;  } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { newCustomer.LastName = lastName; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { newCustomer.BirthDate = birthDate; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { newCustomer.MobilePhone = mobilePhone; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { newCustomer.Email = email; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { newCustomer.BusinessPhone = buisnessPhone; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { newCustomer.Salutation = salutaion; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { newCustomer.Gender = gender; } catch (ArgumentException ex) { errors.Add(ex.Message); }
            try { newCustomer.Title = title; } catch (ArgumentException ex) { errors.Add(ex.Message); }

            if (errors.Count > 0)
            {
                return null;
            }

            _customerList.Add(newCustomer);
            return newCustomer;
        }

        public List <Customer> GetAll()
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
