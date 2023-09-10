namespace my_first_DB
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            label1 = new Label();
            Edit = new Button();
            Add = new Button();
            Delete = new Button();
            reset = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(307, 210);
            button1.Name = "button1";
            button1.Size = new Size(161, 67);
            button1.TabIndex = 0;
            button1.Text = "Download";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(341, 78);
            label1.Name = "label1";
            label1.Size = new Size(112, 15);
            label1.TabIndex = 1;
            label1.Text = "Download Database";
            // 
            // Edit
            // 
            Edit.Image = (Image)resources.GetObject("Edit.Image");
            Edit.Location = new Point(546, 214);
            Edit.Name = "Edit";
            Edit.Size = new Size(132, 58);
            Edit.TabIndex = 2;
            Edit.Text = "  Edit";
            Edit.TextAlign = ContentAlignment.MiddleLeft;
            Edit.UseVisualStyleBackColor = true;
            Edit.Click += button2_Click;
            // 
            // Add
            // 
            Add.Image = (Image)resources.GetObject("Add.Image");
            Add.Location = new Point(546, 114);
            Add.Name = "Add";
            Add.Size = new Size(132, 58);
            Add.TabIndex = 3;
            Add.Text = "  Add";
            Add.TextAlign = ContentAlignment.MiddleLeft;
            Add.UseVisualStyleBackColor = true;
            Add.Click += Add_Click;
            // 
            // Delete
            // 
            Delete.Image = (Image)resources.GetObject("Delete.Image");
            Delete.Location = new Point(546, 330);
            Delete.Name = "Delete";
            Delete.Size = new Size(132, 58);
            Delete.TabIndex = 4;
            Delete.Text = " Delete";
            Delete.TextAlign = ContentAlignment.MiddleLeft;
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // reset
            // 
            reset.Location = new Point(12, 12);
            reset.Name = "reset";
            reset.Size = new Size(46, 26);
            reset.TabIndex = 5;
            reset.Text = "reset";
            reset.UseVisualStyleBackColor = true;
            reset.Click += reset_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(reset);
            Controls.Add(Delete);
            Controls.Add(Add);
            Controls.Add(Edit);
            Controls.Add(label1);
            Controls.Add(button1);
            ForeColor = Color.Black;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Button Edit;
        private Button Add;
        private Button Delete;
        private Button reset;
    }
}