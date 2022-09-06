namespace CollegeManagment.UI.Forms
{
    partial class GradeForm
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
            this.GradesDataGridView = new System.Windows.Forms.DataGridView();
            this.GradeTextBox = new System.Windows.Forms.TextBox();
            this.GradeLable = new System.Windows.Forms.Label();
            this.teacherCoursesComboBox = new System.Windows.Forms.ComboBox();
            this.studentComboBox = new System.Windows.Forms.ComboBox();
            this.teacherCoursesLable = new System.Windows.Forms.Label();
            this.studentLable = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GradesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.FloralWhite;
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.DeleteButton.Location = new System.Drawing.Point(682, 192);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(88, 69);
            this.DeleteButton.TabIndex = 39;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.BackColor = System.Drawing.Color.FloralWhite;
            this.EditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.EditButton.Location = new System.Drawing.Point(680, 303);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(89, 69);
            this.EditButton.TabIndex = 38;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.FloralWhite;
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.AddButton.Location = new System.Drawing.Point(680, 96);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(89, 64);
            this.AddButton.TabIndex = 37;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // GradesDataGridView
            // 
            this.GradesDataGridView.AllowUserToAddRows = false;
            this.GradesDataGridView.AllowUserToResizeColumns = false;
            this.GradesDataGridView.AllowUserToResizeRows = false;
            this.GradesDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.GradesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GradesDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.GradesDataGridView.Location = new System.Drawing.Point(277, 33);
            this.GradesDataGridView.Name = "GradesDataGridView";
            this.GradesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GradesDataGridView.Size = new System.Drawing.Size(366, 383);
            this.GradesDataGridView.TabIndex = 36;
            this.GradesDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GradesDataGridView_CellMouseClick);
            // 
            // GradeTextBox
            // 
            this.GradeTextBox.Location = new System.Drawing.Point(99, 73);
            this.GradeTextBox.Name = "GradeTextBox";
            this.GradeTextBox.Size = new System.Drawing.Size(100, 20);
            this.GradeTextBox.TabIndex = 44;
            // 
            // GradeLable
            // 
            this.GradeLable.AutoSize = true;
            this.GradeLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.GradeLable.Location = new System.Drawing.Point(122, 55);
            this.GradeLable.Name = "GradeLable";
            this.GradeLable.Size = new System.Drawing.Size(46, 15);
            this.GradeLable.TabIndex = 45;
            this.GradeLable.Text = "Grade";
            // 
            // teacherCoursesComboBox
            // 
            this.teacherCoursesComboBox.FormattingEnabled = true;
            this.teacherCoursesComboBox.Location = new System.Drawing.Point(39, 174);
            this.teacherCoursesComboBox.Name = "teacherCoursesComboBox";
            this.teacherCoursesComboBox.Size = new System.Drawing.Size(207, 21);
            this.teacherCoursesComboBox.TabIndex = 46;
            // 
            // studentComboBox
            // 
            this.studentComboBox.FormattingEnabled = true;
            this.studentComboBox.Location = new System.Drawing.Point(39, 285);
            this.studentComboBox.Name = "studentComboBox";
            this.studentComboBox.Size = new System.Drawing.Size(207, 21);
            this.studentComboBox.TabIndex = 47;
            // 
            // teacherCoursesLable
            // 
            this.teacherCoursesLable.AutoSize = true;
            this.teacherCoursesLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.teacherCoursesLable.Location = new System.Drawing.Point(83, 145);
            this.teacherCoursesLable.Name = "teacherCoursesLable";
            this.teacherCoursesLable.Size = new System.Drawing.Size(130, 15);
            this.teacherCoursesLable.TabIndex = 48;
            this.teacherCoursesLable.Text = "Teachers \\ Courses";
            // 
            // studentLable
            // 
            this.studentLable.AutoSize = true;
            this.studentLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.studentLable.Location = new System.Drawing.Point(105, 267);
            this.studentLable.Name = "studentLable";
            this.studentLable.Size = new System.Drawing.Size(63, 15);
            this.studentLable.TabIndex = 49;
            this.studentLable.Text = "Students";
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.Silver;
            this.backButton.Location = new System.Drawing.Point(682, 405);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 33);
            this.backButton.TabIndex = 50;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // Grades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.studentLable);
            this.Controls.Add(this.teacherCoursesLable);
            this.Controls.Add(this.studentComboBox);
            this.Controls.Add(this.teacherCoursesComboBox);
            this.Controls.Add(this.GradeLable);
            this.Controls.Add(this.GradeTextBox);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.GradesDataGridView);
            this.Controls.Add(this.EditButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Grades";
            this.Text = "Grades";
            this.Load += new System.EventHandler(this.Grades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GradesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.DataGridView GradesDataGridView;
        private System.Windows.Forms.TextBox GradeTextBox;
        private System.Windows.Forms.Label GradeLable;
        private System.Windows.Forms.ComboBox teacherCoursesComboBox;
        private System.Windows.Forms.ComboBox studentComboBox;
        private System.Windows.Forms.Label teacherCoursesLable;
        private System.Windows.Forms.Label studentLable;
        private System.Windows.Forms.Button backButton;
    }
}