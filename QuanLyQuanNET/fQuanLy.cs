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
    public partial class fQuanLy : Form
    {
        string username;
        string password;
        public fQuanLy(string username, string password)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
        }

        private void tsbMayTinh_Click(object sender, EventArgs e)
        {
            panelTong.Controls.Clear();
            fQLMayTinh maytinh = new fQLMayTinh(username, password);
            maytinh.TopLevel = false;
            maytinh.FormBorderStyle = FormBorderStyle.None;
            panelTong.Controls.Add(maytinh);
            maytinh.Show();
        }

        private void tsbKhachHang_Click(object sender, EventArgs e)
        {
            panelTong.Controls.Clear();
            fQLKhachHang khachhang = new fQLKhachHang(username, password);
            khachhang.TopLevel = false;
            khachhang.FormBorderStyle = FormBorderStyle.None;
            panelTong.Controls.Add(khachhang);
            khachhang.Show();
        }

        private void tsbNhanVien_Click(object sender, EventArgs e)
        {
            panelTong.Controls.Clear();
            fQLNhanVien nhanvien = new fQLNhanVien(username, password);
            nhanvien.TopLevel = false;
            nhanvien.FormBorderStyle = FormBorderStyle.None;
            panelTong.Controls.Add(nhanvien);
            nhanvien.Show();
        }

        private void tsbDichVu_Click(object sender, EventArgs e)
        {
            panelTong.Controls.Clear();
            fQLDichVu dichvu = new fQLDichVu(username, password);
            dichvu.TopLevel = false;
            dichvu.FormBorderStyle = FormBorderStyle.None;
            panelTong.Controls.Add(dichvu);
            dichvu.Show();
        }

        private void tsbHoaDonMT_Click(object sender, EventArgs e)
        {
            panelTong.Controls.Clear();
            fQLHoaDonMayTinh hoadonmaytinh = new fQLHoaDonMayTinh(username, password);
            hoadonmaytinh.TopLevel = false;
            hoadonmaytinh.FormBorderStyle = FormBorderStyle.None;
            panelTong.Controls.Add(hoadonmaytinh);
            hoadonmaytinh.Show();
        }
        private void tsbHoaDonDV_Click(object sender, EventArgs e)
        {
            panelTong.Controls.Clear();
            fQLHoaDonDichVu hoadondichvu = new fQLHoaDonDichVu(username, password);
            hoadondichvu.TopLevel = false;
            hoadondichvu.FormBorderStyle = FormBorderStyle.None;
            panelTong.Controls.Add(hoadondichvu);
            hoadondichvu.Show();
        }
        private void tsbThongKe_Click(object sender, EventArgs e)
        {
            panelTong.Controls.Clear();
            fQLThongKe thongke = new fQLThongKe(username, password);
            thongke.TopLevel = false;
            thongke.FormBorderStyle = FormBorderStyle.None;
            panelTong.Controls.Add(thongke);
            thongke.Show();
        }

        private void tsbCacMucKhac_Click(object sender, EventArgs e)
        {
            panelTong.Controls.Clear();
            fQLMucKhac cacmuckhac = new fQLMucKhac(username, password);
            cacmuckhac.TopLevel = false;
            cacmuckhac.FormBorderStyle = FormBorderStyle.None;
            panelTong.Controls.Add(cacmuckhac);
            cacmuckhac.Show();
        }

        private void tsbThongTin_Click(object sender, EventArgs e)
        {
            panelTong.Controls.Clear();
            fQLThongTin thongtin = new fQLThongTin(username, password);
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
