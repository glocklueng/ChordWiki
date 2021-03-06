﻿namespace ChordEditor.Forms
{
	partial class SpashScreen
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
						System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpashScreen));
						this.CloseTimer = new System.Windows.Forms.Timer(this.components);
						this.LblVersion = new System.Windows.Forms.Label();
						this.SuspendLayout();
						// 
						// CloseTimer
						// 
						this.CloseTimer.Interval = 2000;
						this.CloseTimer.Tick += new System.EventHandler(this.CloseTimer_Tick);
						// 
						// LblVersion
						// 
						this.LblVersion.Anchor = System.Windows.Forms.AnchorStyles.Right;
						this.LblVersion.BackColor = System.Drawing.Color.Transparent;
						this.LblVersion.ForeColor = System.Drawing.Color.White;
						this.LblVersion.Location = new System.Drawing.Point(454, 73);
						this.LblVersion.Name = "LblVersion";
						this.LblVersion.Size = new System.Drawing.Size(132, 17);
						this.LblVersion.TabIndex = 0;
						this.LblVersion.Text = "Version 1.0.0.0";
						this.LblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
						// 
						// SpashScreen
						// 
						this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
						this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
						this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
						this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
						this.ClientSize = new System.Drawing.Size(598, 398);
						this.Controls.Add(this.LblVersion);
						this.DoubleBuffered = true;
						this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
						this.Name = "SpashScreen";
						this.ShowInTaskbar = false;
						this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
						this.Text = "SpashScreen";
						this.TopMost = true;
						this.Click += new System.EventHandler(this.SpashScreen_Click);
						this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer CloseTimer;
		private System.Windows.Forms.Label LblVersion;
	}
}