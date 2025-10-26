using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZLDotNetTrainingBatch3.ConsoleApp2
{
    internal class SaleEFCoreService
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            var lst = db.Sales.ToList();
            for (int i = 0; i < lst.Count; i++)
            {
                Console.WriteLine(lst[i] + "SaleID");
                Console.WriteLine(lst[i] + "ProductID");
                Console.WriteLine(lst[i] + "Quantity");
                Console.WriteLine(lst[i] + "SaleDateTime");
            }
        }

        public void Create()
        {
            AppDbContext db = new AppDbContext();
            var item = new Tbl_Sale()
            {
                ProductID = 1,
                Quantity = 2,
                SaleDateTime = DateTime.Now,
            };
            db.Sales.Add(item);
            int result = db.SaveChanges();
            string message = result > 0 ? "Insert Successful" : "Insert Failed";
            Console.WriteLine(message);
        }
    }
}
