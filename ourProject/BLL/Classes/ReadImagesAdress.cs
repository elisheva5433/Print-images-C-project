using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DAL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace BLL.Classes
{
    public class ReadImagesAdress : IReadImagesAdress
    {
        public double sum = 0; //סופר כמה ,מונות ההזמנה מכילה
        public void Reader_picture(int id, string selectedOption)
        {

            List<string> pictureList = new List<string>();
            using (StreamReader reader = new StreamReader(@"C:\תיקיה מסלול\C#\PrintIagesProj\Print-images-C-project\תמונות\MISC\AUTXFER.MRK"))
            {
                string line;
                string prefix = "IMG SRC";
                line = reader.ReadLine();
                int startIndex = 14;
                while (!line.StartsWith(prefix))
                {
                    line = reader.ReadLine();
                    //}
                }
                while (line != null)
                {
                    if (line.Length > startIndex)
                    {
                        string newLine = line.Substring(startIndex);
                        pictureList.Add(newLine);
                        line = reader.ReadLine();
                        Console.WriteLine(newLine);
                    }
                }
            }
            ConvertAndSaveImage(pictureList, id, selectedOption);



        }
        public void ConvertAndSaveImage(List<string> pictureList, int id, string selectedOption)
        {
            Console.WriteLine("selectedOption : " + selectedOption);
            string code = GenerateUniqueOrderId();
            foreach (var p in pictureList)
            {
                try
                {
                    string imagePath = p;
                    Console.WriteLine("imagePath: " + imagePath);
                    Console.WriteLine("imagePath: " + imagePath);
                    string basePath = @"H:/C#/פרוייקט/תמונות"; // הנתיב הבסיסי
                    string fullPath = Path.Combine(basePath, imagePath); // החלפת הנתיב
                    fullPath = fullPath.TrimEnd('"');
                    Console.WriteLine("fullPath: " + fullPath);
                    fullPath = Path.GetFullPath(fullPath); // המרה לנתיב מוחלט
                    Console.WriteLine(fullPath);
                    if (!File.Exists(fullPath))
                    {
                        Console.WriteLine("hhh");
                        Console.WriteLine($"File does not exist: {fullPath}");

                    }

                    else
                    {
                        Console.WriteLine("file exist!!!");

                        byte[] img = Encoding.UTF8.GetBytes(fullPath);


                        sum++;
                        using (var context = new OrderDbcontext())
                        {
                            //Console.WriteLine("------------------------------------id stati: "+id);
                            SavingImages savingImage = new SavingImages(id, code, img, 1, selectedOption);
                            //Console.WriteLine(id + " " + code + " " + img + " " + selectedOption);
                            context.SavingImages.Add(savingImage);
                            context.SaveChanges();
                        }

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing image: {ex.Message}");
                }
            }
            using (var context = new OrderDbcontext())
            {
                //מציאת הלקוח המזמין
                var customer = context.Customers.Where(c => c.Id == id).FirstOrDefault();
                Console.WriteLine($"Customer: {customer.CustomerCode}");
                Console.WriteLine("id----------  " + id);
                //int id, string orderCode, int processStatus, string officerCode, string customerCode
                OrderManagment order = new OrderManagment(id, code, 1, GetAvailableOfficer(), customer.CustomerCode, selectedOption);
                order.toString();
                context.OrderManagment.Add(order);
                context.SaveChanges();
            }
        }
        public string GenerateUniqueOrderId()

        {
            var context = new OrderDbcontext();
            int customerCode;
            do
            {
                customerCode = new Random().Next(10000, 99999);

            } while (context.Customers.Any(o => o.Id == customerCode));
            string code = customerCode.ToString();//convert to string
            return code;

        }
        public string GetAvailableOfficer()
        {
            try
            {
                using (var context = new OrderDbcontext())
                {
                    var officersWithOrders = context.OrderManagment.Select(o => o.OfficerCode).Distinct().ToList();
                    // מציאת פקיד שלא נמצא בטבלת ניהול ההזמנות
                    var officerWithoutOrders = context.Officer
                        .Where(o => !officersWithOrders.Contains(o.OfficerCode))
                        .FirstOrDefault();

                    if (officerWithoutOrders != null)
                    {
                        return officerWithoutOrders.OfficerCode;
                    }
                    var officerWithLeastOrders = context.OrderManagment
                     .GroupBy(o => o.OfficerCode)
                     .Select(g => new
                     {
                         OfficerCode = g.Key,
                         OrderCount = g.Count()
                     })
                     .OrderBy(order => order.OrderCount)
                     .FirstOrDefault();

                    if (officerWithLeastOrders != null)
                    {
                        return officerWithLeastOrders.OfficerCode;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
            return string.Empty;
        }

        public Customers customerDetails(int id)
        {
            using (var context = new OrderDbcontext())
            {
                //מציאת הלקוח המזמין
                var customer = context.Customers.Where(c => c.Id == id).FirstOrDefault();
                return customer;
            }

        }
        public double sumPictures(string selectedOption)
        {
            switch (selectedOption)
            {
                case "13 x 18":
                    sum *= 3;
                    break;
                case "15 x 20":
                    sum *= 5.5;
                    break;
                case "20 x 30":
                    sum *= 10;
                    break;
            }
            return sum;
        }

    }
}