using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TZLDotNetTrainingBatch3.ConsoleApp2.AppDbContext;

namespace TZLDotNetTrainingBatch3.ConsoleApp2
{
    public class ProductEFCoreService
    {   
        //private readonly AppDbContext _db;

        //public ProductEFCoreService()
        //{
        //    _db = new AppDbContext();
        //}   
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            var lst= db.Products.ToList();
            for (int i = 0;  i< lst.Count; i++)
            {
                Console.WriteLine(lst[i]+ "ProductName");
                Console.WriteLine(lst[i] +"ProductID");


            }

    }

        public void Create()
        {
            AppDbContext db = new AppDbContext();
            var item = new Tbl_Product()
            {
                ProductName = "Test",
                Price = 10000,
                //Quantity =100,
                CreatedDateTime = DateTime.Now,
                
                DeleteFlag = false

            };
            db.Products.Add(item);  
            int result = db.SaveChanges(); 
            string message = result > 0 ? "Insert Successful" : "Insert Failed";    
            Console.WriteLine(message);

        }


        public void Update()
        {
            AppDbContext db = new AppDbContext();
            //linq to find the record   
            var item = db.Products.Where( x => x.ProductID == 5).FirstOrDefault();// or var item = db.Products.FirstOrDefault(x => x.ProductID == 1);   

            if (item != null)
            {
                return;

            }
            item.ProductName = "Apple";
            item.Price = 20000;
            item.ModifiedDateTime = DateTime.Now;
            int result = db.SaveChanges();
            string message = result > 0 ? "Update Successful" : "Update Failed";
            Console.WriteLine(message);


        }
        public void Delete()
        { 
            AppDbContext db = new AppDbContext(); 
            var item = db.Products.Where(x => x.ProductID == 9).FirstOrDefault();
            if (item != null)
            {
                return;
            }   
            db.Products.Remove(item);
            int result = db.SaveChanges();  
            string message = result > 0 ? "Delete Successful" : "Delete Failed";    
            Console.WriteLine(message);


        }

    }
}
