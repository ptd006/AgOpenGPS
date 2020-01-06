﻿namespace AgOpenGPS
{
    partial class FormFlags
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
            this.btnSouth = new ProXoft.WinForms.RepeatButton();
            this.btnNorth = new ProXoft.WinForms.RepeatButton();
            this.lblFlagSelected = new System.Windows.Forms.Label();
            this.lblLonStart = new System.Windows.Forms.Label();
            this.lblLatStart = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEasting = new System.Windows.Forms.Label();
            this.lblNorthing = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tboxFlagNotes = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDeleteFlag = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSouth
            // 
            this.btnSouth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSouth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSouth.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.btnSouth.Image = global::AgOpenGPS.Properties.Resources.DnArrow64;
            this.btnSouth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSouth.Location = new System.Drawing.Point(173, 12);
            this.btnSouth.Name = "btnSouth";
            this.btnSouth.Size = new System.Drawing.Size(94, 52);
            this.btnSouth.TabIndex = 195;
            this.btnSouth.UseVisualStyleBackColor = true;
            this.btnSouth.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSouth_MouseDown);
            // 
            // btnNorth
            // 
            this.btnNorth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNorth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNorth.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.btnNorth.Image = global::AgOpenGPS.Properties.Resources.UpArrow64;
            this.btnNorth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNorth.Location = new System.Drawing.Point(65, 12);
            this.btnNorth.Name = "btnNorth";
            this.btnNorth.Size = new System.Drawing.Size(94, 52);
            this.btnNorth.TabIndex = 196;
            this.btnNorth.UseVisualStyleBackColor = true;
            this.btnNorth.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnNorth_MouseDown);
            // 
            // lblFlagSelected
            // 
            this.lblFlagSelected.AutoSize = true;
            this.lblFlagSelected.BackColor = System.Drawing.Color.Transparent;
            this.lblFlagSelected.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlagSelected.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFlagSelected.Location = new System.Drawing.Point(5, 18);
            this.lblFlagSelected.Name = "lblFlagSelected";
            this.lblFlagSelected.Size = new System.Drawing.Size(57, 39);
            this.lblFlagSelected.TabIndex = 200;
            this.lblFlagSelected.Text = "99";
            // 
            // lblLonStart
            // 
            this.lblLonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLonStart.AutoSize = true;
            this.lblLonStart.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLonStart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLonStart.Location = new System.Drawing.Point(168, 138);
            this.lblLonStart.Name = "lblLonStart";
            this.lblLonStart.Size = new System.Drawing.Size(101, 19);
            this.lblLonStart.TabIndex = 204;
            this.lblLonStart.Text = "-188.888888";
            // 
            // lblLatStart
            // 
            this.lblLatStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLatStart.AutoSize = true;
            this.lblLatStart.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatStart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLatStart.Location = new System.Drawing.Point(37, 138);
            this.lblLatStart.Name = "lblLatStart";
            this.lblLatStart.Size = new System.Drawing.Size(92, 19);
            this.lblLatStart.TabIndex = 203;
            this.lblLatStart.Text = "-99.999999";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(132, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 19);
            this.label4.TabIndex = 202;
            this.label4.Text = "Lon:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(5, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 19);
            this.label3.TabIndex = 201;
            this.label3.Text = "Lat:";
            // 
            // lblEasting
            // 
            this.lblEasting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEasting.AutoSize = true;
            this.lblEasting.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEasting.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEasting.Location = new System.Drawing.Point(152, 163);
            this.lblEasting.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblEasting.Name = "lblEasting";
            this.lblEasting.Size = new System.Drawing.Size(60, 19);
            this.lblEasting.TabIndex = 208;
            this.lblEasting.Text = "Easting";
            // 
            // lblNorthing
            // 
            this.lblNorthing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNorthing.AutoSize = true;
            this.lblNorthing.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNorthing.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNorthing.Location = new System.Drawing.Point(45, 163);
            this.lblNorthing.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNorthing.Name = "lblNorthing";
            this.lblNorthing.Size = new System.Drawing.Size(71, 19);
            this.lblNorthing.TabIndex = 207;
            this.lblNorthing.Text = "Northing";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(133, 163);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 19);
            this.label5.TabIndex = 206;
            this.label5.Text = "E:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(24, 163);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 19);
            this.label1.TabIndex = 205;
            this.label1.Text = "N:";
            // 
            // tboxFlagNotes
            // 
            this.tboxFlagNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxFlagNotes.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxFlagNotes.Location = new System.Drawing.Point(7, 70);
            this.tboxFlagNotes.Multiline = true;
            this.tboxFlagNotes.Name = "tboxFlagNotes";
            this.tboxFlagNotes.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tboxFlagNotes.Size = new System.Drawing.Size(258, 64);
            this.tboxFlagNotes.TabIndex = 209;
            this.tboxFlagNotes.Text = "Default";
            this.tboxFlagNotes.TextChanged += new System.EventHandler(this.tboxFlagNotes_TextChanged);
            this.tboxFlagNotes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxFlagNotes_KeyPress);
            this.tboxFlagNotes.Leave += new System.EventHandler(this.tboxFlagNotes_Leave);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnExit.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExit.Location = new System.Drawing.Point(156, 194);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(109, 79);
            this.btnExit.TabIndex = 210;
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDeleteFlag
            // 
            this.btnDeleteFlag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteFlag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDeleteFlag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteFlag.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnDeleteFlag.Image = global::AgOpenGPS.Properties.Resources.FlagDelete;
            this.btnDeleteFlag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDeleteFlag.Location = new System.Drawing.Point(7, 192);
            this.btnDeleteFlag.Name = "btnDeleteFlag";
            this.btnDeleteFlag.Size = new System.Drawing.Size(70, 79);
            this.btnDeleteFlag.TabIndex = 211;
            this.btnDeleteFlag.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeleteFlag.UseVisualStyleBackColor = true;
            this.btnDeleteFlag.Click += new System.EventHandler(this.btnDeleteFlag_Click);
            // 
            // FormFlags
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 285);
            this.ControlBox = false;
            this.Controls.Add(this.btnDeleteFlag);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.tboxFlagNotes);
            this.Controls.Add(this.lblEasting);
            this.Controls.Add(this.lblNorthing);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLonStart);
            this.Controls.Add(this.lblLatStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblFlagSelected);
            this.Controls.Add(this.btnSouth);
            this.Controls.Add(this.btnNorth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormFlags";
            this.ShowInTaskbar = false;
            this.Text = "Flags";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormFlags_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProXoft.WinForms.RepeatButton btnSouth;
        private ProXoft.WinForms.RepeatButton btnNorth;
        private System.Windows.Forms.Label lblFlagSelected;
        private System.Windows.Forms.Label lblLonStart;
        private System.Windows.Forms.Label lblLatStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblEasting;
        private System.Windows.Forms.Label lblNorthing;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tboxFlagNotes;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDeleteFlag;
    }
}