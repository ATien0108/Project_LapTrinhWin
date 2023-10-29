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
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyQuanNET
{
    public partial class fQLThongKe : Form
    {
        SqlConnection conn = null;
        string strConnectionString;
        public fQLThongKe(string username, string password)
        {
            strConnectionString = $"Data Source=DESKTOP-I0SB6R7;Initial Catalog=QuanLyQuanNET;" +
                    $"User ID={username};" +
                    $"Password={password};";
            InitializeComponent();
            CreateColumnChartDoanhThu_DichVu();
            CreateColumnChartDoanhThu_MayTinh();
        }

        private void fQLThongKe_Load(object sender, EventArgs e)
        {
            HienThiTKDoanhThu_DichVu();
            HienThiTKDoanhThu_MayTinh();
        }
        private void HienThiTKDoanhThu_DichVu()
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
                command.CommandText = "SELECT * FROM ThongKeDoanhThu_DichVu";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvDoanhThuDV.Items.Clear();
                while (reader.Read())
                {
                    string ngay = reader.GetInt32(0).ToString();
                    string thang = reader.GetInt32(1).ToString();
                    string nam = reader.GetInt32(2).ToString();
                    string tongTien = reader.GetInt32(3).ToString();

                    ListViewItem lvi = new ListViewItem(ngay);
                    lvi.SubItems.Add(thang);
                    lvi.SubItems.Add(nam);
                    lvi.SubItems.Add(tongTien);

                    lsvDoanhThuDV.Items.Add(lvi);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi rồi");
            }
            finally
            {
                conn.Close();
            }
        }
        private void HienThiTKDoanhThu_MayTinh()
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
                command.CommandText = "SELECT * FROM ThongKeDoanhThu_MayTinh";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lsvDoanhThuMT.Items.Clear();
                while (reader.Read())
                {
                    string ngay = reader.GetInt32(0).ToString();
                    string thang = reader.GetInt32(1).ToString();
                    string nam = reader.GetInt32(2).ToString();
                    int? tongTien = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3);

                    ListViewItem lvi = new ListViewItem(ngay);
                    lvi.SubItems.Add(thang);
                    lvi.SubItems.Add(nam);
                    lvi.SubItems.Add(tongTien?.ToString() ?? "NULL");

                    lsvDoanhThuMT.Items.Add(lvi);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi rồi");
            }
            finally
            {
                conn.Close();
            }
        }
        private void CreateColumnChartDoanhThu_DichVu()
        {
            try
            {
                // Thiết lập kích thước và vị trí của biểu đồ cột
                chartDoanhThuDV.Series["Series1"].ChartType = SeriesChartType.Column;
                chartDoanhThuDV.Series["Series1"].IsVisibleInLegend = false;
                chartDoanhThuDV.Series["Series1"].XValueMember = "Tuan";
                chartDoanhThuDV.Series["Series1"].YValueMembers = "DoanhThu";
                chartDoanhThuDV.ChartAreas[0].AxisX.Interval = 1;
                chartDoanhThuDV.Titles.Add("Title1").Text = "Biểu Đồ Doanh Thu Dịch Vụ";
                string query = "SELECT * FROM ThongKeDoanhThu_DichVu_TheoTuan";
                using (SqlConnection connection = new SqlConnection(strConnectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Thiết lập dữ liệu cho biểu đồ tròn và cột
                    chartDoanhThuDV.DataSource = dataTable;
                    chartDoanhThuDV.DataBind();
                }

                // Thêm biểu đồ cột vào form
                pDoanhThuDV.Controls.Add(chartDoanhThuDV);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi rồi");
            }
        }

        private void CreateColumnChartDoanhThu_MayTinh()
        {
            try
            {
                // Thiết lập kích thước và vị trí của biểu đồ cột
                chartDoanhThuMT.Series.Clear(); // Xóa các series trước đó
                chartDoanhThuMT.ChartAreas.Clear(); // Xóa các chart area trước đó

                ChartArea chartArea = new ChartArea();
                chartDoanhThuMT.ChartAreas.Add(chartArea);

                Series series = new Series();
                series.ChartType = SeriesChartType.Column;
                series.IsVisibleInLegend = false;
                series.XValueMember = "Tuan";
                series.YValueMembers = "DoanhThu";
                chartDoanhThuMT.Series.Add(series);

                chartDoanhThuMT.ChartAreas[0].AxisX.Interval = 1;
                chartDoanhThuMT.Titles.Clear(); // Xóa các titles trước đó
                chartDoanhThuMT.Titles.Add("Title1").Text = "Biểu Đồ Doanh Thu Máy Tính";

                string query = "SELECT Tuan, DoanhThu FROM ThongKeDoanhThu_MayTinh_TheoTuan";
                using (SqlConnection connection = new SqlConnection(strConnectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Thiết lập dữ liệu cho biểu đồ cột
                    chartDoanhThuMT.DataSource = dataTable;
                    chartDoanhThuMT.DataBind();
                }

                // Thêm biểu đồ cột vào form
                pDoanhThuMT.Controls.Clear(); // Xóa các controls trước đó
                pDoanhThuMT.Controls.Add(chartDoanhThuMT);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi rồi");
            }
        }
    }
}
