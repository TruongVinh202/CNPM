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
    public partial class ChangePersional : Form
    {
        public ChangePersional()
        {
            InitializeComponent();
        }
        public ChangePersional(string user,string name,string pass):this()
        {
            //load thog tin len
            txtUser.Text = user;
            txtName.Text = name;
            txtPass.Text = pass;
        }

        //Dong
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Luu tt moi
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                Save(txtUser.Text, txtName.Text, txtPass.Text);
                MessageBox.Show("Đã thay đổi", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Thông tin không hợp lệ", "Lỗi...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Ham Luu tt moi
        private void Save(string user,string name,string pass)
        {
            DataProvider provider = new DataProvider();
            provider.resetAccount(name, pass, user);
        }
    }
}
