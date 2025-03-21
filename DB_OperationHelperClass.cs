﻿using MySql.Data.MySqlClient;
using Quartz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUTZ_Capstone_Project
{
    internal class DB_OperationHelperClass
    {
        // connection string for MAMP (localhost)
        private static string connectionString = $"SERVER=localhost;UID=root;PWD=root;DATABASE=attendancepayrolldb;";

        // Method: Execute SELECT query to retrieve data from the Database
        public static DataTable QueryData(string sql)
        {
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to the database: {ex.Message}",
                    "Database connection error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return dt;
        }

        // Method: Execute SELECT query to retrieve data from the Database with parameterized arguments
        public static DataTable ParameterizedQueryData(string sql, Dictionary<string, object> parameters)
        {
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;

                    // Add parameters to the command
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                    }

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to the database: {ex.Message}",
                    "Database connection error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return dt;
        }

        // Method: Execute CRUD operation to the Database with parameterized arguments
        public static bool ExecuteCRUDSQLQuery(string sql, Dictionary<string, object> parameters)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;

                        // Add parameters to the command
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }

                        cmd.ExecuteNonQuery();
                    }

                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("An error encountered while attempting to execute SQL commands to the database." +
                        "\n" + e.Message, "Failed to execute SQL commands!",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
        }

        public static async Task<bool> ExecuteCRUDSQLQueryAsync(string sql, Dictionary<string, object> parameters)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync(); // Open the connection asynchronously

                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.Text;

                        // Add parameters to the command
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }

                        await cmd.ExecuteNonQueryAsync(); // Execute the query asynchronously
                    }

                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("An error encountered while attempting to execute SQL commands to the database." +
                        "\n" + e.Message, "Failed to execute SQL commands!",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
        }
    }
}


