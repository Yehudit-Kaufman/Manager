using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Manager
{
    internal class Product
    {
        
       

        public int InsertProduct(string connectionString)
        {
            string CategoryId, ProductName, Description, Price, Image, result;
            int rowsAffectted = 0;
            bool continueToFill = true;
            while (continueToFill)
            {
                Console.WriteLine("insert categoryId");
                CategoryId = Console.ReadLine();
                Console.WriteLine("insert name");
                ProductName = Console.ReadLine();
                Console.WriteLine("insert Description");
                Description = Console.ReadLine();
                Console.WriteLine("insert Price");
                Price = Console.ReadLine();
                Console.WriteLine("insert Image");
                Image = Console.ReadLine();
                Console.WriteLine("would you like to continue?  y/n");
                result = Console.ReadLine();

                string query = "INSERT INTO Product_1(Category_ID, Name, Description, Price, Image)" +
                    "VALUES (@CategoryId, @ProductName, @Description, @Price, @Image)";

                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = CategoryId;
                    cmd.Parameters.Add("@ProductName", SqlDbType.VarChar,15).Value = ProductName;
                    cmd.Parameters.Add("@Description", SqlDbType.VarChar, 15).Value = Description;
                    cmd.Parameters.Add("@Price", SqlDbType.Float).Value = Price;
                    cmd.Parameters.Add("@Image", SqlDbType.VarChar, 10).Value = Image;

                    cn.Open();
                   rowsAffectted+= cmd.ExecuteNonQuery();
                    cn.Close();
                    if (result == "y")
                        continueToFill = true;
                    else
                    {
                        continueToFill = false;
                        
                    }
                }
            }

            return rowsAffectted;
        }

        internal void getProducts(string connectionString)
        {
            string queryString = "select * from Product_1";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                           reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                    }
                    reader.Close();

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
                    
                 
            }
        }
    }
}
