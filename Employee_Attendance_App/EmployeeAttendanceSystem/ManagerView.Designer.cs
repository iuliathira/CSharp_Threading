namespace EmployeeAttendanceSystem
{
    partial class ManagerView
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
            this.label1 = new System.Windows.Forms.Label();
            this.loggedUsersTable = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.manageContsButton = new System.Windows.Forms.Button();
            this.viewTasksBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.logoutBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.loggedUsersTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Miriam CLM", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(74, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(422, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Attendance Management System";
            // 
            // loggedUsersTable
            // 
            this.loggedUsersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.loggedUsersTable.Location = new System.Drawing.Point(30, 170);
            this.loggedUsersTable.Name = "loggedUsersTable";
            this.loggedUsersTable.RowTemplate.Height = 24;
            this.loggedUsersTable.Size = new System.Drawing.Size(240, 394);
            this.loggedUsersTable.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "View logged in employees:";
            // 
            // manageContsButton
            // 
            this.manageContsButton.Location = new System.Drawing.Point(330, 213);
            this.manageContsButton.Name = "manageContsButton";
            this.manageContsButton.Size = new System.Drawing.Size(103, 58);
            this.manageContsButton.TabIndex = 4;
            this.manageContsButton.Text = "Account Management";
            this.manageContsButton.UseVisualStyleBackColor = true;
            this.manageContsButton.Click += new System.EventHandler(this.manageContsButton_Click);
            // 
            // viewTasksBtn
            // 
            this.viewTasksBtn.Location = new System.Drawing.Point(330, 347);
            this.viewTasksBtn.Name = "viewTasksBtn";
            this.viewTasksBtn.Size = new System.Drawing.Size(103, 58);
            this.viewTasksBtn.TabIndex = 5;
            this.viewTasksBtn.Text = "View tasks";
            this.viewTasksBtn.UseVisualStyleBackColor = true;
            this.viewTasksBtn.Click += new System.EventHandler(this.viewTasksBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(327, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Options for accounts management";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(327, 298);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "View employee\'s tasks";
            // 
            // logoutBtn
            // 
            this.logoutBtn.Location = new System.Drawing.Point(592, 3);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(88, 48);
            this.logoutBtn.TabIndex = 8;
            this.logoutBtn.Text = "LOGOUT";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // ManagerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 631);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.viewTasksBtn);
            this.Controls.Add(this.manageContsButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.loggedUsersTable);
            this.Controls.Add(this.label1);
            this.Name = "ManagerView";
            this.Text = "managerWindow";
            ((System.ComponentModel.ISupportInitialize)(this.loggedUsersTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView loggedUsersTable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button manageContsButton;
        private System.Windows.Forms.Button viewTasksBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button logoutBtn;
    }
}