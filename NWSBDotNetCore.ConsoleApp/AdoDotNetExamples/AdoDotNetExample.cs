using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace NWSBDotNetCore.ConsoleApp.AdoDotNetExamples
{
    internal class AdoDotNetExample
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "ASUS",
            InitialCatalog = "DotNetTrainingBatch4",
            UserID = "sa",
            Password = "sa@123",

        };
        public void Read()
        {


            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            //SqlConnection connection = new SqlConnection("Data Source=ASUS;Initial Catalog=DotNetTrainingBatch4;User ID=sa;Password=sa@123;");
            connection.Open();
            Console.WriteLine("connection open.");

            // take a space to show database data
            string query = " select * from Tbl_Blog";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            // data will be write on variable dt



            connection.Close();
            Console.WriteLine("connection close.");

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("BlogId => " + dr["BlogId"]);
                Console.WriteLine("BlogTitle => " + dr["BlogTitle"]);
                Console.WriteLine("BlogAuthor => " + dr["BlogAuthor"]);
                Console.WriteLine("BlogContent => " + dr["BlogContent"]);
                Console.WriteLine("=====================================");

            }
        }
        public void Edit(int id)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            //SqlConnection connection = new SqlConnection("Data Source=ASUS;Initial Catalog=DotNetTrainingBatch4;User ID=sa;Password=sa@123;");
            connection.Open();


            // take a space to show database data
            string query = " select * from Tbl_Blog where BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            // data will be write on variable dt



            connection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No data found.");
                return;
            }

            DataRow dr = dt.Rows[0];

            Console.WriteLine("BlogId => " + dr["BlogId"]);
            Console.WriteLine("BlogTitle => " + dr["BlogTitle"]);
            Console.WriteLine("BlogAuthor => " + dr["BlogAuthor"]);
            Console.WriteLine("BlogContent => " + dr["BlogContent"]);
            Console.WriteLine("=====================================");



        }
        public void Create(string title, string author, string content)
        {


            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            //SqlConnection connection = new SqlConnection("Data Source=ASUS;Initial Catalog=DotNetTrainingBatch4;User ID=sa;Password=sa@123;");
            connection.Open();
            Console.WriteLine("connection open.");

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);

            int result = cmd.ExecuteNonQuery();

            connection.Close();
            Console.WriteLine("connection close.");

            string message = result > 0 ? "Saving Successful." : "Saving Failed";
            Console.WriteLine(message);
        }
        public void Update(int id, string title, string author, string content)
        {

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            //SqlConnection connection = new SqlConnection("Data Source=ASUS;Initial Catalog=DotNetTrainingBatch4;User ID=sa;Password=sa@123;");
            connection.Open();
            Console.WriteLine("connection open.");

            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);

            int result = cmd.ExecuteNonQuery();

            connection.Close();
            Console.WriteLine("connection close.");

            string message = result > 0 ? "Updating Successful." : "Updating Failed";
            Console.WriteLine(message);

        }
        public void Delete(int id)
        {

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            //SqlConnection connection = new SqlConnection("Data Source=ASUS;Initial Catalog=DotNetTrainingBatch4;User ID=sa;Password=sa@123;");
            connection.Open();
            Console.WriteLine("connection open.");

            string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId= @BlogId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);

            int result = cmd.ExecuteNonQuery();

            connection.Close();
            Console.WriteLine("connection close.");

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed";
            Console.WriteLine(message);

        }
    }
}
