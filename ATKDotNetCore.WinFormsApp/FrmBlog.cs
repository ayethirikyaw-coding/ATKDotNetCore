using ATKDotNetCore.Shared;
using ATKDotNetCore.WinFormsApp.Models;
using ATKDotNetCore.WinFormsApp.Queries;

namespace ATKDotNetCore.WinFormsApp
{
    public partial class FrmBlog : Form
    {
        private readonly DapperService _dapperService;
        public FrmBlog()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BlogModel blog = new BlogModel();
            blog.BlogAuthor = txtAuthor.Text.Trim();
            blog.BlogTitle = txtTitle.Text.Trim();
            blog.BlogContent = txtContent.Text.Trim();

            int result = _dapperService.Execute(BlogQuery.BlogCreateQuery, blog);
            string message = result > 0 ? "Saving successful." : "Saving failed";
            var messageBoxIcon = result > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show(message, "Blog", MessageBoxButtons.OK, messageBoxIcon);
            if (result > 0)
                ClearControls();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void ClearControls()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtContent.Clear();

            txtTitle.Focus();
        }
    }
}
