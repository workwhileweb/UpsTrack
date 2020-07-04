namespace UpsTrack
{
    partial class Search
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelDestZipCode = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxDestZip = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabelPages = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxPages = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabelMaxTrack = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxMaxTracks = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClear = new System.Windows.Forms.ToolStripButton();
            this.reoGridControl = new unvell.ReoGrid.ReoGridControl();
            this.toolStripDateTimeFromDate = new TTT.WinForm.Extend.ToolStripDateTime();
            this.toolStripLabelFromDate = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSearch,
            this.toolStripLabelDestZipCode,
            this.toolStripTextBoxDestZip,
            this.toolStripLabelFromDate,
            this.toolStripDateTimeFromDate,
            this.toolStripLabelPages,
            this.toolStripTextBoxPages,
            this.toolStripLabelMaxTrack,
            this.toolStripTextBoxMaxTracks,
            this.toolStripButtonSave,
            this.toolStripButtonClear});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(898, 32);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButtonSearch
            // 
            this.toolStripButtonSearch.Image = global::UpsTrack.Properties.Resources.search_15_16;
            this.toolStripButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearch.Name = "toolStripButtonSearch";
            this.toolStripButtonSearch.Size = new System.Drawing.Size(61, 29);
            this.toolStripButtonSearch.Text = "search";
            this.toolStripButtonSearch.Click += new System.EventHandler(this.ToolStripButtonSearch_Click);
            // 
            // toolStripLabelDestZipCode
            // 
            this.toolStripLabelDestZipCode.Name = "toolStripLabelDestZipCode";
            this.toolStripLabelDestZipCode.Size = new System.Drawing.Size(64, 29);
            this.toolStripLabelDestZipCode.Text = "by zipcode";
            // 
            // toolStripTextBoxDestZip
            // 
            this.toolStripTextBoxDestZip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxDestZip.Name = "toolStripTextBoxDestZip";
            this.toolStripTextBoxDestZip.Size = new System.Drawing.Size(233, 32);
            this.toolStripTextBoxDestZip.Text = global::UpsTrack.Properties.Settings.Default.Zipcode;
            // 
            // toolStripLabelPages
            // 
            this.toolStripLabelPages.Name = "toolStripLabelPages";
            this.toolStripLabelPages.Size = new System.Drawing.Size(65, 29);
            this.toolStripLabelPages.Text = "total pages";
            // 
            // toolStripTextBoxPages
            // 
            this.toolStripTextBoxPages.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxPages.Name = "toolStripTextBoxPages";
            this.toolStripTextBoxPages.Size = new System.Drawing.Size(34, 32);
            this.toolStripTextBoxPages.Text = global::UpsTrack.Properties.Settings.Default.Pages;
            // 
            // toolStripLabelMaxTrack
            // 
            this.toolStripLabelMaxTrack.Name = "toolStripLabelMaxTrack";
            this.toolStripLabelMaxTrack.Size = new System.Drawing.Size(64, 29);
            this.toolStripLabelMaxTrack.Text = "max tracks";
            // 
            // toolStripTextBoxMaxTracks
            // 
            this.toolStripTextBoxMaxTracks.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxMaxTracks.Name = "toolStripTextBoxMaxTracks";
            this.toolStripTextBoxMaxTracks.Size = new System.Drawing.Size(34, 32);
            this.toolStripTextBoxMaxTracks.Text = global::UpsTrack.Properties.Settings.Default.MaxTracks;
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.Image = global::UpsTrack.Properties.Resources.excel_16;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(50, 29);
            this.toolStripButtonSave.Text = "save";
            this.toolStripButtonSave.Click += new System.EventHandler(this.ToolStripButtonSave_Click);
            // 
            // toolStripButtonClear
            // 
            this.toolStripButtonClear.Image = global::UpsTrack.Properties.Resources.delete_property_16;
            this.toolStripButtonClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClear.Name = "toolStripButtonClear";
            this.toolStripButtonClear.Size = new System.Drawing.Size(52, 20);
            this.toolStripButtonClear.Text = "clear";
            this.toolStripButtonClear.Click += new System.EventHandler(this.ToolStripButtonClear_Click);
            // 
            // reoGridControl
            // 
            this.reoGridControl.BackColor = System.Drawing.Color.White;
            this.reoGridControl.ColumnHeaderContextMenuStrip = null;
            this.reoGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reoGridControl.LeadHeaderContextMenuStrip = null;
            this.reoGridControl.Location = new System.Drawing.Point(0, 32);
            this.reoGridControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reoGridControl.Name = "reoGridControl";
            this.reoGridControl.RowHeaderContextMenuStrip = null;
            this.reoGridControl.Script = null;
            this.reoGridControl.SheetTabContextMenuStrip = null;
            this.reoGridControl.SheetTabNewButtonVisible = true;
            this.reoGridControl.SheetTabVisible = true;
            this.reoGridControl.SheetTabWidth = 70;
            this.reoGridControl.ShowScrollEndSpacing = true;
            this.reoGridControl.Size = new System.Drawing.Size(898, 372);
            this.reoGridControl.TabIndex = 1;
            this.reoGridControl.Text = "reoGridControl1";
            // 
            // toolStripDateTimeFromDate
            // 
            this.toolStripDateTimeFromDate.BackColor = System.Drawing.Color.Transparent;
            this.toolStripDateTimeFromDate.CustomFormat = "MM/dd/yyyy";
            this.toolStripDateTimeFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.toolStripDateTimeFromDate.Name = "toolStripDateTimeFromDate";
            this.toolStripDateTimeFromDate.Size = new System.Drawing.Size(206, 29);
            this.toolStripDateTimeFromDate.Value = new System.DateTime(2020, 2, 12, 13, 18, 53, 149);
            // 
            // toolStripLabelFromDate
            // 
            this.toolStripLabelFromDate.Name = "toolStripLabelFromDate";
            this.toolStripLabelFromDate.Size = new System.Drawing.Size(33, 29);
            this.toolStripLabelFromDate.Text = "from";
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 404);
            this.Controls.Add(this.reoGridControl);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Search";
            this.Text = "track finder by h3ll";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Search_FormClosing);
            this.Load += new System.EventHandler(this.Search_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxDestZip;
        private System.Windows.Forms.ToolStripLabel toolStripLabelDestZipCode;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearch;
        private unvell.ReoGrid.ReoGridControl reoGridControl;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxPages;
        private System.Windows.Forms.ToolStripLabel toolStripLabelPages;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxMaxTracks;
        private System.Windows.Forms.ToolStripLabel toolStripLabelMaxTrack;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonClear;
        private TTT.WinForm.Extend.ToolStripDateTime toolStripDateTimeFromDate;
        private System.Windows.Forms.ToolStripLabel toolStripLabelFromDate;
    }
}

