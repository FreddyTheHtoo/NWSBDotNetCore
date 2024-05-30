using NWSBDotNetCore.Shared;
using NWSBDotNetCore.WindowFormApp.Models;
using NWSBDotNetCore.WindowFormApp.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
            BlogList();
        }
        
        private void BlogList()
        {
            List<BlogModel> lst = _dapperService.Query<BlogModel>(BlogQuery.BlogList);
            dgvData.DataSource = lst;

        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex == -1) return; // for click on the position x,y(-1,-1) 
            
            var blogId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colId"].Value);

            #region If
            //if (e.ColumnIndex == (int)EnumFormControlType.Edit)
            //{
            //    FrmBlog frmBlog = new FrmBlog(blogId);
            //    frmBlog.ShowDialog();

            //    BlogList();

            //}
            //else if (e.ColumnIndex == (int)EnumFormControlType.Delete)
            //{
            //    var dialogRsult = MessageBox.Show("Are you sure you want to Delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (dialogRsult != DialogResult.Yes) return;


            //    DeleteBlog(blogId);
            //    BlogList();
            //}
            #endregion

            #region switch case
            int index = e.ColumnIndex;
            EnumFormControlType enumFormControlType = (EnumFormControlType)index;
            switch (enumFormControlType)
            {
                
                case EnumFormControlType.Edit:
                    FrmBlog frmBlog = new FrmBlog(blogId);
                    frmBlog.ShowDialog();

                    BlogList();
                    break;
                case EnumFormControlType.Delete:
                    var dialogRsult = MessageBox.Show("Are you sure you want to Delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogRsult != DialogResult.Yes) return;


                    DeleteBlog(blogId);
                    BlogList();
                    break;
                case EnumFormControlType.None:
                default:
                    MessageBox.Show("Invalid Case");
                    break;
            }

            #endregion

        }

        private void DeleteBlog (int id)
        {
            var result = _dapperService.Execute(Queries.BlogQuery.BlogDelete,new { BlogId = id });
            string message = result > 0 ? "Deleteing Successful.." : "Deleting Failed.";
            MessageBox.Show(message);

        }
    }
}
