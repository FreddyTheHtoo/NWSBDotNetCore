using Dapper;
using NWSBDotNetCore.ConsoleApp.Connections;
using NWSBDotNetCore.ConsoleApp.Dtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWSBDotNetCore.ConsoleApp.DapperExamples
{
    internal class DapperExample
    {
        public void Run()
        {
            /* Read()*/
            ;
            //Edit(1);
            //Edit(11);
            //Create("Titles", "Authors", "Contents");
            //Update(1003,"Titles 2", "Authors 3", "Contents 3");
            //Delete(3);

        }

        private void Read()
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

            List<BloDto> lst = db.Query<BloDto>("select * from Tbl_Blog").ToList();

            //ToList(); ka execute lote kine dr

            foreach (BloDto item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("-----------------------------");

            }

        }
        private void Edit(int id)
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BloDto>("select * from Tbl_Blog where BlogId=@BlogId", new BloDto { BlogId = id }).FirstOrDefault();
            //FirstOrDefaul(); ka default value ko null anay nk htar pay poh
            //if(item == null)
            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("-----------------------------");
        }
        private void Create(string title, string author, string content)
        {
            var item = new BloDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };


            string query = @"INSERT INTO [dbo].[Tbl_Blog]
             ([BlogTitle]
            ,[BlogAuthor]
            ,[BlogContent])
      VALUES (@BlogTitle
                ,@BlogAuthor
                 ,@BlogContent)";


            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

            int result = db.Execute(query, item);

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);
        }
        private void Update(int id, string title, string author, string content)
        {
            var item = new BloDto
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };


            string query = @"UPDATE [dbo].[Tbl_Blog]
     SET        [BlogTitle]=@BlogTitle
            ,[BlogAuthor]=@BlogAuthor
            ,[BlogContent]=@BlogContent
    WHERE BlogId=@BlogId";


            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

            int result = db.Execute(query, item);

            string message = result > 0 ? "Update Successful." : "Update Failed.";
            Console.WriteLine(message);
        }

        private void Delete(int id)
        {
            var item = new BloDto
            {
                BlogId = id,

            };


            string query = @"DELETE FROM [dbo].[Tbl_Blog] WHERE BlogId=@BlogId";


            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

            int result = db.Execute(query, item);

            string message = result > 0 ? "Delete Successful." : "Delete Failed.";
            Console.WriteLine(message);
        }
    }
}

