using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace TZLDotNetTrainingBatch3.ConsoleApp2
{
    public class ProductService
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



            string query = @"SELECT [ProductID]
                           ,[ProductName]
                          ,[Price]
                          ,[DeleteFlag]
                      FROM [dbo].[Tbl_Product]";

            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            connection.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                //Console.WriteLine("Product ID" + row["ProductID"]);
                int rowNo = i + 1;
                decimal price = Convert.ToDecimal(row["price"]);

                Console.WriteLine("No." + rowNo.ToString() + " " + row["ProductName"] + "(" + price.ToString("n0") + ")");
                //Console.WriteLine("Price -->" + row["Price"]);
                Console.WriteLine("----------------------");

            }

        }

        public void Create()
        {
            string query = @" 
            INSERT INTO[dbo].[Tbl_Product]
            ([ProductName]
           , [Price]
           , [DeleteFlag])
         VALUES
           ('Test'
           , 10000
           , 0)";
            
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open(); 
            SqlCommand cmd = new SqlCommand(query, connection);
            var result = cmd.ExecuteNonQuery();

            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            int test = result > 0 ? 1 : 0;  

            Console.WriteLine(message);
            Console.WriteLine(test);


            connection.Close();



        }   

        public void Update()
        {
            string query = @"  UPDATE [dbo].[Tbl_Product]
            SET [ProductName] = 'Test2'
            ,[Price] = 20000
            ,[DeleteFlag] = 0
            WHERE ProductID = 8 ";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            SqlCommand cmd = new SqlCommand(query, connection); 
          
            connection.Open();
            int result = cmd.ExecuteNonQuery();
            string message = result > 0 ?  "Deleting Successfull" : "Deleting Failed";   
            int test = result > 0 ? 1 : 0;

            connection.Close();
            

        }

        public void Delete()
        {
            string query = @"DELETE FROM [dbo].[Tbl_Product]
                WHERE DeleteFlag = 1 ";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            SqlCommand cmd = new SqlCommand(query, connection);

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            string message = result > 0 ? "Updating Successfull" : "Updating Failed";
            int test = result > 0 ? 1 : 0;

            connection.Close();
        }
    }
}

