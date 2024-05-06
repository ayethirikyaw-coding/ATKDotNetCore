using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ATKDotNetCore.Shared
{
    public class AdoDotNetService
    {
        private readonly string _connectionString;

        public AdoDotNetService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<T> Query<T>(string query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            if(parameters is not null && parameters.Length > 0)
            {
                //foreach (var item in parameter)
                //{
                //    cmd.Parameters.AddWithValue(item.Name, item.Value);
                //}

                //cmd.Parameters.AddRange(parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray());
                var parametersArray = parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray();
                cmd.Parameters.AddRange(parametersArray);
            }
                 
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();
            string json = JsonConvert.SerializeObject(dt); // C# to json
            List<T> lst = JsonConvert.DeserializeObject<List<T>>(json)!; //json to C#

            return lst;
        }

        public T QueryFirstOrDefault<T>(string query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            if (parameters is not null && parameters.Length > 0)
            {
                var parametersArray = parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray();
                cmd.Parameters.AddRange(parametersArray);
            }

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();

            string json = JsonConvert.SerializeObject(dt); // C# to json
            List<T> lst = JsonConvert.DeserializeObject<List<T>>(json)!; //json to C#
            if (lst.Count == 0)
            {
                //return null; //compile error
                return default!;
            }
            return lst[0];
        }

        public int Execute(string query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            if (parameters is not null && parameters.Length > 0)
            {
                var parametersArray = parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray();
                cmd.Parameters.AddRange(parametersArray);
            }

            int result = cmd.ExecuteNonQuery();

            connection.Close();
            //string json = JsonConvert.SerializeObject(dt); // C# to json
            //List<T> lst = JsonConvert.DeserializeObject<List<T>>(json)!; //json to C#
            return result;
        }
    }

    public class AdoDotNetParameter
    {
        public AdoDotNetParameter() { }
        public AdoDotNetParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }

        public object Value { get; set; }
    }
}
