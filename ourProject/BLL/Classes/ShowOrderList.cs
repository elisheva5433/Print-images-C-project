using BLL.Interfaces;
using DAL;
using DAL.Classes;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes
{
    public class ShowOrderList : IShowOrderList
    {
        public List<OrderManagment> selectOrders(String OfficerCode)
        {
            List<OrderManagment> orders = new List<OrderManagment>();
            using (SqlConnection connection = new SqlConnection("Server=sqlsrv;Database=NewRREYPHONE;Trusted_Connection=True;Encrypt=False"))
            using (SqlCommand command = new SqlCommand("select * from OrderManagment where OfficerCode = @OfficerCode", connection))
            {

                command.Parameters.AddWithValue("@OfficerCode", OfficerCode);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrderManagment order = new OrderManagment
                        {
                            Id = Convert.ToInt32(reader["Id"].ToString()),
                            OrderCode = reader["OrderCode"].ToString(),
                            ProcessStatus = Convert.ToInt32(reader["ProcessStatus"].ToString()),
                            OfficerCode = reader["OfficerCode"].ToString(),
                            CustomerCode = reader["CustomerCode"].ToString(),
                            SizePicture = reader["SizePicture"].ToString()
                        };
                        if (order.ProcessStatus == 1)
                        {
                            orders.Add(order);
                        }
                    }
                }
            }
            return orders;
        }


        public void orderSuccessfull(int id)
        {
            
            try
            {
                string connectionString = "Server=sqlsrv;Database=NewRREYPHONE;Trusted_Connection=True;Encrypt=False";
                string sql = "UPDATE OrderManagment SET ProcessStatus = 2 WHERE Id = @Id";
                //using (var context = new OrderDbcontext())
                //{
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(sql, connection))
                    {
                        Console.WriteLine("I passed here too1!");
                        try
                        {

                            //command.Parameters.Add("@Id", SqrlDbType.Int).Value = id; // שימוש ב-authorId כערך הפרמטר @Id
                            command.Parameters.AddWithValue("@Id", id);




                            command.ExecuteNonQuery();
                            Console.WriteLine("I passed here too3!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("errorrrrrr: " + ex.Message);
                        }
                    }
                }
            }



            catch (Exception ex)
            {
                Console.WriteLine("error: " + ex.Message);
            }
            }
        }
    }
