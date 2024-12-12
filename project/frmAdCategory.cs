using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace project
{
    public partial class frmAdCategory : Form
    {
        public frmAdCategory()
        {
            InitializeComponent();
        }

        private void frmAdCategory_Load(object sender, EventArgs e)
        {
            load();
        }

        //ham load thong tin
        private void load()
        {
            try
            {
                DataProvider provider = new DataProvider();
                DataTable table = provider.loadCategory();
                dgvResult.DataSource = table;
            }
            catch
            {
                MessageBox.Show("Không thể tải dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Them moi
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text != "")
                {
                    DataProvider provider = new DataProvider();
                    provider.AddCate(txtName.Text);
                    MessageBox.Show("Thêm thành công!", "Đã thêm",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    txtName.ResetText();
                    load();
                }
                else
                {
                    MessageBox.Show("Tên mới trống!", "Thiếu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Khi click chon => datagidview
        private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int t = dgvResult.CurrentCell.RowIndex;
            lblText.Text = dgvResult.Rows[t].Cells[0].Value.ToString();
        }

        //Xoa 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    //Nhan yes
                    DataProvider provider = new DataProvider();
                    provider.DelCate(lblText.Text);
                    MessageBox.Show("Xóa thành công!", "Đã xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load();
                }
                //nhan no
            }
            catch
            {
                MessageBox.Show("Không thể xóa danh mục này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //cHINH SUA
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                DataProvider provider = new DataProvider();
                provider.UpdateCate(txtName.Text,lblText.Text);
                MessageBox.Show("Sửa thành công!", "Đã sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load();
                txtName.ResetText();
            }
            catch
            {
                MessageBox.Show("Không thể chỉnh sửa danh mục này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
