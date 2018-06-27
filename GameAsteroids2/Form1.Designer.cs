namespace GameAsteroids2
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.startLabel = new System.Windows.Forms.Label();
            this.exitLabel = new System.Windows.Forms.Label();
            this.recordsLabel = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Image = global::GameAsteroids2.Resource1.GeekBrains;
            this.pictureBox1.Location = new System.Drawing.Point(45, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 50);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.BackColor = System.Drawing.SystemColors.WindowText;
            this.startLabel.Font = new System.Drawing.Font("Pixel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.startLabel.Location = new System.Drawing.Point(42, 325);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(62, 14);
            this.startLabel.TabIndex = 4;
            this.startLabel.Text = "START";
            this.startLabel.Click += new System.EventHandler(this.startLabel_Click);
            // 
            // exitLabel
            // 
            this.exitLabel.AutoSize = true;
            this.exitLabel.BackColor = System.Drawing.SystemColors.WindowText;
            this.exitLabel.Font = new System.Drawing.Font("Pixel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.exitLabel.Location = new System.Drawing.Point(42, 372);
            this.exitLabel.Name = "exitLabel";
            this.exitLabel.Size = new System.Drawing.Size(45, 14);
            this.exitLabel.TabIndex = 5;
            this.exitLabel.Text = "EXIT";
            this.exitLabel.Click += new System.EventHandler(this.exitLabel_Click);
            // 
            // recordsLabel
            // 
            this.recordsLabel.AutoSize = true;
            this.recordsLabel.BackColor = System.Drawing.SystemColors.WindowText;
            this.recordsLabel.Font = new System.Drawing.Font("Pixel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recordsLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.recordsLabel.Location = new System.Drawing.Point(42, 348);
            this.recordsLabel.Name = "recordsLabel";
            this.recordsLabel.Size = new System.Drawing.Size(119, 14);
            this.recordsLabel.TabIndex = 6;
            this.recordsLabel.Text = "HIGH SCORES";
            this.recordsLabel.Click += new System.EventHandler(this.recordsLabel_Click);
            // 
            // nameBox
            // 
            this.nameBox.BackColor = System.Drawing.SystemColors.WindowText;
            this.nameBox.Font = new System.Drawing.Font("Pixel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameBox.ForeColor = System.Drawing.SystemColors.Window;
            this.nameBox.Location = new System.Drawing.Point(302, 209);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(221, 28);
            this.nameBox.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.recordsLabel);
            this.Controls.Add(this.exitLabel);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label startLabel;
        public System.Windows.Forms.Label exitLabel;
        public System.Windows.Forms.Label recordsLabel;
        public System.Windows.Forms.TextBox nameBox;
    }
}

