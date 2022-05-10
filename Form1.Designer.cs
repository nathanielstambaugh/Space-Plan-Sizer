namespace Space_Plan_Sizer__.NET_4._8_
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTKW = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKW = new System.Windows.Forms.TextBox();
            this.txtSQFT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDoit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter KW from the ELE file:";
            // 
            // txtTKW
            // 
            this.txtTKW.Location = new System.Drawing.Point(154, 17);
            this.txtTKW.Name = "txtTKW";
            this.txtTKW.Size = new System.Drawing.Size(100, 20);
            this.txtTKW.TabIndex = 1;
            this.txtTKW.TextChanged += new System.EventHandler(this.txtTKW_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Calculated KiloWatts:";
            // 
            // txtKW
            // 
            this.txtKW.Location = new System.Drawing.Point(154, 53);
            this.txtKW.Name = "txtKW";
            this.txtKW.ReadOnly = true;
            this.txtKW.Size = new System.Drawing.Size(100, 20);
            this.txtKW.TabIndex = 3;
            this.txtKW.TextChanged += new System.EventHandler(this.txtKW_TextChanged);
            // 
            // txtSQFT
            // 
            this.txtSQFT.Location = new System.Drawing.Point(154, 94);
            this.txtSQFT.Name = "txtSQFT";
            this.txtSQFT.ReadOnly = true;
            this.txtSQFT.Size = new System.Drawing.Size(100, 20);
            this.txtSQFT.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Calculated Square Feet:";
            // 
            // txtDoit
            // 
            this.txtDoit.Location = new System.Drawing.Point(95, 137);
            this.txtDoit.Name = "txtDoit";
            this.txtDoit.Size = new System.Drawing.Size(75, 23);
            this.txtDoit.TabIndex = 6;
            this.txtDoit.Text = "Do the thing";
            this.txtDoit.UseVisualStyleBackColor = true;
            this.txtDoit.Click += new System.EventHandler(this.txtDoit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 172);
            this.Controls.Add(this.txtDoit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSQFT);
            this.Controls.Add(this.txtKW);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTKW);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Space Plan Sizer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTKW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKW;
        private System.Windows.Forms.TextBox txtSQFT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button txtDoit;
    }
}

