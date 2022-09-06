namespace CollegeManagment.UI.Forms
{
    partial class TeacherForm
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
            this.teacherNameTextBox = new System.Windows.Forms.TextBox();
            this.teacherLastNameTextBox = new System.Windows.Forms.TextBox();
            this.NameLable = new System.Windows.Forms.Label();
            this.LastNameLable = new System.Windows.Forms.Label();
            this.BirthdayLable = new System.Windows.Forms.Label();
            this.teachersDataGridView = new System.Windows.Forms.DataGridView();
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.birthdayDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.backButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.teachersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // teacherNameTextBox
            // 
            this.teacherNameTextBox.Location = new System.Drawing.Point(64, 50);
            this.teacherNameTextBox.Name = "teacherNameTextBox";
            this.teacherNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.teacherNameTextBox.TabIndex = 0;
            // 
            // teacherLastNameTextBox
            // 
            this.teacherLastNameTextBox.Location = new System.Drawing.Point(229, 50);
            this.teacherLastNameTextBox.Name = "teacherLastNameTextBox";
            this.teacherLastNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.teacherLastNameTextBox.TabIndex = 1;
            // 
            // NameLable
            // 
            this.NameLable.AutoSize = true;
            this.NameLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.NameLable.Location = new System.Drawing.Point(80, 30);
            this.NameLable.Name = "NameLable";
            this.NameLable.Size = new System.Drawing.Size(45, 15);
            this.NameLable.TabIndex = 3;
            this.NameLable.Text = "Name";
            // 
            // LastNameLable
            // 
            this.LastNameLable.AutoSize = true;
            this.LastNameLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.LastNameLable.Location = new System.Drawing.Point(241, 30);
            this.LastNameLable.Name = "LastNameLable";
            this.LastNameLable.Size = new System.Drawing.Size(72, 15);
            this.LastNameLable.TabIndex = 4;
            this.LastNameLable.Text = "LastName";
            // 
            // BirthdayLable
            // 
            this.BirthdayLable.AutoSize = true;
            this.BirthdayLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.BirthdayLable.Location = new System.Drawing.Point(446, 32);
            this.BirthdayLable.Name = "BirthdayLable";
            this.BirthdayLable.Size = new System.Drawing.Size(59, 15);
            this.BirthdayLable.TabIndex = 5;
            this.BirthdayLable.Text = "Birthday";
            // 
            // teachersDataGridView
            // 
            this.teachersDataGridView.AllowUserToAddRows = false;
            this.teachersDataGridView.AllowUserToResizeRows = false;
            this.teachersDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.teachersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.teachersDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.teachersDataGridView.Location = new System.Drawing.Point(114, 134);
            this.teachersDataGridView.MultiSelect = false;
            this.teachersDataGridView.Name = "teachersDataGridView";
            this.teachersDataGridView.RowHeadersVisible = false;
            this.teachersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.teachersDataGridView.Size = new System.Drawing.Size(340, 167);
            this.teachersDataGridView.TabIndex = 6;
            this.teachersDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.TeachersDataGridView_CellMouseClick);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.FloralWhite;
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.addButton.Location = new System.Drawing.Point(131, 364);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 41);
            this.addButton.TabIndex = 7;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // editButton
            // 
            this.editButton.BackColor = System.Drawing.Color.FloralWhite;
            this.editButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.editButton.Location = new System.Drawing.Point(244, 364);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 41);
            this.editButton.TabIndex = 8;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = false;
            this.editButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.FloralWhite;
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.deleteButton.Location = new System.Drawing.Point(360, 364);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 41);
            this.deleteButton.TabIndex = 9;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // birthdayDateTimePicker
            // 
            this.birthdayDateTimePicker.Location = new System.Drawing.Point(360, 50);
            this.birthdayDateTimePicker.Name = "birthdayDateTimePicker";
            this.birthdayDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.birthdayDateTimePicker.TabIndex = 11;
            this.birthdayDateTimePicker.Value = new System.DateTime(2022, 8, 21, 15, 33, 19, 0);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.Silver;
            this.backButton.Location = new System.Drawing.Point(12, 421);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 33);
            this.backButton.TabIndex = 12;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // TeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(571, 466);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.birthdayDateTimePicker);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.teachersDataGridView);
            this.Controls.Add(this.BirthdayLable);
            this.Controls.Add(this.LastNameLable);
            this.Controls.Add(this.NameLable);
            this.Controls.Add(this.teacherLastNameTextBox);
            this.Controls.Add(this.teacherNameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TeacherForm";
            this.Text = "Teacher";
            this.Load += new System.EventHandler(this.TeacherForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.teachersDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox teacherNameTextBox;
        private System.Windows.Forms.TextBox teacherLastNameTextBox;
        private System.Windows.Forms.Label NameLable;
        private System.Windows.Forms.Label LastNameLable;
        private System.Windows.Forms.Label BirthdayLable;
        private System.Windows.Forms.DataGridView teachersDataGridView;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.DateTimePicker birthdayDateTimePicker;
        private System.Windows.Forms.Button backButton;
    }
}