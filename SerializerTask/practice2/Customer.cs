using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice2
{
    internal class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }


        public static string path = Path.GetFullPath(Path.Combine("..", "..", "..", "Data", "customer.json"));

        public  void Add(Customer customer)
        {

            StreamReader sr = new StreamReader(path);

            string customers = sr.ReadToEnd();

            sr.Close();
            List<Customer> newCustomers = JsonConvert.DeserializeObject<List<Customer>>(customers);

            newCustomers.Add(customer);

            string result = JsonConvert.SerializeObject(newCustomers);

            StreamWriter sw = new(path);
            sw.WriteLine(result);
            sw.Close();


        }


        public  void Search(int id)
        {
            StreamReader sr = new StreamReader(path);

            string customers = sr.ReadToEnd();

            sr.Close();
            List<Customer> newCustomers = JsonConvert.DeserializeObject<List<Customer>>(customers);

            var found = newCustomers.Find(c => c.Id == id);
            Console.WriteLine(found.FirstName + " " + found.LastName);

        }

        public  void Update(int id, string firstName, string lastName, string newPhoneNumber)
        {

            StreamReader sr = new StreamReader(path);

            string customers = sr.ReadToEnd();

            sr.Close();
            List<Customer> newCustomers = JsonConvert.DeserializeObject<List<Customer>>(customers);

            var found = newCustomers.Find(c => c.Id == id);
            found.PhoneNumber = newPhoneNumber;
            found.FirstName = firstName;
            found.LastName = lastName;


            string result = JsonConvert.SerializeObject(newCustomers);

            StreamWriter sw = new(path);
            sw.WriteLine(result);
            sw.Close();



        }

        public  void Delete(int id)
        {

            StreamReader sr = new StreamReader(path);

            string customers = sr.ReadToEnd();

            sr.Close();
            List<Customer> newCustomers = JsonConvert.DeserializeObject<List<Customer>>(customers);

            var found = newCustomers.Find(c => c.Id == id);
            if (found != null)
            {
                newCustomers.Remove(found);

            }
            else
            {
                Console.WriteLine("bele customer yoxdur");
            }

            string result = JsonConvert.SerializeObject(newCustomers);

            StreamWriter sw = new(path);
            sw.WriteLine(result);
            sw.Close();

        }


        public  void GetAll()
        {

            StreamReader sr = new StreamReader(path);

            string customers = sr.ReadToEnd();

            sr.Close();




            List<Customer> newCustomers = JsonConvert.DeserializeObject<List<Customer>>(customers);

            newCustomers.ForEach(c => Console.WriteLine($"Id:{c.Id} Name:{c.FirstName} Surname: {c.LastName} PhoneNumber:{c.PhoneNumber}"));
        }


    }
}
