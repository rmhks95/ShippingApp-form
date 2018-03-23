namespace DotNetShipping.SampleApp
{
    partial class addVal
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
            this.add1_lab = new System.Windows.Forms.Label();
            this.add2_label = new System.Windows.Forms.Label();
            this.city_lab = new System.Windows.Forms.Label();
            this.state_lab = new System.Windows.Forms.Label();
            this.zip_lab = new System.Windows.Forms.Label();
            this.add1_box = new System.Windows.Forms.TextBox();
            this.add2_box = new System.Windows.Forms.TextBox();
            this.city_box = new System.Windows.Forms.TextBox();
            this.state_box = new System.Windows.Forms.TextBox();
            this.zip_box = new System.Windows.Forms.TextBox();
            this.check_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // add1_lab
            // 
            this.add1_lab.AutoSize = true;
            this.add1_lab.Location = new System.Drawing.Point(13, 23);
            this.add1_lab.Name = "add1_lab";
            this.add1_lab.Size = new System.Drawing.Size(57, 13);
            this.add1_lab.TabIndex = 0;
            this.add1_lab.Text = "Address 1:";
            // 
            // add2_label
            // 
            this.add2_label.AutoSize = true;
            this.add2_label.Location = new System.Drawing.Point(13, 50);
            this.add2_label.Name = "add2_label";
            this.add2_label.Size = new System.Drawing.Size(57, 13);
            this.add2_label.TabIndex = 1;
            this.add2_label.Text = "Address 2:";
            // 
            // city_lab
            // 
            this.city_lab.AutoSize = true;
            this.city_lab.Location = new System.Drawing.Point(13, 78);
            this.city_lab.Name = "city_lab";
            this.city_lab.Size = new System.Drawing.Size(27, 13);
            this.city_lab.TabIndex = 2;
            this.city_lab.Text = "City:";
            // 
            // state_lab
            // 
            this.state_lab.AutoSize = true;
            this.state_lab.Location = new System.Drawing.Point(129, 78);
            this.state_lab.Name = "state_lab";
            this.state_lab.Size = new System.Drawing.Size(35, 13);
            this.state_lab.TabIndex = 3;
            this.state_lab.Text = "State:";
            // 
            // zip_lab
            // 
            this.zip_lab.AutoSize = true;
            this.zip_lab.Location = new System.Drawing.Point(200, 78);
            this.zip_lab.Name = "zip_lab";
            this.zip_lab.Size = new System.Drawing.Size(25, 13);
            this.zip_lab.TabIndex = 4;
            this.zip_lab.Text = "Zip:";
            // 
            // add1_box
            // 
            this.add1_box.Location = new System.Drawing.Point(76, 19);
            this.add1_box.Name = "add1_box";
            this.add1_box.Size = new System.Drawing.Size(214, 20);
            this.add1_box.TabIndex = 5;
            // 
            // add2_box
            // 
            this.add2_box.Location = new System.Drawing.Point(76, 47);
            this.add2_box.Name = "add2_box";
            this.add2_box.Size = new System.Drawing.Size(214, 20);
            this.add2_box.TabIndex = 6;
            // 
            // city_box
            // 
            this.city_box.Location = new System.Drawing.Point(41, 75);
            this.city_box.Name = "city_box";
            this.city_box.Size = new System.Drawing.Size(82, 20);
            this.city_box.TabIndex = 7;
            // 
            // state_box
            // 
            this.state_box.Location = new System.Drawing.Point(165, 75);
            this.state_box.MaxLength = 2;
            this.state_box.Name = "state_box";
            this.state_box.Size = new System.Drawing.Size(26, 20);
            this.state_box.TabIndex = 8;
            // 
            // zip_box
            // 
            this.zip_box.Location = new System.Drawing.Point(222, 75);
            this.zip_box.MaxLength = 7;
            this.zip_box.Name = "zip_box";
            this.zip_box.Size = new System.Drawing.Size(68, 20);
            this.zip_box.TabIndex = 9;
            // 
            // check_button
            // 
            this.check_button.Location = new System.Drawing.Point(16, 109);
            this.check_button.Name = "check_button";
            this.check_button.Size = new System.Drawing.Size(274, 25);
            this.check_button.TabIndex = 11;
            this.check_button.Text = "Check Address";
            this.check_button.UseVisualStyleBackColor = true;
            this.check_button.Click += new System.EventHandler(this.check_button_Click);
            // 
            // addVal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 144);
            this.Controls.Add(this.check_button);
            this.Controls.Add(this.zip_box);
            this.Controls.Add(this.state_box);
            this.Controls.Add(this.city_box);
            this.Controls.Add(this.add2_box);
            this.Controls.Add(this.add1_box);
            this.Controls.Add(this.zip_lab);
            this.Controls.Add(this.state_lab);
            this.Controls.Add(this.city_lab);
            this.Controls.Add(this.add2_label);
            this.Controls.Add(this.add1_lab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "addVal";
            this.Text = "Address Validation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label add1_lab;
        private System.Windows.Forms.Label add2_label;
        private System.Windows.Forms.Label city_lab;
        private System.Windows.Forms.Label state_lab;
        private System.Windows.Forms.Label zip_lab;
        private System.Windows.Forms.TextBox add1_box;
        private System.Windows.Forms.TextBox add2_box;
        private System.Windows.Forms.TextBox city_box;
        private System.Windows.Forms.TextBox state_box;
        private System.Windows.Forms.TextBox zip_box;
        private System.Windows.Forms.Button check_button;
    }
}