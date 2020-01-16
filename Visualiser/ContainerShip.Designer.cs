namespace Visualiser
{
    partial class ContainerShip
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
            this.lboxLoadedContainers = new System.Windows.Forms.ListBox();
            this.btnCalculateOptimalLayout = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lboxShip = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddShip = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nUDWidthOfShip = new System.Windows.Forms.NumericUpDown();
            this.nUDLengthShip = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cBoxCooled = new System.Windows.Forms.CheckBox();
            this.cBoxValueable = new System.Windows.Forms.CheckBox();
            this.btnAddContainer = new System.Windows.Forms.Button();
            this.nUDContainerWeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lboxContainers = new System.Windows.Forms.ListBox();
            this.lblLink = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDWidthOfShip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDLengthShip)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDContainerWeight)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lboxLoadedContainers
            // 
            this.lboxLoadedContainers.FormattingEnabled = true;
            this.lboxLoadedContainers.Location = new System.Drawing.Point(541, 12);
            this.lboxLoadedContainers.Name = "lboxLoadedContainers";
            this.lboxLoadedContainers.Size = new System.Drawing.Size(672, 420);
            this.lboxLoadedContainers.TabIndex = 19;
            // 
            // btnCalculateOptimalLayout
            // 
            this.btnCalculateOptimalLayout.Location = new System.Drawing.Point(213, 375);
            this.btnCalculateOptimalLayout.Name = "btnCalculateOptimalLayout";
            this.btnCalculateOptimalLayout.Size = new System.Drawing.Size(61, 62);
            this.btnCalculateOptimalLayout.TabIndex = 18;
            this.btnCalculateOptimalLayout.Text = "Calculate optimal layout";
            this.btnCalculateOptimalLayout.UseVisualStyleBackColor = true;
            this.btnCalculateOptimalLayout.Click += new System.EventHandler(this.btnCalculateOptimalLayout_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lboxShip);
            this.groupBox4.Location = new System.Drawing.Point(150, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(124, 145);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Shiplist:";
            // 
            // lboxShip
            // 
            this.lboxShip.FormattingEnabled = true;
            this.lboxShip.Location = new System.Drawing.Point(7, 20);
            this.lboxShip.Name = "lboxShip";
            this.lboxShip.Size = new System.Drawing.Size(111, 121);
            this.lboxShip.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAddShip);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.nUDWidthOfShip);
            this.groupBox2.Controls.Add(this.nUDLengthShip);
            this.groupBox2.Location = new System.Drawing.Point(6, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(138, 146);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add ship";
            // 
            // btnAddShip
            // 
            this.btnAddShip.Location = new System.Drawing.Point(6, 113);
            this.btnAddShip.Name = "btnAddShip";
            this.btnAddShip.Size = new System.Drawing.Size(120, 23);
            this.btnAddShip.TabIndex = 4;
            this.btnAddShip.Text = "Add";
            this.btnAddShip.UseVisualStyleBackColor = true;
            this.btnAddShip.Click += new System.EventHandler(this.btnAddShip_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Width of ship:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Length of ship:";
            // 
            // nUDWidthOfShip
            // 
            this.nUDWidthOfShip.Location = new System.Drawing.Point(6, 87);
            this.nUDWidthOfShip.Name = "nUDWidthOfShip";
            this.nUDWidthOfShip.Size = new System.Drawing.Size(120, 20);
            this.nUDWidthOfShip.TabIndex = 1;
            // 
            // nUDLengthShip
            // 
            this.nUDLengthShip.Location = new System.Drawing.Point(6, 36);
            this.nUDLengthShip.Name = "nUDLengthShip";
            this.nUDLengthShip.Size = new System.Drawing.Size(120, 20);
            this.nUDLengthShip.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cBoxCooled);
            this.groupBox1.Controls.Add(this.cBoxValueable);
            this.groupBox1.Controls.Add(this.btnAddContainer);
            this.groupBox1.Controls.Add(this.nUDContainerWeight);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 239);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 198);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add container";
            // 
            // cBoxCooled
            // 
            this.cBoxCooled.AutoSize = true;
            this.cBoxCooled.Location = new System.Drawing.Point(6, 160);
            this.cBoxCooled.Name = "cBoxCooled";
            this.cBoxCooled.Size = new System.Drawing.Size(59, 17);
            this.cBoxCooled.TabIndex = 7;
            this.cBoxCooled.Text = "Cooled";
            this.cBoxCooled.UseVisualStyleBackColor = true;
            // 
            // cBoxValueable
            // 
            this.cBoxValueable.AutoSize = true;
            this.cBoxValueable.Location = new System.Drawing.Point(7, 136);
            this.cBoxValueable.Name = "cBoxValueable";
            this.cBoxValueable.Size = new System.Drawing.Size(67, 17);
            this.cBoxValueable.TabIndex = 6;
            this.cBoxValueable.Text = "Valuable";
            this.cBoxValueable.UseVisualStyleBackColor = true;
            // 
            // btnAddContainer
            // 
            this.btnAddContainer.Location = new System.Drawing.Point(132, 169);
            this.btnAddContainer.Name = "btnAddContainer";
            this.btnAddContainer.Size = new System.Drawing.Size(62, 23);
            this.btnAddContainer.TabIndex = 5;
            this.btnAddContainer.Text = "Add";
            this.btnAddContainer.UseVisualStyleBackColor = true;
            this.btnAddContainer.Click += new System.EventHandler(this.btnAddContainer_Click);
            // 
            // nUDContainerWeight
            // 
            this.nUDContainerWeight.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUDContainerWeight.Location = new System.Drawing.Point(7, 44);
            this.nUDContainerWeight.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.nUDContainerWeight.Minimum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.nUDContainerWeight.Name = "nUDContainerWeight";
            this.nUDContainerWeight.Size = new System.Drawing.Size(120, 20);
            this.nUDContainerWeight.TabIndex = 4;
            this.nUDContainerWeight.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "kg";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type container:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Container weight:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lboxContainers);
            this.groupBox3.Location = new System.Drawing.Point(280, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(254, 426);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Containerlist:";
            // 
            // lboxContainers
            // 
            this.lboxContainers.FormattingEnabled = true;
            this.lboxContainers.Location = new System.Drawing.Point(6, 19);
            this.lboxContainers.Name = "lboxContainers";
            this.lboxContainers.Size = new System.Drawing.Size(242, 394);
            this.lboxContainers.TabIndex = 3;
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Location = new System.Drawing.Point(32, 459);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(30, 13);
            this.lblLink.TabIndex = 20;
            this.lblLink.Text = "Link:";
            // 
            // ContainerShip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 497);
            this.Controls.Add(this.lblLink);
            this.Controls.Add(this.lboxLoadedContainers);
            this.Controls.Add(this.btnCalculateOptimalLayout);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "ContainerShip";
            this.Text = "ContainerShip";
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDWidthOfShip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDLengthShip)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDContainerWeight)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lboxLoadedContainers;
        private System.Windows.Forms.Button btnCalculateOptimalLayout;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lboxShip;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddShip;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nUDWidthOfShip;
        private System.Windows.Forms.NumericUpDown nUDLengthShip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cBoxCooled;
        private System.Windows.Forms.CheckBox cBoxValueable;
        private System.Windows.Forms.Button btnAddContainer;
        private System.Windows.Forms.NumericUpDown nUDContainerWeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lboxContainers;
        private System.Windows.Forms.Label lblLink;
    }
}