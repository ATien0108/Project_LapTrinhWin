using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyQuanNET
{
    public partial class fQLHoaDonDichVu : Form
    {
        int Flag = 0;
        SqlConnection conn = null;
        string strConnectionString;
        public fQLHoaDonDichVu(string username, string password)
        {
            strConnectionString = $"Data Source=DESKTOP-I0SB6R7;Initial Catalog=QuanLyQuanNET;" +
                     $"User ID={username};" +
                     $"Password={password};";
            InitializeComponent();
        }

        private void fQLHoaDonDichVu_Load(object sender, EventArgs e)
        {
            HienThiHoaDonDichVu();

            txtMaDichVu.ReadOnly = true;
            txtSoLuong.ReadOnly = true;
            txtMaHoaDonDV.ReadOnly = true;
            txtMaTaiKhoan.ReadOnly = true;
            txtThoiGianDatHang.ReadOnly = true;
            txtTongThanhTien.ReadOnly = true;
        }

        private void HienThiHoaDonDichVu()
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
                command.CommandText = "SELECT * FROM View_DonHangDichVu ";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvHoaDonDV.Items.Clear();
                while (reader.Read())
                {
                    string MaHoaDonDV = reader.IsDBNull(0) ? null : reader.GetString(0);
                    string MaTaiKhoan = reader.IsDBNull(1) ? null : reader.GetString(1);
                    string MaDichVu = reader.IsDBNull(2) ? null : reader.GetString(2);
                    int? SoLuong = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3);
                    DateTime? ThoiGianDatHang = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4);
                    int? TongThanhTien = reader.IsDBNull(5) ? (int?)null : reader.GetInt32(5);

                    ListViewItem lvi = new ListViewItem(MaHoaDonDV ?? "NULL");
                    lvi.SubItems.Add(MaTaiKhoan ?? "NULL");
                    lvi.SubItems.Add(MaDichVu ?? "NULL");
                    lvi.SubItems.Add(SoLuong?.ToString() ?? "NULL");
                    lvi.SubItems.Add(ThoiGianDatHang?.ToString() ?? "NULL");
                    lvi.SubItems.Add(TongThanhTien?.ToString() ?? "NULL");

                    lsvHoaDonDV.Items.Add(lvi);
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

        private void lsvHoaDonDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvHoaDonDV.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvHoaDonDV.SelectedItems[0];
            string MaHoaDonDV = lvi.SubItems[0].Text.Trim();

            HienThiChiTietHoaDonDV(MaHoaDonDV);
        }

        private void HienThiChiTietHoaDonDV(string maHoaDonDV)
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
                command.CommandText = "HienThiHoaDonDichVu";
                command.Connection = conn;

                SqlParameter parMaHoaDonDV = new SqlParameter("@MaHoaDonDV", SqlDbType.NVarChar);
                parMaHoaDonDV.Value = maHoaDonDV;
                command.Parameters.Add(parMaHoaDonDV);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaHoaDonDV.Text = reader.IsDBNull(0) ? "NULL" : reader.GetString(0);
                    txtMaTaiKhoan.Text = reader.IsDBNull(1) ? "NULL" : reader.GetString(1);
                    txtMaDichVu.Text = reader.IsDBNull(2) ? "NULL" : reader.GetString(2);
                    txtSoLuong.Text = reader.IsDBNull(3) ? "NULL" : reader.GetInt32(3).ToString();
                    txtThoiGianDatHang.Text = reader.IsDBNull(4) ? "NULL" : reader.GetDateTime(4).ToString();
                    txtTongThanhTien.Text = reader.IsDBNull(5) ? "NULL" : reader.GetInt32(5).ToString();

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
            HienThiHoaDonDichVu();

            txtMaDichVu.ReadOnly= true;
            txtSoLuong.ReadOnly= true;
            txtMaHoaDonDV.ReadOnly= true;   
            txtMaTaiKhoan.ReadOnly= true;
            txtThoiGianDatHang.ReadOnly= true;
            txtTongThanhTien.ReadOnly=true;

            txtMaDichVu.Clear();
            txtMaHoaDonDV.Clear();
            txtMaTaiKhoan.Clear();
            txtSoLuong.Clear();
            txtThoiGianDatHang.Clear();
            txtTongThanhTien.Clear();
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
                txtMaDichVu.ReadOnly = false;
                txtMaTaiKhoan.ReadOnly = false;
                txtMaHoaDonDV.ReadOnly = true;
                txtThoiGianDatHang.ReadOnly = true;
                txtSoLuong.ReadOnly = false;
                txtTongThanhTien.ReadOnly = true;

                txtTongThanhTien.Text = string.Empty;
                txtThoiGianDatHang.Text = string.Empty;
                txtMaDichVu.Text = string.Empty;
                txtMaTaiKhoan.Text = string.Empty;
                txtSoLuong.Text = string.Empty;
                txtMaHoaDonDV.Text = string.Empty;
                
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
                txtMaTaiKhoan.ReadOnly = false;
                txtMaHoaDonDV.ReadOnly = true;
                txtThoiGianDatHang.ReadOnly = false;
                txtSoLuong.ReadOnly = false;
                txtTongThanhTien.ReadOnly = false;
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
                    command.CommandText = "ThemHoaDonDichVu";
                    command.Connection = conn;

                    command.Parameters.Add("@MaTaiKhoan", SqlDbType.NVarChar).Value = txtMaTaiKhoan.Text;
                    command.Parameters.Add("@MaDichVu", SqlDbType.NVarChar).Value = txtMaDichVu.Text;
                    command.Parameters.Add("@SoLuong", SqlDbType.Int).Value = int.Parse(txtSoLuong.Text);

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
                    command.CommandText = "SuaHoaDonDichVu";
                    command.Connection = conn;

                    command.Parameters.Add("@MaHoaDonDV", SqlDbType.NVarChar).Value = txtMaHoaDonDV.Text;
                    command.Parameters.Add("@MaTaiKhoan", SqlDbType.NVarChar).Value = txtMaTaiKhoan.Text;
                    command.Parameters.Add("@MaDichVu", SqlDbType.NVarChar).Value = txtMaDichVu.Text;
                    command.Parameters.Add("@SoLuong", SqlDbType.Int).Value = int.Parse(txtSoLuong.Text);
                    command.Parameters.Add("@ThoiGianDatHang", SqlDbType.DateTime).Value = DateTime.Parse(txtThoiGianDatHang.Text);
                    command.Parameters.Add("@TongThanhTien", SqlDbType.Int).Value = int.Parse(txtTongThanhTien.Text);

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

       

    }
}
