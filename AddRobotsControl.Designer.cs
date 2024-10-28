namespace FinalProject
{
    partial class AddRobotsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            txt_imageurl = new TextBox();
            txt_companyname = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            comboBox2 = new ComboBox();
            txt_usage2 = new ComboBox();
            button1 = new Button();
            label11 = new Label();
            comboBox1 = new ComboBox();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            txt_price = new TextBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            txt_axes = new TextBox();
            label7 = new Label();
            txt_robotweight = new TextBox();
            label6 = new Label();
            txt_reach = new TextBox();
            label5 = new Label();
            txt_payload = new TextBox();
            txt_robotname = new TextBox();
            label3 = new Label();
            label4 = new Label();
            combobox_type = new ComboBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(iconButton1);
            groupBox1.Controls.Add(txt_imageurl);
            groupBox1.Controls.Add(txt_companyname);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(3, 16);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(323, 180);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add Company";
            // 
            // iconButton1
            // 
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.Add;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(97, 128);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(112, 34);
            iconButton1.TabIndex = 4;
            iconButton1.UseVisualStyleBackColor = true;
            iconButton1.Click += iconButton1_Click;
            // 
            // txt_imageurl
            // 
            txt_imageurl.Location = new Point(150, 74);
            txt_imageurl.Name = "txt_imageurl";
            txt_imageurl.Size = new Size(150, 31);
            txt_imageurl.TabIndex = 3;
            // 
            // txt_companyname
            // 
            txt_companyname.Location = new Point(150, 34);
            txt_companyname.Name = "txt_companyname";
            txt_companyname.Size = new Size(150, 31);
            txt_companyname.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 77);
            label2.Name = "label2";
            label2.Size = new Size(98, 25);
            label2.TabIndex = 1;
            label2.Text = "Image URL";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 40);
            label1.Name = "label1";
            label1.Size = new Size(138, 25);
            label1.TabIndex = 0;
            label1.Text = "Company name";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBox2);
            groupBox2.Controls.Add(txt_usage2);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Controls.Add(iconButton2);
            groupBox2.Controls.Add(txt_price);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(txt_axes);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(txt_robotweight);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(txt_reach);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txt_payload);
            groupBox2.Controls.Add(txt_robotname);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(359, 16);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(329, 524);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Add Robot";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Cobot", "Industrial" });
            comboBox2.Location = new Point(151, 279);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(149, 33);
            comboBox2.TabIndex = 19;
            // 
            // txt_usage2
            // 
            txt_usage2.FormattingEnabled = true;
            txt_usage2.Items.AddRange(new object[] { "Arc welding", "Assembly", "Painting" });
            txt_usage2.Location = new Point(150, 240);
            txt_usage2.Name = "txt_usage2";
            txt_usage2.Size = new Size(150, 33);
            txt_usage2.TabIndex = 18;
            // 
            // button1
            // 
            button1.Location = new Point(150, 405);
            button1.Name = "button1";
            button1.Size = new Size(150, 34);
            button1.TabIndex = 2;
            button1.Text = "Refresh creators";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 359);
            label11.Name = "label11";
            label11.Size = new Size(70, 25);
            label11.TabIndex = 17;
            label11.Text = "Creator";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(150, 356);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(150, 33);
            comboBox1.TabIndex = 16;
            // 
            // iconButton2
            // 
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.FlatStyle = FlatStyle.Flat;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.Add;
            iconButton2.IconColor = Color.Black;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.Location = new Point(107, 465);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(112, 34);
            iconButton2.TabIndex = 5;
            iconButton2.UseVisualStyleBackColor = true;
            iconButton2.Click += iconButton2_Click;
            // 
            // txt_price
            // 
            txt_price.Location = new Point(150, 319);
            txt_price.Name = "txt_price";
            txt_price.Size = new Size(150, 31);
            txt_price.TabIndex = 15;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 322);
            label10.Name = "label10";
            label10.Size = new Size(69, 25);
            label10.TabIndex = 14;
            label10.Text = "Price($)";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 282);
            label9.Name = "label9";
            label9.Size = new Size(49, 25);
            label9.TabIndex = 12;
            label9.Text = "Type";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 241);
            label8.Name = "label8";
            label8.Size = new Size(133, 25);
            label8.TabIndex = 10;
            label8.Text = "Usage of robot";
            // 
            // txt_axes
            // 
            txt_axes.Location = new Point(150, 195);
            txt_axes.Name = "txt_axes";
            txt_axes.Size = new Size(150, 31);
            txt_axes.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 198);
            label7.Name = "label7";
            label7.Size = new Size(138, 25);
            label7.TabIndex = 8;
            label7.Text = "Number of axes";
            // 
            // txt_robotweight
            // 
            txt_robotweight.Location = new Point(150, 152);
            txt_robotweight.Name = "txt_robotweight";
            txt_robotweight.Size = new Size(150, 31);
            txt_robotweight.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 155);
            label6.Name = "label6";
            label6.Size = new Size(149, 25);
            label6.TabIndex = 6;
            label6.Text = "Robot weight(kg)";
            // 
            // txt_reach
            // 
            txt_reach.Location = new Point(150, 113);
            txt_reach.Name = "txt_reach";
            txt_reach.Size = new Size(150, 31);
            txt_reach.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 116);
            label5.Name = "label5";
            label5.Size = new Size(100, 25);
            label5.TabIndex = 4;
            label5.Text = "Reach(mm)";
            // 
            // txt_payload
            // 
            txt_payload.Location = new Point(150, 74);
            txt_payload.Name = "txt_payload";
            txt_payload.Size = new Size(150, 31);
            txt_payload.TabIndex = 3;
            // 
            // txt_robotname
            // 
            txt_robotname.Location = new Point(150, 34);
            txt_robotname.Name = "txt_robotname";
            txt_robotname.Size = new Size(150, 31);
            txt_robotname.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 77);
            label3.Name = "label3";
            label3.Size = new Size(104, 25);
            label3.TabIndex = 1;
            label3.Text = "Payload(kg)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 40);
            label4.Name = "label4";
            label4.Size = new Size(59, 25);
            label4.TabIndex = 0;
            label4.Text = "Name";
            // 
            // combobox_type
            // 
            combobox_type.FormattingEnabled = true;
            combobox_type.Items.AddRange(new object[] { "Cobot", "Industrial" });
            combobox_type.Location = new Point(150, 282);
            combobox_type.Name = "combobox_type";
            combobox_type.Size = new Size(150, 33);
            combobox_type.TabIndex = 19;
            // 
            // AddRobotsControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 255);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "AddRobotsControl";
            Size = new Size(1178, 660);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private TextBox txt_imageurl;
        private TextBox txt_companyname;
        private Label label2;
        private Label label1;
        private GroupBox groupBox2;
        private FontAwesome.Sharp.IconButton iconButton2;
        private TextBox txt_price;
        private Label label10;
        //private TextBox txt_type3;
        private Label label9;
        private Label label8;
        private TextBox txt_axes;
        private Label label7;
        private TextBox txt_robotweight;
        private Label label6;
        private TextBox txt_reach;
        private Label label5;
        private TextBox txt_payload;
        private TextBox txt_robotname;
        private Label label3;
        private Label label4;
        private Label label11;
        private ComboBox comboBox1;
        private Button button1;
        private ComboBox txt_usage2;
        private ComboBox combobox_type;
        private ComboBox comboBox2;
    }
}
