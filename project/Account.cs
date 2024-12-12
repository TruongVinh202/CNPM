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
    public partial class frmAdAccount : Form
    {
        string oldusername;
        public frmAdAccount()
        {
            InitializeComponent();
        }
        private void Account_Load(object sender, EventArgs e)
        {
            load();
        }
        //ham load thong tin
        private void load()
        {
            DataProvider provider = new DataProvider();
            DataTable table = provider.loadAccount();
            dgvResult.DataSource = table;
        }
        private void clear()
        {
            txtUsername.ResetText();
            txtDisplayname.ResetText();
            txtPassword.ResetText();
            ckbAdmin.Checked = false;
        }
        private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvResult.Rows[e.RowIndex];
                txtUsername.Text = row.Cells[0].Value.ToString();
                oldusername = row.Cells[0].Value.ToString();
                txtDisplayname.Text = row.Cells[1].Value.ToString();
                txtPassword.Text = row.Cells[2].Value.ToString();
                if (row.Cells[3].Value.ToString() == "ADMIN")
                    ckbAdmin.Checked = true;
                else if (row.Cells[3].Value.ToString() == "CASHIER")
                    ckbAdmin.Checked = false;
            }
        }

        //Them tai khoan
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string displayname = txtDisplayname.Text;
                string password = txtPassword.Text;
                string type="CASHIER";
                if (ckbAdmin.Checked == true)
                {
                    type = "ADMIN";        //admin 
                }
                DataProvider provider = new DataProvider();
                provider.AddAccount(username,displayname,password,type);
                MessageBox.Show("Thêm thành công!\n Tài khoản "+displayname+" đã được thêm.", "Đã thêm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load();
                clear();
            }
            catch
            {
                MessageBox.Show("Không thêm được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Xoa tai khoan
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc xóa tài khoản " + oldusername + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    //Nhan yes
                    string name = txtUsername.Text;
                    DataProvider provider = new DataProvider();
                    provider.DelAccount(name);
                    MessageBox.Show("Xóa thành công!\n Tài khoản " + name + " đã được xóa.", "Đã xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load();
                    clear();
                }
                //nhan no
            }
            catch
            {
                MessageBox.Show("Không xóa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Sua tai khoan
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string newusername = txtUsername.Text;
                string newdisplayname = txtDisplayname.Text;
                string newpassword = txtPassword.Text;
                string type="CASHIER";
                if (ckbAdmin.Checked == true)
                {
                    type = "ADMIN";
                }
                DataProvider provider = new DataProvider();
                provider.UpdateAccount(newusername,newdisplayname,newpassword,type,oldusername);
                MessageBox.Show("Chỉnh sửa thành công!\n Tài khoản " + oldusername + " đã chỉnh sửa.", "Đã sửa",MessageBoxButtons.OK,MessageBoxIcon.Information);
                load();
                clear();
            }
            catch
            {
                MessageBox.Show("Không sữa được!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
