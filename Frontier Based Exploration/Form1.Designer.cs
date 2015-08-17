namespace Frontier_Based_Exploration
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
            this.nextImage_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.input_pictureBox = new System.Windows.Forms.PictureBox();
            this.frontier_pictureBox = new System.Windows.Forms.PictureBox();
            this.edgeDetection_pictureBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.x_textBox = new System.Windows.Forms.TextBox();
            this.y_textBox = new System.Windows.Forms.TextBox();
            this.x_label = new System.Windows.Forms.Label();
            this.y_label = new System.Windows.Forms.Label();
            this.set_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.input_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontier_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edgeDetection_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // nextImage_button
            // 
            this.nextImage_button.Enabled = false;
            this.nextImage_button.Location = new System.Drawing.Point(196, 6);
            this.nextImage_button.Name = "nextImage_button";
            this.nextImage_button.Size = new System.Drawing.Size(75, 23);
            this.nextImage_button.TabIndex = 0;
            this.nextImage_button.Text = "Next";
            this.nextImage_button.UseVisualStyleBackColor = true;
            this.nextImage_button.Click += new System.EventHandler(this.nextImage_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Path :";
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(59, 8);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // input_pictureBox
            // 
            this.input_pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.input_pictureBox.Location = new System.Drawing.Point(8, 92);
            this.input_pictureBox.Name = "input_pictureBox";
            this.input_pictureBox.Size = new System.Drawing.Size(400, 400);
            this.input_pictureBox.TabIndex = 4;
            this.input_pictureBox.TabStop = false;
            // 
            // frontier_pictureBox
            // 
            this.frontier_pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.frontier_pictureBox.InitialImage = null;
            this.frontier_pictureBox.Location = new System.Drawing.Point(424, 92);
            this.frontier_pictureBox.Name = "frontier_pictureBox";
            this.frontier_pictureBox.Size = new System.Drawing.Size(400, 400);
            this.frontier_pictureBox.TabIndex = 5;
            this.frontier_pictureBox.TabStop = false;
            // 
            // edgeDetection_pictureBox
            // 
            this.edgeDetection_pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edgeDetection_pictureBox.InitialImage = null;
            this.edgeDetection_pictureBox.Location = new System.Drawing.Point(844, 92);
            this.edgeDetection_pictureBox.Name = "edgeDetection_pictureBox";
            this.edgeDetection_pictureBox.Size = new System.Drawing.Size(400, 400);
            this.edgeDetection_pictureBox.TabIndex = 6;
            this.edgeDetection_pictureBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Input Picture:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(424, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Frontiers :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(844, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Edge Detection :";
            // 
            // x_textBox
            // 
            this.x_textBox.Location = new System.Drawing.Point(359, 7);
            this.x_textBox.Name = "x_textBox";
            this.x_textBox.Size = new System.Drawing.Size(49, 20);
            this.x_textBox.TabIndex = 11;
            // 
            // y_textBox
            // 
            this.y_textBox.Location = new System.Drawing.Point(437, 7);
            this.y_textBox.Name = "y_textBox";
            this.y_textBox.Size = new System.Drawing.Size(49, 20);
            this.y_textBox.TabIndex = 12;
            // 
            // x_label
            // 
            this.x_label.AutoSize = true;
            this.x_label.Location = new System.Drawing.Point(336, 10);
            this.x_label.Name = "x_label";
            this.x_label.Size = new System.Drawing.Size(17, 13);
            this.x_label.TabIndex = 13;
            this.x_label.Text = "X:";
            // 
            // y_label
            // 
            this.y_label.AutoSize = true;
            this.y_label.Location = new System.Drawing.Point(414, 10);
            this.y_label.Name = "y_label";
            this.y_label.Size = new System.Drawing.Size(17, 13);
            this.y_label.TabIndex = 14;
            this.y_label.Text = "Y:";
            // 
            // set_button
            // 
            this.set_button.Location = new System.Drawing.Point(506, 5);
            this.set_button.Name = "set_button";
            this.set_button.Size = new System.Drawing.Size(58, 23);
            this.set_button.TabIndex = 15;
            this.set_button.Text = "Set";
            this.set_button.UseVisualStyleBackColor = true;
            this.set_button.Click += new System.EventHandler(this.set_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 503);
            this.Controls.Add(this.set_button);
            this.Controls.Add(this.y_label);
            this.Controls.Add(this.x_label);
            this.Controls.Add(this.y_textBox);
            this.Controls.Add(this.x_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edgeDetection_pictureBox);
            this.Controls.Add(this.frontier_pictureBox);
            this.Controls.Add(this.input_pictureBox);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nextImage_button);
            this.Name = "Form1";
            this.Text = "Frontier Based Exploration";
            ((System.ComponentModel.ISupportInitialize)(this.input_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontier_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edgeDetection_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button nextImage_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PictureBox input_pictureBox;
        private System.Windows.Forms.PictureBox frontier_pictureBox;
        private System.Windows.Forms.PictureBox edgeDetection_pictureBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox x_textBox;
        private System.Windows.Forms.TextBox y_textBox;
        private System.Windows.Forms.Label x_label;
        private System.Windows.Forms.Label y_label;
        private System.Windows.Forms.Button set_button;
    }
}

