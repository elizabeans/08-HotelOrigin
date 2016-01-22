using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelOrigin.Core.Domain;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.IO;

namespace HotelOrigin.Core.Repository
{
    public class CustomerRepository
    {
        private static ObservableCollection<Customer> customers = new ObservableCollection<Customer>();

        // Create 
        public static Customer Create()
        {
            Customer customer = new Customer();

            customers.Add(customer);

            return customer;
        }

        public static void Add(Customer customer)
        {
            customers.Add(customer);
        }

        public static Guid CreateGuid()
        {
            return Guid.NewGuid();
        }

        // Read
        public static Customer GetById(Guid id)
        {
            return customers.FirstOrDefault(c => c.Id == id); //same as below but shorter

            /*Customer foundCustomer = null;
            for(int i = 0; i < customers.Count; i++)
            {
                if(customers.ElementAt(i).Id == id)
                {
                    foundCustomer = customers.ElementAt(i);
                }
            }
            return foundCustomer;*/
        }

        public static ObservableCollection<Customer> GetAll() //to return all customers for grid
        {
            return customers; // returns whole customers list
        }
        
        // Update
        public static void Update(Customer customer, string firstName, string lastName, string telephone, string emailAddress)
        {
            customer.FirstName = firstName;
            customer.LastName = lastName;
            customer.TelephoneNumber = telephone;
            customer.EmailAddress = emailAddress;
        }

        
        // Delete
        public static void Delete(Guid id)
        {
            var customer = GetById(id);

            customers.Remove(customer);
        }

        public static void Delete(Customer customer)
        {
            customers.Remove(customer);
        }

        // Save/Load to Disk
        public static void SaveToDisk()
        {
            string json = JsonConvert.SerializeObject(customers);                                   // serializes the objects
            File.WriteAllText("customers.json", json);                                              // writes it to customers.json file
        }

        public static void LoadFromDisk()
        {
            if (File.Exists("customers.json"))
            {
                string json = File.ReadAllText("customers.json");                                   // reads from customers.json
                customers = JsonConvert.DeserializeObject<ObservableCollection<Customer>>(json);    // deserializes the objects and puts it into the observablecollection
            }
        }
    }
}
