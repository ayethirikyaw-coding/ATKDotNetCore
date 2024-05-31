using ATKDotNetCore.Shared;
using ATKDotNetCore.WinFormsApp.Models;
using ATKDotNetCore.WinFormsApp.Queries;

namespace ATKDotNetCore.WinFormsApp
{
    public partial class FrmBlog : Form
    {
        private readonly DapperService _dapperService;
        private readonly int _blogId;

        public FrmBlog()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
        }

        public FrmBlog(int id)
        {
            InitializeComponent();
            _blogId = id;
            _dapperService = new DapperService(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);

            var model = _dapperService.QueryFirstOrDefault<BlogModel>("select * from tbl_blog where BlogId = @BlogId",
                new { BlogId = _blogId });

            txtAuthor.Text = model.BlogAuthor;
            txtTitle.Text = model.BlogTitle;
            txtContent.Text = model.BlogContent;

            btnSave.Visible = false;
            btnUpdate.Visible = true;
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                BlogModel blog = new BlogModel()
                {
                    BlogId = _blogId,
                    BlogAuthor = txtAuthor.Text.Trim(),
                    BlogTitle = txtTitle.Text.Trim(),
                    BlogContent = txtContent.Text.Trim()
                };

                var result = _dapperService.Execute(BlogQuery.BlogListUpdate, blog);
                string message = result > 0 ? "Updating Successful." : "Updating failed.";
                MessageBox.Show(message);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
