using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting connection...");
            MySqlConnection connect = DBUtils.GetDBConnection();

            try
            {
                Console.WriteLine("Openning connection...");
                connect.Open();
                Console.WriteLine("Connection successful!");
                DebtMoreThanHundred(connect);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally { connect.Close(); connect.Dispose(); }
            Console.Read();
        }

        private static void DebtMoreThanHundred (MySqlConnection connect)
        {
            string firstName, secondName;
            string sql = "SELECT * FROM споживачі WHERE заборгованість > 100";

            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = connect;
            cmd.CommandText = sql;        

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        firstName = reader["ім_я"].ToString();
                        secondName = reader["прізвище"].ToString();
                        Console.WriteLine("-------------");
                        Console.WriteLine("Всі споживачи із заборгованістю більше 100 гривень: Ім'я:" + firstName + "Прізвище:" + secondName);
                        Console.WriteLine("-------------");
                    }
                } else
                {
                    Console.WriteLine("Application dont find rows");
                }            
            }
        }
    }
}
