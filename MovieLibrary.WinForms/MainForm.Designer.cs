namespace HelloWorld.WinForms
{
    partial class MainForm
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
            createButton = new Button();
            deleteButton = new Button();
            exitButton = new Button();
            MovieList = new ListBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // createButton
            // 
            createButton.BackColor = Color.FromArgb(0, 192, 0);
            createButton.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            createButton.ForeColor = SystemColors.ButtonFace;
            createButton.Location = new Point(522, 109);
            createButton.Name = "createButton";
            createButton.Size = new Size(150, 30);
            createButton.TabIndex = 0;
            createButton.Text = "Create";
            createButton.UseVisualStyleBackColor = false;
            createButton.Click += CreateButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.BackColor = Color.FromArgb(192, 0, 0);
            deleteButton.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            deleteButton.ForeColor = SystemColors.ButtonFace;
            deleteButton.Location = new Point(522, 145);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(150, 30);
            deleteButton.TabIndex = 2;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = false;
            deleteButton.Click += DeleteButton_Click;
            // 
            // exitButton
            // 
            exitButton.BackColor = Color.Maroon;
            exitButton.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            exitButton.ForeColor = SystemColors.ButtonFace;
            exitButton.Location = new Point(522, 409);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(150, 30);
            exitButton.TabIndex = 3;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = false;
            exitButton.Click += ExitButton_Click;
            // 
            // MovieList
            // 
            MovieList.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            MovieList.FormattingEnabled = true;
            MovieList.ItemHeight = 21;
            MovieList.Location = new Point(3, 36);
            MovieList.Name = "MovieList";
            MovieList.Size = new Size(488, 403);
            MovieList.TabIndex = 4;
            MovieList.SelectedIndexChanged += ListBox_SelectedIndexChanged;
            MovieList.DoubleClick += ListBox_DoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 12);
            label1.Name = "label1";
            label1.Size = new Size(475, 21);
            label1.TabIndex = 5;
            label1.Text = "You can click on movie from the list to get more info or update it.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(497, 76);
            label2.Name = "label2";
            label2.Size = new Size(175, 21);
            label2.TabIndex = 6;
            label2.Text = "Create or Delete Movie";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 461);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(MovieList);
            Controls.Add(exitButton);
            Controls.Add(deleteButton);
            Controls.Add(createButton);
            Margin = new Padding(2);
            Name = "MainForm";
            Text = "Main";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button createButton;
        private Button deleteButton;
        private Button exitButton;
        private ListBox MovieList;
        private Label label1;
        private Label label2;
    }
}