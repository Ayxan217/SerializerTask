using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace practice2
{
    internal class Program
    {

        //public static string Path = @"C:\Users\pc\source\repos\practice2\practice2\practice2.csproj";
        public  static string path = Path.GetFullPath(Path.Combine("..", "..", "..", "Data", "customer.json"));
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer{Id = 1,FirstName = "Nurane", LastName = "Veliyeva",PhoneNumber = "042395043"},
                 new Customer{Id = 2,FirstName = "eli", LastName = "Veliyeva",PhoneNumber = "042395043"},
                  new Customer{Id = 3,FirstName = "huseyn", LastName = "Veliyeva",PhoneNumber = "042395043"},
                   new Customer{Id = 4,FirstName = "david", LastName = "Veliyeva",PhoneNumber = "042395043"},
                    new Customer{Id = 5,FirstName = "kerim", LastName = "Veliyeva",PhoneNumber = "042395043"},
            };
            //Directory.CreateDirectory(@"C:\Users\pc\source\repos\practice2\practice2\Data");

            //File.Create(@"C:\Users\pc\source\repos\practice2\practice2\Data\customer.json");
            string result = JsonConvert.SerializeObject(customers);

            


            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(result);
            sw.Close();


        

           

            Add(new Customer
            {
                Id = 6,FirstName = "Ayxan", LastName = "memmedli",PhoneNumber = "3425"
            });

            Add(new Customer
            {
                Id = 7,
                FirstName = "John",
                LastName = "Roobinson",
                PhoneNumber = "3425116"
            });

            Search(6);

            Update(5, "gul", "ehmedova", "323453646");

            Delete(5);
            GetAll();
        }


        
       public static void Add(Customer customer)
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


        public static void Search(int id)
        {
            StreamReader sr = new StreamReader(path);

            string customers = sr.ReadToEnd();

            sr.Close();
            List<Customer> newCustomers = JsonConvert.DeserializeObject<List<Customer>>(customers);

          var found = newCustomers.Find(c=>c.Id == id);
            Console.WriteLine(found.FirstName + " " + found.LastName);

        }

        public static void Update(int id,string firstName, string lastName, string newPhoneNumber)
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

        public static void Delete(int id) {

            StreamReader sr = new StreamReader(path);

            string customers = sr.ReadToEnd();

            sr.Close();
            List<Customer> newCustomers = JsonConvert.DeserializeObject<List<Customer>>(customers);

            var found = newCustomers.Find(c=>c.Id == id);
            if (found != null) {
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


        public static void GetAll()
        {

            StreamReader sr = new StreamReader(path);

            string customers = sr.ReadToEnd();

            sr.Close();
            

            

            List<Customer> newCustomers = JsonConvert.DeserializeObject<List<Customer>>(customers);

            newCustomers.ForEach(c => Console.WriteLine($"Id:{c.Id} Name:{c.FirstName} Surname: {c.LastName} PhoneNumber:{c.PhoneNumber}"));
        }
    }
}