﻿namespace ChordEditor.Forms
{
    partial class SheetDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SheetDatabase));
            this.LV = new BrightIdeasSoftware.ObjectListView();
            this.ChTitle = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ChArtist = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ChCategory = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ChAuthor = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ChRevisor = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.IL = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnOpen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LV)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LV
            // 
            this.LV.AllColumns.Add(this.ChTitle);
            this.LV.AllColumns.Add(this.ChArtist);
            this.LV.AllColumns.Add(this.ChCategory);
            this.LV.AllColumns.Add(this.ChAuthor);
            this.LV.AllColumns.Add(this.ChRevisor);
            this.LV.CellEditUseWholeCell = false;
            this.LV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ChTitle,
            this.ChArtist,
            this.ChCategory,
            this.ChAuthor,
            this.ChRevisor});
            this.LV.Cursor = System.Windows.Forms.Cursors.Default;
            this.LV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LV.EmptyListMsg = "";
            this.LV.FullRowSelect = true;
            this.LV.GridLines = true;
            this.LV.Location = new System.Drawing.Point(3, 3);
            this.LV.Name = "LV";
            this.LV.RowHeight = 26;
            this.LV.Size = new System.Drawing.Size(777, 425);
            this.LV.SmallImageList = this.IL;
            this.LV.TabIndex = 1;
            this.LV.UseCompatibleStateImageBehavior = false;
            this.LV.View = System.Windows.Forms.View.Details;
            this.LV.SelectionChanged += new System.EventHandler(this.LV_SelectionChanged);
            this.LV.ItemActivate += new System.EventHandler(this.LV_ItemActivate);
            // 
            // ChTitle
            // 
            this.ChTitle.AspectName = "Title";
            this.ChTitle.Text = "Title";
            this.ChTitle.UseInitialLetterForGroup = true;
            this.ChTitle.Width = 160;
            // 
            // ChArtist
            // 
            this.ChArtist.AspectName = "Artist";
            this.ChArtist.Text = "Artist";
            this.ChArtist.UseInitialLetterForGroup = true;
            this.ChArtist.Width = 100;
            // 
            // ChCategory
            // 
            this.ChCategory.AspectName = "SheetCategory";
            this.ChCategory.Text = "Category";
            // 
            // ChAuthor
            // 
            this.ChAuthor.AspectName = "SheetAuthor";
            this.ChAuthor.Text = "Author";
            // 
            // ChRevisor
            // 
            this.ChRevisor.AspectName = "SheetRevisor";
            this.ChRevisor.Text = "Revisor";
            // 
            // IL
            // 
            this.IL.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IL.ImageStream")));
            this.IL.TransparentColor = System.Drawing.Color.Transparent;
            this.IL.Images.SetKeyName(0, "incomplete");
            this.IL.Images.SetKeyName(1, "suspended");
            this.IL.Images.SetKeyName(2, "verified");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.LV, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(783, 480);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.BtnOpen, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 434);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(777, 43);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // BtnOpen
            // 
            this.BtnOpen.Enabled = false;
            this.BtnOpen.Location = new System.Drawing.Point(685, 3);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(89, 37);
            this.BtnOpen.TabIndex = 0;
            this.BtnOpen.Text = "Open";
            this.BtnOpen.UseVisualStyleBackColor = true;
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // SheetDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 480);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SheetDatabase";
            this.Text = "Sheet Database";
            this.Load += new System.EventHandler(this.SheetDatabase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LV)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView LV;
        private BrightIdeasSoftware.OLVColumn ChTitle;
        private BrightIdeasSoftware.OLVColumn ChArtist;
        private BrightIdeasSoftware.OLVColumn ChAuthor;
        private BrightIdeasSoftware.OLVColumn ChRevisor;
        private BrightIdeasSoftware.OLVColumn ChCategory;
        private System.Windows.Forms.ImageList IL;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button BtnOpen;
    }
}