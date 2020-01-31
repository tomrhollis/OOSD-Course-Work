namespace Lab1
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblkWh = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtkWh = new System.Windows.Forms.TextBox();
            this.btnCalc = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtBill = new System.Windows.Forms.TextBox();
            this.lblOffkWh = new System.Windows.Forms.Label();
            this.txtOffkWh = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstCustomers = new System.Windows.Forms.ListBox();
            this.btnAddCust = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtComTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtResTotal = new System.Windows.Forms.TextBox();
            this.txtIndTotal = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumCust = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblkWh
            // 
            this.lblkWh.Location = new System.Drawing.Point(25, 34);
            this.lblkWh.Name = "lblkWh";
            this.lblkWh.Size = new System.Drawing.Size(79, 17);
            this.lblkWh.TabIndex = 0;
            this.lblkWh.Text = "kWh:";
            this.lblkWh.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 25);
            this.label1.TabIndex = 98;
            this.label1.Text = "Billing System";
            // 
            // txtkWh
            // 
            this.txtkWh.Location = new System.Drawing.Point(110, 31);
            this.txtkWh.Name = "txtkWh";
            this.txtkWh.Size = new System.Drawing.Size(83, 22);
            this.txtkWh.TabIndex = 3;
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(7, 174);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(85, 32);
            this.btnCalc.TabIndex = 5;
            this.btnCalc.Text = "&Calculate";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // btnClear
            // 
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.Location = new System.Drawing.Point(116, 174);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(82, 32);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "C&lear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(75, 292);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(83, 32);
            this.btnQuit.TabIndex = 7;
            this.btnQuit.Text = "&Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(4, 120);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(98, 17);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "Billed Amount:";
            // 
            // txtBill
            // 
            this.txtBill.BackColor = System.Drawing.Color.PaleGreen;
            this.txtBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBill.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtBill.Location = new System.Drawing.Point(108, 117);
            this.txtBill.Name = "txtBill";
            this.txtBill.ReadOnly = true;
            this.txtBill.Size = new System.Drawing.Size(90, 22);
            this.txtBill.TabIndex = 9;
            this.txtBill.TabStop = false;
            // 
            // lblOffkWh
            // 
            this.lblOffkWh.AutoSize = true;
            this.lblOffkWh.Location = new System.Drawing.Point(4, 76);
            this.lblOffkWh.Name = "lblOffkWh";
            this.lblOffkWh.Size = new System.Drawing.Size(100, 17);
            this.lblOffkWh.TabIndex = 10;
            this.lblOffkWh.Text = "Off-Peak kWh:";
            this.lblOffkWh.Visible = false;
            // 
            // txtOffkWh
            // 
            this.txtOffkWh.Location = new System.Drawing.Point(110, 73);
            this.txtOffkWh.Name = "txtOffkWh";
            this.txtOffkWh.Size = new System.Drawing.Size(83, 22);
            this.txtOffkWh.TabIndex = 4;
            this.txtOffkWh.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(199, 206);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtOffkWh);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.lblOffkWh);
            this.groupBox1.Controls.Add(this.btnCalc);
            this.groupBox1.Controls.Add(this.lblkWh);
            this.groupBox1.Controls.Add(this.txtkWh);
            this.groupBox1.Controls.Add(this.txtBill);
            this.groupBox1.Location = new System.Drawing.Point(233, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 232);
            this.groupBox1.TabIndex = 99;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bill Calculation";
            // 
            // lstCustomers
            // 
            this.lstCustomers.FormattingEnabled = true;
            this.lstCustomers.ItemHeight = 16;
            this.lstCustomers.Location = new System.Drawing.Point(461, 49);
            this.lstCustomers.Name = "lstCustomers";
            this.lstCustomers.Size = new System.Drawing.Size(500, 516);
            this.lstCustomers.TabIndex = 100;
            this.lstCustomers.SelectedIndexChanged += new System.EventHandler(this.lstCustomers_SelectedIndexChanged);
            // 
            // btnAddCust
            // 
            this.btnAddCust.Location = new System.Drawing.Point(324, 271);
            this.btnAddCust.Name = "btnAddCust";
            this.btnAddCust.Size = new System.Drawing.Size(117, 40);
            this.btnAddCust.TabIndex = 101;
            this.btnAddCust.Text = "&Add Customer";
            this.btnAddCust.UseVisualStyleBackColor = true;
            this.btnAddCust.Click += new System.EventHandler(this.btnAddCust_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(458, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 21);
            this.label2.TabIndex = 102;
            this.label2.Text = "Customers:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtNumCust);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtTotal);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtIndTotal);
            this.groupBox2.Controls.Add(this.txtComTotal);
            this.groupBox2.Controls.Add(this.txtResTotal);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(205, 332);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(236, 258);
            this.groupBox2.TabIndex = 103;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Report of Charges";
            // 
            // txtComTotal
            // 
            this.txtComTotal.Location = new System.Drawing.Point(137, 80);
            this.txtComTotal.Name = "txtComTotal";
            this.txtComTotal.ReadOnly = true;
            this.txtComTotal.Size = new System.Drawing.Size(83, 22);
            this.txtComTotal.TabIndex = 13;
            this.txtComTotal.Text = "$0.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Industrial";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Commercial";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(41, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Residential:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtResTotal
            // 
            this.txtResTotal.Location = new System.Drawing.Point(137, 38);
            this.txtResTotal.Name = "txtResTotal";
            this.txtResTotal.ReadOnly = true;
            this.txtResTotal.Size = new System.Drawing.Size(83, 22);
            this.txtResTotal.TabIndex = 12;
            this.txtResTotal.Text = "$0.00";
            // 
            // txtIndTotal
            // 
            this.txtIndTotal.Location = new System.Drawing.Point(137, 124);
            this.txtIndTotal.Name = "txtIndTotal";
            this.txtIndTotal.ReadOnly = true;
            this.txtIndTotal.Size = new System.Drawing.Size(83, 22);
            this.txtIndTotal.TabIndex = 17;
            this.txtIndTotal.Text = "$0.00";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(137, 173);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(83, 22);
            this.txtTotal.TabIndex = 19;
            this.txtTotal.Text = "$0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(30, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Total Billed";
            // 
            // txtNumCust
            // 
            this.txtNumCust.Location = new System.Drawing.Point(137, 213);
            this.txtNumCust.Name = "txtNumCust";
            this.txtNumCust.ReadOnly = true;
            this.txtNumCust.Size = new System.Drawing.Size(83, 22);
            this.txtNumCust.TabIndex = 21;
            this.txtNumCust.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "# of Customers";
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnCalc;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.CancelButton = this.btnClear;
            this.ClientSize = new System.Drawing.Size(973, 602);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddCust);
            this.Controls.Add(this.lstCustomers);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmMain";
            this.Text = "Max Power Inc Billing Calculator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblkWh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtkWh;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtBill;
        private System.Windows.Forms.Label lblOffkWh;
        private System.Windows.Forms.TextBox txtOffkWh;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstCustomers;
        private System.Windows.Forms.Button btnAddCust;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIndTotal;
        private System.Windows.Forms.TextBox txtComTotal;
        private System.Windows.Forms.TextBox txtResTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNumCust;
        private System.Windows.Forms.Label label7;
    }
}

