using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;
using tx_help_center_2014.Classes;

namespace tx_help_center_2014
{
	public class frmMain : Form
	{
		private const int CS_DROPSHADOW = 131072;

		private bool bMoving;

		private int iMouseX;

		private int iMouseY;

		private TileController controller;

		private int gradientDelta;

		private bool forward = true;

		private IContainer components;

		private Label label1;

		private PictureBox pictureBox1;

		private Panel panel1;

		private MyPanel panel2;

		private PictureBox pbMinimize;

		private PictureBox pbClose;

		private Label lblTitle;

		private FlowLayoutPanel flowLayoutPanel1;

		private Label lblWhatsNext;

		private TileControl tileControl1;

		private PictureBox pictureBox2;

		private Timer timer1;

		private TileControl tileControl2;

		private TileControl tileControl3;

		private TileControl tileControl4;

		private TileControl tileControl5;

		private TileControl tileControl6;

		private TileControl tileControl7;

		private TileControl tileControl8;

		private TileControl tileControl9;

		private Panel panel3;

		private LinkLabel linkLabel1;

		private Label label4;

		private PictureBox pbBackButton;

		private PictureBox pictureBox3;

		private PictureBox pictureBox4;

		private PictureBox pictureBox7;

		private PictureBox pictureBox6;

		private PictureBox pictureBox5;

		private Timer timer2;

		private Label lblMainTitle;

		private Label label5;

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams obj = base.CreateParams;
				obj.ClassStyle |= 131072;
				return obj;
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (base.Opacity * 100.0 == 100.0)
			{
				this.timer1.Stop();
				return;
			}
			base.Opacity += 0.1;
			base.Left++;
		}

		public frmMain()
		{
			this.InitializeComponent();
			this.timer1.Interval = 1;
			this.timer1.Start();
			this.timer2.Start();
			this.controller = new TileController(this.flowLayoutPanel1, this.pbBackButton, this.pictureBox3, this.pictureBox4, this.lblMainTitle, this.lblWhatsNext);
			this.label1.Text = "Copyright © 1991 - " + DateTime.Now.Year + " Text Control GmbH";
		}

		private void label4_MouseDown(object sender, MouseEventArgs e)
		{
			this.bMoving = true;
			this.iMouseX = Cursor.Position.X - base.Left;
			this.iMouseY = Cursor.Position.Y - base.Top;
		}

		private void label4_MouseUp(object sender, MouseEventArgs e)
		{
			this.bMoving = false;
		}

