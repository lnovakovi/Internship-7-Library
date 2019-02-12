namespace Library.Presentation.Main
{
    partial class MainForm
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
            this.btnAddAuthor = new System.Windows.Forms.Button();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.btnDeleteAuthor = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAddPublisher = new System.Windows.Forms.Button();
            this.btnDeletePublisher = new System.Windows.Forms.Button();
            this.btnStudentDetails = new System.Windows.Forms.Button();
            this.btnAuthorDetails = new System.Windows.Forms.Button();
            this.btnBookDetails = new System.Windows.Forms.Button();
            this.btnPublisherDetails = new System.Windows.Forms.Button();
            this.btnEditStudent = new System.Windows.Forms.Button();
            this.btnEditAuthor = new System.Windows.Forms.Button();
            this.btnEditBook = new System.Windows.Forms.Button();
            this.btnEditPublisher = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBorrow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddAuthor
            // 
            this.btnAddAuthor.Location = new System.Drawing.Point(31, 39);
            this.btnAddAuthor.Name = "btnAddAuthor";
            this.btnAddAuthor.Size = new System.Drawing.Size(159, 66);
            this.btnAddAuthor.TabIndex = 0;
            this.btnAddAuthor.Text = "Add author";
            this.btnAddAuthor.UseVisualStyleBackColor = true;
            this.btnAddAuthor.Click += new System.EventHandler(this.btnAddAuthor_Click);
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Location = new System.Drawing.Point(31, 111);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(158, 68);
            this.btnAddStudent.TabIndex = 1;
            this.btnAddStudent.Text = "Add student";
            this.btnAddStudent.UseVisualStyleBackColor = true;
            // 
            // btnAddBook
            // 
            this.btnAddBook.Location = new System.Drawing.Point(31, 185);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(159, 60);
            this.btnAddBook.TabIndex = 2;
            this.btnAddBook.Text = "Add book";
            this.btnAddBook.UseVisualStyleBackColor = true;
            // 
            // btnDeleteAuthor
            // 
            this.btnDeleteAuthor.Location = new System.Drawing.Point(32, 395);
            this.btnDeleteAuthor.Name = "btnDeleteAuthor";
            this.btnDeleteAuthor.Size = new System.Drawing.Size(158, 56);
            this.btnDeleteAuthor.TabIndex = 3;
            this.btnDeleteAuthor.Text = "Delete author";
            this.btnDeleteAuthor.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(33, 457);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 56);
            this.button2.TabIndex = 4;
            this.button2.Text = "Delete student";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 519);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 53);
            this.button1.TabIndex = 5;
            this.button1.Text = "Delete book";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnAddPublisher
            // 
            this.btnAddPublisher.Location = new System.Drawing.Point(31, 251);
            this.btnAddPublisher.Name = "btnAddPublisher";
            this.btnAddPublisher.Size = new System.Drawing.Size(159, 65);
            this.btnAddPublisher.TabIndex = 6;
            this.btnAddPublisher.Text = "Add publisher";
            this.btnAddPublisher.UseVisualStyleBackColor = true;
            this.btnAddPublisher.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnDeletePublisher
            // 
            this.btnDeletePublisher.Location = new System.Drawing.Point(33, 578);
            this.btnDeletePublisher.Name = "btnDeletePublisher";
            this.btnDeletePublisher.Size = new System.Drawing.Size(158, 52);
            this.btnDeletePublisher.TabIndex = 7;
            this.btnDeletePublisher.Text = "Delete Publisher";
            this.btnDeletePublisher.UseVisualStyleBackColor = true;
            // 
            // btnStudentDetails
            // 
            this.btnStudentDetails.Location = new System.Drawing.Point(219, 113);
            this.btnStudentDetails.Name = "btnStudentDetails";
            this.btnStudentDetails.Size = new System.Drawing.Size(157, 65);
            this.btnStudentDetails.TabIndex = 8;
            this.btnStudentDetails.Text = "Student details";
            this.btnStudentDetails.UseVisualStyleBackColor = true;
            // 
            // btnAuthorDetails
            // 
            this.btnAuthorDetails.Location = new System.Drawing.Point(219, 39);
            this.btnAuthorDetails.Name = "btnAuthorDetails";
            this.btnAuthorDetails.Size = new System.Drawing.Size(157, 68);
            this.btnAuthorDetails.TabIndex = 9;
            this.btnAuthorDetails.Text = "Author details";
            this.btnAuthorDetails.UseVisualStyleBackColor = true;
            // 
            // btnBookDetails
            // 
            this.btnBookDetails.Location = new System.Drawing.Point(219, 189);
            this.btnBookDetails.Name = "btnBookDetails";
            this.btnBookDetails.Size = new System.Drawing.Size(157, 56);
            this.btnBookDetails.TabIndex = 10;
            this.btnBookDetails.Text = "Book details";
            this.btnBookDetails.UseVisualStyleBackColor = true;
            this.btnBookDetails.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // btnPublisherDetails
            // 
            this.btnPublisherDetails.Location = new System.Drawing.Point(219, 251);
            this.btnPublisherDetails.Name = "btnPublisherDetails";
            this.btnPublisherDetails.Size = new System.Drawing.Size(157, 65);
            this.btnPublisherDetails.TabIndex = 11;
            this.btnPublisherDetails.Text = "Publisher details";
            this.btnPublisherDetails.UseVisualStyleBackColor = true;
            // 
            // btnEditStudent
            // 
            this.btnEditStudent.Location = new System.Drawing.Point(219, 457);
            this.btnEditStudent.Name = "btnEditStudent";
            this.btnEditStudent.Size = new System.Drawing.Size(157, 56);
            this.btnEditStudent.TabIndex = 12;
            this.btnEditStudent.Text = "Edit student";
            this.btnEditStudent.UseVisualStyleBackColor = true;
            // 
            // btnEditAuthor
            // 
            this.btnEditAuthor.Location = new System.Drawing.Point(219, 395);
            this.btnEditAuthor.Name = "btnEditAuthor";
            this.btnEditAuthor.Size = new System.Drawing.Size(157, 56);
            this.btnEditAuthor.TabIndex = 13;
            this.btnEditAuthor.Text = "Edit author";
            this.btnEditAuthor.UseVisualStyleBackColor = true;
            // 
            // btnEditBook
            // 
            this.btnEditBook.Location = new System.Drawing.Point(219, 519);
            this.btnEditBook.Name = "btnEditBook";
            this.btnEditBook.Size = new System.Drawing.Size(156, 53);
            this.btnEditBook.TabIndex = 14;
            this.btnEditBook.Text = "Edit book";
            this.btnEditBook.UseVisualStyleBackColor = true;
            // 
            // btnEditPublisher
            // 
            this.btnEditPublisher.Location = new System.Drawing.Point(219, 578);
            this.btnEditPublisher.Name = "btnEditPublisher";
            this.btnEditPublisher.Size = new System.Drawing.Size(157, 52);
            this.btnEditPublisher.TabIndex = 15;
            this.btnEditPublisher.Text = "Edit publisher";
            this.btnEditPublisher.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(619, 71);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(490, 588);
            this.listView1.TabIndex = 16;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(615, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Actual loans";
            // 
            // btnBorrow
            // 
            this.btnBorrow.Location = new System.Drawing.Point(420, 323);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(165, 68);
            this.btnBorrow.TabIndex = 18;
            this.btnBorrow.Text = "New Borrow";
            this.btnBorrow.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 705);
            this.Controls.Add(this.btnBorrow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnEditPublisher);
            this.Controls.Add(this.btnEditBook);
            this.Controls.Add(this.btnEditAuthor);
            this.Controls.Add(this.btnEditStudent);
            this.Controls.Add(this.btnPublisherDetails);
            this.Controls.Add(this.btnBookDetails);
            this.Controls.Add(this.btnAuthorDetails);
            this.Controls.Add(this.btnStudentDetails);
            this.Controls.Add(this.btnDeletePublisher);
            this.Controls.Add(this.btnAddPublisher);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnDeleteAuthor);
            this.Controls.Add(this.btnAddBook);
            this.Controls.Add(this.btnAddStudent);
            this.Controls.Add(this.btnAddAuthor);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddAuthor;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Button btnDeleteAuthor;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAddPublisher;
        private System.Windows.Forms.Button btnDeletePublisher;
        private System.Windows.Forms.Button btnStudentDetails;
        private System.Windows.Forms.Button btnAuthorDetails;
        private System.Windows.Forms.Button btnBookDetails;
        private System.Windows.Forms.Button btnPublisherDetails;
        private System.Windows.Forms.Button btnEditStudent;
        private System.Windows.Forms.Button btnEditAuthor;
        private System.Windows.Forms.Button btnEditBook;
        private System.Windows.Forms.Button btnEditPublisher;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBorrow;
    }
}