﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ConsoleApp1
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection() { 
            string host = "localhost";
            int port = 3306;
            string database = "electricity_payments";
            string username = "monty";
            string password = "PASSWORD";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}
