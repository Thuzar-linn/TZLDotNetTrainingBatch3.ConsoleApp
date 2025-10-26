using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace TZLDotNetTrainingBatch3.ConsoleApp2
{
    public class AppDbContext : DbContext
    {
        internal object TblProductCategories;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            { DataSource = ".",
              InitialCatalog = "Batch3MiniPOS",
              UserID = "sa",
              Password = "sasa@123",
              TrustServerCertificate = true,
            };
            optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);

        }

        public DbSet<Tbl_Product> Products { get; set; }
        public DbSet<Tbl_Sale> Sales { get; set; }

        public DbSet<Tbl_ProductCategory> ProductCategories { get; set; }



    }
    [Table("Tbl_Sale")]
    public class Tbl_Sale
    {
        [Key]
        public int SaleID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public DateTime SaleDateTime { get; set; }
    }
    [Table("Tbl_Product")]
    public class Tbl_Product
    {

        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public bool DeleteFlag { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime ModifiedDateTime { get; set; }

    }
    [Table("Tbl_ProductCategory")]
    public class Tbl_ProductCategory
    {
        [Key]
        public int ProductCategoryID { get; set; }
        public string ProductCategoryCode { get; set; }
        public string ProductCategoryName { get; set; }
    }
}
