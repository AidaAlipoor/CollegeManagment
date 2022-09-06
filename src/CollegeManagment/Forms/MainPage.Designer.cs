namespace CollegeManagment.UI.Forms
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.TeacherButton = new System.Windows.Forms.Button();
            this.StudentButton = new System.Windows.Forms.Button();
            this.GradeButton = new System.Windows.Forms.Button();
            this.CoursesButton = new System.Windows.Forms.Button();
            this.teacherCoursesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TeacherButton
            // 
            resources.ApplyResources(this.TeacherButton, "TeacherButton");
            this.TeacherButton.Name = "TeacherButton";
            this.TeacherButton.UseVisualStyleBackColor = true;
            this.TeacherButton.Click += new System.EventHandler(this.TeacherButton_Click);
            // 
            // StudentButton
            // 
            resources.ApplyResources(this.StudentButton, "StudentButton");
            this.StudentButton.Name = "StudentButton";
            this.StudentButton.UseVisualStyleBackColor = true;
            this.StudentButton.Click += new System.EventHandler(this.StudentButton_Click);
            // 
            // GradeButton
            // 
            resources.ApplyResources(this.GradeButton, "GradeButton");
            this.GradeButton.Name = "GradeButton";
            this.GradeButton.UseVisualStyleBackColor = true;
            this.GradeButton.Click += new System.EventHandler(this.GradeButton_Click);
            // 
            // CoursesButton
            // 
            resources.ApplyResources(this.CoursesButton, "CoursesButton");
            this.CoursesButton.Name = "CoursesButton";
            this.CoursesButton.UseVisualStyleBackColor = true;
            this.CoursesButton.Click += new System.EventHandler(this.CoursesButton_Click);
            // 
            // teacherCoursesButton
            // 
            resources.ApplyResources(this.teacherCoursesButton, "teacherCoursesButton");
            this.teacherCoursesButton.Name = "teacherCoursesButton";
            this.teacherCoursesButton.UseVisualStyleBackColor = true;
            this.teacherCoursesButton.Click += new System.EventHandler(this.TeacherCoursesButton_Click);
            // 
            // MainPage
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.Controls.Add(this.teacherCoursesButton);
            this.Controls.Add(this.CoursesButton);
            this.Controls.Add(this.GradeButton);
            this.Controls.Add(this.StudentButton);
            this.Controls.Add(this.TeacherButton);
            this.Name = "MainPage";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button TeacherButton;
        private System.Windows.Forms.Button StudentButton;
        private System.Windows.Forms.Button GradeButton;
        private System.Windows.Forms.Button CoursesButton;
        private System.Windows.Forms.Button teacherCoursesButton;
    }
}