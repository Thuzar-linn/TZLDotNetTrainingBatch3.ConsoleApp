using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using static TZLDotNetTrainingBatch3.ConsoleApp2.ProductDapperService;

namespace TZLDotNetTrainingBatch3.ConsoleApp2
{
    public class SaleDapperService
    {
        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "Batch3MiniPOS",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public class SaleDto
        {
            public int SaleID { get; set; }
            public int ProductID { get; set; }
            public int Quantity { get; set; }
            public decimal TotalPrice { get; set; }
        }   
        public void Read()
        {
            using (IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                string query = @"SELECT [SaleID]
                              ,[ProductID]
                              ,[Quantity]
                              ,[TotalPrice]
                          FROM [dbo].[Tbl_Sale]";

                List<SaleDto> lst = db.Query<SaleDto>(query).ToList();
                for (int i = 0; i < lst.Count; i++)
                {
                    Console.WriteLine(lst[i].SaleID);
                    Console.WriteLine(lst[i].ProductID);
                    Console.WriteLine(lst[i].Quantity);
                    Console.WriteLine(lst[i].TotalPrice);
                    

                }
            }
        }
        public void Create()
        {
            using (IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                string query = @"INSERT INTO [dbo].[Tbl_Sale]
                               ([ProductID]
                               ,[Quantity]
                               ,[TotalPrice])
                         VALUES
                               (@ProductID
                               ,@Quantity
                               ,@TotalPrice)";
                int result = db.Execute(query);
                string message = result > 0 ? "Insert Success" : "Insert Fail"; 
                Console.WriteLine(message);

            }
        }
        //do not use update and delete in this project
        //public void Update()
        //{
        //    using (IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
        //    {
        //        db.Open();
        //        string query = @"UPDATE [dbo].[Tbl_Sale]
        //                       SET [ProductID] = @ProductID
        //                          ,[Quantity] = @Quantity
        //                          ,[TotalPrice] = @TotalPrice
        //                     WHERE SaleID = @SaleID";
        //        int result = db.Execute(query);
        //        string message = result > 0 ? "Update Success" : "Update Fail";
        //        Console.WriteLine(message);
        //    }
        //}
        //public void Delete()
        //{
        //    using (IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
        //    {
        //        db.Open();
        //        string query = @"DELETE FROM [dbo].[Tbl_Sale]
        //                     WHERE SaleID = 1";
        //        int result = db.Execute(query);
        //        string message = result > 0 ? "Delete Success" : "Delete Fail";
        //        Console.WriteLine(message);
        //    }
        //}
    }
}
