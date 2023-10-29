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
    public partial class fQLHoaDonMayTinh : Form
    {
        int FlagCT = 0;
        SqlConnection conn = null;
        string strConnectionString;
        public fQLHoaDonMayTinh(string username, string password)
        {
            strConnectionString = $"Data Source=DESKTOP-I0SB6R7;Initial Catalog=QuanLyQuanNET;" +
                    $"User ID={username};" +
                    $"Password={password};";
            InitializeComponent();
        }

        private void fQLHoaDonMayTinh_Load(object sender, EventArgs e)
        {
            HienThiHoaDonMayTinh();
        }

        private void HienThiHoaDonMayTinh()
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
                command.CommandText = "SELECT * FROM View_HoaDonMayTinh ";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvHoaDonMT.Items.Clear();
                while (reader.Read())
                {
                    string MaHoaDonMT = reader.IsDBNull(0) ? null : reader.GetString(0);
                    string MaTaiKhoan = reader.IsDBNull(1) ? null : reader.GetString(1);
                    string MaMayTinh = reader.IsDBNull(2) ? null : reader.GetString(2);
                    DateTime? ThoiGianMoMay = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3);
                    DateTime? ThoiGianThanhToan = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4);
                    int? ThoiGianSuDung = reader.IsDBNull(5) ? (int?)null : reader.GetInt32(5);
                    int? TongThanhTien = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6);

                    ListViewItem lvi = new ListViewItem(MaHoaDonMT ?? "NULL");
                    lvi.SubItems.Add(MaTaiKhoan ?? "NULL");
                    lvi.SubItems.Add(MaMayTinh ?? "NULL");
                    lvi.SubItems.Add(ThoiGianMoMay?.ToString() ?? "NULL");
                    lvi.SubItems.Add(ThoiGianThanhToan?.ToString() ?? "NULL");
                    lvi.SubItems.Add(ThoiGianSuDung?.ToString() ?? "NULL");
                    lvi.SubItems.Add(TongThanhTien?.ToString() ?? "NULL");

                    lsvHoaDonMT.Items.Add(lvi);
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

        private void lsvHoaDonMT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvHoaDonMT.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvHoaDonMT.SelectedItems[0];
            string MaHoaDonMT = lvi.SubItems[0].Text.Trim();

            HienThiChiTietHoaDonMT(MaHoaDonMT);
        }

        private void HienThiChiTietHoaDonMT(string maHoaDonMT)
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
                command.CommandText = "HienThiHoaDonMayTinh";
                command.Connection = conn;

                SqlParameter parMaHoaDonMT = new SqlParameter("@MaHoaDonMT", SqlDbType.NVarChar);
                parMaHoaDonMT.Value = maHoaDonMT;
                command.Parameters.Add(parMaHoaDonMT);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaHoaDonMT.Text = reader.IsDBNull(0) ? "NULL" : reader.GetString(0);
                    txtMaTaiKhoan.Text = reader.IsDBNull(1) ? "NULL" : reader.GetString(1);
                    txtMaMayTinh.Text = reader.IsDBNull(2) ? "NULL" : reader.GetString(2);
                    txtThoiGianMoMay.Text = reader.IsDBNull(3) ? "NULL" : reader.GetDateTime(3).ToString();
                    txtThoiGianThanhToan.Text = reader.IsDBNull(4) ? "NULL" : reader.GetDateTime(4).ToString();
                    txtThoiGianSuDung.Text = reader.IsDBNull(5) ? "NULL" : reader.GetInt32(5).ToString();
                    txtTongThanhTien.Text = reader.IsDBNull(6) ? "NULL" : reader.GetInt32(6).ToString();
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
            HienThiHoaDonMayTinh();

            txtMaHoaDonMT.Clear();
            txtMaMayTinh.Clear();
            txtMaTaiKhoan.Clear();
            txtThoiGianMoMay.Clear();
            txtThoiGianSuDung.Clear();
            txtThoiGianThanhToan.Clear();
            txtTongThanhTien.Clear();
        }

        
        private void btnThem_Click(object sender, EventArgs e)
        {
            FlagCT = 1;
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
                txtMaMayTinh.ReadOnly = false;
                txtThoiGianMoMay.ReadOnly = false;
                txtThoiGianSuDung.ReadOnly = false;
                txtTongThanhTien.ReadOnly = false;
                

                txtTongThanhTien.Text = string.Empty;
                txtThoiGianMoMay.Text = string.Empty;
                txtMaMayTinh.Text = string.Empty;
                txtMaTaiKhoan.Text = string.Empty;
                txtThoiGianSuDung.Text = string.Empty;
                txtThoiGianThanhToan.Text = string.Empty;
                txtMaHoaDonMT.Text = string.Empty;

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
            FlagCT = 2;
            try
            {
                if (conn == null)
                    conn = new SqlConnection(strConnectionString);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                txtMaHoaDonMT.ReadOnly = true;
                txtMaTaiKhoan.ReadOnly= false;
                txtMaMayTinh.ReadOnly = false;
                txtThoiGianMoMay.ReadOnly = false;
                txtThoiGianThanhToan.ReadOnly=false;
                txtThoiGianSuDung.ReadOnly = false;
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
            if (FlagCT == 1)
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ThemHoaDonMayTinh";
                    command.Connection = conn;

                    command.Parameters.Add("@MaTaiKhoan", SqlDbType.NVarChar).Value = txtMaTaiKhoan.Text;
                    command.Parameters.Add("@MaMayTinh", SqlDbType.NVarChar).Value = txtMaMayTinh.Text;
                    command.Parameters.Add("@ThoiGianMoMay", SqlDbType.DateTime).Value = DateTime.Parse(txtThoiGianMoMay.Text);
                    command.Parameters.Add("@ThoiGianSuDung", SqlDbType.Int).Value = int.Parse(txtThoiGianSuDung.Text);
                    command.Parameters.Add("@TongThanhTien", SqlDbType.Int).Value = int.Parse(txtTongThanhTien.Text);

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
            if (FlagCT == 2)
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SuaHoaDonMayTinh";
                    command.Connection = conn;

                    command.Parameters.Add("@MaHoaDonMT", SqlDbType.NVarChar).Value = txtMaHoaDonMT.Text;
                    command.Parameters.Add("@MaTaiKhoan", SqlDbType.NVarChar).Value = txtMaTaiKhoan.Text;
                    command.Parameters.Add("@MaMayTinh", SqlDbType.NVarChar).Value = txtMaMayTinh.Text;
                    command.Parameters.Add("@ThoiGianMoMay", SqlDbType.DateTime).Value = DateTime.Parse(txtThoiGianMoMay.Text);
                    command.Parameters.Add("@ThoiGianThanhToan", SqlDbType.DateTime).Value = DateTime.Parse(txtThoiGianThanhToan.Text);
                    command.Parameters.Add("@ThoiGianSuDung", SqlDbType.Int).Value = int.Parse(txtThoiGianSuDung.Text);
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
