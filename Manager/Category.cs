using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    internal class Category
    {
        public int InsertCategory(string connectionString)
        {
            string Category_Name, result;
            int rowsAffectted = 0;
            bool continueToFill = true;
            while (continueToFill)
            {
                Console.WriteLine("insert Category Name");
                Category_Name = Console.ReadLine();
                Console.WriteLine("would you like to continue?  y/n");
                result = Console.ReadLine();

                string query = "INSERT INTO Category(Category_Name)" +
                    "VALUES (@Category_Name)";

                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@Category_Name", SqlDbType.VarChar,15).Value = Category_Name;
              
                    cn.Open();
                    rowsAffectted += cmd.ExecuteNonQuery();
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

        internal void getCategories(string connectionString)
        {
            string queryString = "select * from Category";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}",
                           reader[0], reader[1]);
                    }
                    reader.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();


            }
        }
    }
}
