namespace CollegeManagment.UI.Forms
{
    partial class StudentsForm
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
            this.StudentsDataGridView = new System.Windows.Forms.DataGridView();
            this.IdNumberLable = new System.Windows.Forms.Label();
            this.LastNameLable = new System.Windows.Forms.Label();
            this.NameLable = new System.Windows.Forms.Label();
            this.StudentIdNumberTextBox = new System.Windows.Forms.TextBox();
            this.StudentLastNameTextBox = new System.Windows.Forms.TextBox();
            this.StudentNameTextBox = new System.Windows.Forms.TextBox();
            this.backButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StudentsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.FloralWhite;
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.DeleteButton.Location = new System.Drawing.Point(333, 352);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 41);
            this.DeleteButton.TabIndex = 19;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.BackColor = System.Drawing.Color.FloralWhite;
            this.EditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.EditButton.Location = new System.Drawing.Point(231, 352);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 41);
            this.EditButton.TabIndex = 18;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.FloralWhite;
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.AddButton.Location = new System.Drawing.Point(123, 352);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 41);
            this.AddButton.TabIndex = 17;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // StudentsDataGridView
            // 
            this.StudentsDataGridView.AllowUserToAddRows = false;
            this.StudentsDataGridView.AllowUserToResizeRows = false;
            this.StudentsDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.StudentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentsDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.StudentsDataGridView.Location = new System.Drawing.Point(94, 142);
            this.StudentsDataGridView.Name = "StudentsDataGridView";
            this.StudentsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.StudentsDataGridView.Size = new System.Drawing.Size(340, 167);
            this.StudentsDataGridView.TabIndex = 16;
            this.StudentsDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.StudentsDataGridView_CellMouseClick);
            // 
            // IdNumberLable
            // 
            this.IdNumberLable.AutoSize = true;
            this.IdNumberLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.IdNumberLable.Location = new System.Drawing.Point(413, 40);
            this.IdNumberLable.Name = "IdNumberLable";
            this.IdNumberLable.Size = new System.Drawing.Size(74, 15);
            this.IdNumberLable.TabIndex = 15;
            this.IdNumberLable.Text = "Id Number";
            // 
            // LastNameLable
            // 
            this.LastNameLable.AutoSize = true;
            this.LastNameLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.LastNameLable.Location = new System.Drawing.Point(234, 38);
            this.LastNameLable.Name = "LastNameLable";
            this.LastNameLable.Size = new System.Drawing.Size(72, 15);
            this.LastNameLable.TabIndex = 14;
            this.LastNameLable.Text = "LastName";
            // 
            // NameLable
            // 
            this.NameLable.AutoSize = true;
            this.NameLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.NameLable.Location = new System.Drawing.Point(55, 38);
            this.NameLable.Name = "NameLable";
            this.NameLable.Size = new System.Drawing.Size(45, 15);
            this.NameLable.TabIndex = 13;
            this.NameLable.Text = "Name";
            // 
            // StudentIdNumberTextBox
            // 
            this.StudentIdNumberTextBox.Location = new System.Drawing.Point(399, 58);
            this.StudentIdNumberTextBox.Name = "StudentIdNumberTextBox";
            this.StudentIdNumberTextBox.Size = new System.Drawing.Size(100, 20);
            this.StudentIdNumberTextBox.TabIndex = 12;
            // 
            // StudentLastNameTextBox
            // 
            this.StudentLastNameTextBox.Location = new System.Drawing.Point(222, 58);
            this.StudentLastNameTextBox.Name = "StudentLastNameTextBox";
            this.StudentLastNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.StudentLastNameTextBox.TabIndex = 11;
            // 
            // StudentNameTextBox
            // 
            this.StudentNameTextBox.Location = new System.Drawing.Point(35, 58);
            this.StudentNameTextBox.Name = "StudentNameTextBox";
            this.StudentNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.StudentNameTextBox.TabIndex = 10;
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.Silver;
            this.backButton.Location = new System.Drawing.Point(12, 416);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 33);
            this.backButton.TabIndex = 20;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // Students
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(539, 461);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.StudentsDataGridView);
            this.Controls.Add(this.IdNumberLable);
            this.Controls.Add(this.LastNameLable);
            this.Controls.Add(this.NameLable);
            this.Controls.Add(this.StudentIdNumberTextBox);
            this.Controls.Add(this.StudentLastNameTextBox);
            this.Controls.Add(this.StudentNameTextBox);
            this.Name = "Students";
            this.Text = "Students";
            this.Load += new System.EventHandler(this.Students_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StudentsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.DataGridView StudentsDataGridView;
        private System.Windows.Forms.Label IdNumberLable;
        private System.Windows.Forms.Label LastNameLable;
        private System.Windows.Forms.Label NameLable;
        private System.Windows.Forms.TextBox StudentIdNumberTextBox;
        private System.Windows.Forms.TextBox StudentLastNameTextBox;
        private System.Windows.Forms.TextBox StudentNameTextBox;
        private System.Windows.Forms.Button backButton;
    }
}