
namespace QuadTree {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.buttonStart = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.numericUpDownPointAmount = new System.Windows.Forms.NumericUpDown();
            this.labelPointAmount = new System.Windows.Forms.Label();
            this.numericUpDownNodeCapacity = new System.Windows.Forms.NumericUpDown();
            this.labelNodeCapacity = new System.Windows.Forms.Label();
            this.buttonMovingControl = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.numericUpDownColorTolerance = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDesiredRatio = new System.Windows.Forms.NumericUpDown();
            this.labelColorTolerance = new System.Windows.Forms.Label();
            this.labelDesiredRatio = new System.Windows.Forms.Label();
            this.ButtonShowCompressed = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPointAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNodeCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColorTolerance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDesiredRatio)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStart.Location = new System.Drawing.Point(14, 106);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(103, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(132, 9);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(500, 500);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.SizeChanged += new System.EventHandler(this.pictureBox_SizeChanged);
            // 
            // numericUpDownPointAmount
            // 
            this.numericUpDownPointAmount.Location = new System.Drawing.Point(14, 35);
            this.numericUpDownPointAmount.Maximum = new decimal(new int[] {
            25000,
            0,
            0,
            0});
            this.numericUpDownPointAmount.Name = "numericUpDownPointAmount";
            this.numericUpDownPointAmount.Size = new System.Drawing.Size(103, 23);
            this.numericUpDownPointAmount.TabIndex = 2;
            this.numericUpDownPointAmount.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // labelPointAmount
            // 
            this.labelPointAmount.AutoSize = true;
            this.labelPointAmount.Location = new System.Drawing.Point(16, 17);
            this.labelPointAmount.Name = "labelPointAmount";
            this.labelPointAmount.Size = new System.Drawing.Size(88, 15);
            this.labelPointAmount.TabIndex = 3;
            this.labelPointAmount.Text = "Points amount:";
            // 
            // numericUpDownNodeCapacity
            // 
            this.numericUpDownNodeCapacity.Location = new System.Drawing.Point(14, 77);
            this.numericUpDownNodeCapacity.Name = "numericUpDownNodeCapacity";
            this.numericUpDownNodeCapacity.Size = new System.Drawing.Size(103, 23);
            this.numericUpDownNodeCapacity.TabIndex = 4;
            this.numericUpDownNodeCapacity.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // labelNodeCapacity
            // 
            this.labelNodeCapacity.AutoSize = true;
            this.labelNodeCapacity.Location = new System.Drawing.Point(18, 61);
            this.labelNodeCapacity.Name = "labelNodeCapacity";
            this.labelNodeCapacity.Size = new System.Drawing.Size(86, 15);
            this.labelNodeCapacity.TabIndex = 5;
            this.labelNodeCapacity.Text = "Node capacity:";
            // 
            // buttonMovingControl
            // 
            this.buttonMovingControl.Enabled = false;
            this.buttonMovingControl.Location = new System.Drawing.Point(16, 155);
            this.buttonMovingControl.Name = "buttonMovingControl";
            this.buttonMovingControl.Size = new System.Drawing.Size(101, 40);
            this.buttonMovingControl.TabIndex = 6;
            this.buttonMovingControl.Text = "Start moving points";
            this.buttonMovingControl.UseVisualStyleBackColor = true;
            this.buttonMovingControl.Click += new System.EventHandler(this.buttonMovingControl_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(18, 215);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(99, 31);
            this.buttonLoad.TabIndex = 7;
            this.buttonLoad.Text = "Load image";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click_1);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Enabled = false;
            this.buttonGenerate.Location = new System.Drawing.Point(18, 342);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(99, 29);
            this.buttonGenerate.TabIndex = 8;
            this.buttonGenerate.Text = "Generate Tree";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // numericUpDownColorTolerance
            // 
            this.numericUpDownColorTolerance.Location = new System.Drawing.Point(18, 269);
            this.numericUpDownColorTolerance.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownColorTolerance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownColorTolerance.Name = "numericUpDownColorTolerance";
            this.numericUpDownColorTolerance.Size = new System.Drawing.Size(99, 23);
            this.numericUpDownColorTolerance.TabIndex = 9;
            this.numericUpDownColorTolerance.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDownDesiredRatio
            // 
            this.numericUpDownDesiredRatio.DecimalPlaces = 3;
            this.numericUpDownDesiredRatio.Location = new System.Drawing.Point(18, 313);
            this.numericUpDownDesiredRatio.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDesiredRatio.Name = "numericUpDownDesiredRatio";
            this.numericUpDownDesiredRatio.Size = new System.Drawing.Size(99, 23);
            this.numericUpDownDesiredRatio.TabIndex = 10;
            this.numericUpDownDesiredRatio.Value = new decimal(new int[] {
            975,
            0,
            0,
            196608});
            // 
            // labelColorTolerance
            // 
            this.labelColorTolerance.AutoSize = true;
            this.labelColorTolerance.Location = new System.Drawing.Point(20, 252);
            this.labelColorTolerance.Name = "labelColorTolerance";
            this.labelColorTolerance.Size = new System.Drawing.Size(91, 15);
            this.labelColorTolerance.TabIndex = 11;
            this.labelColorTolerance.Text = "Color tolerance:";
            // 
            // labelDesiredRatio
            // 
            this.labelDesiredRatio.AutoSize = true;
            this.labelDesiredRatio.Location = new System.Drawing.Point(28, 296);
            this.labelDesiredRatio.Name = "labelDesiredRatio";
            this.labelDesiredRatio.Size = new System.Drawing.Size(76, 15);
            this.labelDesiredRatio.TabIndex = 12;
            this.labelDesiredRatio.Text = "Desired ratio:";
            // 
            // ButtonShowCompressed
            // 
            this.ButtonShowCompressed.Enabled = false;
            this.ButtonShowCompressed.Location = new System.Drawing.Point(18, 377);
            this.ButtonShowCompressed.Name = "ButtonShowCompressed";
            this.ButtonShowCompressed.Size = new System.Drawing.Size(99, 56);
            this.ButtonShowCompressed.TabIndex = 13;
            this.ButtonShowCompressed.Text = "Show compressed image";
            this.ButtonShowCompressed.UseVisualStyleBackColor = true;
            this.ButtonShowCompressed.Click += new System.EventHandler(this.ButtonShowCompressed_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 521);
            this.Controls.Add(this.ButtonShowCompressed);
            this.Controls.Add(this.labelDesiredRatio);
            this.Controls.Add(this.labelColorTolerance);
            this.Controls.Add(this.numericUpDownDesiredRatio);
            this.Controls.Add(this.numericUpDownColorTolerance);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonMovingControl);
            this.Controls.Add(this.labelNodeCapacity);
            this.Controls.Add(this.numericUpDownNodeCapacity);
            this.Controls.Add(this.labelPointAmount);
            this.Controls.Add(this.numericUpDownPointAmount);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.buttonStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPointAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNodeCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColorTolerance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDesiredRatio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.NumericUpDown numericUpDownPointAmount;
        private System.Windows.Forms.Label labelPointAmount;
        private System.Windows.Forms.NumericUpDown numericUpDownNodeCapacity;
        private System.Windows.Forms.Label labelNodeCapacity;
        private System.Windows.Forms.Button buttonMovingControl;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.NumericUpDown numericUpDownTolerance;
        private System.Windows.Forms.NumericUpDown numericUpDownColorTolerance;
        private System.Windows.Forms.NumericUpDown numericUpDownDesiredRatio;
        private System.Windows.Forms.Label labelColorTolerance;
        private System.Windows.Forms.Label labelDesiredRatio;
        private System.Windows.Forms.Button ButtonShowCompressed;
    }
}

