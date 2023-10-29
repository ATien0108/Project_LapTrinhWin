using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanNET
{
    public partial class fQLKhachHang : Form
    {
        int Flag = 0;
        int FlagTK = 1;
        SqlConnection conn = null;
        string strConnectionString;
        public fQLKhachHang(string username, string password)
        {
            strConnectionString = $"Data Source=DESKTOP-I0SB6R7;Initial Catalog=QuanLyQuanNET;" +
                    $"User ID={username};" +
                    $"Password={password};";
            InitializeComponent();
        }

        private void fQLKhachHang_Load(object sender, EventArgs e)
        {
            HienThiKhachHang();
            HienThiTaiKhoanKH();

            txtMaKhachHang.ReadOnly= true;
            txtTenKhachHang.ReadOnly= true;
            txtSoDienThoai.ReadOnly= true;
            txtDiaChi.ReadOnly= true;
            txtMaTaiKhoan.ReadOnly= true;
            txtMaKhachHangTK.ReadOnly= true;
            txtTenDangNhap.ReadOnly= true;
            txtMatKhau.ReadOnly= true;
            txtSoTienDaNap.ReadOnly= true;
            txtTrangThaiTaiKhoan.ReadOnly= true;
        }

        private void HienThiKhachHang()
        {
            try
            {
                if (conn == null)
                {
                    conn = new SqlConnection(strConnectionString);
                }

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM View_KhachHang ";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvKhachHang.Items.Clear();
                while (reader.Read())
                {
                    string MaKhachHang = reader.IsDBNull(0) ? null : reader.GetString(0);
                    string TenKhachHang = reader.IsDBNull(1) ? null : reader.GetString(1);
                    string SoDienThoai = reader.IsDBNull(2) ? null : reader.GetString(2);
                    string DiaChi = reader.IsDBNull(3) ? null : reader.GetString(3);
    

                    ListViewItem lvi = new ListViewItem(MaKhachHang ?? "NULL");
                    lvi.SubItems.Add(TenKhachHang ?? "NULL");
                    lvi.SubItems.Add(SoDienThoai?? "NULL");
                    lvi.SubItems.Add(DiaChi ?? "NULL");


                    lsvKhachHang.Items.Add(lvi);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            };
        }

        private void HienThiTaiKhoanKH()
        {
            try
            {
                if (conn == null)
                {
                    conn = new SqlConnection(strConnectionString);
                }

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM View_TaiKhoan_KhachHang ";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvTaiKhoanKhachHang.Items.Clear();
                while (reader.Read())
                {
                    string MaTaiKhoan = reader.IsDBNull(0) ? null : reader.GetString(0);
                    string MaKhachHang = reader.IsDBNull(1) ? null : reader.GetString(1);
                    string TenDangNhap = reader.IsDBNull(2) ? null : reader.GetString(2);
                    string MatKhau = reader.IsDBNull(3) ? null : reader.GetString(3);
                    int? SoTienDaNap = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4);
                    int? TrangThaiTaiKhoan = reader.IsDBNull(5) ? (int?)null : reader.GetInt32(5);


                    ListViewItem lvi = new ListViewItem(MaTaiKhoan ?? "NULL");
                    lvi.SubItems.Add(MaKhachHang ?? "NULL");
                    lvi.SubItems.Add(TenDangNhap ?? "NULL");
                    lvi.SubItems.Add(MatKhau ?? "NULL");
                    lvi.SubItems.Add(SoTienDaNap?.ToString() ?? "NULL");
                    lvi.SubItems.Add(TrangThaiTaiKhoan?.ToString() ?? "NULL");


                    lsvTaiKhoanKhachHang.Items.Add(lvi);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            };
        }

        private void lsvKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvKhachHang.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvKhachHang.SelectedItems[0];
            string MaKhachHang = lvi.SubItems[0].Text.Trim();

            HienThiChiTietKhachHang(MaKhachHang);
        }

        private void HienThiChiTietKhachHang(string maKhachHang)
        {
            try
            {
                if (conn == null)
                {
                    conn = new SqlConnection(strConnectionString);
                }
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "HienThiKhachHang";
                command.Connection = conn;

                SqlParameter parMaKhachHang = new SqlParameter("@MaKhachHang", SqlDbType.NVarChar);
                parMaKhachHang.Value = maKhachHang;
                command.Parameters.Add(parMaKhachHang);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaKhachHang.Text = reader.IsDBNull(0) ? "NULL" : reader.GetString(0);
                    txtTenKhachHang.Text = reader.IsDBNull(1) ? "NULL" : reader.GetString(1);
                    txtSoDienThoai.Text = reader.IsDBNull(2) ? "NULL" : reader.GetString(2);
                    txtDiaChi.Text = reader.IsDBNull(3) ? "NULL" : reader.GetString(3);

                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void lsvTaiKhoanKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvTaiKhoanKhachHang.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvTaiKhoanKhachHang.SelectedItems[0];
            string MaTaiKhoanKH = lvi.SubItems[0].Text.Trim();

            HienThiChiTietTaiKhoanKH(MaTaiKhoanKH);
        }

        private void HienThiChiTietTaiKhoanKH(string maTaiKhoanKH)
        {
            try
            {
                if (conn == null)
                {
                    conn = new SqlConnection(strConnectionString);
                }
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "HienThiTaiKhoanKH";
                command.Connection = conn;

                SqlParameter parMaTaiKhoanKH = new SqlParameter("@MaTaiKhoan", SqlDbType.NVarChar);
                parMaTaiKhoanKH.Value = maTaiKhoanKH;
                command.Parameters.Add(parMaTaiKhoanKH);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaTaiKhoan.Text = reader.IsDBNull(0) ? "NULL" : reader.GetString(0);
                    txtMaKhachHangTK.Text = reader.IsDBNull(1) ? "NULL" : reader.GetString(1);
                    txtTenDangNhap.Text = reader.IsDBNull(2) ? "NULL" : reader.GetString(2);
                    txtMatKhau.Text = reader.IsDBNull(3) ? "NULL" : reader.GetString(3);
                    txtSoTienDaNap.Text = reader.IsDBNull(4) ? "NULL" : reader.GetInt32(4).ToString();
                    txtTrangThaiTaiKhoan.Text = reader.IsDBNull(5) ? "NULL" : reader.GetInt32(5).ToString();

                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Flag = 1;
            try
            {
                if (conn == null)
                {
                    conn = new SqlConnection(strConnectionString);
                }
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                txtMaKhachHang.ReadOnly = true;
                txtTenKhachHang.ReadOnly = false;
                txtSoDienThoai.ReadOnly = false;
                txtDiaChi.ReadOnly = false;

                txtDiaChi.Text = string.Empty;
                txtTenKhachHang.Text = string.Empty;
                txtMaKhachHang.Text = string.Empty;
                txtSoDienThoai.Text = string.Empty;

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Flag = 2;
            try
            {
                if (conn == null)
                    conn = new SqlConnection(strConnectionString);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                txtMaKhachHang.ReadOnly = false;
                txtTenKhachHang.ReadOnly = false;
                txtSoDienThoai.ReadOnly = false;
                txtDiaChi.ReadOnly = false;

            }
            catch (SqlException ex)
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
            if (Flag == 1)
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ThemKhachHang";
                    command.Connection = conn;

                    command.Parameters.Add("@TenKhachHang", SqlDbType.NVarChar).Value = txtTenKhachHang.Text;
                    command.Parameters.Add("@SoDienThoai", SqlDbType.NVarChar).Value = txtSoDienThoai.Text;
                    command.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtDiaChi.Text;

                    int n = command.ExecuteNonQuery();
                    if (n > 0)
                    {

                        MessageBox.Show("Lưu Thành Công");
                    }
                    else
                    {
                        MessageBox.Show("Lưu Thất Bại");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            if (Flag == 2)
            {
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
                    }
                    else
                    {
                        MessageBox.Show("Sửa Thất Bại");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            HienThiKhachHang();

            txtMaKhachHang.ReadOnly = true;
            txtTenKhachHang.ReadOnly = true;
            txtSoDienThoai.ReadOnly = true;
            txtDiaChi.ReadOnly = true;

            txtMaKhachHang.Clear();
            txtTenKhachHang.Clear();
            txtSoDienThoai.Clear();
            txtDiaChi.Clear();
        }

        private void btnThemTK_Click(object sender, EventArgs e)
        {
            FlagTK = 1;
            try
            {
                if (conn == null)
                {
                    conn = new SqlConnection(strConnectionString);
                }
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                txtMaTaiKhoan.ReadOnly = false;
                txtMaKhachHangTK.ReadOnly = false;
                txtTenDangNhap.ReadOnly = false;
                txtSoTienDaNap.ReadOnly = false;
                txtTrangThaiTaiKhoan.ReadOnly = false;
                txtMatKhau.ReadOnly = false;

                txtMaTaiKhoan.Text = string.Empty;
                txtMaKhachHangTK.Text = string.Empty;
                txtTenDangNhap.Text = string.Empty;
                txtSoTienDaNap.Text = string.Empty;
                txtTrangThaiTaiKhoan.Text = string.Empty;
                txtMatKhau.Text = string.Empty;

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnSuaTK_Click(object sender, EventArgs e)
        {
            FlagTK = 2;
            try
            {
                if (conn == null)
                    conn = new SqlConnection(strConnectionString);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                txtMaTaiKhoan.ReadOnly = false;
                txtMaKhachHangTK.ReadOnly = false;
                txtTenDangNhap.ReadOnly = false;
                txtSoTienDaNap.ReadOnly = false;
                txtTrangThaiTaiKhoan.ReadOnly=false;
                txtMatKhau.ReadOnly = false;

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnLuuTK_Click(object sender, EventArgs e)
        {
            if (conn == null)
            {
                conn = new SqlConnection(strConnectionString);
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            if (FlagTK == 1)
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ThemTaiKhoanKhachHang";
                    command.Connection = conn;

                    command.Parameters.Add("@MaTaiKhoan", SqlDbType.NVarChar).Value = txtMaTaiKhoan.Text;
                    command.Parameters.Add("@MaKhachHang", SqlDbType.NVarChar).Value = txtMaKhachHangTK.Text;
                    command.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar).Value = txtTenDangNhap.Text;
                    command.Parameters.Add("@SoTienDaNap", SqlDbType.Int).Value = int.Parse(txtSoTienDaNap.Text);
                    command.Parameters.Add("@TrangThaiTaiKhoan", SqlDbType.Int).Value = int.Parse(txtTrangThaiTaiKhoan.Text);
                    command.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = txtMatKhau.Text;


                    int n = command.ExecuteNonQuery();
                    if (n > 0)
                    {

                        MessageBox.Show("Lưu Thành Công");
                    }
                    else
                    {
                        MessageBox.Show("Lưu Thất Bại");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            if (FlagTK == 2)
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SuaTaiKhoanKhachHang";
                    command.Connection = conn;

                    command.Parameters.Add("@MaTaiKhoan", SqlDbType.VarChar).Value = txtMaTaiKhoan.Text;
                    command.Parameters.Add("@MaKhachHang", SqlDbType.VarChar).Value = txtMaKhachHangTK.Text;
                    command.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar).Value = txtTenDangNhap.Text;
                    command.Parameters.Add("@SoTienDaNap", SqlDbType.Int).Value = int.Parse(txtSoTienDaNap.Text);
                    command.Parameters.Add("@TrangThaiTaiKhoan", SqlDbType.Int).Value = int.Parse(txtTrangThaiTaiKhoan.Text);
                    command.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = txtMatKhau.Text;

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    int n = command.ExecuteNonQuery();
                    if (n > 0)
                    {
                        MessageBox.Show("Sửa Thành Công");
                    }
                    else
                    {
                        MessageBox.Show("Sửa Thất Bại");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnTaiLaiTK_Click(object sender, EventArgs e)
        {
            HienThiTaiKhoanKH();

            txtMaTaiKhoan.ReadOnly = true;
            txtMaKhachHangTK.ReadOnly = true;
            txtTenDangNhap.ReadOnly = true;
            txtMatKhau.ReadOnly = true;
            txtSoTienDaNap.ReadOnly = true;
            txtTrangThaiTaiKhoan.ReadOnly = true;

            txtMaTaiKhoan.Clear();
            txtMaKhachHangTK.Clear();
            txtTenDangNhap.Clear();
            txtSoTienDaNap.Clear();
            txtTrangThaiTaiKhoan.Clear();
            txtMatKhau.Clear();
        }

        private void rbMaKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbMaKhachHang.Checked)
                {
                    // Truy vấn dữ liệu từ cơ sở dữ liệu theo tên sách và đổ vào ComboBox
                    cbTimKiem.Items.Clear();
                    string query = "SELECT MaKhachHang FROM KhachHang";
                    using (SqlConnection connection = new SqlConnection(strConnectionString))
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbTimKiem.Items.Add(reader.GetString(0));
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void rbTenKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbTenKhachHang.Checked)
                {
                    // Truy vấn dữ liệu từ cơ sở dữ liệu theo tên sách và đổ vào ComboBox
                    cbTimKiem.Items.Clear();
                    string query = "SELECT TenKhachHang FROM KhachHang";
                    using (SqlConnection connection = new SqlConnection(strConnectionString))
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbTimKiem.Items.Add(reader.GetString(0));
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string HoTen = cbTimKiem.Text.Trim();
            string MaKH = cbTimKiem.Text.Trim();

            try
            {
                if (conn == null)
                {
                    conn = new SqlConnection(strConnectionString);
                }
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text; // Thay đổi kiểu CommandType
                command.CommandText = "SELECT * FROM TimKiemKhachHang(@MaKhachHang, @TenKhachHang)"; // Sử dụng câu truy vấn SELECT để lấy dữ liệu từ function

                command.Parameters.AddWithValue("@MaKhachHang", "%" + MaKH + "%");
                command.Parameters.AddWithValue("@TenKhachHang", "%" + HoTen + "%");

                SqlDataReader reader = command.ExecuteReader();

                lsvKhachHang.Items.Clear();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader.GetString(0));
                    item.SubItems.Add(reader.GetString(1));
                    item.SubItems.Add(reader.GetString(2));
                    item.SubItems.Add(reader.GetString(3));

                    lsvKhachHang.Items.Add(item);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
