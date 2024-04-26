using NWSBDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
//SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
//stringBuilder.DataSource = "ASUS";
//stringBuilder.InitialCatalog = "DotNetTrainingBatch4";
//stringBuilder.UserID = "sa";
//stringBuilder.Password = "sa@123";
//stringBuilder.TrustServerCertificate = true;
//stringBuilder.Encrypt = false;

//SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);
////SqlConnection connection = new SqlConnection("Data Source=ASUS;Initial Catalog=DotNetTrainingBatch4;User ID=sa;Password=sa@123;");
//connection.Open();
//Console.WriteLine("connection open.");

//// take a space to show database data
//string query = " select * from Tbl_Blog";
//SqlCommand cmd = new SqlCommand(query, connection);
//SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
//DataTable dt = new DataTable();
//sqlDataAdapter.Fill(dt);
//// data will be write on variable dt



//connection.Close();
//Console.WriteLine("connection close.");

//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine("BlogId => " + dr["BlogId"]);
//    Console.WriteLine("BlogTitle => " + dr["BlogTitle"]);
//    Console.WriteLine("BlogAuthor => " + dr["BlogAuthor"]);
//    Console.WriteLine("BlogContent => " + dr["BlogContent"]);
//    Console.WriteLine("=====================================");

//}

//ado.net read
//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create("title", "author", "content");
//adoDotNetExample.Update(1002, "test title", "test author", "test content");
//adoDotNetExample.Delete(1002);
//adoDotNetExample.Edit(1002);
//adoDotNetExample.Edit(1);
//DapperExample dapperExample = new DapperExample();
//dapperExample.Run();
EFCoreExample eFCoreExample = new EFCoreExample();
eFCoreExample.Run();

Console.ReadLine();
