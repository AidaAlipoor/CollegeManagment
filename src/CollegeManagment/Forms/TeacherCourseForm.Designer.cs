namespace CollegeManagment.UI.Forms
{
    partial class TeacherCourseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherCourseForm));
            this.CoursesComboBox = new System.Windows.Forms.ComboBox();
            this.teacherComboBox = new System.Windows.Forms.ComboBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.teacherCoursesDataGridView = new System.Windows.Forms.DataGridView();
            this.EditButton = new System.Windows.Forms.Button();
            this.teachersLable = new System.Windows.Forms.Label();
            this.CursesLabel = new System.Windows.Forms.Label();
            this.backPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.teacherCoursesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CoursesComboBox
            // 
            this.CoursesComboBox.FormattingEnabled = true;
            this.CoursesComboBox.Location = new System.Drawing.Point(382, 55);
            this.CoursesComboBox.Name = "CoursesComboBox";
            this.CoursesComboBox.Size = new System.Drawing.Size(207, 21);
            this.CoursesComboBox.TabIndex = 53;
            // 
            // teacherComboBox
            // 
            this.teacherComboBox.FormattingEnabled = true;
            this.teacherComboBox.Location = new System.Drawing.Point(94, 55);
            this.teacherComboBox.Name = "teacherComboBox";
            this.teacherComboBox.Size = new System.Drawing.Size(207, 21);
            this.teacherComboBox.TabIndex = 52;
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.FloralWhite;
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.DeleteButton.Location = new System.Drawing.Point(602, 216);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(88, 62);
            this.DeleteButton.TabIndex = 51;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.FloralWhite;
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.AddButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AddButton.Location = new System.Drawing.Point(601, 137);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(89, 58);
            this.AddButton.TabIndex = 49;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // teacherCoursesDataGridView
            // 
            this.teacherCoursesDataGridView.AllowUserToAddRows = false;
            this.teacherCoursesDataGridView.AllowUserToResizeRows = false;
            this.teacherCoursesDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.teacherCoursesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.teacherCoursesDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.teacherCoursesDataGridView.Location = new System.Drawing.Point(141, 128);
            this.teacherCoursesDataGridView.Name = "teacherCoursesDataGridView";
            this.teacherCoursesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.teacherCoursesDataGridView.Size = new System.Drawing.Size(367, 263);
            this.teacherCoursesDataGridView.TabIndex = 48;
            this.teacherCoursesDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.teacherCoursesDataGridView_CellMouseClick);
            // 
            // EditButton
            // 
            this.EditButton.BackColor = System.Drawing.Color.FloralWhite;
            this.EditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.EditButton.Location = new System.Drawing.Point(601, 307);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(89, 56);
            this.EditButton.TabIndex = 50;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // teachersLable
            // 
            this.teachersLable.AutoSize = true;
            this.teachersLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.teachersLable.Location = new System.Drawing.Point(160, 35);
            this.teachersLable.Name = "teachersLable";
            this.teachersLable.Size = new System.Drawing.Size(76, 17);
            this.teachersLable.TabIndex = 54;
            this.teachersLable.Text = "Teachers";
            // 
            // CursesLabel
            // 
            this.CursesLabel.AutoSize = true;
            this.CursesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.CursesLabel.Location = new System.Drawing.Point(454, 35);
            this.CursesLabel.Name = "CursesLabel";
            this.CursesLabel.Size = new System.Drawing.Size(67, 17);
            this.CursesLabel.TabIndex = 55;
            this.CursesLabel.Text = "Courses";
            // 
            // backPictureBox
            // 
            this.backPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("backPictureBox.Image")));
            this.backPictureBox.Location = new System.Drawing.Point(33, 307);
            this.backPictureBox.Name = "backPictureBox";
            this.backPictureBox.Size = new System.Drawing.Size(64, 64);
            this.backPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.backPictureBox.TabIndex = 56;
            this.backPictureBox.TabStop = false;
            this.backPictureBox.Click += new System.EventHandler(this.backPictureBox_Click);
            // 
            // TeacherCourses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(767, 450);
            this.Controls.Add(this.backPictureBox);
            this.Controls.Add(this.CursesLabel);
            this.Controls.Add(this.teachersLable);
            this.Controls.Add(this.CoursesComboBox);
            this.Controls.Add(this.teacherComboBox);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.teacherCoursesDataGridView);
            this.Controls.Add(this.EditButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TeacherCourses";
            this.Text = "TeacherCourses";
            this.Load += new System.EventHandler(this.TeacherCourses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.teacherCoursesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CoursesComboBox;
        private System.Windows.Forms.ComboBox teacherComboBox;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.DataGridView teacherCoursesDataGridView;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Label teachersLable;
        private System.Windows.Forms.Label CursesLabel;
        private System.Windows.Forms.PictureBox backPictureBox;
    }
}