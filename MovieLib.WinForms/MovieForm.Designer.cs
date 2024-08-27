namespace MovieLib.WinForms
{
	partial class NewMovie
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
			if (disposing && ( components != null ))
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
			label1 = new Label();
			label2 = new Label();
			dateTimePicker = new DateTimePicker();
			label3 = new Label();
			movieSeen = new CheckBox();
			cancelButton = new Button();
			createButton = new Button();
			txtPlot = new RichTextBox();
			txtTitle = new TextBox();
			label4 = new Label();
			label5 = new Label();
			label6 = new Label();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Microsoft Sans Serif", 14.25F);
			label1.Location = new Point(25, 56);
			label1.Name = "label1";
			label1.Size = new Size(50, 24);
			label1.TabIndex = 0;
			label1.Text = "Title:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Microsoft Sans Serif", 14.25F);
			label2.Location = new Point(25, 103);
			label2.Name = "label2";
			label2.Size = new Size(46, 24);
			label2.TabIndex = 1;
			label2.Text = "Plot:";
			// 
			// dateTimePicker
			// 
			dateTimePicker.Location = new Point(224, 358);
			dateTimePicker.Name = "dateTimePicker";
			dateTimePicker.Size = new Size(231, 23);
			dateTimePicker.TabIndex = 2;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Microsoft Sans Serif", 14.25F);
			label3.Location = new Point(25, 358);
			label3.Name = "label3";
			label3.Size = new Size(133, 24);
			label3.TabIndex = 3;
			label3.Text = "Date Watched:";
			// 
			// movieSeen
			// 
			movieSeen.AutoSize = true;
			movieSeen.Font = new Font("Microsoft Sans Serif", 14.25F);
			movieSeen.Location = new Point(25, 388);
			movieSeen.Name = "movieSeen";
			movieSeen.Size = new Size(193, 28);
			movieSeen.TabIndex = 5;
			movieSeen.Text = "I've seen this movie";
			movieSeen.UseVisualStyleBackColor = true;
			// 
			// cancelButton
			// 
			cancelButton.BackColor = Color.FromArgb(192, 0, 0);
			cancelButton.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
			cancelButton.ForeColor = SystemColors.ButtonFace;
			cancelButton.Location = new Point(366, 419);
			cancelButton.Name = "cancelButton";
			cancelButton.Size = new Size(150, 30);
			cancelButton.TabIndex = 6;
			cancelButton.Text = "Cancel";
			cancelButton.UseVisualStyleBackColor = false;
			cancelButton.Click += CancelButton_Click;
			// 
			// createButton
			// 
			createButton.BackColor = Color.FromArgb(0, 192, 0);
			createButton.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
			createButton.ForeColor = SystemColors.ButtonFace;
			createButton.Location = new Point(522, 419);
			createButton.Name = "createButton";
			createButton.Size = new Size(150, 30);
			createButton.TabIndex = 7;
			createButton.Text = "Create";
			createButton.UseVisualStyleBackColor = false;
			createButton.Click += CreateButton_Click;
			// 
			// txtPlot
			// 
			txtPlot.Location = new Point(133, 106);
			txtPlot.Name = "txtPlot";
			txtPlot.Size = new Size(450, 213);
			txtPlot.TabIndex = 8;
			txtPlot.Text = "";
			// 
			// txtTitle
			// 
			txtTitle.Location = new Point(133, 59);
			txtTitle.Name = "txtTitle";
			txtTitle.Size = new Size(450, 23);
			txtTitle.TabIndex = 9;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.BackColor = Color.White;
			label4.ForeColor = Color.FromArgb(192, 0, 0);
			label4.Location = new Point(72, 62);
			label4.Name = "label4";
			label4.Size = new Size(55, 17);
			label4.TabIndex = 10;
			label4.Text = "Required";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.BackColor = Color.White;
			label5.ForeColor = Color.FromArgb(192, 0, 0);
			label5.Location = new Point(72, 106);
			label5.Name = "label5";
			label5.Size = new Size(55, 17);
			label5.TabIndex = 11;
			label5.Text = "Required";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.BackColor = Color.White;
			label6.ForeColor = Color.FromArgb(192, 0, 0);
			label6.Location = new Point(163, 363);
			label6.Name = "label6";
			label6.Size = new Size(55, 17);
			label6.TabIndex = 12;
			label6.Text = "Required";
			// 
			// NewMovie
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(684, 461);
			Controls.Add(label6);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(txtTitle);
			Controls.Add(txtPlot);
			Controls.Add(createButton);
			Controls.Add(cancelButton);
			Controls.Add(movieSeen);
			Controls.Add(label3);
			Controls.Add(dateTimePicker);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "NewMovie";
			Text = "New_Movie";
			Load += New_Movie_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label2;
		private DateTimePicker dateTimePicker;
		private Label label3;
		private CheckBox movieSeen;
		private Button cancelButton;
		private Button createButton;
		private RichTextBox txtPlot;
		private TextBox txtTitle;
		private Label label4;
		private Label label5;
		private Label label6;
	}
}