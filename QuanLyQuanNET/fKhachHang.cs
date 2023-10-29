using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanNET
{
    public partial class fKhachHang : Form
    {
        string username;
        string password;
        public fKhachHang(string username, string password)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
        }

        private void tsbMayTinh_Click(object sender, EventArgs e)
        {
            panelTong.Controls.Clear();
            fMayTinh maytinh = new fMayTinh(username);
            maytinh.TopLevel = false;
            maytinh.FormBorderStyle = FormBorderStyle.None;
            panelTong.Controls.Add(maytinh);
            maytinh.Show();
        }

        private void tsbDichVu_Click(object sender, EventArgs e)
        {
            panelTong.Controls.Clear();
            fDichVu dichvu = new fDichVu(username, password);
            dichvu.TopLevel = false;
            dichvu.FormBorderStyle = FormBorderStyle.None;
            panelTong.Controls.Add(dichvu);
            dichvu.Show();
        }

        private void tsbThongTin_Click(object sender, EventArgs e)
        {
            panelTong.Controls.Clear();
            fThongTin thongtin = new fThongTin(username, password);
            thongtin.TopLevel = false;
            thongtin.FormBorderStyle = FormBorderStyle.None;
            panelTong.Controls.Add(thongtin);
            thongtin.Show();
        }

        private void tsbDangXuat_Click(object sender, EventArgs e)
        {
            // Hiển thị message box để xác nhận việc đăng xuất
            DialogResult result = MessageBox.Show("Bạn có thật sự muốn đăng xuất không ?", "Xác nhận đăng xuất", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            // Kiểm tra kết quả trả về từ message box
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
