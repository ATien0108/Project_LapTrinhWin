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
    public partial class fQLMucKhac : Form
    {
        int Flag = 0;
        int FlagPM = 0;
        SqlConnection conn = null;
        string strConnectionString;
        public fQLMucKhac(string username, string password)
        {
            strConnectionString = $"Data Source=DESKTOP-I0SB6R7;Initial Catalog=QuanLyQuanNET;" +
                    $"User ID={username};" +
                    $"Password={password};";
            InitializeComponent();
        }

        private void fQLMucKhac_Load(object sender, EventArgs e)
        {
            HienThiChucVu();
            HienThiPhongMay();

            txtMaChucVu.ReadOnly = true;
            txtTenChucVu.ReadOnly = true;
            txtMoTaCV.ReadOnly = true;
            txtLuong.ReadOnly = true;
            txtMaPhong.ReadOnly = true;
            txtTenPhong.ReadOnly = true;
            txtSoLuongMay.ReadOnly = true;
            txtDonGiaMay.ReadOnly = true;
        }

        private void HienThiChucVu()
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
                command.CommandText = "SELECT * FROM View_ChucVu ";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvChucVu.Items.Clear();
                while (reader.Read())
                {
                    string MaChucVu = reader.IsDBNull(0) ? null : reader.GetString(0);
                    string TenChucVu = reader.IsDBNull(1) ? null : reader.GetString(1);
                    string MoTaCV = reader.IsDBNull(2) ? null : reader.GetString(2);
                    decimal? Luong = reader.IsDBNull(3) ? default(decimal?) : reader.GetDecimal(3);


                    ListViewItem lvi = new ListViewItem(MaChucVu ?? "NULL");
                    lvi.SubItems.Add(TenChucVu ?? "NULL");
                    lvi.SubItems.Add(MoTaCV ?? "NULL");
                    lvi.SubItems.Add(Luong.HasValue ? Luong.ToString() : "NULL");


                    lsvChucVu.Items.Add(lvi);
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

        private void HienThiPhongMay()
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
                command.CommandText = "SELECT * FROM View_PhongMay ";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvPhongMay.Items.Clear();
                while (reader.Read())
                {
                    string MaPhong = reader.IsDBNull(0) ? null : reader.GetString(0);
                    string TenPhong = reader.IsDBNull(1) ? null : reader.GetString(1);
                    int? SoLuongMay = reader.IsDBNull(2) ? default(int?) : reader.GetInt32(2);
                    int? DonGiaMoiMay = reader.IsDBNull(3) ? default(int?) : reader.GetInt32(3);

                    ListViewItem lvi = new ListViewItem(MaPhong ?? "NULL");
                    lvi.SubItems.Add(TenPhong ?? "NULL");
                    lvi.SubItems.Add(SoLuongMay.HasValue ? SoLuongMay.ToString() : "NULL");
                    lvi.SubItems.Add(DonGiaMoiMay.HasValue ? DonGiaMoiMay.ToString() : "NULL");


                    lsvPhongMay.Items.Add(lvi);
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

        private void lsvChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvChucVu.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvChucVu.SelectedItems[0];
            string MaChucVu = lvi.SubItems[0].Text.Trim();

            HienThiChiTietChucVu(MaChucVu);
        }

        private void HienThiChiTietChucVu(string maChucVu)
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
                command.CommandText = "HienThiChucVu";
                command.Connection = conn;

                SqlParameter parMaChucVu = new SqlParameter("@MaChucVu", SqlDbType.NVarChar);
                parMaChucVu.Value = maChucVu;
                command.Parameters.Add(parMaChucVu);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaChucVu.Text = reader.IsDBNull(0) ? "NULL" : reader.GetString(0);
                    txtTenChucVu.Text = reader.IsDBNull(1) ? "NULL" : reader.GetString(1);
                    txtMoTaCV.Text = reader.IsDBNull(2) ? "NULL" : reader.GetString(2);
                    txtLuong.Text = reader.IsDBNull(3) ? "NULL" : reader.GetDecimal(3).ToString();
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

        private void lsvPhongMay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvPhongMay.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvPhongMay.SelectedItems[0];
            string MaPhong = lvi.SubItems[0].Text.Trim();

            HienThiChiTietPhongMay(MaPhong);
        }

        private void HienThiChiTietPhongMay(string maPhong)
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
                command.CommandText = "HienThiPhongMay";
                command.Connection = conn;

                SqlParameter parMaPhong = new SqlParameter("@MaPhong", SqlDbType.NVarChar);
                parMaPhong.Value = maPhong;
                command.Parameters.Add(parMaPhong);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtMaPhong.Text = reader.IsDBNull(0) ? "NULL" : reader.GetString(0);
                    txtTenPhong.Text = reader.IsDBNull(1) ? "NULL" : reader.GetString(1);
                    txtSoLuongMay.Text = reader.IsDBNull(2) ? "NULL" : reader.GetInt32(2).ToString();
                    txtDonGiaMay.Text = reader.IsDBNull(3) ? "NULL" : reader.GetInt32(3).ToString();
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
                txtMaChucVu.ReadOnly = true;
                txtTenChucVu.ReadOnly = false;
                txtMoTaCV.ReadOnly = false;
                txtLuong.ReadOnly = false;

                txtMaChucVu.Text = string.Empty;
                txtTenChucVu.Text = string.Empty;
                txtMoTaCV.Text = string.Empty;
                txtLuong.Text = string.Empty;
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

                txtMaChucVu.ReadOnly = false;
                txtTenChucVu.ReadOnly = false;
                txtMoTaCV.ReadOnly = false;
                txtLuong.ReadOnly = false;
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
                    command.CommandText = "ThemChucVu";
                    command.Connection = conn;

                    command.Parameters.Add("@TenChucVu", SqlDbType.NVarChar).Value = txtTenChucVu.Text;
                    command.Parameters.Add("@MoTaCongViec", SqlDbType.NVarChar).Value = txtMoTaCV.Text;
                    command.Parameters.Add("@Luong", SqlDbType.Decimal).Value = txtLuong.Text;

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
                    command.CommandText = "SuaChucVu";
                    command.Connection = conn;

                    command.Parameters.Add("@MaChucVu", SqlDbType.NVarChar).Value = txtMaChucVu.Text;
                    command.Parameters.Add("@TenChucVu", SqlDbType.NVarChar).Value = txtTenChucVu.Text;
                    command.Parameters.Add("@MoTaCongViec", SqlDbType.NVarChar).Value = txtMoTaCV.Text;
                    command.Parameters.Add("@Luong", SqlDbType.Decimal).Value = txtLuong.Text;

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
            HienThiChucVu();

            txtMaChucVu.ReadOnly = true;
            txtTenChucVu.ReadOnly = true;
            txtMoTaCV.ReadOnly = true;
            txtLuong.ReadOnly = true;

            txtMaChucVu.Clear();
            txtTenChucVu.Clear();
            txtMoTaCV.Clear();
            txtLuong.Clear();
        }

        private void btnThemPM_Click(object sender, EventArgs e)
        {
            FlagPM = 1;
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
                txtMaPhong.ReadOnly = true;
                txtTenPhong.ReadOnly = false;
                txtSoLuongMay.ReadOnly = false;
                txtDonGiaMay.ReadOnly = false;

                txtMaPhong.Text = string.Empty;
                txtTenPhong.Text = string.Empty;
                txtSoLuongMay.Text = string.Empty;
                txtDonGiaMay.Text = string.Empty;
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

        private void btnSuaPM_Click(object sender, EventArgs e)
        {
            FlagPM = 2;
            try
            {
                if (conn == null)
                    conn = new SqlConnection(strConnectionString);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                txtMaPhong.ReadOnly = false;
                txtTenPhong.ReadOnly = false;
                txtSoLuongMay.ReadOnly = false;
                txtDonGiaMay.ReadOnly = false;
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

        private void btnLuuPM_Click(object sender, EventArgs e)
        {
            if (conn == null)
            {
                conn = new SqlConnection(strConnectionString);
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            if (FlagPM == 1)
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ThemPhongMay";
                    command.Connection = conn;

                    command.Parameters.Add("@TenPhong", SqlDbType.NVarChar).Value = txtTenPhong.Text;
                    command.Parameters.Add("@SoLuongMay", SqlDbType.Int).Value = txtSoLuongMay.Text;
                    command.Parameters.Add("@DonGiaMoiMay", SqlDbType.Int).Value = txtDonGiaMay.Text;

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
            if (FlagPM == 2)
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SuaPhongMay";
                    command.Connection = conn;

                    command.Parameters.Add("@MaPhong", SqlDbType.NVarChar).Value = txtMaPhong.Text;
                    command.Parameters.Add("@TenPhong", SqlDbType.NVarChar).Value = txtTenPhong.Text;
                    command.Parameters.Add("@SoLuongMay", SqlDbType.Int).Value = txtSoLuongMay.Text;
                    command.Parameters.Add("@DonGiaMoiMay", SqlDbType.Int).Value = txtDonGiaMay.Text;

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

        private void btnTaiLaiPM_Click(object sender, EventArgs e)
        {
            HienThiPhongMay();

            txtMaPhong.ReadOnly = true;
            txtTenPhong.ReadOnly = true;
            txtSoLuongMay.ReadOnly = true;
            txtDonGiaMay.ReadOnly = true;

            txtMaPhong.Clear();
            txtTenPhong.Clear();
            txtSoLuongMay.Clear();
            txtDonGiaMay.Clear();
        }
    }
}
