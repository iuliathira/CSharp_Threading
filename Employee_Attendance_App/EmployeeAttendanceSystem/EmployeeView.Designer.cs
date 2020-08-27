namespace EmployeeAttendanceSystem
{
    partial class EmployeeView
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
            this.tasksTable = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.viewAttBtn = new System.Windows.Forms.Button();
            this.updateTaskBtn = new System.Windows.Forms.Button();
            this.logoutBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tasksTable)).BeginInit();
            this.SuspendLayout();
            // 
            // tasksTable
            // 
            this.tasksTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tasksTable.Location = new System.Drawing.Point(12, 147);
            this.tasksTable.Name = "tasksTable";
            this.tasksTable.RowTemplate.Height = 24;
            this.tasksTable.Size = new System.Drawing.Size(350, 275);
            this.tasksTable.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(100, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Task Management";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 100);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(119, 17);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Employee Name: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Assigned Tasks:";
            // 
            // viewAttBtn
            // 
            this.viewAttBtn.Location = new System.Drawing.Point(431, 147);
            this.viewAttBtn.Name = "viewAttBtn";
            this.viewAttBtn.Size = new System.Drawing.Size(183, 98);
            this.viewAttBtn.TabIndex = 4;
            this.viewAttBtn.Text = "View attendance for the last 7 days";
            this.viewAttBtn.UseVisualStyleBackColor = true;
            this.viewAttBtn.Click += new System.EventHandler(this.viewAttendanceBtn_Click);
            // 
            // updateTaskBtn
            // 
            this.updateTaskBtn.Location = new System.Drawing.Point(431, 302);
            this.updateTaskBtn.Name = "updateTaskBtn";
            this.updateTaskBtn.Size = new System.Drawing.Size(183, 95);
            this.updateTaskBtn.TabIndex = 5;
            this.updateTaskBtn.Text = "Update selected task";
            this.updateTaskBtn.UseVisualStyleBackColor = true;
            this.updateTaskBtn.Click += new System.EventHandler(this.updateTaskBtn_Click);
            // 
            // logoutBtn
            // 
            this.logoutBtn.Location = new System.Drawing.Point(540, 17);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(75, 38);
            this.logoutBtn.TabIndex = 6;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // EmployeeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 450);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.updateTaskBtn);
            this.Controls.Add(this.viewAttBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tasksTable);
            this.Name = "EmployeeView";
            this.Text = "consultaSarcini";
            ((System.ComponentModel.ISupportInitialize)(this.tasksTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tasksTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button viewAttBtn;
        private System.Windows.Forms.Button updateTaskBtn;
        private System.Windows.Forms.Button logoutBtn;
    }
}