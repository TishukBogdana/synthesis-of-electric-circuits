namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.denominator = new System.Windows.Forms.TextBox();
            this.numerator = new System.Windows.Forms.TextBox();
            this.RLC = new System.Windows.Forms.RadioButton();
            this.RC = new System.Windows.Forms.RadioButton();
            this.RL = new System.Windows.Forms.RadioButton();
            this.LC = new System.Windows.Forms.RadioButton();
            this.maxNum = new System.Windows.Forms.TextBox();
            this.degree = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.func = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // denominator
            // 
            this.denominator.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.denominator.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.denominator.Location = new System.Drawing.Point(27, 460);
            this.denominator.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.denominator.Name = "denominator";
            this.denominator.Size = new System.Drawing.Size(537, 32);
            this.denominator.TabIndex = 0;
            this.denominator.Text = "denominator";
            this.denominator.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // numerator
            // 
            this.numerator.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numerator.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.numerator.Location = new System.Drawing.Point(27, 416);
            this.numerator.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.numerator.Name = "numerator";
            this.numerator.Size = new System.Drawing.Size(537, 32);
            this.numerator.TabIndex = 1;
            this.numerator.Text = "numerator";
            // 
            // RLC
            // 
            this.RLC.AutoSize = true;
            this.RLC.BackColor = System.Drawing.Color.Transparent;
            this.RLC.Checked = true;
            this.RLC.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RLC.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RLC.Location = new System.Drawing.Point(378, 76);
            this.RLC.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.RLC.Name = "RLC";
            this.RLC.Size = new System.Drawing.Size(67, 26);
            this.RLC.TabIndex = 2;
            this.RLC.TabStop = true;
            this.RLC.Text = "RLC";
            this.RLC.UseVisualStyleBackColor = false;
            // 
            // RC
            // 
            this.RC.AutoSize = true;
            this.RC.BackColor = System.Drawing.Color.Transparent;
            this.RC.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RC.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RC.Location = new System.Drawing.Point(378, 121);
            this.RC.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.RC.Name = "RC";
            this.RC.Size = new System.Drawing.Size(56, 26);
            this.RC.TabIndex = 3;
            this.RC.Text = "RC";
            this.RC.UseVisualStyleBackColor = false;
            // 
            // RL
            // 
            this.RL.AutoSize = true;
            this.RL.BackColor = System.Drawing.Color.Transparent;
            this.RL.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RL.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RL.Location = new System.Drawing.Point(378, 164);
            this.RL.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.RL.Name = "RL";
            this.RL.Size = new System.Drawing.Size(53, 26);
            this.RL.TabIndex = 4;
            this.RL.Text = "RL";
            this.RL.UseVisualStyleBackColor = false;
            // 
            // LC
            // 
            this.LC.AutoSize = true;
            this.LC.BackColor = System.Drawing.Color.Transparent;
            this.LC.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LC.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LC.Location = new System.Drawing.Point(378, 209);
            this.LC.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.LC.Name = "LC";
            this.LC.Size = new System.Drawing.Size(53, 26);
            this.LC.TabIndex = 5;
            this.LC.Text = "LC";
            this.LC.UseVisualStyleBackColor = false;
            // 
            // maxNum
            // 
            this.maxNum.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maxNum.ForeColor = System.Drawing.Color.Black;
            this.maxNum.Location = new System.Drawing.Point(37, 102);
            this.maxNum.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.maxNum.Name = "maxNum";
            this.maxNum.Size = new System.Drawing.Size(129, 32);
            this.maxNum.TabIndex = 7;
            this.maxNum.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // degree
            // 
            this.degree.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.degree.ForeColor = System.Drawing.Color.Black;
            this.degree.Location = new System.Drawing.Point(37, 203);
            this.degree.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.degree.Name = "degree";
            this.degree.Size = new System.Drawing.Size(129, 32);
            this.degree.TabIndex = 8;
            this.degree.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(32, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 22);
            this.label1.TabIndex = 9;
            this.label1.Text = "Maximum number of components";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(32, 181);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 22);
            this.label2.TabIndex = 10;
            this.label2.Text = "The degree of polynimial";
            // 
            // func
            // 
            this.func.FormattingEnabled = true;
            this.func.Items.AddRange(new object[] {
            "U(p)",
            "I(p)",
            "K(p) -I2(p)/I1(p)",
            "K(p) - U2(p)/U1(p)"});
            this.func.Location = new System.Drawing.Point(36, 319);
            this.func.Name = "func";
            this.func.Size = new System.Drawing.Size(121, 33);
            this.func.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(42, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 22);
            this.label3.TabIndex = 12;
            this.label3.Text = "F(p)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(27, 385);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 22);
            this.label4.TabIndex = 13;
            this.label4.Text = "Polynimial";
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(221, 511);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(81, 40);
            this.Start.TabIndex = 14;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(684, 661);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.func);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.degree);
            this.Controls.Add(this.maxNum);
            this.Controls.Add(this.LC);
            this.Controls.Add(this.RL);
            this.Controls.Add(this.RC);
            this.Controls.Add(this.RLC);
            this.Controls.Add(this.numerator);
            this.Controls.Add(this.denominator);
            this.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Form1";
            this.Text = "sintes";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox denominator;
        private System.Windows.Forms.TextBox numerator;
        private System.Windows.Forms.RadioButton RLC;
        private System.Windows.Forms.RadioButton RC;
        private System.Windows.Forms.RadioButton RL;
        private System.Windows.Forms.RadioButton LC;
        private System.Windows.Forms.TextBox maxNum;
        private System.Windows.Forms.TextBox degree;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox func;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Start;
    }

}

