using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWSBDotNetCore.ConsoleApp
{
    internal class DapperExample
    {
        public void Run()
        {
           /* Read()*/;
            Edit(1);
            //Edit(11);
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
            var item= db.Query<BloDto>("select * from Tbl_Blog where BlogId=@BlogId", new BloDto { BlogId = id}).FirstOrDefault();
            //FirstOrDefaul(); ka default value ko null anay nk htar pay poh
            //if(item == null)
            if(item is null)
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
    }
}

