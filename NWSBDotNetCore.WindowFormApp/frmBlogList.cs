using NWSBDotNetCore.Shared;
using NWSBDotNetCore.WindowFormApp.Models;
using NWSBDotNetCore.WindowFormApp.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NWSBDotNetCore.WindowFormApp
{
    public partial class frmBlogList : Form
    {
        private readonly DapperService _dapperService;
        public frmBlogList()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }

        private void frmBlogList_Load(object sender, EventArgs e)
        {
            List<BlogModel> lst = _dapperService.Query<BlogModel>(BlogQuery.BlogList);
            dgvData.DataSource = lst;
        }
    }
}
