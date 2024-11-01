using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace practice2
{
    internal class Program
    {

        //public static string Path = @"C:\Users\pc\source\repos\practice2\practice2\practice2.csproj";
       
        static void Main(string[] args)
        {

            Customer customer = new Customer();

            List<Customer> customers = new List<Customer>
            {
                new Customer{Id = 1,FirstName = "Nurane", LastName = "Veliyeva",PhoneNumber = "042395043"},
                 new Customer{Id = 2,FirstName = "eli", LastName = "Veliyeva",PhoneNumber = "042395043"},
                  new Customer{Id = 3,FirstName = "huseyn", LastName = "Veliyeva",PhoneNumber = "042395043"},
                   new Customer{Id = 4,FirstName = "david", LastName = "Veliyeva",PhoneNumber = "042395043"},
                    new Customer{Id = 5,FirstName = "kerim", LastName = "Veliyeva",PhoneNumber = "042395043"},
            };
            Directory.CreateDirectory(@"C:\Users\pc\source\repos\practice2\practice2\Data");

            File.Create(@"C:\Users\pc\source\repos\practice2\practice2\Data\customer.json");
            string result = JsonConvert.SerializeObject(customers);

            


            StreamWriter sw = new StreamWriter(Customer.path);
            sw.WriteLine(result);
            sw.Close();


        

           

            customer.Add(new Customer
            {
                Id = 6,FirstName = "Ayxan", LastName = "memmedli",PhoneNumber = "3425"
            });

            customer.Add(new Customer
            {
                Id = 7,
                FirstName = "John",
                LastName = "Roobinson",
                PhoneNumber = "3425116"
            });

            customer.Search(6);

           customer.Update(5, "gul", "ehmedova", "323453646");

            customer.Delete(5);
            customer.GetAll();
        }


        
      
    }
}