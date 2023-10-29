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
    public partial class fQLDichVu : Form
    {
        int Flag = 0;
        SqlConnection conn = null;
        string strConnectionString;
        public fQLDichVu(string username, string password)
        {
            strConnectionString = $"Data Source=DESKTOP-I0SB6R7;Initial Catalog=QuanLyQuanNET;" +
                    $"User ID={username};" +
                    $"Password={password};";
            InitializeComponent();
        }

        private void fQLDichVu_Load(object sender, EventArgs e)
        {
            HienThiDoUong();
            HienThiDoAnNhanh();
            HienThiCom();
            HienThiTheGameVaDienThoai();
        }

        private void HienThiDoUong()
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
                command.CommandText = "SELECT * FROM View_DichVu_DoUong ";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvDoUong.Items.Clear();
                while (reader.Read())
                {
                    string MaDichVu = reader.IsDBNull(0) ? null : reader.GetString(0);
                    string LoaiDichVu = reader.IsDBNull(1) ? null : reader.GetString(1);
                    string TenSanPham = reader.IsDBNull(2) ? null : reader.GetString(2);
                    int? DonGia = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3);

                    ListViewItem lvi = new ListViewItem(MaDichVu ?? "NULL");
                    lvi.SubItems.Add(LoaiDichVu ?? "NULL");
                    lvi.SubItems.Add(TenSanPham ?? "NULL");
                    lvi.SubItems.Add(DonGia?.ToString() ?? "NULL");

                    lsvDoUong.Items.Add(lvi);
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

        private void HienThiDoAnNhanh()
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
                command.CommandText = "SELECT * FROM View_DichVu_DoAnNhanh ";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvDoAnNhanh.Items.Clear();
                while (reader.Read())
                {
                    string MaDichVu = reader.IsDBNull(0) ? null : reader.GetString(0);
                    string LoaiDichVu = reader.IsDBNull(1) ? null : reader.GetString(1);
                    string TenSanPham = reader.IsDBNull(2) ? null : reader.GetString(2);
                    int? DonGia = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3);

                    ListViewItem lvi = new ListViewItem(MaDichVu ?? "NULL");
                    lvi.SubItems.Add(LoaiDichVu ?? "NULL");
                    lvi.SubItems.Add(TenSanPham ?? "NULL");
                    lvi.SubItems.Add(DonGia?.ToString() ?? "NULL");

                    lsvDoAnNhanh.Items.Add(lvi);
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

        private void HienThiCom()
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
                command.CommandText = "SELECT * FROM View_DichVu_Com ";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvCom.Items.Clear();
                while (reader.Read())
                {
                    string MaDichVu = reader.IsDBNull(0) ? null : reader.GetString(0);
                    string LoaiDichVu = reader.IsDBNull(1) ? null : reader.GetString(1);
                    string TenSanPham = reader.IsDBNull(2) ? null : reader.GetString(2);
                    int? DonGia = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3);

                    ListViewItem lvi = new ListViewItem(MaDichVu ?? "NULL");
                    lvi.SubItems.Add(LoaiDichVu ?? "NULL");
                    lvi.SubItems.Add(TenSanPham ?? "NULL");
                    lvi.SubItems.Add(DonGia?.ToString() ?? "NULL");

                    lsvCom.Items.Add(lvi);
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

        private void HienThiTheGameVaDienThoai()
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
                command.CommandText = "SELECT * FROM View_DichVu_The ";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvTheGameDienThoai.Items.Clear();
                while (reader.Read())
                {
                    string MaDichVu = reader.IsDBNull(0) ? null : reader.GetString(0);
                    string LoaiDichVu = reader.IsDBNull(1) ? null : reader.GetString(1);
                    string TenSanPham = reader.IsDBNull(2) ? null : reader.GetString(2);
                    int? DonGia = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3);

                    ListViewItem lvi = new ListViewItem(MaDichVu ?? "NULL");
                    lvi.SubItems.Add(LoaiDichVu ?? "NULL");
                    lvi.SubItems.Add(TenSanPham ?? "NULL");
                    lvi.SubItems.Add(DonGia?.ToString() ?? "NULL");

                    lsvTheGameDienThoai.Items.Add(lvi);
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

        private void lsvDoUong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvDoUong.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvDoUong.SelectedItems[0];
            string MaDichVu = lvi.SubItems[0].Text.Trim();

            HienThiChiTietDoUong(MaDichVu);
        }

        private void HienThiChiTietDoUong(string maDichVu)
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
                command.CommandText = "HienThiDichVu";
                command.Connection = conn;

                SqlParameter parMaDichVu = new SqlParameter("@MaDichVu", SqlDbType.NVarChar);
                parMaDichVu.Value = maDichVu;
                command.Parameters.Add(parMaDichVu);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaDichVu.Text = reader.IsDBNull(0) ? "NULL" : reader.GetString(0);
                    txtLoaiDichVu.Text = reader.IsDBNull(1) ? "NULL" : reader.GetString(1);
                    txtTenSanPham.Text = reader.IsDBNull(2) ? "NULL" : reader.GetString(2);
                    txtDonGia.Text = reader.IsDBNull(3) ? "NULL" : reader.GetInt32(3).ToString();

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

        private void lsvDoAnNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvDoAnNhanh.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvDoAnNhanh.SelectedItems[0];
            string MaDichVu = lvi.SubItems[0].Text.Trim();

            HienThiChiTietDoAnNhanh(MaDichVu);
        }

        private void HienThiChiTietDoAnNhanh(string maDichVu)
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
                command.CommandText = "HienThiDichVu";
                command.Connection = conn;

                SqlParameter parMaDichVu = new SqlParameter("@MaDichVu", SqlDbType.NVarChar);
                parMaDichVu.Value = maDichVu;
                command.Parameters.Add(parMaDichVu);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaDichVu.Text = reader.IsDBNull(0) ? "NULL" : reader.GetString(0);
                    txtLoaiDichVu.Text = reader.IsDBNull(1) ? "NULL" : reader.GetString(1);
                    txtTenSanPham.Text = reader.IsDBNull(2) ? "NULL" : reader.GetString(2);
                    txtDonGia.Text = reader.IsDBNull(3) ? "NULL" : reader.GetInt32(3).ToString();

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

        private void lsvCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvCom.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvCom.SelectedItems[0];
            string MaDichVu = lvi.SubItems[0].Text.Trim();

            HienThiChiTietCom(MaDichVu);
        }

        private void HienThiChiTietCom(string maDichVu)
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
                command.CommandText = "HienThiDichVu";
                command.Connection = conn;

                SqlParameter parMaDichVu = new SqlParameter("@MaDichVu", SqlDbType.NVarChar);
                parMaDichVu.Value = maDichVu;
                command.Parameters.Add(parMaDichVu);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaDichVu.Text = reader.IsDBNull(0) ? "NULL" : reader.GetString(0);
                    txtLoaiDichVu.Text = reader.IsDBNull(1) ? "NULL" : reader.GetString(1);
                    txtTenSanPham.Text = reader.IsDBNull(2) ? "NULL" : reader.GetString(2);
                    txtDonGia.Text = reader.IsDBNull(3) ? "NULL" : reader.GetInt32(3).ToString();

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

        private void lsvTheGameDienThoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvTheGameDienThoai.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvTheGameDienThoai.SelectedItems[0];
            string MaDichVu = lvi.SubItems[0].Text.Trim();

            HienThiChiTietTheGameVaDienThoai(MaDichVu);
        }

        private void HienThiChiTietTheGameVaDienThoai(string maDichVu)
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
                command.CommandText = "HienThiDichVu";
                command.Connection = conn;

                SqlParameter parMaDichVu = new SqlParameter("@MaDichVu", SqlDbType.NVarChar);
                parMaDichVu.Value = maDichVu;
                command.Parameters.Add(parMaDichVu);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaDichVu.Text = reader.IsDBNull(0) ? "NULL" : reader.GetString(0);
                    txtLoaiDichVu.Text = reader.IsDBNull(1) ? "NULL" : reader.GetString(1);
                    txtTenSanPham.Text = reader.IsDBNull(2) ? "NULL" : reader.GetString(2);
                    txtDonGia.Text = reader.IsDBNull(3) ? "NULL" : reader.GetInt32(3).ToString();

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

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            HienThiDoUong();
            HienThiDoAnNhanh();
            HienThiCom();
            HienThiTheGameVaDienThoai();

            txtDonGia.Clear();
            txtLoaiDichVu.Clear();
            txtMaDichVu.Clear();
            txtMaTaiKhoan.Clear();
            txtSoLuong.Clear();
            txtTenSanPham.Clear();
        }

        private void btnGoiDichVu_Click(object sender, EventArgs e)
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
                command.CommandText = "GoiDichVu";
                command.Connection = conn;


                command.Parameters.Add("@MaTaiKhoan", SqlDbType.NVarChar).Value = txtMaTaiKhoan.Text;
                command.Parameters.Add("@MaDichVu", SqlDbType.NVarChar).Value = txtMaDichVu.Text;
                command.Parameters.Add("@SoLuong", SqlDbType.Int).Value = int.Parse(txtSoLuong.Text);

                int n = command.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("Gọi món Thành Công");
                }
                else
                {
                    MessageBox.Show("Gọi món Thất Bại");
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
                txtMaDichVu.ReadOnly = true;
                txtLoaiDichVu.ReadOnly = false;
                txtTenSanPham.ReadOnly = false;
                txtDonGia.ReadOnly = false;
                txtSoLuong.ReadOnly = false;
                txtMaTaiKhoan.ReadOnly = false;

                txtDonGia.Text = string.Empty;
                txtLoaiDichVu.Text = string.Empty;
                txtMaDichVu.Text = string.Empty;
                txtMaTaiKhoan.Text = string.Empty;
                txtSoLuong.Text = string.Empty;
                txtTenSanPham.Text = string.Empty;

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

                txtMaDichVu.ReadOnly = false;
                txtLoaiDichVu.ReadOnly = false;
                txtTenSanPham.ReadOnly = false;
                txtDonGia.ReadOnly = false;
                txtMaTaiKhoan.ReadOnly = false;
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
                    command.CommandText = "ThemDichVu";
                    command.Connection = conn;

                    command.Parameters.Add("@LoaiDichVu", SqlDbType.NVarChar).Value = txtLoaiDichVu.Text;
                    command.Parameters.Add("@TenSanPham", SqlDbType.NVarChar).Value = txtTenSanPham.Text;
                    command.Parameters.Add("@DonGia", SqlDbType.Int).Value = int.Parse(txtDonGia.Text);

                    int n = command.ExecuteNonQuery();
                    if (n == 0)
                    {
                        MessageBox.Show("Lưu Thất Bại");
                    }
                    else
                    {
                        MessageBox.Show("Lưu Thành Công");
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
                    command.CommandText = "SuaDichVu";
                    command.Connection = conn;

                    command.Parameters.Add("@MaDichVu", SqlDbType.NVarChar).Value = txtMaDichVu.Text;
                    command.Parameters.Add("@LoaiDichVu", SqlDbType.NVarChar).Value = txtLoaiDichVu.Text;
                    command.Parameters.Add("@TenSanPham", SqlDbType.NVarChar).Value = txtTenSanPham.Text;
                    command.Parameters.Add("@DonGia", SqlDbType.Int).Value = int.Parse(txtDonGia.Text);

                    int n = command.ExecuteNonQuery();
                    if (n == 0)
                    {
                        MessageBox.Show("Sửa Thất Bại");
                    }
                    else
                    {
                        MessageBox.Show("Sửa Thành Công");
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

    }
}
