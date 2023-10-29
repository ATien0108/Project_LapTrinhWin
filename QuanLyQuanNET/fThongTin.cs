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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyQuanNET
{
    public partial class fThongTin : Form
    {
        string username, password;
        SqlConnection conn = null;
        string strConnectionString;
        public fThongTin(string username, string password)
        {
            strConnectionString = $"Data Source=DESKTOP-I0SB6R7;Initial Catalog=QuanLyQuanNET; Integrated Security = True; ";
            InitializeComponent();
            this.username = username;
            this.password = password;
        }
        private void fThongTin_Load(object sender, EventArgs e)
        {
            hienThiThongTin();
        }
        private void hienThiThongTin()
        {
            using (SqlConnection connection = new SqlConnection(strConnectionString))
            {
                using (SqlCommand command = new SqlCommand("HienThiThongTinKhachHang", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaKhachHang", username);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Lấy dữ liệu từ SqlDataReader
                        string maKhachHang = reader.GetString(0);
                        string hoTen = reader.GetString(1);
                        string soDienThoai = reader.GetString(2);
                        string diaChi = reader.GetString(3);
                        string maTaiKhoan = reader.GetString(4);
                        string tenDangNhap = reader.GetString(6);
                        string matKhau = reader.GetString(7);
                        int soTienDaNap = reader.GetInt32(8);
                        int trangThaiTaiKhoan = reader.GetInt32(9);
                        // Hiển thị thông tin nhân viên trong textbox
                        txtMaKhachHang.Text = maKhachHang;
                        txtTenKhachHang.Text = hoTen;
                        txtDiaChi.Text = diaChi;
                        txtSoDienThoai.Text = soDienThoai;
                        txtMaTaiKhoan.Text = maTaiKhoan;
                        txtTenDangNhap.Text = tenDangNhap;
                        txtMatKhau.Text = matKhau;
                        txtSoTienDaNap.Text = soTienDaNap.ToString();
                        txtTrangThaiTaiKhoan.Text = trangThaiTaiKhoan.ToString();
                    }
                    reader.Close();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn == null)
                    conn = new SqlConnection(strConnectionString);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                txtMaKhachHang.ReadOnly = true;
                txtTenKhachHang.ReadOnly = false;
                txtDiaChi.ReadOnly = false;
                txtSoTienDaNap.ReadOnly = true;
                txtSoDienThoai.ReadOnly = false;
                txtMaTaiKhoan.ReadOnly = true;
                txtTenDangNhap.ReadOnly = true;
                txtMatKhau.ReadOnly = true;
                txtTrangThaiTaiKhoan.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (conn == null)
            {
                conn = new SqlConnection(strConnectionString);
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SuaKhachHang";
                command.Connection = conn;

                command.Parameters.Add("@MaKhachHang", SqlDbType.NVarChar).Value = txtMaKhachHang.Text;
                command.Parameters.Add("@TenKhachHang", SqlDbType.NVarChar).Value = txtTenKhachHang.Text;
                command.Parameters.Add("@SoDienThoai", SqlDbType.NVarChar).Value = txtSoDienThoai.Text;
                command.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtDiaChi.Text;

                int n = command.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("Sửa Thành Công");
                    hienThiThongTin();
                }
                else
                {
                    MessageBox.Show("Sửa Thất Bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Hủy mọi thao tác?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                fThongTin_Load(this, EventArgs.Empty);

                txtMaKhachHang.ReadOnly = true;
                txtTenKhachHang.ReadOnly = true;
                txtDiaChi.ReadOnly = true;
                txtSoTienDaNap.ReadOnly = true;
                txtSoDienThoai.ReadOnly = true;
                txtMaTaiKhoan.ReadOnly = true;
                txtTenDangNhap.ReadOnly = true;
                txtMatKhau.ReadOnly = true;
                txtTrangThaiTaiKhoan.ReadOnly = true;
            }
        }
    }
}
