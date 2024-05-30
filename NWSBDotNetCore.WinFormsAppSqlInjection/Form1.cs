using NWSBDotNetCore.Shared;

namespace NWSBDotNetCore.WinFormsAppSqlInjection
{
    public partial class Form1 : Form
    {
        private readonly DapperService _dapperService;
        public Form1()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string query = $"select * from Tbl_User where Email = @Email and Password = @Password ";
            var model = _dapperService.QueryFirstOrDefault<UserModel>(query, new
            {
                Email = textEmail.Text.Trim(),
                Password = textPassword.Text.Trim()
            });
            if (model == null)
            {
                MessageBox.Show("Invalid User");
                return;
            }

            MessageBox.Show("IsAdmin" + model.Email);
        }
    }
}


public class UserModel
{
    public string Email { get; set; }

    public string Password { get; set; }
    public bool IsAdmin { get; set; }
}