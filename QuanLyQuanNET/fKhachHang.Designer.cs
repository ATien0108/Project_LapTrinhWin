namespace QuanLyQuanNET
{
    partial class fKhachHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fKhachHang));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbMayTinh = new System.Windows.Forms.ToolStripButton();
            this.tsbDichVu = new System.Windows.Forms.ToolStripButton();
            this.tsbThongTin = new System.Windows.Forms.ToolStripButton();
            this.tsbDangXuat = new System.Windows.Forms.ToolStripButton();
            this.panelTong = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Gainsboro;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbMayTinh,
            this.tsbDichVu,
            this.tsbThongTin,
            this.tsbDangXuat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(2477, 125);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbMayTinh
            // 
            this.tsbMayTinh.AutoSize = false;
            this.tsbMayTinh.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbMayTinh.Image = ((System.Drawing.Image)(resources.GetObject("tsbMayTinh.Image")));
            this.tsbMayTinh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMayTinh.Name = "tsbMayTinh";
            this.tsbMayTinh.Size = new System.Drawing.Size(250, 80);
            this.tsbMayTinh.Text = "Máy tính";
            this.tsbMayTinh.Click += new System.EventHandler(this.tsbMayTinh_Click);
            // 
            // tsbDichVu
            // 
            this.tsbDichVu.AutoSize = false;
            this.tsbDichVu.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbDichVu.Image = ((System.Drawing.Image)(resources.GetObject("tsbDichVu.Image")));
            this.tsbDichVu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDichVu.Name = "tsbDichVu";
            this.tsbDichVu.Size = new System.Drawing.Size(250, 80);
            this.tsbDichVu.Text = "Dịch vụ";
            this.tsbDichVu.Click += new System.EventHandler(this.tsbDichVu_Click);
            // 
            // tsbThongTin
            // 
            this.tsbThongTin.AutoSize = false;
            this.tsbThongTin.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbThongTin.Image = ((System.Drawing.Image)(resources.GetObject("tsbThongTin.Image")));
            this.tsbThongTin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbThongTin.Name = "tsbThongTin";
            this.tsbThongTin.Size = new System.Drawing.Size(250, 80);
            this.tsbThongTin.Text = "Thông tin";
            this.tsbThongTin.Click += new System.EventHandler(this.tsbThongTin_Click);
            // 
            // tsbDangXuat
            // 
            this.tsbDangXuat.AutoSize = false;
            this.tsbDangXuat.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbDangXuat.Image = ((System.Drawing.Image)(resources.GetObject("tsbDangXuat.Image")));
            this.tsbDangXuat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDangXuat.Name = "tsbDangXuat";
            this.tsbDangXuat.Size = new System.Drawing.Size(250, 80);
            this.tsbDangXuat.Text = "Đăng xuất";
            this.tsbDangXuat.Click += new System.EventHandler(this.tsbDangXuat_Click);
            // 
            // panelTong
            // 
            this.panelTong.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelTong.Location = new System.Drawing.Point(0, 125);
            this.panelTong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelTong.Name = "panelTong";
            this.panelTong.Size = new System.Drawing.Size(2477, 1050);
            this.panelTong.TabIndex = 2;
            // 
            // fKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2483, 1180);
            this.Controls.Add(this.panelTong);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fKhachHang";
            this.Text = "fKhachHang";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbMayTinh;
        private System.Windows.Forms.ToolStripButton tsbDichVu;
        private System.Windows.Forms.ToolStripButton tsbThongTin;
        private System.Windows.Forms.ToolStripButton tsbDangXuat;
        private System.Windows.Forms.Panel panelTong;
    }
}