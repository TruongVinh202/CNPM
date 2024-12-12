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
    public partial class frmAdFood : Form
    {
        string oldname;
        public frmAdFood()
        {
            InitializeComponent();
        }

        private void frmAdFood_Load(object sender, EventArgs e)
        {
            load();
            setNameCategory();
        }
        //cap nhat category de chon
        private void setNameCategory()
        {
            DataProvider provider = new DataProvider();
            DataTable table = provider.loadCategory();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                cbbAddCate.Items.Add(table.Rows[i][0].ToString());
            }
        }

        //ham load thong tin
        private void load()
        {
            try
            {
                DataProvider provider = new DataProvider();
                DataTable table = provider.loadAllFood();
                dgvResult.DataSource = table;
            }
            catch
            {
                MessageBox.Show("Tải không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //reset
        private void clear()
        {
            txtAddName.ResetText();
            cbbAddCate.ResetText();
            nudAddPrice.Value = 1000;
            cbbAddCate.Focus();
        }

        //click table
        private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvResult.Rows[e.RowIndex];
                    txtAddName.Text = row.Cells[0].Value.ToString();
                    oldname = row.Cells[0].Value.ToString();
                    cbbAddCate.Text = row.Cells[1].Value.ToString();
                    nudAddPrice.Value = Int32.Parse(row.Cells[2].Value.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Lỗi data!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //them mon
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtAddName.Text;
                string nameCate = cbbAddCate.Text;
                float price = Convert.ToInt64(nudAddPrice.Value);
                DataProvider provider = new DataProvider();
                provider.AddFood(nameCate,name,price);
                MessageBox.Show("Thêm thành công", "Đã thêm",MessageBoxButtons.OK,MessageBoxIcon.Information);
                clear();
                load();
            }
            catch
            {
                MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Xoa mon
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    //Nhan yes
                    string name = txtAddName.Text;
                    DataProvider provider = new DataProvider();
                    provider.DelFood(name);
                    MessageBox.Show("Xóa thành công!", "Đã xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    load();
                }
                //nhan no
            }
            catch
            {
                MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Sua mon
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string newname = txtAddName.Text;
                string nameCate = cbbAddCate.Text;
                float price = Convert.ToInt32(nudAddPrice.Value);
                DataProvider provider = new DataProvider();
                provider.UpdateFood(nameCate,newname,price,oldname);
                MessageBox.Show("Sửa thành công!", "Đã sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
                load();
            }
            catch
            {
                MessageBox.Show("Sửa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
