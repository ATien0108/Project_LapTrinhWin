using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanNET
{
    public partial class fDangNhap : Form
    {
        SqlConnection sqlCon = null;
        string username;
        string password;
        public fDangNhap()
        {
            InitializeComponent();
        }
        private void KetNoiVoiCSDL_NhanVien()
        {
            username = this.txtTenTaiKhoan.Text;
            password = this.txtMatKhau.Text;
            try
            {
                string strCon = $"Data Source=DESKTOP-I0SB6R7;Initial Catalog=QuanLyQuanNET;" +
                    $"User ID={username};" +
                    $"Password={password};";

                sqlCon = new SqlConnection(strCon);

                sqlCon.Open();
                fQuanLy f = new fQuanLy(username, password);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi rồi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlCon.Close();
            }
        }
        private void KetNoiVoiCSDL_KhachHang()
        {
            username = this.txtTenTaiKhoan.Text;
            password = this.txtMatKhau.Text;
            try
            {
                if (KiemTraDangNhap(username, password))
                {
                    fKhachHang kh = new fKhachHang(username, password);
                    this.Hide();
                    kh.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Lỗi: tài khoản hoặc mật khẩu của bạn không đúng ! Hãy kiếm tra lại thông tin ! ", "Lỗi rồi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi rồi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static bool KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            string strCon = $"Data Source = DESKTOP-I0SB6R7; Initial Catalog=QuanLyQuanNET; Integrated Security = True;";

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM TaiKhoan_KhachHang WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    command.Parameters.AddWithValue("@MatKhau", matKhau);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbNhanVien.Checked)
                {
                    // Đăng nhập vào form quản lý nhân viên
                    KetNoiVoiCSDL_NhanVien();
                }
                else if (rbKhachHang.Checked)
                {
                    //// Đăng nhập vào form khách hàng
                    KetNoiVoiCSDL_KhachHang();

                }
                else
                {
                    // Hiển thị thông báo lựa chọn đăng nhập
                    MessageBox.Show("Vui lòng chọn loại tài khoản để đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void fDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát khỏi chương trình không ?", "Thông báo",
                MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        private void cbMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMatKhau.Checked == true)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void fDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
