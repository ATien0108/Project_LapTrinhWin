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
    public partial class fMayTinh : Form
    {
        string username;
        SqlConnection conn = null;
        string strConnectionString;
        public fMayTinh(string username)
        {
            strConnectionString = $"Data Source =DESKTOP-I0SB6R7; Initial Catalog=QuanLyQuanNET; Integrated Security = True;";
            InitializeComponent();
            this.username = username;
        }

        private void fMayTinh_Load(object sender, EventArgs e)
        {
            HienThiMayPhong_Thuong();
            HienThiMayPhong_VIP();
            HienThiMayPhong_Stream();
            HienThiMayPhong_Training();

            txtMaMayTinh.ReadOnly= true;
            txtMaPhong.ReadOnly= true;
            txtTenMayTinh.ReadOnly= true;
            txtThoiGianMo.ReadOnly= true;
            txtTrangThaiMT.ReadOnly= true;
            txtMaTaiKhoan.ReadOnly= false;
        }

        private void HienThiMayPhong_Thuong()
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
                command.CommandText = "SELECT * FROM View_MayTinhThuong";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvPhongThuong.Items.Clear();
                while (reader.Read())
                {
                    string MaMayTinhThuong = reader.IsDBNull(0) ? null : reader.GetString(0);
                    string MaPhongThuong = reader.IsDBNull(1) ? null : reader.GetString(1);
                    string TenMayTinhThuong = reader.IsDBNull(2) ? null : reader.GetString(2);
                    int? TrangThaiMayTinhThuong = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3);
                    DateTime? ThoiGianMoThuong = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4);
                    string MaTaiKhoanThuong = reader.IsDBNull(5) ? null : reader.GetString(5);

                    ListViewItem lvi = new ListViewItem(MaMayTinhThuong ?? "NULL");
                    lvi.SubItems.Add(MaPhongThuong ?? "NULL");
                    lvi.SubItems.Add(TenMayTinhThuong ?? "NULL");
                    lvi.SubItems.Add(TrangThaiMayTinhThuong?.ToString() ?? "NULL");
                    lvi.SubItems.Add(ThoiGianMoThuong?.ToString() ?? "NULL");
                    lvi.SubItems.Add(MaTaiKhoanThuong ?? "NULL");

                    lsvPhongThuong.Items.Add(lvi);
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

        private void HienThiMayPhong_VIP()
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
                command.CommandText = "SELECT * FROM View_MayTinhVIP";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvPhongVIP.Items.Clear();
                while (reader.Read())
                {
                    string MaMayTinhVIP = reader.IsDBNull(0) ? null : reader.GetString(0);
                    string MaPhongVIP = reader.IsDBNull(1) ? null : reader.GetString(1);
                    string TenMayTinhVIP = reader.IsDBNull(2) ? null : reader.GetString(2);
                    int? TrangThaiMayTinhVIP = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3);
                    DateTime? ThoiGianMoVIP = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4);
                    string MaTaiKhoanVIP = reader.IsDBNull(5) ? null : reader.GetString(5);

                    ListViewItem lvi = new ListViewItem(MaMayTinhVIP ?? "NULL");
                    lvi.SubItems.Add(MaPhongVIP ?? "NULL");
                    lvi.SubItems.Add(TenMayTinhVIP ?? "NULL");
                    lvi.SubItems.Add(TrangThaiMayTinhVIP?.ToString() ?? "NULL");
                    lvi.SubItems.Add(ThoiGianMoVIP?.ToString() ?? "NULL");
                    lvi.SubItems.Add(MaTaiKhoanVIP ?? "NULL");

                    lsvPhongVIP.Items.Add(lvi);
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

        private void HienThiMayPhong_Stream()
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
                command.CommandText = "SELECT * FROM View_MayTinhStream";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvPhongStream.Items.Clear();
                while (reader.Read())
                {
                    string MaMayTinhStream = reader.IsDBNull(0) ? null : reader.GetString(0);
                    string MaPhongStream = reader.IsDBNull(1) ? null : reader.GetString(1);
                    string TenMayTinhStream = reader.IsDBNull(2) ? null : reader.GetString(2);
                    int? TrangThaiMayTinhStream = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3);
                    DateTime? ThoiGianMoStream = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4);
                    string MaTaiKhoanStream = reader.IsDBNull(5) ? null : reader.GetString(5);

                    ListViewItem lvi = new ListViewItem(MaMayTinhStream ?? "NULL");
                    lvi.SubItems.Add(MaPhongStream ?? "NULL");
                    lvi.SubItems.Add(TenMayTinhStream ?? "NULL");
                    lvi.SubItems.Add(TrangThaiMayTinhStream?.ToString() ?? "NULL");
                    lvi.SubItems.Add(ThoiGianMoStream?.ToString() ?? "NULL");
                    lvi.SubItems.Add(MaTaiKhoanStream ?? "NULL");

                    lsvPhongStream.Items.Add(lvi);
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

        private void HienThiMayPhong_Training()
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
                command.CommandText = "SELECT * FROM View_MayTinhTraining";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvPhongTraining.Items.Clear();
                while (reader.Read())
                {
                    string MaMayTinhTraining = reader.IsDBNull(0) ? null : reader.GetString(0);
                    string MaPhongTraining = reader.IsDBNull(1) ? null : reader.GetString(1);
                    string TenMayTinhTraining = reader.IsDBNull(2) ? null : reader.GetString(2);
                    int? TrangThaiMayTinhTraining = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3);
                    DateTime? ThoiGianMoTraining = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4);
                    string MaTaiKhoanTraining = reader.IsDBNull(5) ? null : reader.GetString(5);

                    ListViewItem lvi = new ListViewItem(MaMayTinhTraining ?? "NULL");
                    lvi.SubItems.Add(MaPhongTraining ?? "NULL");
                    lvi.SubItems.Add(TenMayTinhTraining ?? "NULL");
                    lvi.SubItems.Add(TrangThaiMayTinhTraining?.ToString() ?? "NULL");
                    lvi.SubItems.Add(ThoiGianMoTraining?.ToString() ?? "NULL");
                    lvi.SubItems.Add(MaTaiKhoanTraining ?? "NULL");

                    lsvPhongTraining.Items.Add(lvi);
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

        private void lsvPhongThuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvPhongThuong.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvPhongThuong.SelectedItems[0];
            string MaMayTinh = lvi.SubItems[0].Text.Trim();

            HienThiChiTietPhong_Thuong(MaMayTinh);
        }

        private void HienThiChiTietPhong_Thuong(string maMayTinh)
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
                command.CommandText = "HienThiMayTinh";
                command.Connection = conn;

                SqlParameter parMaMayTinh = new SqlParameter("@MaMayTinh", SqlDbType.NVarChar);
                parMaMayTinh.Value = maMayTinh;
                command.Parameters.Add(parMaMayTinh);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaMayTinh.Text = reader.IsDBNull(0) ? "NULL" : reader.GetString(0);
                    txtMaPhong.Text = reader.IsDBNull(1) ? "NULL" : reader.GetString(1);
                    txtTenMayTinh.Text = reader.IsDBNull(2) ? "NULL" : reader.GetString(2);

                    if (reader.IsDBNull(3))
                    {
                        txtTrangThaiMT.Text = "NULL";
                    }
                    else
                    {
                        int trangThai = reader.GetInt32(3);
                        txtTrangThaiMT.Text = trangThai.ToString();
                    }

                    if (reader.IsDBNull(4))
                    {
                        txtThoiGianMo.Text = "NULL";
                    }
                    else
                    {
                        DateTime thoiGianMo = reader.GetDateTime(4);
                        txtThoiGianMo.Text = thoiGianMo.ToString();
                    }

                    txtMaTaiKhoan.Text = reader.IsDBNull(5) ? "NULL" : reader.GetString(5);
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

        private void lsvPhongVIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvPhongVIP.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvPhongVIP.SelectedItems[0];
            string MaMayTinh = lvi.SubItems[0].Text.Trim();

            HienThiChiTietPhong_VIP(MaMayTinh);
        }

        private void HienThiChiTietPhong_VIP(string maMayTinh)
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
                command.CommandText = "HienThiMayTinh";
                command.Connection = conn;

                SqlParameter parMaMayTinh = new SqlParameter("@MaMayTinh", SqlDbType.NVarChar);
                parMaMayTinh.Value = maMayTinh;
                command.Parameters.Add(parMaMayTinh);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaMayTinh.Text = reader.IsDBNull(0) ? "NULL" : reader.GetString(0);
                    txtMaPhong.Text = reader.IsDBNull(1) ? "NULL" : reader.GetString(1);
                    txtTenMayTinh.Text = reader.IsDBNull(2) ? "NULL" : reader.GetString(2);

                    if (reader.IsDBNull(3))
                    {
                        txtTrangThaiMT.Text = "NULL";
                    }
                    else
                    {
                        int trangThai = reader.GetInt32(3);
                        txtTrangThaiMT.Text = trangThai.ToString();
                    }

                    if (reader.IsDBNull(4))
                    {
                        txtThoiGianMo.Text = "NULL";
                    }
                    else
                    {
                        DateTime thoiGianMo = reader.GetDateTime(4);
                        txtThoiGianMo.Text = thoiGianMo.ToString();
                    }

                    txtMaTaiKhoan.Text = reader.IsDBNull(5) ? "NULL" : reader.GetString(5);
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

        private void lsvPhongStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvPhongStream.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvPhongStream.SelectedItems[0];
            string MaMayTinh = lvi.SubItems[0].Text.Trim();

            HienThiChiTietPhong_Stream(MaMayTinh);
        }

        private void HienThiChiTietPhong_Stream(string maMayTinh)
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
                command.CommandText = "HienThiMayTinh";
                command.Connection = conn;

                SqlParameter parMaMayTinh = new SqlParameter("@MaMayTinh", SqlDbType.NVarChar);
                parMaMayTinh.Value = maMayTinh;
                command.Parameters.Add(parMaMayTinh);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaMayTinh.Text = reader.IsDBNull(0) ? "NULL" : reader.GetString(0);
                    txtMaPhong.Text = reader.IsDBNull(1) ? "NULL" : reader.GetString(1);
                    txtTenMayTinh.Text = reader.IsDBNull(2) ? "NULL" : reader.GetString(2);

                    if (reader.IsDBNull(3))
                    {
                        txtTrangThaiMT.Text = "NULL";
                    }
                    else
                    {
                        int trangThai = reader.GetInt32(3);
                        txtTrangThaiMT.Text = trangThai.ToString();
                    }

                    if (reader.IsDBNull(4))
                    {
                        txtThoiGianMo.Text = "NULL";
                    }
                    else
                    {
                        DateTime thoiGianMo = reader.GetDateTime(4);
                        txtThoiGianMo.Text = thoiGianMo.ToString();
                    }

                    txtMaTaiKhoan.Text = reader.IsDBNull(5) ? "NULL" : reader.GetString(5);
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

        private void lsvPhongTraining_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvPhongTraining.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvPhongTraining.SelectedItems[0];
            string MaMayTinh = lvi.SubItems[0].Text.Trim();

            HienThiChiTietPhong_Training(MaMayTinh);
        }

        private void HienThiChiTietPhong_Training(string maMayTinh)
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
                command.CommandText = "HienThiMayTinh";
                command.Connection = conn;

                SqlParameter parMaMayTinh = new SqlParameter("@MaMayTinh", SqlDbType.NVarChar);
                parMaMayTinh.Value = maMayTinh;
                command.Parameters.Add(parMaMayTinh);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaMayTinh.Text = reader.IsDBNull(0) ? "NULL" : reader.GetString(0);
                    txtMaPhong.Text = reader.IsDBNull(1) ? "NULL" : reader.GetString(1);
                    txtTenMayTinh.Text = reader.IsDBNull(2) ? "NULL" : reader.GetString(2);

                    if (reader.IsDBNull(3))
                    {
                        txtTrangThaiMT.Text = "NULL";
                    }
                    else
                    {
                        int trangThai = reader.GetInt32(3);
                        txtTrangThaiMT.Text = trangThai.ToString();
                    }

                    if (reader.IsDBNull(4))
                    {
                        txtThoiGianMo.Text = "NULL";
                    }
                    else
                    {
                        DateTime thoiGianMo = reader.GetDateTime(4);
                        txtThoiGianMo.Text = thoiGianMo.ToString();
                    }

                    txtMaTaiKhoan.Text = reader.IsDBNull(5) ? "NULL" : reader.GetString(5);
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
            HienThiMayPhong_Thuong();
            HienThiMayPhong_VIP();
            HienThiMayPhong_Stream();
            HienThiMayPhong_Training();

            txtMaMayTinh.Clear();
            txtMaPhong.Clear();
            txtMaTaiKhoan.Clear();
            txtTenMayTinh.Clear();
            txtThoiGianMo.Clear();
            txtTrangThaiMT.Clear();
        }

        private void btnMoMay_Click(object sender, EventArgs e)
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
                command.CommandText = "MoMayTinh";
                command.Connection = conn;

                command.Parameters.Add("@MaMayTinh", SqlDbType.NVarChar).Value = txtMaMayTinh.Text;
                command.Parameters.Add("@MaTaiKhoan", SqlDbType.NVarChar).Value = username;

                 command.ExecuteNonQuery();
                 MessageBox.Show("Mở Máy Thành Công");
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

        private void btnTatMay_Click(object sender, EventArgs e)
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
                command.CommandText = "TatMayTinh";
                command.Connection = conn;

                command.Parameters.Add("@MaMayTinh", SqlDbType.NVarChar).Value = txtMaMayTinh.Text;
                command.ExecuteNonQuery();
                MessageBox.Show("Tắt Máy Thành Công");
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
