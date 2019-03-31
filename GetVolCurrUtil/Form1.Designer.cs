namespace GetVolCurrUtil
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
            this.components = new System.ComponentModel.Container();
            this.startBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.voltageTB = new System.Windows.Forms.TextBox();
            this.currentTB = new System.Windows.Forms.TextBox();
            this.intervalTB = new System.Windows.Forms.TextBox();
            this.testTimeTB = new System.Windows.Forms.TextBox();
            this.remainTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(12, 160);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(174, 23);
            this.startBtn.TabIndex = 0;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Voltage (V) : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Current (mA) :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Inteval Time (ms):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "Test Time (sec):";
            // 
            // voltageTB
            // 
            this.voltageTB.Location = new System.Drawing.Point(111, 10);
            this.voltageTB.Name = "voltageTB";
            this.voltageTB.Size = new System.Drawing.Size(75, 22);
            this.voltageTB.TabIndex = 6;
            // 
            // currentTB
            // 
            this.currentTB.Location = new System.Drawing.Point(111, 38);
            this.currentTB.Name = "currentTB";
            this.currentTB.Size = new System.Drawing.Size(75, 22);
            this.currentTB.TabIndex = 7;
            // 
            // intervalTB
            // 
            this.intervalTB.Location = new System.Drawing.Point(111, 78);
            this.intervalTB.Name = "intervalTB";
            this.intervalTB.Size = new System.Drawing.Size(75, 22);
            this.intervalTB.TabIndex = 8;
            // 
            // testTimeTB
            // 
            this.testTimeTB.Location = new System.Drawing.Point(111, 109);
            this.testTimeTB.Name = "testTimeTB";
            this.testTimeTB.Size = new System.Drawing.Size(75, 22);
            this.testTimeTB.TabIndex = 9;
            // 
            // remainTime
            // 
            this.remainTime.AutoSize = true;
            this.remainTime.Location = new System.Drawing.Point(12, 135);
            this.remainTime.Name = "remainTime";
            this.remainTime.Size = new System.Drawing.Size(8, 12);
            this.remainTime.TabIndex = 10;
            this.remainTime.Text = ".";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 196);
            this.Controls.Add(this.remainTime);
            this.Controls.Add(this.testTimeTB);
            this.Controls.Add(this.intervalTB);
            this.Controls.Add(this.currentTB);
            this.Controls.Add(this.voltageTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startBtn);
            this.Name = "Form1";
            this.Text = "Get Data";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox voltageTB;
        private System.Windows.Forms.TextBox currentTB;
        private System.Windows.Forms.TextBox intervalTB;
        private System.Windows.Forms.TextBox testTimeTB;
        private System.Windows.Forms.Label remainTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}

