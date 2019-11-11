﻿namespace AgOpenGPS
{
    partial class FormEditAB
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
            this.nudMinTurnRadius = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSmallSnapRight = new System.Windows.Forms.Label();
            this.lblSnapSmallLeft = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.bntOK = new System.Windows.Forms.Button();
            this.btnAdjLeft = new System.Windows.Forms.Button();
            this.btnAdjRight = new System.Windows.Forms.Button();
            this.btnLeftFullWidth = new System.Windows.Forms.Button();
            this.btnRightFullWidth = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnSnap = new System.Windows.Forms.Button();
            this.lblWidthRight = new System.Windows.Forms.Label();
            this.lblWidthLeft = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinTurnRadius)).BeginInit();
            this.SuspendLayout();
            // 
            // nudMinTurnRadius
            // 
            this.nudMinTurnRadius.BackColor = System.Drawing.Color.AliceBlue;
            this.nudMinTurnRadius.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMinTurnRadius.InterceptArrowKeys = false;
            this.nudMinTurnRadius.Location = new System.Drawing.Point(81, 98);
            this.nudMinTurnRadius.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudMinTurnRadius.Name = "nudMinTurnRadius";
            this.nudMinTurnRadius.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudMinTurnRadius.Size = new System.Drawing.Size(152, 46);
            this.nudMinTurnRadius.TabIndex = 411;
            this.nudMinTurnRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudMinTurnRadius.ValueChanged += new System.EventHandler(this.nudMinTurnRadius_ValueChanged);
            this.nudMinTurnRadius.Enter += new System.EventHandler(this.nudMinTurnRadius_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(134, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 19);
            this.label1.TabIndex = 414;
            this.label1.Text = "cm";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSmallSnapRight
            // 
            this.lblSmallSnapRight.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSmallSnapRight.Location = new System.Drawing.Point(302, 3);
            this.lblSmallSnapRight.Name = "lblSmallSnapRight";
            this.lblSmallSnapRight.Size = new System.Drawing.Size(74, 19);
            this.lblSmallSnapRight.TabIndex = 416;
            this.lblSmallSnapRight.Text = "10 cm";
            this.lblSmallSnapRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSnapSmallLeft
            // 
            this.lblSnapSmallLeft.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSnapSmallLeft.Location = new System.Drawing.Point(108, 3);
            this.lblSnapSmallLeft.Name = "lblSnapSmallLeft";
            this.lblSnapSmallLeft.Size = new System.Drawing.Size(74, 19);
            this.lblSnapSmallLeft.TabIndex = 417;
            this.lblSnapSmallLeft.Text = "-10 cm";
            this.lblSnapSmallLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(329, 96);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 58);
            this.btnCancel.TabIndex = 420;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // bntOK
            // 
            this.bntOK.BackColor = System.Drawing.Color.Transparent;
            this.bntOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntOK.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.bntOK.FlatAppearance.BorderSize = 0;
            this.bntOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntOK.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.bntOK.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.bntOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bntOK.Location = new System.Drawing.Point(408, 96);
            this.bntOK.Name = "bntOK";
            this.bntOK.Size = new System.Drawing.Size(70, 58);
            this.bntOK.TabIndex = 419;
            this.bntOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bntOK.UseVisualStyleBackColor = false;
            this.bntOK.Click += new System.EventHandler(this.bntOk_Click);
            // 
            // btnAdjLeft
            // 
            this.btnAdjLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnAdjLeft.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnAdjLeft.FlatAppearance.BorderSize = 0;
            this.btnAdjLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdjLeft.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnAdjLeft.Image = global::AgOpenGPS.Properties.Resources.SnapLeftBig;
            this.btnAdjLeft.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdjLeft.Location = new System.Drawing.Point(4, 98);
            this.btnAdjLeft.Name = "btnAdjLeft";
            this.btnAdjLeft.Size = new System.Drawing.Size(71, 45);
            this.btnAdjLeft.TabIndex = 413;
            this.btnAdjLeft.UseVisualStyleBackColor = false;
            this.btnAdjLeft.Click += new System.EventHandler(this.btnAdjLeft_Click);
            // 
            // btnAdjRight
            // 
            this.btnAdjRight.BackColor = System.Drawing.Color.Transparent;
            this.btnAdjRight.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnAdjRight.FlatAppearance.BorderSize = 0;
            this.btnAdjRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdjRight.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnAdjRight.Image = global::AgOpenGPS.Properties.Resources.SnapRightBig;
            this.btnAdjRight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdjRight.Location = new System.Drawing.Point(239, 98);
            this.btnAdjRight.Name = "btnAdjRight";
            this.btnAdjRight.Size = new System.Drawing.Size(73, 45);
            this.btnAdjRight.TabIndex = 412;
            this.btnAdjRight.UseVisualStyleBackColor = false;
            this.btnAdjRight.Click += new System.EventHandler(this.btnAdjRight_Click);
            // 
            // btnLeftFullWidth
            // 
            this.btnLeftFullWidth.BackColor = System.Drawing.Color.Transparent;
            this.btnLeftFullWidth.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnLeftFullWidth.FlatAppearance.BorderSize = 0;
            this.btnLeftFullWidth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeftFullWidth.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnLeftFullWidth.Image = global::AgOpenGPS.Properties.Resources.SnapLeftWidth;
            this.btnLeftFullWidth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLeftFullWidth.Location = new System.Drawing.Point(17, 19);
            this.btnLeftFullWidth.Name = "btnLeftFullWidth";
            this.btnLeftFullWidth.Size = new System.Drawing.Size(70, 45);
            this.btnLeftFullWidth.TabIndex = 404;
            this.btnLeftFullWidth.UseVisualStyleBackColor = false;
            this.btnLeftFullWidth.Click += new System.EventHandler(this.btnLeftFullWidth_Click);
            // 
            // btnRightFullWidth
            // 
            this.btnRightFullWidth.BackColor = System.Drawing.Color.Transparent;
            this.btnRightFullWidth.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnRightFullWidth.FlatAppearance.BorderSize = 0;
            this.btnRightFullWidth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRightFullWidth.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnRightFullWidth.Image = global::AgOpenGPS.Properties.Resources.SnapRightWidth;
            this.btnRightFullWidth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRightFullWidth.Location = new System.Drawing.Point(401, 19);
            this.btnRightFullWidth.Name = "btnRightFullWidth";
            this.btnRightFullWidth.Size = new System.Drawing.Size(70, 45);
            this.btnRightFullWidth.TabIndex = 403;
            this.btnRightFullWidth.UseVisualStyleBackColor = false;
            this.btnRightFullWidth.Click += new System.EventHandler(this.btnRightFullWidth_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnLeft.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnLeft.FlatAppearance.BorderSize = 0;
            this.btnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeft.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeft.Image = global::AgOpenGPS.Properties.Resources.SnapLeft;
            this.btnLeft.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLeft.Location = new System.Drawing.Point(112, 19);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(70, 45);
            this.btnLeft.TabIndex = 277;
            this.btnLeft.UseVisualStyleBackColor = false;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.BackColor = System.Drawing.Color.Transparent;
            this.btnRight.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnRight.FlatAppearance.BorderSize = 0;
            this.btnRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRight.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRight.Image = global::AgOpenGPS.Properties.Resources.SnapRight;
            this.btnRight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRight.Location = new System.Drawing.Point(306, 19);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(70, 45);
            this.btnRight.TabIndex = 278;
            this.btnRight.UseVisualStyleBackColor = false;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnSnap
            // 
            this.btnSnap.BackColor = System.Drawing.Color.Transparent;
            this.btnSnap.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.btnSnap.FlatAppearance.BorderSize = 0;
            this.btnSnap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSnap.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSnap.Image = global::AgOpenGPS.Properties.Resources.Snap2;
            this.btnSnap.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSnap.Location = new System.Drawing.Point(207, 19);
            this.btnSnap.Name = "btnSnap";
            this.btnSnap.Size = new System.Drawing.Size(74, 45);
            this.btnSnap.TabIndex = 179;
            this.btnSnap.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSnap.UseVisualStyleBackColor = false;
            this.btnSnap.Click += new System.EventHandler(this.btnSnap_Click);
            // 
            // lblWidthRight
            // 
            this.lblWidthRight.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWidthRight.Location = new System.Drawing.Point(397, 3);
            this.lblWidthRight.Name = "lblWidthRight";
            this.lblWidthRight.Size = new System.Drawing.Size(81, 19);
            this.lblWidthRight.TabIndex = 421;
            this.lblWidthRight.Text = "2.3m";
            this.lblWidthRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWidthLeft
            // 
            this.lblWidthLeft.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWidthLeft.Location = new System.Drawing.Point(8, 3);
            this.lblWidthLeft.Name = "lblWidthLeft";
            this.lblWidthLeft.Size = new System.Drawing.Size(90, 19);
            this.lblWidthLeft.TabIndex = 422;
            this.lblWidthLeft.Text = "-28.3m";
            this.lblWidthLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormEditAB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(490, 161);
            this.ControlBox = false;
            this.Controls.Add(this.lblWidthLeft);
            this.Controls.Add(this.lblWidthRight);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.bntOK);
            this.Controls.Add(this.lblSnapSmallLeft);
            this.Controls.Add(this.lblSmallSnapRight);
            this.Controls.Add(this.btnAdjLeft);
            this.Controls.Add(this.btnAdjRight);
            this.Controls.Add(this.nudMinTurnRadius);
            this.Controls.Add(this.btnLeftFullWidth);
            this.Controls.Add(this.btnRightFullWidth);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnSnap);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormEditAB";
            this.ShowInTaskbar = false;
            this.Text = "Edit AB Line";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormEditAB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudMinTurnRadius)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button btnSnap;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnRightFullWidth;
        private System.Windows.Forms.Button btnLeftFullWidth;
        private System.Windows.Forms.NumericUpDown nudMinTurnRadius;
        private System.Windows.Forms.Button btnAdjRight;
        private System.Windows.Forms.Button btnAdjLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSmallSnapRight;
        private System.Windows.Forms.Label lblSnapSmallLeft;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button bntOK;
        private System.Windows.Forms.Label lblWidthRight;
        private System.Windows.Forms.Label lblWidthLeft;
    }
}