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
    public partial class fQLNhanVien : Form
    {
        int Flag = 0;
        int FlagTK = 0;
        SqlConnection conn = null;
        string strConnectionString;
        public fQLNhanVien(string username, string password)
        {
            strConnectionString = $"Data Source=DESKTOP-I0SB6R7;Initial Catalog=QuanLyQuanNET;" +
                     $"User ID={username};" +
                     $"Password={password};";
            InitializeComponent();
        }

        private void fQLNhanVien_Load(object sender, EventArgs e)
        {
            HienThiNhanVien();
            HienThiTaiKhoanNV();

            txtMaNhanVien.ReadOnly= true;
            txtTenNhanVien.ReadOnly= true;
            txtSoDienThoai.ReadOnly= true;
            txtDiaChi.ReadOnly= true;
            txtMaChucVu.ReadOnly= true;
            txtMaTaiKhoan.ReadOnly= true;
            txtMaNhanVienTK.ReadOnly= true;
            txtTenDangNhap.ReadOnly= true;
            txtMatKhau.ReadOnly= true;
        }

        private void HienThiNhanVien()
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
                command.CommandText = "SELECT * FROM View_NhanVien ";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvNhanVien.Items.Clear();
                while (reader.Read())
                {
                    string MaNhanVien = reader.IsDBNull(0) ? null : reader.GetString(0);
                    string TenNhanVien = reader.IsDBNull(1) ? null : reader.GetString(1);
                    string SoDienThoai = reader.IsDBNull(2) ? null : reader.GetString(2);
                    string DiaChi = reader.IsDBNull(3) ? null : reader.GetString(3);
                    string MaChucVu = reader.IsDBNull(4) ? null : reader.GetString(4);

                    ListViewItem lvi = new ListViewItem(MaNhanVien ?? "NULL");
                    lvi.SubItems.Add(TenNhanVien ?? "NULL");
                    lvi.SubItems.Add(SoDienThoai ?? "NULL");
                    lvi.SubItems.Add(DiaChi ?? "NULL");
                    lvi.SubItems.Add(MaChucVu ?? "NULL");

                    lsvNhanVien.Items.Add(lvi);
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

        private void HienThiTaiKhoanNV()
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
                command.CommandText = "SELECT * FROM View_TaiKhoan_NhanVien ";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvTaiKhoanNhanVien.Items.Clear();
                while (reader.Read())
                {
                    string MaTaiKhoan = reader.IsDBNull(0) ? null : reader.GetString(0);
                    string MaNhanVien = reader.IsDBNull(1) ? null : reader.GetString(1);
                    string TenDangNhap = reader.IsDBNull(2) ? null : reader.GetString(2);
                    string MatKhau = reader.IsDBNull(3) ? null : reader.GetString(3);

                    ListViewItem lvi = new ListViewItem(MaTaiKhoan ?? "NULL");
                    lvi.SubItems.Add(MaNhanVien ?? "NULL");
                    lvi.SubItems.Add(TenDangNhap ?? "NULL");
                    lvi.SubItems.Add(MatKhau ?? "NULL");

                    lsvTaiKhoanNhanVien.Items.Add(lvi);
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

        private void lsvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvNhanVien.SelectedItems.Count == 0) return;

            ListViewItem lvi =lsvNhanVien.SelectedItems[0];
            string MaNhanVien = lvi.SubItems[0].Text.Trim();

            HienThiChiTietNhanVien(MaNhanVien);
        }

        private void HienThiChiTietNhanVien(string maNhanVien)
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
                command.CommandText = "HienThiNhanVien";
                command.Connection = conn;

                SqlParameter parMaNhanVien = new SqlParameter("@MaNhanVien", SqlDbType.NVarChar);
                parMaNhanVien.Value = maNhanVien;
                command.Parameters.Add(parMaNhanVien);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaNhanVien.Text = reader.IsDBNull(0) ? "NULL" : reader.GetString(0);
                    txtTenNhanVien.Text = reader.IsDBNull(1) ? "NULL" : reader.GetString(1);
                    txtSoDienThoai.Text = reader.IsDBNull(2) ? "NULL" : reader.GetString(2);
                    txtDiaChi.Text = reader.IsDBNull(3) ? "NULL" : reader.GetString(3);
                    txtMaChucVu.Text = reader.IsDBNull(4) ? "NULL" : reader.GetString(4);

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

        private void lsvTaiKhoanNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvTaiKhoanNhanVien.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvTaiKhoanNhanVien.SelectedItems[0];
            string MaTaiKhoan = lvi.SubItems[0].Text.Trim();

            HienThiChiTietTaiKhoanNV(MaTaiKhoan);
        }

        private void HienThiChiTietTaiKhoanNV(string maTaiKhoan)
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
                command.CommandText = "HienThiTaiKhoanNV";
                command.Connection = conn;

                SqlParameter parMaTaiKhoan = new SqlParameter("@MaTaiKhoan", SqlDbType.NVarChar);
                parMaTaiKhoan.Value = maTaiKhoan;
                command.Parameters.Add(parMaTaiKhoan);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaTaiKhoan.Text = reader.IsDBNull(0) ? "NULL" : reader.GetString(0);
                    txtMaNhanVienTK.Text = reader.IsDBNull(1) ? "NULL" : reader.GetString(1);
                    txtTenDangNhap.Text = reader.IsDBNull(2) ? "NULL" : reader.GetString(2);
                    txtMatKhau.Text = reader.IsDBNull(3) ? "NULL" : reader.GetString(3);

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
                txtMaNhanVien.ReadOnly = true;
                txtTenNhanVien.ReadOnly = false;
                txtSoDienThoai.ReadOnly = false;
                txtDiaChi.ReadOnly = false;
                txtMaChucVu.ReadOnly= false;

                txtDiaChi.Text = string.Empty;
                txtMaNhanVien.Text = string.Empty;
                txtTenNhanVien.Text = string.Empty;
                txtSoDienThoai.Text = string.Empty;
                txtMaChucVu.Text = string.Empty;

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

                txtMaNhanVien.ReadOnly = false;
                txtTenNhanVien.ReadOnly = false;
                txtSoDienThoai.ReadOnly = false;
                txtDiaChi.ReadOnly = false;
                txtMaChucVu.ReadOnly= false;

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
                    command.CommandText = "ThemNhanVien";
                    command.Connection = conn;

                    command.Parameters.Add("@TenNhanVien", SqlDbType.NVarChar).Value = txtTenNhanVien.Text;
                    command.Parameters.Add("@SoDienThoai", SqlDbType.NVarChar).Value = txtSoDienThoai.Text;
                    command.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtDiaChi.Text;
                    command.Parameters.Add("@MaChucVu", SqlDbType.NVarChar).Value = txtMaChucVu.Text;

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
                    command.CommandText = "CapNhatNhanVien";
                    command.Connection = conn;

                    command.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = txtMaNhanVien.Text;
                    command.Parameters.Add("@TenNhanVIen", SqlDbType.NVarChar).Value = txtTenNhanVien.Text;
                    command.Parameters.Add("@SoDienThoai", SqlDbType.NVarChar).Value = txtSoDienThoai.Text;
                    command.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtDiaChi.Text;
                    command.Parameters.Add("@MaChucVu", SqlDbType.NVarChar).Value = txtMaChucVu.Text;


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
            HienThiNhanVien();

            txtMaNhanVien.ReadOnly = true;
            txtTenNhanVien.ReadOnly = true;
            txtSoDienThoai.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtMaChucVu.ReadOnly = true;

            txtMaNhanVien.Clear();
            txtTenNhanVien.Clear();
            txtSoDienThoai.Clear();
            txtDiaChi.Clear();
            txtMaChucVu.Clear();
        }

        private void btnThemTKNV_Click(object sender, EventArgs e)
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
                txtMaNhanVienTK.ReadOnly = false;
                txtTenDangNhap.ReadOnly = false;
                txtMatKhau.ReadOnly = false;

                txtMaTaiKhoan.Text = string.Empty;
                txtMaNhanVienTK.Text = string.Empty;
                txtTenDangNhap.Text = string.Empty;
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

        private void btnSuaTKNV_Click(object sender, EventArgs e)
        {
            FlagTK = 2;
            try
            {
                if (conn == null)
                    conn = new SqlConnection(strConnectionString);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                txtMaTaiKhoan.ReadOnly = true;
                txtMaNhanVienTK.ReadOnly = true;
                txtTenDangNhap.ReadOnly = true;
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

        private void btnLuuTKNV_Click(object sender, EventArgs e)
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
                    command.CommandText = "ThemTaiKhoanNhanVien";
                    command.Connection = conn;

                    command.Parameters.Add("@MaTaiKhoan", SqlDbType.NVarChar).Value = txtMaTaiKhoan.Text;
                    command.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = txtMaNhanVienTK.Text;
                    command.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar).Value = txtTenDangNhap.Text;
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
                    command.CommandText = "SuaTaiKhoanNhanVien";
                    command.Connection = conn;

                    command.Parameters.Add("@MaTaiKhoan", SqlDbType.NVarChar).Value = txtMaTaiKhoan.Text;
                    command.Parameters.Add("@MaNhanVien", SqlDbType.NVarChar).Value = txtMaNhanVienTK.Text;
                    command.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar).Value = txtTenDangNhap.Text;
                    command.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = txtMatKhau.Text;


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

        private void btnTaiLaiTKNV_Click(object sender, EventArgs e)
        {
            HienThiTaiKhoanNV();

            txtMaTaiKhoan.ReadOnly = true;
            txtMaNhanVienTK.ReadOnly = true;
            txtTenDangNhap.ReadOnly = true;
            txtMatKhau.ReadOnly = true;

            txtMaTaiKhoan.Clear();
            txtMaNhanVienTK.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
        }

        private void rbMaNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbMaNhanVien.Checked)
                {
                    // Truy vấn dữ liệu từ cơ sở dữ liệu theo tên sách và đổ vào ComboBox
                    cbTimKiem.Items.Clear();
                    string query = "SELECT MaNhanVien FROM NhanVien";
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

        private void rbTenNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbTenNhanVien.Checked)
                {
                    // Truy vấn dữ liệu từ cơ sở dữ liệu theo tên sách và đổ vào ComboBox
                    cbTimKiem.Items.Clear();
                    string query = "SELECT TenNhanVien FROM NhanVien";
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

        private void rbMaChucVu_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbMaChucVu.Checked)
                {
                    // Truy vấn dữ liệu từ cơ sở dữ liệu theo tên sách và đổ vào ComboBox
                    cbTimKiem.Items.Clear();
                    string query = "SELECT DISTINCT MaChucVu FROM NhanVien";
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
            string tenNhanVien = cbTimKiem.Text.Trim();
            string maNhanVien = cbTimKiem.Text.Trim();
            string maChucVu = cbTimKiem.Text.Trim();

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
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM TimKiemNhanVien(@TenNhanVien, @MaNhanVien, @MaChucVu)";

                command.Parameters.AddWithValue("@TenNhanVien", "%" + tenNhanVien + "%");
                command.Parameters.AddWithValue("@MaNhanVien", "%" + maNhanVien + "%");
                command.Parameters.AddWithValue("@MaChucVu", "%" + maChucVu + "%");

                SqlDataReader reader = command.ExecuteReader();

                lsvNhanVien.Items.Clear();

                int rowCount = 0;

                while (reader.Read())
                {
                    rowCount++;

                    ListViewItem item = new ListViewItem(reader.GetString(0));
                    item.SubItems.Add(reader.GetString(1));
                    item.SubItems.Add(reader.GetString(2));
                    item.SubItems.Add(reader.GetString(3));
                    item.SubItems.Add(reader.GetString(4));

                    lsvNhanVien.Items.Add(item);
                }

                reader.Close();

                if (rowCount == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp.");
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

    }
}
