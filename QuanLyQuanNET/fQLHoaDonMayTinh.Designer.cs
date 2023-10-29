namespace QuanLyQuanNET
{
    partial class fQLHoaDonMayTinh
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
            this.lsvHoaDonMT = new System.Windows.Forms.ListView();
            this.MaHoaDonMT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MaTaiKhoan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MaMayTinh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ThoiGianMoMay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ThoiGianThanhToan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ThoiGianSuDung = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TongThanhTien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTongThanhTien = new System.Windows.Forms.TextBox();
            this.txtThoiGianSuDung = new System.Windows.Forms.TextBox();
            this.txtThoiGianThanhToan = new System.Windows.Forms.TextBox();
            this.lbTongThanhTien = new System.Windows.Forms.Label();
            this.lbThoiGianSuDung = new System.Windows.Forms.Label();
            this.lbThoiGianThanhToan = new System.Windows.Forms.Label();
            this.btnTaiLai = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtThoiGianMoMay = new System.Windows.Forms.TextBox();
            this.txtMaMayTinh = new System.Windows.Forms.TextBox();
            this.txtMaTaiKhoan = new System.Windows.Forms.TextBox();
            this.txtMaHoaDonMT = new System.Windows.Forms.TextBox();
            this.lbThoiGianMoMay = new System.Windows.Forms.Label();
            this.lbMaMayTinh = new System.Windows.Forms.Label();
            this.lbMaTaiKhoan = new System.Windows.Forms.Label();
            this.lbMaHoaDon = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvHoaDonMT
            // 
            this.lsvHoaDonMT.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MaHoaDonMT,
            this.MaTaiKhoan,
            this.MaMayTinh,
            this.ThoiGianMoMay,
            this.ThoiGianThanhToan,
            this.ThoiGianSuDung,
            this.TongThanhTien});
            this.lsvHoaDonMT.FullRowSelect = true;
            this.lsvHoaDonMT.HideSelection = false;
            this.lsvHoaDonMT.Location = new System.Drawing.Point(796, 15);
            this.lsvHoaDonMT.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lsvHoaDonMT.Name = "lsvHoaDonMT";
            this.lsvHoaDonMT.Size = new System.Drawing.Size(1669, 1013);
            this.lsvHoaDonMT.TabIndex = 34;
            this.lsvHoaDonMT.UseCompatibleStateImageBehavior = false;
            this.lsvHoaDonMT.View = System.Windows.Forms.View.Details;
            this.lsvHoaDonMT.SelectedIndexChanged += new System.EventHandler(this.lsvHoaDonMT_SelectedIndexChanged);
            // 
            // MaHoaDonMT
            // 
            this.MaHoaDonMT.Text = "Mã hóa đơn";
            this.MaHoaDonMT.Width = 90;
            // 
            // MaTaiKhoan
            // 
            this.MaTaiKhoan.Text = "Mã tài khoản";
            this.MaTaiKhoan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MaTaiKhoan.Width = 90;
            // 
            // MaMayTinh
            // 
            this.MaMayTinh.Text = "Mã máy tính";
            this.MaMayTinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MaMayTinh.Width = 90;
            // 
            // ThoiGianMoMay
            // 
            this.ThoiGianMoMay.Text = "Thời gian mở máy";
            this.ThoiGianMoMay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ThoiGianMoMay.Width = 120;
            // 
            // ThoiGianThanhToan
            // 
            this.ThoiGianThanhToan.Text = "Thời gian thanh toán";
            this.ThoiGianThanhToan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ThoiGianThanhToan.Width = 120;
            // 
            // ThoiGianSuDung
            // 
            this.ThoiGianSuDung.Text = "Thời gian sử dụng";
            this.ThoiGianSuDung.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ThoiGianSuDung.Width = 100;
            // 
            // TongThanhTien
            // 
            this.TongThanhTien.Text = "Tổng thành tiền";
            this.TongThanhTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TongThanhTien.Width = 100;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.txtTongThanhTien);
            this.panel1.Controls.Add(this.txtThoiGianSuDung);
            this.panel1.Controls.Add(this.txtThoiGianThanhToan);
            this.panel1.Controls.Add(this.lbTongThanhTien);
            this.panel1.Controls.Add(this.lbThoiGianSuDung);
            this.panel1.Controls.Add(this.lbThoiGianThanhToan);
            this.panel1.Controls.Add(this.btnTaiLai);
            this.panel1.Controls.Add(this.btnLuu);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.txtThoiGianMoMay);
            this.panel1.Controls.Add(this.txtMaMayTinh);
            this.panel1.Controls.Add(this.txtMaTaiKhoan);
            this.panel1.Controls.Add(this.txtMaHoaDonMT);
            this.panel1.Controls.Add(this.lbThoiGianMoMay);
            this.panel1.Controls.Add(this.lbMaMayTinh);
            this.panel1.Controls.Add(this.lbMaTaiKhoan);
            this.panel1.Controls.Add(this.lbMaHoaDon);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(23, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 1012);
            this.panel1.TabIndex = 33;
            // 
            // txtTongThanhTien
            // 
            this.txtTongThanhTien.Location = new System.Drawing.Point(328, 655);
            this.txtTongThanhTien.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtTongThanhTien.Name = "txtTongThanhTien";
            this.txtTongThanhTien.Size = new System.Drawing.Size(385, 31);
            this.txtTongThanhTien.TabIndex = 34;
            // 
            // txtThoiGianSuDung
            // 
            this.txtThoiGianSuDung.Location = new System.Drawing.Point(328, 572);
            this.txtThoiGianSuDung.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtThoiGianSuDung.Name = "txtThoiGianSuDung";
            this.txtThoiGianSuDung.Size = new System.Drawing.Size(385, 31);
            this.txtThoiGianSuDung.TabIndex = 33;
            // 
            // txtThoiGianThanhToan
            // 
            this.txtThoiGianThanhToan.Location = new System.Drawing.Point(328, 482);
            this.txtThoiGianThanhToan.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtThoiGianThanhToan.Name = "txtThoiGianThanhToan";
            this.txtThoiGianThanhToan.Size = new System.Drawing.Size(385, 31);
            this.txtThoiGianThanhToan.TabIndex = 32;
            // 
            // lbTongThanhTien
            // 
            this.lbTongThanhTien.AutoSize = true;
            this.lbTongThanhTien.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongThanhTien.Location = new System.Drawing.Point(21, 655);
            this.lbTongThanhTien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTongThanhTien.Name = "lbTongThanhTien";
            this.lbTongThanhTien.Size = new System.Drawing.Size(233, 35);
            this.lbTongThanhTien.TabIndex = 31;
            this.lbTongThanhTien.Text = "Tổng thành tiền:";
            // 
            // lbThoiGianSuDung
            // 
            this.lbThoiGianSuDung.AutoSize = true;
            this.lbThoiGianSuDung.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThoiGianSuDung.Location = new System.Drawing.Point(21, 570);
            this.lbThoiGianSuDung.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbThoiGianSuDung.Name = "lbThoiGianSuDung";
            this.lbThoiGianSuDung.Size = new System.Drawing.Size(267, 35);
            this.lbThoiGianSuDung.TabIndex = 30;
            this.lbThoiGianSuDung.Text = "Thời gian sử dụng:";
            // 
            // lbThoiGianThanhToan
            // 
            this.lbThoiGianThanhToan.AutoSize = true;
            this.lbThoiGianThanhToan.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThoiGianThanhToan.Location = new System.Drawing.Point(20, 482);
            this.lbThoiGianThanhToan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbThoiGianThanhToan.Name = "lbThoiGianThanhToan";
            this.lbThoiGianThanhToan.Size = new System.Drawing.Size(300, 35);
            this.lbThoiGianThanhToan.TabIndex = 29;
            this.lbThoiGianThanhToan.Text = "Thời gian thanh toán:";
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnTaiLai.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiLai.Location = new System.Drawing.Point(404, 865);
            this.btnTaiLai.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(273, 114);
            this.btnTaiLai.TabIndex = 25;
            this.btnTaiLai.Text = "Tải lại";
            this.btnTaiLai.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnLuu.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(53, 865);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(273, 114);
            this.btnLuu.TabIndex = 24;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnSua.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(404, 731);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(273, 114);
            this.btnSua.TabIndex = 23;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnThem.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(53, 731);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(273, 114);
            this.btnThem.TabIndex = 22;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // txtThoiGianMoMay
            // 
            this.txtThoiGianMoMay.Location = new System.Drawing.Point(328, 398);
            this.txtThoiGianMoMay.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtThoiGianMoMay.Name = "txtThoiGianMoMay";
            this.txtThoiGianMoMay.Size = new System.Drawing.Size(385, 31);
            this.txtThoiGianMoMay.TabIndex = 17;
            // 
            // txtMaMayTinh
            // 
            this.txtMaMayTinh.Location = new System.Drawing.Point(328, 312);
            this.txtMaMayTinh.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtMaMayTinh.Name = "txtMaMayTinh";
            this.txtMaMayTinh.Size = new System.Drawing.Size(385, 31);
            this.txtMaMayTinh.TabIndex = 16;
            // 
            // txtMaTaiKhoan
            // 
            this.txtMaTaiKhoan.Location = new System.Drawing.Point(328, 228);
            this.txtMaTaiKhoan.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtMaTaiKhoan.Name = "txtMaTaiKhoan";
            this.txtMaTaiKhoan.Size = new System.Drawing.Size(385, 31);
            this.txtMaTaiKhoan.TabIndex = 15;
            // 
            // txtMaHoaDonMT
            // 
            this.txtMaHoaDonMT.Location = new System.Drawing.Point(328, 139);
            this.txtMaHoaDonMT.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtMaHoaDonMT.Name = "txtMaHoaDonMT";
            this.txtMaHoaDonMT.Size = new System.Drawing.Size(385, 31);
            this.txtMaHoaDonMT.TabIndex = 14;
            // 
            // lbThoiGianMoMay
            // 
            this.lbThoiGianMoMay.AutoSize = true;
            this.lbThoiGianMoMay.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThoiGianMoMay.Location = new System.Drawing.Point(20, 392);
            this.lbThoiGianMoMay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbThoiGianMoMay.Name = "lbThoiGianMoMay";
            this.lbThoiGianMoMay.Size = new System.Drawing.Size(265, 35);
            this.lbThoiGianMoMay.TabIndex = 11;
            this.lbThoiGianMoMay.Text = "Thời gian mở máy:";
            // 
            // lbMaMayTinh
            // 
            this.lbMaMayTinh.AutoSize = true;
            this.lbMaMayTinh.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaMayTinh.Location = new System.Drawing.Point(20, 310);
            this.lbMaMayTinh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMaMayTinh.Name = "lbMaMayTinh";
            this.lbMaMayTinh.Size = new System.Drawing.Size(204, 37);
            this.lbMaMayTinh.TabIndex = 10;
            this.lbMaMayTinh.Text = "Mã máy tính:";
            // 
            // lbMaTaiKhoan
            // 
            this.lbMaTaiKhoan.AutoSize = true;
            this.lbMaTaiKhoan.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaTaiKhoan.Location = new System.Drawing.Point(20, 224);
            this.lbMaTaiKhoan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMaTaiKhoan.Name = "lbMaTaiKhoan";
            this.lbMaTaiKhoan.Size = new System.Drawing.Size(210, 37);
            this.lbMaTaiKhoan.TabIndex = 9;
            this.lbMaTaiKhoan.Text = "Mã tài khoản:";
            // 
            // lbMaHoaDon
            // 
            this.lbMaHoaDon.AutoSize = true;
            this.lbMaHoaDon.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaHoaDon.Location = new System.Drawing.Point(20, 139);
            this.lbMaHoaDon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMaHoaDon.Name = "lbMaHoaDon";
            this.lbMaHoaDon.Size = new System.Drawing.Size(197, 37);
            this.lbMaHoaDon.TabIndex = 8;
            this.lbMaHoaDon.Text = "Mã hóa đơn:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Coral;
            this.label2.Location = new System.Drawing.Point(147, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(422, 51);
            this.label2.TabIndex = 7;
            this.label2.Text = "Thông Tin Hóa Đơn";
            // 
            // fQLHoaDonMayTinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(2488, 1042);
            this.Controls.Add(this.lsvHoaDonMT);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "fQLHoaDonMayTinh";
            this.Text = "fHoaDon";
            this.Load += new System.EventHandler(this.fQLHoaDonMayTinh_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsvHoaDonMT;
        private System.Windows.Forms.ColumnHeader MaHoaDonMT;
        private System.Windows.Forms.ColumnHeader MaTaiKhoan;
        private System.Windows.Forms.ColumnHeader MaMayTinh;
        private System.Windows.Forms.ColumnHeader ThoiGianMoMay;
        private System.Windows.Forms.ColumnHeader ThoiGianThanhToan;
        private System.Windows.Forms.ColumnHeader ThoiGianSuDung;
        private System.Windows.Forms.ColumnHeader TongThanhTien;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTongThanhTien;
        private System.Windows.Forms.TextBox txtThoiGianSuDung;
        private System.Windows.Forms.TextBox txtThoiGianThanhToan;
        private System.Windows.Forms.Label lbTongThanhTien;
        private System.Windows.Forms.Label lbThoiGianSuDung;
        private System.Windows.Forms.Label lbThoiGianThanhToan;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtThoiGianMoMay;
        private System.Windows.Forms.TextBox txtMaMayTinh;
        private System.Windows.Forms.TextBox txtMaTaiKhoan;
        private System.Windows.Forms.TextBox txtMaHoaDonMT;
        private System.Windows.Forms.Label lbThoiGianMoMay;
        private System.Windows.Forms.Label lbMaMayTinh;
        private System.Windows.Forms.Label lbMaTaiKhoan;
        private System.Windows.Forms.Label lbMaHoaDon;
        private System.Windows.Forms.Label label2;
    }
}