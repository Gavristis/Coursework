using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CourseworkEmulator
{
    class Program
    {
        static void Main(string[] args)
        {

            var t = new DirectoryInfo(Directory.GetCurrentDirectory());
            var res = t.Parent.Parent.Parent.Parent.GetDirectories().First(d => d.Name == "Coursework.Web").GetDirectories().First(d => d.Name == "App_Data");
            AppDomain.CurrentDomain.SetData("DataDirectory", res.FullName);
            Random rand = new Random();
            var db = new MyDbContext();
            while (true)
            {
                try
                {
                    foreach (var flower in db.Flowers.AsNoTracking().ToList())
                    {
                        Thread.Sleep(rand.Next(1000, 5000));
                        flower.Moisture = rand.Next(30, 90);
                        flower.Light = rand.Next(100, 100000);
                        flower.Temperature = rand.Next(15, 40);
                        Console.WriteLine("Flower {0} is updated", flower.FlowerId);
                        db.Entry(flower).State = EntityState.Modified;
                        db.SaveChanges();
                        db.Entry(flower).State = EntityState.Detached;
                    }
                   
                }

                catch(Exception e)
                {
                    Console.WriteLine("Error: {0}", e.Message);
                }
            }
        }
    }
}
