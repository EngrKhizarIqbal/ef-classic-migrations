using EF6Context;
using System;
using System.Linq;

namespace EFClasicTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start of Program!");
            Console.WriteLine("");

            using (var context = new EFContextForEF6())
            {
                var webUsers = context.Customers.Include(i => i.WebUsers).ToList();
                foreach (var item in webUsers)
                {
                    Console.WriteLine($"Customer Name: {item.Name}\t WebUsers: [{string.Join(", ", item.WebUsers.Select(s => s.Name))}]");
                }

                try
                {
                    context.Customers.Add(new Entities.Customer
                    {
                        Name = "0123456789"
                    });

                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            Console.WriteLine("");
            Console.WriteLine("End of Program.");
            Console.ReadKey();
        }
    }
}
