using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NWSBDotNetCore.Shared
{
    public class AdoDotNetService
    {
        private readonly string _connectionString;
        public AdoDotNetService(string connection) 
        {
         _connectionString = connection;
        }


        public List<T> Query<T>(String query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            // take a space to show database data
            SqlCommand cmd = new SqlCommand(query, connection);
            if (parameters is not null && parameters.Length > 0)
            {
                //foreach(var item in parameters)
                //{

                //    cmd.Parameters.AddWithValue(item.Name, item.Value);
                //}
                //OR
                var parametersArray = parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray();
                cmd.Parameters.AddRange(parametersArray);
                //OR
               //cmd.Parameters.AddRange(parameters.Select(item=> new SqlParameter(item.Name,item.Value)).ToArray());
               //pro yae nee
            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            // data will be write on variable dt

            connection.Close();

            var jason = JsonConvert.SerializeObject(dt); //Changing C# to json
            List<T> lst= JsonConvert.DeserializeObject<List<T>>(jason)!; //json to C#
            return lst;



        }
        public T QueryFirstOrDefault<T>(String query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            // take a space to show database data
            SqlCommand cmd = new SqlCommand(query, connection);
            if (parameters is not null && parameters.Length > 0)
            {
                //foreach(var item in parameters)
                //{

                //    cmd.Parameters.AddWithValue(item.Name, item.Value);
                //}
                //OR
                var parametersArray = parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray();
                cmd.Parameters.AddRange(parametersArray);
                //OR
               //cmd.Parameters.AddRange(parameters.Select(item=> new SqlParameter(item.Name,item.Value)).ToArray());
               //pro yae nee
            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            // data will be write on variable dt

            connection.Close();

            var jason = JsonConvert.SerializeObject(dt); //Changing C# to json
            List<T> lst = JsonConvert.DeserializeObject<List<T>>(jason)!; //json to C#
            return lst[0];



        }
        public int Execute(String query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            if (parameters is not null && parameters.Length > 0)
            {
                var parametersArray = parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray();
                cmd.Parameters.AddRange(parametersArray);
               
            }
            var result= cmd.ExecuteNonQuery();
            connection.Close();
            return result;
        }

        }

        public class AdoDotNetParameter
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public AdoDotNetParameter() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public AdoDotNetParameter(string name, object? value)
        {
            Name = name;
            Value = value;
        }
       
        public string Name { get; set; }
        public object? Value { get; set; }
    }
}
