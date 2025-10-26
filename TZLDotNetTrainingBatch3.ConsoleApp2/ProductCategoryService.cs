using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TZLDotNetTrainingBatch3.ConsoleApp2.Database.EFAppDbContextModels;
using TZLDotNetTrainingBatch3.ConsoleApp2.Database.EFAppDbContextModels;


namespace TZLDotNetTrainingBatch3.ConsoleApp2
{
    public class ProductCategoryService
    {
        public void Read()
        { 
             EFAppDbContext db = new EFAppDbContext();

             var categories = db.TblProductCategories.ToList();

            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine("CategoryName: " + categories[i]);
                Console.WriteLine("CategoryID: " + categories[i]);
            }

        }

        public void Create()
        {
            EFAppDbContext db = new EFAppDbContext();
            var category = new TblProductCategory()
            {
                ProductCategoryCode = "CAT001",
                ProductCategoryName = "Electronics"
            };
            db.TblProductCategories.Add(category);
            int result = db.SaveChanges();  
            string message = result > 0 ? "Insert Successful" : "Insert Failed";
            Console.WriteLine(message);



        }

        public void Update()
        {
            EFAppDbContext db = new EFAppDbContext();
            var category = db.TblProductCategories.FirstOrDefault(c => c.ProductCategoryId == 1);
            if (category == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }
            category.ProductCategoryName = "Updated Category Name";
            int result = db.SaveChanges();
            string message = result > 0 ? "Update Successful" : "Update Failed";
            Console.WriteLine(message);
        }

        public void Delete()
        {
            EFAppDbContext db = new EFAppDbContext();
            var category = db.TblProductCategories.FirstOrDefault(c => c.ProductCategoryId == 2);

            if (category == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }

            db.TblProductCategories.Remove(category);
            int result = db.SaveChanges();
            string message = result > 0 ? "Delete Successful" : "Delete Failed";
            Console.WriteLine(message);
        }
    }
    
}
