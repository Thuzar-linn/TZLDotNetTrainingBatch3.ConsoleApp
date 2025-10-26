using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;


namespace TZLDotNetTrainingBatch3.ConsoleApp2
{
    public class ProductDapperService
    {
        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "Batch3MiniPOS",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public class ProductDto
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public decimal Price { get; set; }
            public bool DeleteFlag { get; set; }
        }   

        public void Read()
        {
            using (IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                string query = @"SELECT [ProductID]
                               ,[ProductName]
                               ,[Price]
                               ,[DeleteFlag]
                           FROM [dbo].[Tbl_Product]";
               List <ProductDto> lst = db.Query<ProductDto>(query).ToList();
                for (int i = 0; i < lst.Count; i++)
                {
                    Console.WriteLine(lst[i].ProductID);
                    Console.WriteLine(lst[i].ProductName);
                    Console.WriteLine(lst[i].Price);
                    Console.WriteLine(lst[i].DeleteFlag);   

                }
                {
                    
                }


            }
        }

        public void Create()
        {
            using (IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
               
                db.Open();  
                string query = @"INSERT INTO [dbo].[Tbl_Product]
                                       ([ProductName]
                                       ,[Price]
                                       ,[DeleteFlag])
                                 VALUES
                                       ('Apple'
                                       ,1000
                                       ,0)"; 
               int result = db.Execute(query);
                string message = result > 0? "Created Successful" : "Created Failed"; 
                Console.WriteLine(message);

            }
        }   

        public void Update()
        {
            using (IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString)) 
            {
                db.Open();
                string query = @"UPDATE [dbo].[Tbl_Product]
                                   SET [ProductName] = 'Lemon'
                                      ,[Price] = 2000
                                      ,[DeleteFlag] = 0
                                 WHERE ProductID = 1"; 
                int result = db.Execute(query);
                string message = result > 0 ? "Updated Successful" : "Updated Failed";
                Console.WriteLine(message);
            }
        }

        public void Delete()
        {
            using (IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            { 
                db.Open();
                string query = @"DELETE FROM [dbo].[Tbl_Product]
                                 WHERE ProductID = 1"; 
                int result = db.Execute(query);
                string message = result > 0 ? "Deleted Successful" : "Deleted Failed";
                Console.WriteLine(message);
            }
        }



    }
}
