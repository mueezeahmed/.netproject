﻿namespace TodoLIstApp.tasks
{
    partial class tasksForm
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

        private Button btnAddTask;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAddTask = new Button();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(46, 303);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(182, 84);
            btnAddTask.TabIndex = 0;
            btnAddTask.Text = "Add new Task";
            btnAddTask.Click += BtnAddTask_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkGray;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.FloralWhite;
            button1.Location = new Point(234, 303);
            button1.Name = "button1";
            button1.Size = new Size(182, 84);
            button1.TabIndex = 1;
            button1.Text = "Categories";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.DarkGray;
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = Color.FloralWhite;
            button2.Location = new Point(422, 303);
            button2.Name = "button2";
            button2.Size = new Size(182, 84);
            button2.TabIndex = 2;
            button2.Text = "Logout";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // tasksForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 472);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnAddTask);
            ImeMode = ImeMode.On;
            Name = "tasksForm";
            Text = "tasksForm";
            Load += tasksForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
    }
}