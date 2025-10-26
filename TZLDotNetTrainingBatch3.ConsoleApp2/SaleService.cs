using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace TZLDotNetTrainingBatch3.ConsoleApp2
{
    public class SaleService
    {
         SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()

            {
                DataSource = ".",
                InitialCatalog = "Batch3MiniPOS",   
                UserID = "sa",
                Password = "sasa@123",  
                TrustServerCertificate = true  
            };
            
        
        public void Read()
        {
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();


            string query = @"SELECT [SaleID]
                          ,[ProductId]
                          ,[Quantity]
                          ,[Price]
                          ,[DeleteFlag]
                          ,[CreateDateTime]
                      FROM [dbo].[Sale]";

            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            connection.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow rowNo = dt.Rows[i];
                int saleNo = i + 1;
                decimal price = Convert.ToDecimal(rowNo["Price"]);
                Console.WriteLine("No." + saleNo.ToString() + " " + rowNo["ProductID"] + "(" + price.ToString("n0") + ")");

            }
        }

        public void Create()
        {
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"INSERT INTO [dbo].[Sale]
                           ([SaleID]
                           ,[ProductId]
                           ,[Quantity]
                           ,[Price]
                           ,[DeleteFlag]
                           ,[CreateDateTime])
                     VALUES
                           (<SaleID, int,>
                           ,<ProductId, int,>
                           ,<Quantity, int,>
                           ,<Price, decimal(18,0),>
                           ,<DeleteFlag, bit,>
                           ,<CreateDateTime, datetime,>)";    
            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery(); 
            string message = result > 0 ? "Insert Success" : "Insert Failed";   
            Console.WriteLine(message); 
            connection.Close(); 
        }

        public void Update()
        {
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"UPDATE [dbo].[Sale]
                               SET [SaleID] = 1
                                  ,[ProductId] = 1
                                  ,[Price] = 10000
                                  
                             WHERE SaleID = 1";  
            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();
            string message = result > 0 ? "Update Success" : "Update Failed";
            Console.WriteLine(message);
        }
        public void Delete()
        {
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"DELETE FROM [dbo].[Sale]
                            WHERE SaleID = 3";  
            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();
            string message = result > 0 ? "Delete Success" : "Delete Failed";
            Console.WriteLine(message);
        }   

    }
}
