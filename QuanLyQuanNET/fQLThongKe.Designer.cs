namespace QuanLyQuanNET
{
    partial class fQLThongKe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lsvDoanhThuDV = new System.Windows.Forms.ListView();
            this.Ngay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Thang = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TongDoanhThu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.pDoanhThuDV = new System.Windows.Forms.Panel();
            this.chartDoanhThuDV = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pDoanhThuMT = new System.Windows.Forms.Panel();
            this.lsvDoanhThuMT = new System.Windows.Forms.ListView();
            this.Ngay1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Thang1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nam1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TongDoanhThu1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.chartDoanhThuMT = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pDoanhThuDV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThuDV)).BeginInit();
            this.pDoanhThuMT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThuMT)).BeginInit();
            this.SuspendLayout();
            // 
            // lsvDoanhThuDV
            // 
            this.lsvDoanhThuDV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Ngay,
            this.Thang,
            this.Nam,
            this.TongDoanhThu});
            this.lsvDoanhThuDV.FullRowSelect = true;
            this.lsvDoanhThuDV.HideSelection = false;
            this.lsvDoanhThuDV.Location = new System.Drawing.Point(10, 46);
            this.lsvDoanhThuDV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lsvDoanhThuDV.Name = "lsvDoanhThuDV";
            this.lsvDoanhThuDV.Size = new System.Drawing.Size(790, 250);
            this.lsvDoanhThuDV.TabIndex = 1;
            this.lsvDoanhThuDV.UseCompatibleStateImageBehavior = false;
            this.lsvDoanhThuDV.View = System.Windows.Forms.View.Details;
            // 
            // Ngay
            // 
            this.Ngay.Text = "Ngày";
            this.Ngay.Width = 100;
            // 
            // Thang
            // 
            this.Thang.Text = "Tháng";
            this.Thang.Width = 100;
            // 
            // Nam
            // 
            this.Nam.Text = "Năm";
            this.Nam.Width = 100;
            // 
            // TongDoanhThu
            // 
            this.TongDoanhThu.Text = "Tổng doanh thu";
            this.TongDoanhThu.Width = 220;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(177, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(434, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Thống Kê Doanh Thu Dịch Vụ";
            // 
            // pDoanhThuDV
            // 
            this.pDoanhThuDV.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pDoanhThuDV.Controls.Add(this.chartDoanhThuDV);
            this.pDoanhThuDV.Controls.Add(this.label1);
            this.pDoanhThuDV.Controls.Add(this.lsvDoanhThuDV);
            this.pDoanhThuDV.Location = new System.Drawing.Point(11, 10);
            this.pDoanhThuDV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pDoanhThuDV.Name = "pDoanhThuDV";
            this.pDoanhThuDV.Size = new System.Drawing.Size(813, 648);
            this.pDoanhThuDV.TabIndex = 3;
            // 
            // chartDoanhThuDV
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThuDV.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDoanhThuDV.Legends.Add(legend1);
            this.chartDoanhThuDV.Location = new System.Drawing.Point(10, 301);
            this.chartDoanhThuDV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartDoanhThuDV.Name = "chartDoanhThuDV";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartDoanhThuDV.Series.Add(series1);
            this.chartDoanhThuDV.Size = new System.Drawing.Size(789, 332);
            this.chartDoanhThuDV.TabIndex = 4;
            this.chartDoanhThuDV.Text = "chart1";
            // 
            // pDoanhThuMT
            // 
            this.pDoanhThuMT.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pDoanhThuMT.Controls.Add(this.chartDoanhThuMT);
            this.pDoanhThuMT.Controls.Add(this.label2);
            this.pDoanhThuMT.Controls.Add(this.lsvDoanhThuMT);
            this.pDoanhThuMT.Location = new System.Drawing.Point(834, 11);
            this.pDoanhThuMT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pDoanhThuMT.Name = "pDoanhThuMT";
            this.pDoanhThuMT.Size = new System.Drawing.Size(813, 648);
            this.pDoanhThuMT.TabIndex = 6;
            // 
            // lsvDoanhThuMT
            // 
            this.lsvDoanhThuMT.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Ngay1,
            this.Thang1,
            this.Nam1,
            this.TongDoanhThu1});
            this.lsvDoanhThuMT.FullRowSelect = true;
            this.lsvDoanhThuMT.HideSelection = false;
            this.lsvDoanhThuMT.Location = new System.Drawing.Point(12, 45);
            this.lsvDoanhThuMT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lsvDoanhThuMT.Name = "lsvDoanhThuMT";
            this.lsvDoanhThuMT.Size = new System.Drawing.Size(790, 250);
            this.lsvDoanhThuMT.TabIndex = 5;
            this.lsvDoanhThuMT.UseCompatibleStateImageBehavior = false;
            this.lsvDoanhThuMT.View = System.Windows.Forms.View.Details;
            // 
            // Ngay1
            // 
            this.Ngay1.Text = "Ngày";
            this.Ngay1.Width = 100;
            // 
            // Thang1
            // 
            this.Thang1.Text = "Tháng";
            this.Thang1.Width = 100;
            // 
            // Nam1
            // 
            this.Nam1.Text = "Năm";
            this.Nam1.Width = 100;
            // 
            // TongDoanhThu1
            // 
            this.TongDoanhThu1.Text = "Tổng doanh thu";
            this.TongDoanhThu1.Width = 220;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Coral;
            this.label2.Location = new System.Drawing.Point(196, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(451, 35);
            this.label2.TabIndex = 5;
            this.label2.Text = "Thống Kê Doanh Thu Máy Tính";
            // 
            // chartDoanhThuMT
            // 
            chartArea2.Name = "ChartArea1";
            this.chartDoanhThuMT.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartDoanhThuMT.Legends.Add(legend2);
            this.chartDoanhThuMT.Location = new System.Drawing.Point(13, 300);
            this.chartDoanhThuMT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartDoanhThuMT.Name = "chartDoanhThuMT";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartDoanhThuMT.Series.Add(series2);
            this.chartDoanhThuMT.Size = new System.Drawing.Size(789, 332);
            this.chartDoanhThuMT.TabIndex = 5;
            this.chartDoanhThuMT.Text = "chart1";
            // 
            // fQLThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1659, 667);
            this.Controls.Add(this.pDoanhThuMT);
            this.Controls.Add(this.pDoanhThuDV);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "fQLThongKe";
            this.Text = "fThongKe";
            this.Load += new System.EventHandler(this.fQLThongKe_Load);
            this.pDoanhThuDV.ResumeLayout(false);
            this.pDoanhThuDV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThuDV)).EndInit();
            this.pDoanhThuMT.ResumeLayout(false);
            this.pDoanhThuMT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThuMT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsvDoanhThuDV;
        private System.Windows.Forms.ColumnHeader Ngay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pDoanhThuDV;
        private System.Windows.Forms.ColumnHeader Thang;
        private System.Windows.Forms.ColumnHeader Nam;
        private System.Windows.Forms.ColumnHeader TongDoanhThu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThuDV;
        private System.Windows.Forms.Panel pDoanhThuMT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lsvDoanhThuMT;
        private System.Windows.Forms.ColumnHeader Ngay1;
        private System.Windows.Forms.ColumnHeader Thang1;
        private System.Windows.Forms.ColumnHeader Nam1;
        private System.Windows.Forms.ColumnHeader TongDoanhThu1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThuMT;
    }
}