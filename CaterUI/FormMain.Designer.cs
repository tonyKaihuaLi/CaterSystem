namespace CaterUI
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuManagerInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMemberInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTableInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDishInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOrderInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.tcHallInfo = new System.Windows.Forms.TabControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImage = global::CaterUI.Properties.Resources.menuBg;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuManagerInfo,
            this.menuMemberInfo,
            this.menuTableInfo,
            this.menuDishInfo,
            this.menuOrderInfo,
            this.menuLogout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1637, 73);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // menuManagerInfo
            // 
            this.menuManagerInfo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuManagerInfo.Image = global::CaterUI.Properties.Resources.menuManager;
            this.menuManagerInfo.Name = "menuManagerInfo";
            this.menuManagerInfo.Size = new System.Drawing.Size(260, 69);
            this.menuManagerInfo.Text = "Manager";
            this.menuManagerInfo.Click += new System.EventHandler(this.menuManagerInfo_Click);
            // 
            // menuMemberInfo
            // 
            this.menuMemberInfo.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.menuMemberInfo.Image = global::CaterUI.Properties.Resources.menuMember;
            this.menuMemberInfo.Name = "menuMemberInfo";
            this.menuMemberInfo.Size = new System.Drawing.Size(338, 69);
            this.menuMemberInfo.Text = "Membership";
            this.menuMemberInfo.Click += new System.EventHandler(this.menuMemberInfo_Click);
            // 
            // menuTableInfo
            // 
            this.menuTableInfo.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.menuTableInfo.Image = global::CaterUI.Properties.Resources.menuTable;
            this.menuTableInfo.Name = "menuTableInfo";
            this.menuTableInfo.Size = new System.Drawing.Size(181, 69);
            this.menuTableInfo.Text = "Table";
            this.menuTableInfo.Click += new System.EventHandler(this.menuTableInfo_Click);
            // 
            // menuDishInfo
            // 
            this.menuDishInfo.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.menuDishInfo.Image = global::CaterUI.Properties.Resources.menuDish;
            this.menuDishInfo.Name = "menuDishInfo";
            this.menuDishInfo.Size = new System.Drawing.Size(195, 69);
            this.menuDishInfo.Text = "Order";
            this.menuDishInfo.Click += new System.EventHandler(this.menuDishInfo_Click);
            // 
            // menuOrderInfo
            // 
            this.menuOrderInfo.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.menuOrderInfo.Image = global::CaterUI.Properties.Resources.menuOrder;
            this.menuOrderInfo.Name = "menuOrderInfo";
            this.menuOrderInfo.Size = new System.Drawing.Size(292, 69);
            this.menuOrderInfo.Text = "Check Out";
            this.menuOrderInfo.Click += new System.EventHandler(this.menuOrderInfo_Click);
            // 
            // menuLogout
            // 
            this.menuLogout.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.menuLogout.Image = global::CaterUI.Properties.Resources.menuQuit;
            this.menuLogout.Name = "menuLogout";
            this.menuLogout.Size = new System.Drawing.Size(146, 69);
            this.menuLogout.Text = "Exit";
            this.menuLogout.Click += new System.EventHandler(this.menuLogout_Click);
            // 
            // tcHallInfo
            // 
            this.tcHallInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcHallInfo.Location = new System.Drawing.Point(0, 73);
            this.tcHallInfo.Name = "tcHallInfo";
            this.tcHallInfo.SelectedIndex = 0;
            this.tcHallInfo.Size = new System.Drawing.Size(1637, 747);
            this.tcHallInfo.TabIndex = 1;
            this.tcHallInfo.SelectedIndexChanged += new System.EventHandler(this.tcHallInfo_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "desk1.png");
            this.imageList1.Images.SetKeyName(1, "desk2.png");
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1637, 820);
            this.Controls.Add(this.tcHallInfo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Manage System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuManagerInfo;
        private System.Windows.Forms.ToolStripMenuItem menuMemberInfo;
        private System.Windows.Forms.ToolStripMenuItem menuTableInfo;
        private System.Windows.Forms.ToolStripMenuItem menuDishInfo;
        private System.Windows.Forms.ToolStripMenuItem menuOrderInfo;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
        private System.Windows.Forms.TabControl tcHallInfo;
        private System.Windows.Forms.ImageList imageList1;
    }
}