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
    public partial class fQLThongTin : Form
    {
        string username;
        string password;
        SqlConnection conn = null;
        string strConnectionString;
        public fQLThongTin(string username, string password)
        {
            strConnectionString = $"Data Source=DESKTOP-I0SB6R7;Initial Catalog=QuanLyQuanNET;" +
                   $"User ID={username};" +
                   $"Password={password};";
            InitializeComponent();
            this.username = username;
            this.password = password;
        }
        private void fQLThongTin_Load(object sender, EventArgs e)
        {
            hienThiThongTin();
        }
        private void hienThiThongTin()
        {
            using (SqlConnection connection = new SqlConnection(strConnectionString))
            {
                using (SqlCommand command = new SqlCommand("HienThiThongTinNhanVien", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaNhanVien", username);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Lấy dữ liệu từ SqlDataReader
                        string maNhanVien = reader.GetString(0);
                        string hoTen = reader.GetString(1);
                        string soDienThoai = reader.GetString(2);
                        string diaChi = reader.GetString(3);
                        string maChucVu = reader.GetString(4);
                        string maTaiKhoan = reader.GetString(5);
                        string tenDangNhap = reader.GetString(7);
                        string matKhau = reader.GetString(8);
                        // Hiển thị thông tin nhân viên trong textbox
                        txtMaNhanVien.Text = maNhanVien;
                        txtTenNhanVien.Text = hoTen;
                        txtMaChucVu.Text = maChucVu;
                        txtDiaChi.Text = diaChi;
                        txtSoDienThoai.Text = soDienThoai;
                        txtMaTaiKhoan.Text = maTaiKhoan;
                        txtTenDangNhap.Text = tenDangNhap;
                        txtMatKhau.Text = matKhau;
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

                txtMaNhanVien.ReadOnly = true;
                txtTenNhanVien.ReadOnly = false;
                txtDiaChi.ReadOnly = false;
                txtMaChucVu.ReadOnly = true;
                txtSoDienThoai.ReadOnly = false;
                txtMaTaiKhoan.ReadOnly = true;
                txtTenDangNhap.ReadOnly = true;
                txtMatKhau.ReadOnly = true;
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
                command.CommandText = "CapNhatNhanVien";
                command.Connection = conn;

                command.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = txtMaNhanVien.Text;
                //txtMaSach.Text = command.Parameters["@MaSach"].Value.ToString();
                command.Parameters.Add("@TenNhanVien", SqlDbType.NVarChar).Value = txtTenNhanVien.Text;
                command.Parameters.Add("@SoDienThoai", SqlDbType.NVarChar).Value = txtSoDienThoai.Text;
                command.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtDiaChi.Text;
                command.Parameters.Add("@MaChucVu", SqlDbType.NVarChar).Value = txtMaChucVu.Text;

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
                fQLThongTin_Load(this, EventArgs.Empty);

                txtMaNhanVien.ReadOnly = true;
                txtTenNhanVien.ReadOnly = true;
                txtDiaChi.ReadOnly = true;
                txtMaChucVu.ReadOnly = true;
                txtSoDienThoai.ReadOnly = true;
                txtMaTaiKhoan.ReadOnly = true;
                txtTenDangNhap.ReadOnly = true;
                txtMatKhau.ReadOnly = true;
            }
        }
    }
}
