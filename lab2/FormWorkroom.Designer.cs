namespace lab2
{
    partial class FormWorkroom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWorkroom));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Owners = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton__Cars = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Mechanics = new System.Windows.Forms.ToolStripButton();
            this.dataGridView_Workroom = new System.Windows.Forms.DataGridView();
            this.workroomID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mechanicID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiptDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_model = new System.Windows.Forms.TextBox();
            this.textBox_mechanic = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Workroom)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Owners,
            this.toolStripButton__Cars,
            this.toolStripButton_Mechanics});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripButton_Owners
            // 
            this.toolStripButton_Owners.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripButton_Owners, "toolStripButton_Owners");
            this.toolStripButton_Owners.Name = "toolStripButton_Owners";
            this.toolStripButton_Owners.Click += new System.EventHandler(this.toolStripButton_Owners_Click);
            // 
            // toolStripButton__Cars
            // 
            this.toolStripButton__Cars.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripButton__Cars, "toolStripButton__Cars");
            this.toolStripButton__Cars.Name = "toolStripButton__Cars";
            this.toolStripButton__Cars.Click += new System.EventHandler(this.toolStripButton__Cars_Click);
            // 
            // toolStripButton_Mechanics
            // 
            this.toolStripButton_Mechanics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripButton_Mechanics, "toolStripButton_Mechanics");
            this.toolStripButton_Mechanics.Name = "toolStripButton_Mechanics";
            this.toolStripButton_Mechanics.Click += new System.EventHandler(this.toolStripButton_Mechanics_Click);
            // 
            // dataGridView_Workroom
            // 
            this.dataGridView_Workroom.AllowUserToAddRows = false;
            this.dataGridView_Workroom.AllowUserToDeleteRows = false;
            this.dataGridView_Workroom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Workroom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.workroomID,
            this.carID,
            this.mechanicID,
            this.receiptDate,
            this.cost});
            resources.ApplyResources(this.dataGridView_Workroom, "dataGridView_Workroom");
            this.dataGridView_Workroom.Name = "dataGridView_Workroom";
            this.dataGridView_Workroom.ReadOnly = true;
            this.dataGridView_Workroom.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Workroom_CellContentClick);
            // 
            // workroomID
            // 
            this.workroomID.Frozen = true;
            resources.ApplyResources(this.workroomID, "workroomID");
            this.workroomID.Name = "workroomID";
            this.workroomID.ReadOnly = true;
            // 
            // carID
            // 
            this.carID.Frozen = true;
            resources.ApplyResources(this.carID, "carID");
            this.carID.Name = "carID";
            this.carID.ReadOnly = true;
            // 
            // mechanicID
            // 
            this.mechanicID.Frozen = true;
            resources.ApplyResources(this.mechanicID, "mechanicID");
            this.mechanicID.Name = "mechanicID";
            this.mechanicID.ReadOnly = true;
            // 
            // receiptDate
            // 
            this.receiptDate.Frozen = true;
            resources.ApplyResources(this.receiptDate, "receiptDate");
            this.receiptDate.Name = "receiptDate";
            this.receiptDate.ReadOnly = true;
            // 
            // cost
            // 
            this.cost.Frozen = true;
            resources.ApplyResources(this.cost, "cost");
            this.cost.Name = "cost";
            this.cost.ReadOnly = true;
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.Name = "comboBox1";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox2, "comboBox2");
            this.comboBox2.Name = "comboBox2";
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.SystemColors.ActiveBorder;
            resources.ApplyResources(this.buttonAdd, "buttonAdd");
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.SystemColors.ActiveBorder;
            resources.ApplyResources(this.buttonUpdate, "buttonUpdate");
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            resources.ApplyResources(this.buttonDel, "buttonDel");
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.UseVisualStyleBackColor = false;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonDel);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.buttonUpdate);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.buttonAdd);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // dateTimePicker1
            // 
            resources.ApplyResources(this.dateTimePicker1, "dateTimePicker1");
            this.dateTimePicker1.Name = "dateTimePicker1";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // textBox_model
            // 
            resources.ApplyResources(this.textBox_model, "textBox_model");
            this.textBox_model.Name = "textBox_model";
            // 
            // textBox_mechanic
            // 
            resources.ApplyResources(this.textBox_mechanic, "textBox_mechanic");
            this.textBox_mechanic.Name = "textBox_mechanic";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // FormWorkroom
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox_mechanic);
            this.Controls.Add(this.textBox_model);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView_Workroom);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormWorkroom";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Workroom)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Owners;
        private System.Windows.Forms.ToolStripButton toolStripButton__Cars;
        private System.Windows.Forms.ToolStripButton toolStripButton_Mechanics;
        private System.Windows.Forms.DataGridView dataGridView_Workroom;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_model;
        private System.Windows.Forms.TextBox textBox_mechanic;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn workroomID;
        private System.Windows.Forms.DataGridViewTextBoxColumn carID;
        private System.Windows.Forms.DataGridViewTextBoxColumn mechanicID;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiptDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
    }
}