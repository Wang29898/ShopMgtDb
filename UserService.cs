using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace ShoppingMallDemo
{
    public class UserService
    {
        public List<Product> GetInfo()
        {
            List<Product> info = new List<Product>();
            SqlConnection sqlConnection = DatabaseConnection.GetConnection();
            string sqlcommand = "select * from Product";
            SqlCommand sqlCommand = new SqlCommand(sqlcommand, sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();//total 3 users
            while (reader.Read())//0,1,2
            {
                Product infoer = new Product()
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Name = reader["Name"].ToString(),
                    Price = Convert.ToDecimal(reader["Price"]),
                    Category = reader["Category"].ToString()
                    
                    
                };
                info.Add(infoer);
            }
            return info;
        }
        public void SaveUser(Product infoer)
        {
            try
            {
                SqlConnection sqlConnection = DatabaseConnection.GetConnection();
                string sqlquery = $"insert into Product values({infoer.Id},'{infoer.Name}',{infoer.Price},'{infoer.Category}')";
                SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlConnection);
                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Successfully saved.");
                }
                else
                {
                    Console.WriteLine("failed .");
                }
            }
            catch (SqlException sqle)
            {
                throw sqle ;
            }
        }
        public void DeleteByUserId(int Id)
        {
            try
            {
                SqlConnection connection = DatabaseConnection.GetConnection();
                string sqlDeleteQuery = $"Delete from Product where Id={Id}";
                SqlCommand sqlCommand = new SqlCommand(sqlDeleteQuery, connection);
                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("Successfully Deleted!!!!");
                else
                    Console.WriteLine("failed when record is deleted.");
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void UpdateUserById(Product infoer)//
        {
            try
            {
                SqlConnection connection = DatabaseConnection.GetConnection();
                string sqlUpdateQuery = $"update Product set Name='{infoer.Name}',Price={infoer.Price},Category='{infoer.Category}' where id={infoer.Id}";
                SqlCommand sqlCommand = new SqlCommand(sqlUpdateQuery, connection);
                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("Successfully Updated.");
                else
                    Console.WriteLine("failed when record is updated.");
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
        
    }
}
