namespace CollegeManagment.UI.Forms
{
    partial class CourseForm
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
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.CoursesDataGridView = new System.Windows.Forms.DataGridView();
            this.CourseNameLable = new System.Windows.Forms.Label();
            this.CourseNameTextBox = new System.Windows.Forms.TextBox();
            this.backButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CoursesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.FloralWhite;
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.DeleteButton.Location = new System.Drawing.Point(359, 330);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 41);
            this.DeleteButton.TabIndex = 29;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.BackColor = System.Drawing.Color.FloralWhite;
            this.EditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.EditButton.Location = new System.Drawing.Point(232, 330);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 41);
            this.EditButton.TabIndex = 28;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.FloralWhite;
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.AddButton.Location = new System.Drawing.Point(105, 330);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 41);
            this.AddButton.TabIndex = 27;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // CoursesDataGridView
            // 
            this.CoursesDataGridView.AllowUserToAddRows = false;
            this.CoursesDataGridView.AllowUserToResizeRows = false;
            this.CoursesDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.CoursesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CoursesDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.CoursesDataGridView.Location = new System.Drawing.Point(172, 133);
            this.CoursesDataGridView.Name = "CoursesDataGridView";
            this.CoursesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CoursesDataGridView.Size = new System.Drawing.Size(170, 167);
            this.CoursesDataGridView.TabIndex = 26;
            this.CoursesDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CoursesDataGridView_CellMouseClick);
            // 
            // CourseNameLable
            // 
            this.CourseNameLable.AutoSize = true;
            this.CourseNameLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.CourseNameLable.Location = new System.Drawing.Point(213, 60);
            this.CourseNameLable.Name = "CourseNameLable";
            this.CourseNameLable.Size = new System.Drawing.Size(94, 15);
            this.CourseNameLable.TabIndex = 23;
            this.CourseNameLable.Text = "Course Name";
            // 
            // CourseNameTextBox
            // 
            this.CourseNameTextBox.Location = new System.Drawing.Point(198, 78);
            this.CourseNameTextBox.Name = "CourseNameTextBox";
            this.CourseNameTextBox.Size = new System.Drawing.Size(119, 20);
            this.CourseNameTextBox.TabIndex = 20;
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.Silver;
            this.backButton.Location = new System.Drawing.Point(12, 393);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 33);
            this.backButton.TabIndex = 30;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // Courses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(535, 438);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.CoursesDataGridView);
            this.Controls.Add(this.CourseNameLable);
            this.Controls.Add(this.CourseNameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Courses";
            this.Text = "Courses";
            this.Load += new System.EventHandler(this.Courses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CoursesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.DataGridView CoursesDataGridView;
        private System.Windows.Forms.Label CourseNameLable;
        private System.Windows.Forms.TextBox CourseNameTextBox;
        private System.Windows.Forms.Button backButton;
    }
}