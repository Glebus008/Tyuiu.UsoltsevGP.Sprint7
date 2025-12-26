namespace Tyuiu.UsoltsevGP.Sprint7.V8
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            panel1 = new Panel();
            button3 = new Button();
            pictureBox1 = new PictureBox();
            groupBox6 = new GroupBox();
            button4 = new Button();
            textBox6 = new TextBox();
            button2 = new Button();
            button1 = new Button();
            panel2 = new Panel();
            groupBox8 = new GroupBox();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            groupBox7 = new GroupBox();
            button9 = new Button();
            groupBox5 = new GroupBox();
            textBox5 = new TextBox();
            groupBox4 = new GroupBox();
            textBox4 = new TextBox();
            groupBox3 = new GroupBox();
            textBox3 = new TextBox();
            groupBox2 = new GroupBox();
            textBox2 = new TextBox();
            groupBox1 = new GroupBox();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            splitter1 = new Splitter();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox6.SuspendLayout();
            panel2.SuspendLayout();
            groupBox8.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSkyBlue;
            panel1.Controls.Add(button3);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(groupBox6);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1114, 110);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.Location = new Point(1032, 21);
            button3.Name = "button3";
            button3.Size = new Size(70, 69);
            button3.TabIndex = 6;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(251, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(43, 41);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(button4);
            groupBox6.Controls.Add(textBox6);
            groupBox6.Location = new Point(300, 12);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(559, 92);
            groupBox6.TabIndex = 4;
            groupBox6.TabStop = false;
            groupBox6.Text = "Введите марку авт.";
            // 
            // button4
            // 
            button4.BackColor = SystemColors.MenuHighlight;
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button4.ForeColor = Color.White;
            button4.Location = new Point(6, 51);
            button4.Name = "button4";
            button4.Size = new Size(547, 35);
            button4.TabIndex = 1;
            button4.Text = "Поиск";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(6, 22);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(547, 23);
            textBox6.TabIndex = 0;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(88, 21);
            button2.Name = "button2";
            button2.Size = new Size(70, 69);
            button2.TabIndex = 1;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(12, 21);
            button1.Name = "button1";
            button1.Size = new Size(70, 69);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.GradientActiveCaption;
            panel2.Controls.Add(groupBox8);
            panel2.Controls.Add(groupBox7);
            panel2.Controls.Add(groupBox5);
            panel2.Controls.Add(groupBox4);
            panel2.Controls.Add(groupBox3);
            panel2.Controls.Add(groupBox2);
            panel2.Controls.Add(groupBox1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 110);
            panel2.Name = "panel2";
            panel2.Size = new Size(301, 481);
            panel2.TabIndex = 1;
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(button8);
            groupBox8.Controls.Add(button7);
            groupBox8.Controls.Add(button6);
            groupBox8.Dock = DockStyle.Top;
            groupBox8.Location = new Point(0, 343);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(301, 138);
            groupBox8.TabIndex = 5;
            groupBox8.TabStop = false;
            groupBox8.Text = "Фильтрация по";
            // 
            // button8
            // 
            button8.BackColor = Color.MediumSeaGreen;
            button8.Dock = DockStyle.Top;
            button8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button8.Location = new Point(3, 95);
            button8.Name = "button8";
            button8.Size = new Size(295, 38);
            button8.TabIndex = 2;
            button8.Text = "Расходу топлива";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.Gold;
            button7.Dock = DockStyle.Top;
            button7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button7.Location = new Point(3, 57);
            button7.Name = "button7";
            button7.Size = new Size(295, 38);
            button7.TabIndex = 1;
            button7.Text = "Средней скорости";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.Salmon;
            button6.Dock = DockStyle.Top;
            button6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button6.Location = new Point(3, 19);
            button6.Name = "button6";
            button6.Size = new Size(295, 38);
            button6.TabIndex = 0;
            button6.Text = "Техническому состояннию";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(button9);
            groupBox7.Dock = DockStyle.Top;
            groupBox7.Location = new Point(0, 278);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(301, 65);
            groupBox7.TabIndex = 4;
            groupBox7.TabStop = false;
            groupBox7.Text = "Ввести данные?";
            // 
            // button9
            // 
            button9.BackColor = Color.LightSkyBlue;
            button9.Dock = DockStyle.Fill;
            button9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button9.Location = new Point(3, 19);
            button9.Name = "button9";
            button9.Size = new Size(295, 43);
            button9.TabIndex = 1;
            button9.Text = "Подтвердить";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(textBox5);
            groupBox5.Dock = DockStyle.Top;
            groupBox5.Location = new Point(0, 220);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(301, 58);
            groupBox5.TabIndex = 1;
            groupBox5.TabStop = false;
            groupBox5.Text = "Расход топлива (л/100км)";
            // 
            // textBox5
            // 
            textBox5.Dock = DockStyle.Fill;
            textBox5.Location = new Point(3, 19);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(295, 23);
            textBox5.TabIndex = 4;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(textBox4);
            groupBox4.Dock = DockStyle.Top;
            groupBox4.Location = new Point(0, 162);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(301, 58);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Сред. скорость (км/ч)";
            // 
            // textBox4
            // 
            textBox4.Dock = DockStyle.Fill;
            textBox4.Location = new Point(3, 19);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(295, 23);
            textBox4.TabIndex = 3;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBox3);
            groupBox3.Dock = DockStyle.Top;
            groupBox3.Location = new Point(0, 106);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(301, 56);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Тех. состояние";
            // 
            // textBox3
            // 
            textBox3.Dock = DockStyle.Fill;
            textBox3.Location = new Point(3, 19);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(295, 23);
            textBox3.TabIndex = 2;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox2);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 51);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(301, 55);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Марка автомобиля";
            // 
            // textBox2
            // 
            textBox2.Dock = DockStyle.Fill;
            textBox2.Location = new Point(3, 19);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(295, 23);
            textBox2.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(301, 51);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Номерной знак";
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(3, 19);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(295, 23);
            textBox1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Left;
            dataGridView1.Location = new Point(301, 110);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(554, 481);
            dataGridView1.TabIndex = 2;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea2);
            chart1.Dock = DockStyle.Fill;
            legend2.Name = "Legend1";
            chart1.Legends.Add(legend2);
            chart1.Location = new Point(855, 110);
            chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.CustomProperties = "PointWidth=1.5";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chart1.Series.Add(series2);
            chart1.Size = new Size(259, 481);
            chart1.TabIndex = 3;
            chart1.Text = "chart1";
            // 
            // splitter1
            // 
            splitter1.Location = new Point(855, 110);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(3, 481);
            splitter1.TabIndex = 4;
            splitter1.TabStop = false;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1114, 591);
            Controls.Add(splitter1);
            Controls.Add(chart1);
            Controls.Add(dataGridView1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MinimumSize = new Size(1130, 630);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Программа";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            panel2.ResumeLayout(false);
            groupBox8.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button2;
        private Button button1;
        private Panel panel2;
        private DataGridView dataGridView1;
        private GroupBox groupBox5;
        private GroupBox groupBox4;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private GroupBox groupBox6;
        private Button button4;
        private TextBox textBox6;
        private GroupBox groupBox7;
        private Button button8;
        private Button button7;
        private Button button6;
        private GroupBox groupBox8;
        private Button button9;
        private PictureBox pictureBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Splitter splitter1;
        private Button button3;
    }
}