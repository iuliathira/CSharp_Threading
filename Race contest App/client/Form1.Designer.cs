namespace client
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
            this.dataGVRaces = new System.Windows.Forms.DataGridView();
            this.dataGVCont = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboEngine = new System.Windows.Forms.ComboBox();
            this.comboTeam = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVRaces)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVCont)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGVRaces
            // 
            this.dataGVRaces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVRaces.Location = new System.Drawing.Point(12, 127);
            this.dataGVRaces.Name = "dataGVRaces";
            this.dataGVRaces.RowTemplate.Height = 24;
            this.dataGVRaces.Size = new System.Drawing.Size(561, 204);
            this.dataGVRaces.TabIndex = 0;
            this.dataGVRaces.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGVRaces_CellContentClick);
            // 
            // dataGVCont
            // 
            this.dataGVCont.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVCont.Location = new System.Drawing.Point(670, 127);
            this.dataGVCont.Name = "dataGVCont";
            this.dataGVCont.RowTemplate.Height = 24;
            this.dataGVCont.Size = new System.Drawing.Size(537, 204);
            this.dataGVCont.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(667, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose team";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Choose race";
            // 
            // comboEngine
            // 
            this.comboEngine.FormattingEnabled = true;
            this.comboEngine.Location = new System.Drawing.Point(15, 96);
            this.comboEngine.Name = "comboEngine";
            this.comboEngine.Size = new System.Drawing.Size(121, 24);
            this.comboEngine.TabIndex = 4;
            this.comboEngine.SelectedValueChanged += new System.EventHandler(this.comboEngine_SelectedValueChanged);
            // 
            // comboTeam
            // 
            this.comboTeam.FormattingEnabled = true;
            this.comboTeam.Location = new System.Drawing.Point(670, 96);
            this.comboTeam.Name = "comboTeam";
            this.comboTeam.Size = new System.Drawing.Size(121, 24);
            this.comboTeam.TabIndex = 5;
            this.comboTeam.SelectedValueChanged += new System.EventHandler(this.comboTeam_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(355, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "Race Management System";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 556);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Copyright (c) 2019 by Thira Iulia";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(1018, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(20, 17);
            this.nameLabel.TabIndex = 8;
            this.nameLabel.Text = "...";
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.MediumBlue;
            this.buttonAdd.Location = new System.Drawing.Point(571, 441);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(128, 51);
            this.buttonAdd.TabIndex = 9;
            this.buttonAdd.Text = "Register new contestant";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(1235, 582);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboTeam);
            this.Controls.Add(this.comboEngine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGVCont);
            this.Controls.Add(this.dataGVRaces);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGVRaces)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVCont)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGVRaces;
        private System.Windows.Forms.DataGridView dataGVCont;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboEngine;
        private System.Windows.Forms.ComboBox comboTeam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button buttonAdd;
    }
}