		private void label4_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.bMoving)
			{
				base.Left = Cursor.Position.X - this.iMouseX;
				base.Top = Cursor.Position.Y - this.iMouseY;
			}
		}

		private void pbClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void pbMinimize_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void pbClose_MouseHover(object sender, EventArgs e)
		{
			((PictureBox)sender).BackColor = Color.LightGray;
		}

		private void pbClose_MouseLeave(object sender, EventArgs e)
		{
			((PictureBox)sender).BackColor = Color.Transparent;
		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{
			this.controller.SwitchTileGroup();
		}

		private void pictureBox3_MouseHover(object sender, EventArgs e)
		{
			Bitmap image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("tx_help_center_2014.ImgResources.back_blue.png"));
			this.pbBackButton.Image = image;
		}

		private void pictureBox3_MouseLeave(object sender, EventArgs e)
		{
			if (this.pbBackButton.Enabled)
			{
				Bitmap image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("tx_help_center_2014.ImgResources.back.png"));
				this.pbBackButton.Image = image;
			}
		}

		private void pictureBox3_VisibleChanged(object sender, EventArgs e)
		{
			this.pictureBox4.Visible = this.pictureBox3.Visible;
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://support.textcontrol.com/");
		}

		private void pictureBox5_Click(object sender, EventArgs e)
		{
			Process.Start("http://www.facebook.com/txtextcontrol/");
		}

		private void pictureBox6_Click(object sender, EventArgs e)
		{
			Process.Start("http://www.twitter.com/txtextcontrol/");
		}

		private void pictureBox7_Click(object sender, EventArgs e)
		{
			Process.Start("http://www.github.com/textcontrol/");
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			Process.Start("http://www.textcontrol.com/");
		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{
			using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Rectangle(0, 0, base.ClientSize.Width, base.ClientSize.Height), Color.FromArgb(255, 40, 46), Color.FromArgb(136, 33, 94), 45f);
			linearGradientBrush.WrapMode = WrapMode.Tile;
			ColorBlend colorBlend = new ColorBlend();
			colorBlend.Colors = new Color[3]
			{
				Color.FromArgb(255, 40, 46),
				Color.FromArgb(136, 33, 94),
				Color.FromArgb(255, 40, 46)
			};
			colorBlend.Positions = new float[3]
			{
				0f,
				(float)this.gradientDelta / 100f,
				1f
			};
			linearGradientBrush.InterpolationColors = colorBlend;
			e.Graphics.FillRectangle(linearGradientBrush, base.ClientRectangle);
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			if (this.forward)
			{
				this.gradientDelta++;
			}
			else
			{
				this.gradientDelta--;
			}
			if (this.gradientDelta == 100)
			{
				this.forward = false;
			}
			if (this.gradientDelta == 1)
			{
				this.forward = true;
			}
			this.panel2.Invalidate();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tx_help_center_2014.frmMain));
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.pbBackButton = new System.Windows.Forms.PictureBox();
			this.lblWhatsNext = new System.Windows.Forms.Label();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.panel2 = new tx_help_center_2014.Classes.MyPanel();
			this.lblMainTitle = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.pictureBox7 = new System.Windows.Forms.PictureBox();
			this.pictureBox6 = new System.Windows.Forms.PictureBox();
			this.pictureBox5 = new System.Windows.Forms.PictureBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.label4 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblTitle = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pbMinimize = new System.Windows.Forms.PictureBox();
			this.pbClose = new System.Windows.Forms.PictureBox();
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pbBackButton).BeginInit();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBox7).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBox6).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBox5).BeginInit();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pbMinimize).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pbClose).BeginInit();
			base.SuspendLayout();
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.label1.BackColor = System.Drawing.Color.FromArgb(189, 189, 189);
			this.label1.Font = new System.Drawing.Font("Segoe UI Light", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(619, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(239, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Copyright © 1991 - 2018 Text Control GmbH";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.panel1.BackColor = System.Drawing.Color.FromArgb(231, 231, 231);
			this.panel1.Controls.Add(this.pictureBox3);
			this.panel1.Controls.Add(this.pictureBox4);
			this.panel1.Controls.Add(this.pbBackButton);
			this.panel1.Controls.Add(this.lblWhatsNext);
			this.panel1.Controls.Add(this.flowLayoutPanel1);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Location = new System.Drawing.Point(12, 57);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(10);
			this.panel1.Size = new System.Drawing.Size(1039, 593);
			this.panel1.TabIndex = 2;
			this.pictureBox3.Location = new System.Drawing.Point(642, 164);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(340, 239);
			this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox3.TabIndex = 9;
			this.pictureBox3.TabStop = false;
			this.pictureBox3.Visible = false;
			this.pictureBox3.VisibleChanged += new System.EventHandler(pictureBox3_VisibleChanged);
			this.pictureBox4.Image = (System.Drawing.Image)resources.GetObject("pictureBox4.Image");
			this.pictureBox4.Location = new System.Drawing.Point(618, 384);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(388, 40);
			this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox4.TabIndex = 10;
			this.pictureBox4.TabStop = false;
			this.pictureBox4.Visible = false;
			this.pbBackButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.pbBackButton.BackColor = System.Drawing.Color.Transparent;
			this.pbBackButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pbBackButton.Enabled = false;
			this.pbBackButton.Image = (System.Drawing.Image)resources.GetObject("pbBackButton.Image");
			this.pbBackButton.Location = new System.Drawing.Point(16, 129);
			this.pbBackButton.Name = "pbBackButton";
			this.pbBackButton.Size = new System.Drawing.Size(25, 25);
			this.pbBackButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbBackButton.TabIndex = 4;
			this.pbBackButton.TabStop = false;
			this.pbBackButton.Click += new System.EventHandler(pictureBox3_Click);
			this.pbBackButton.MouseLeave += new System.EventHandler(pictureBox3_MouseLeave);
			this.pbBackButton.MouseHover += new System.EventHandler(pictureBox3_MouseHover);
			this.lblWhatsNext.AutoSize = true;
			this.lblWhatsNext.Font = new System.Drawing.Font("Segoe UI Light", 20f);
			this.lblWhatsNext.ForeColor = System.Drawing.Color.Black;
			this.lblWhatsNext.Location = new System.Drawing.Point(44, 120);
			this.lblWhatsNext.Name = "lblWhatsNext";
			this.lblWhatsNext.Size = new System.Drawing.Size(353, 37);
			this.lblWhatsNext.TabIndex = 3;
			this.lblWhatsNext.Text = "What do you want to do next?";
			this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 160);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(580, 345);
			this.flowLayoutPanel1.TabIndex = 5;
			this.panel2.BackColor = System.Drawing.Color.FromArgb(13, 57, 100);
			this.panel2.Controls.Add(this.lblMainTitle);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.pictureBox7);
			this.panel2.Controls.Add(this.pictureBox6);
			this.panel2.Controls.Add(this.pictureBox5);
			this.panel2.Location = new System.Drawing.Point(1, 0);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(10);
			this.panel2.Size = new System.Drawing.Size(1080, 103);
			this.panel2.TabIndex = 4;
			this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(panel2_Paint);
			this.lblMainTitle.AutoSize = true;
			this.lblMainTitle.BackColor = System.Drawing.Color.Transparent;
			this.lblMainTitle.Font = new System.Drawing.Font("Segoe UI Light", 16f, System.Drawing.FontStyle.Bold);
			this.lblMainTitle.ForeColor = System.Drawing.Color.White;
			this.lblMainTitle.Location = new System.Drawing.Point(10, 10);
			this.lblMainTitle.Name = "lblMainTitle";
			this.lblMainTitle.Size = new System.Drawing.Size(221, 30);
			this.lblMainTitle.TabIndex = 0;
			this.lblMainTitle.Text = "TX Text Control .NET";
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Segoe UI Light", 12f);
			this.label5.ForeColor = System.Drawing.Color.White;
			this.label5.Location = new System.Drawing.Point(11, 45);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(899, 58);
			this.label5.TabIndex = 2;
			this.label5.Text = resources.GetString("label5.Text");
			this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox7.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox7.Image = (System.Drawing.Image)resources.GetObject("pictureBox7.Image");
			this.pictureBox7.Location = new System.Drawing.Point(927, 10);
			this.pictureBox7.Margin = new System.Windows.Forms.Padding(5);
			this.pictureBox7.Name = "pictureBox7";
			this.pictureBox7.Size = new System.Drawing.Size(26, 26);
			this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox7.TabIndex = 5;
			this.pictureBox7.TabStop = false;
			this.pictureBox7.Click += new System.EventHandler(pictureBox7_Click);
			this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox6.Image = (System.Drawing.Image)resources.GetObject("pictureBox6.Image");
			this.pictureBox6.Location = new System.Drawing.Point(963, 10);
			this.pictureBox6.Margin = new System.Windows.Forms.Padding(5);
			this.pictureBox6.Name = "pictureBox6";
			this.pictureBox6.Size = new System.Drawing.Size(26, 26);
			this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox6.TabIndex = 4;
			this.pictureBox6.TabStop = false;
			this.pictureBox6.Click += new System.EventHandler(pictureBox6_Click);
			this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox5.Image = (System.Drawing.Image)resources.GetObject("pictureBox5.Image");
			this.pictureBox5.Location = new System.Drawing.Point(999, 10);
			this.pictureBox5.Margin = new System.Windows.Forms.Padding(5);
			this.pictureBox5.Name = "pictureBox5";
			this.pictureBox5.Size = new System.Drawing.Size(26, 26);
			this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox5.TabIndex = 3;
			this.pictureBox5.TabStop = false;
			this.pictureBox5.Click += new System.EventHandler(pictureBox5_Click);
			this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.panel3.BackColor = System.Drawing.Color.FromArgb(189, 189, 189);
			this.panel3.Controls.Add(this.linkLabel1);
			this.panel3.Controls.Add(this.label4);
			this.panel3.Controls.Add(this.pictureBox1);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Location = new System.Drawing.Point(1, 552);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(10);
			this.panel3.Size = new System.Drawing.Size(1038, 41);
			this.panel3.TabIndex = 8;
			this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Black;
			this.linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Font = new System.Drawing.Font("Segoe UI Light", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.linkLabel1.ForeColor = System.Drawing.Color.Black;
			this.linkLabel1.LinkColor = System.Drawing.Color.Black;
			this.linkLabel1.Location = new System.Drawing.Point(363, 14);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(143, 13);
			this.linkLabel1.TabIndex = 3;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "http://support.textcontrol.com";
			this.linkLabel1.VisitedLinkColor = System.Drawing.Color.White;
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.label4.Font = new System.Drawing.Font("Segoe UI Light", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(15, 14);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(460, 17);
			this.label4.TabIndex = 2;
			this.label4.Text = "If you have any questions regarding our products, feel free to contact us at:";
			this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(189, 189, 189);
			this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new System.Drawing.Point(875, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(150, 16);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
			this.lblTitle.BackColor = System.Drawing.Color.Transparent;
			this.lblTitle.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.lblTitle.Font = new System.Drawing.Font("Segoe UI Light", 16f);
			this.lblTitle.ForeColor = System.Drawing.Color.Black;
			this.lblTitle.Location = new System.Drawing.Point(0, 0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(1065, 54);
			this.lblTitle.TabIndex = 2;
			this.lblTitle.Text = "Text Control Help Center";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(label4_MouseDown);
			this.lblTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(label4_MouseMove);
			this.lblTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(label4_MouseUp);
			this.timer1.Tick += new System.EventHandler(timer1_Tick);
			this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
			this.pictureBox2.Location = new System.Drawing.Point(13, 18);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(200, 21);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox2.TabIndex = 6;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(label4_MouseDown);
			this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(label4_MouseMove);
			this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(label4_MouseUp);
			this.pbMinimize.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.pbMinimize.Image = (System.Drawing.Image)resources.GetObject("pbMinimize.Image");
			this.pbMinimize.Location = new System.Drawing.Point(1005, 13);
			this.pbMinimize.Name = "pbMinimize";
			this.pbMinimize.Size = new System.Drawing.Size(20, 20);
			this.pbMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pbMinimize.TabIndex = 5;
			this.pbMinimize.TabStop = false;
			this.pbMinimize.Click += new System.EventHandler(pbMinimize_Click);
			this.pbMinimize.MouseEnter += new System.EventHandler(pbClose_MouseHover);
			this.pbMinimize.MouseLeave += new System.EventHandler(pbClose_MouseLeave);
			this.pbClose.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.pbClose.Image = (System.Drawing.Image)resources.GetObject("pbClose.Image");
			this.pbClose.Location = new System.Drawing.Point(1031, 13);
			this.pbClose.Name = "pbClose";
			this.pbClose.Size = new System.Drawing.Size(20, 20);
			this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pbClose.TabIndex = 4;
			this.pbClose.TabStop = false;
			this.pbClose.Click += new System.EventHandler(pbClose_Click);
			this.pbClose.MouseEnter += new System.EventHandler(pbClose_MouseHover);
			this.pbClose.MouseLeave += new System.EventHandler(pbClose_MouseLeave);
			this.timer2.Tick += new System.EventHandler(timer2_Tick);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(252, 252, 252);
			base.ClientSize = new System.Drawing.Size(1065, 663);
			base.ControlBox = false;
			base.Controls.Add(this.pictureBox2);
			base.Controls.Add(this.pbMinimize);
			base.Controls.Add(this.pbClose);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.lblTitle);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Segoe UI Light", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "frmMain";
			base.Opacity = 0.0;
			base.Padding = new System.Windows.Forms.Padding(10);
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Text Control Help Center";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pbBackButton).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBox7).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBox6).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBox5).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pbMinimize).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pbClose).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
