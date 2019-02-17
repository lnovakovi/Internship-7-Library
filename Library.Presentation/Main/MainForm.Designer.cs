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
            this.btnAddPublisher = new System.Windows.Forms.Button();
            this.btnStudentDetails = new System.Windows.Forms.Button();
            this.btnAuthorDetails = new System.Windows.Forms.Button();
            this.btnBookDetails = new System.Windows.Forms.Button();
            this.btnPublisherDetails = new System.Windows.Forms.Button();
            this.btnEditStudent = new System.Windows.Forms.Button();
            this.btnEditAuthor = new System.Windows.Forms.Button();
            this.btnEditBook = new System.Windows.Forms.Button();
            this.btnEditPublisher = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBorrow = new System.Windows.Forms.Button();
            this.btnCloseBorrow = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lstLoans = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // btnAddBook
            // 
            this.btnAddBook.Location = new System.Drawing.Point(31, 185);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(159, 60);
            this.btnAddBook.TabIndex = 2;
            this.btnAddBook.Text = "Add book";
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // btnAddPublisher
            // 
            this.btnAddPublisher.Location = new System.Drawing.Point(31, 251);
            this.btnAddPublisher.Name = "btnAddPublisher";
            this.btnAddPublisher.Size = new System.Drawing.Size(159, 65);
            this.btnAddPublisher.TabIndex = 6;
            this.btnAddPublisher.Text = "Add publisher";
            this.btnAddPublisher.UseVisualStyleBackColor = true;
            this.btnAddPublisher.Click += new System.EventHandler(this.btnAddPublisher_Click);
            // 
            // btnStudentDetails
            // 
            this.btnStudentDetails.Location = new System.Drawing.Point(219, 113);
            this.btnStudentDetails.Name = "btnStudentDetails";
            this.btnStudentDetails.Size = new System.Drawing.Size(157, 65);
            this.btnStudentDetails.TabIndex = 8;
            this.btnStudentDetails.Text = "Student details";
            this.btnStudentDetails.UseVisualStyleBackColor = true;
            this.btnStudentDetails.Click += new System.EventHandler(this.btnStudentDetails_Click);
            // 
            // btnAuthorDetails
            // 
            this.btnAuthorDetails.Location = new System.Drawing.Point(219, 38);
            this.btnAuthorDetails.Name = "btnAuthorDetails";
            this.btnAuthorDetails.Size = new System.Drawing.Size(157, 68);
            this.btnAuthorDetails.TabIndex = 9;
            this.btnAuthorDetails.Text = "Author details";
            this.btnAuthorDetails.UseVisualStyleBackColor = true;
            this.btnAuthorDetails.Click += new System.EventHandler(this.btnAuthorDetails_Click);
            // 
            // btnBookDetails
            // 
            this.btnBookDetails.Location = new System.Drawing.Point(219, 189);
            this.btnBookDetails.Name = "btnBookDetails";
            this.btnBookDetails.Size = new System.Drawing.Size(157, 56);
            this.btnBookDetails.TabIndex = 10;
            this.btnBookDetails.Text = "Book details";
            this.btnBookDetails.UseVisualStyleBackColor = true;
            this.btnBookDetails.Click += new System.EventHandler(this.btnBookDetails_Click);
            // 
            // btnPublisherDetails
            // 
            this.btnPublisherDetails.Location = new System.Drawing.Point(219, 251);
            this.btnPublisherDetails.Name = "btnPublisherDetails";
            this.btnPublisherDetails.Size = new System.Drawing.Size(157, 65);
            this.btnPublisherDetails.TabIndex = 11;
            this.btnPublisherDetails.Text = "Publisher details";
            this.btnPublisherDetails.UseVisualStyleBackColor = true;
            this.btnPublisherDetails.Click += new System.EventHandler(this.btnPublisherDetails_Click);
            // 
            // btnEditStudent
            // 
            this.btnEditStudent.Location = new System.Drawing.Point(33, 442);
            this.btnEditStudent.Name = "btnEditStudent";
            this.btnEditStudent.Size = new System.Drawing.Size(157, 56);
            this.btnEditStudent.TabIndex = 12;
            this.btnEditStudent.Text = "Edit student";
            this.btnEditStudent.UseVisualStyleBackColor = true;
            this.btnEditStudent.Click += new System.EventHandler(this.btnEditStudent_Click);
            // 
            // btnEditAuthor
            // 
            this.btnEditAuthor.Location = new System.Drawing.Point(33, 369);
            this.btnEditAuthor.Name = "btnEditAuthor";
            this.btnEditAuthor.Size = new System.Drawing.Size(157, 56);
            this.btnEditAuthor.TabIndex = 13;
            this.btnEditAuthor.Text = "Edit author";
            this.btnEditAuthor.UseVisualStyleBackColor = true;
            this.btnEditAuthor.Click += new System.EventHandler(this.btnEditAuthor_Click);
            // 
            // btnEditBook
            // 
            this.btnEditBook.Location = new System.Drawing.Point(33, 516);
            this.btnEditBook.Name = "btnEditBook";
            this.btnEditBook.Size = new System.Drawing.Size(156, 53);
            this.btnEditBook.TabIndex = 14;
            this.btnEditBook.Text = "Edit book";
            this.btnEditBook.UseVisualStyleBackColor = true;
            this.btnEditBook.Click += new System.EventHandler(this.btnEditBook_Click);
            // 
            // btnEditPublisher
            // 
            this.btnEditPublisher.Location = new System.Drawing.Point(33, 585);
            this.btnEditPublisher.Name = "btnEditPublisher";
            this.btnEditPublisher.Size = new System.Drawing.Size(157, 52);
            this.btnEditPublisher.TabIndex = 15;
            this.btnEditPublisher.Text = "Edit publisher";
            this.btnEditPublisher.UseVisualStyleBackColor = true;
            this.btnEditPublisher.Click += new System.EventHandler(this.btnEditPublisher_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(615, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "Actual loans";
            // 
            // btnBorrow
            // 
            this.btnBorrow.Location = new System.Drawing.Point(363, 381);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(165, 68);
            this.btnBorrow.TabIndex = 18;
            this.btnBorrow.Text = "New Borrow";
            this.btnBorrow.UseVisualStyleBackColor = true;
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // btnCloseBorrow
            // 
            this.btnCloseBorrow.Location = new System.Drawing.Point(363, 486);
            this.btnCloseBorrow.Name = "btnCloseBorrow";
            this.btnCloseBorrow.Size = new System.Drawing.Size(165, 66);
            this.btnCloseBorrow.TabIndex = 19;
            this.btnCloseBorrow.Text = "Close borrow";
            this.btnCloseBorrow.UseVisualStyleBackColor = true;
            this.btnCloseBorrow.Click += new System.EventHandler(this.btnCloseBorrow_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(733, 655);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(156, 47);
            this.btnExit.TabIndex = 20;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lstLoans
            // 
            this.lstLoans.FormattingEnabled = true;
            this.lstLoans.ItemHeight = 20;
            this.lstLoans.Location = new System.Drawing.Point(584, 57);
            this.lstLoans.Name = "lstLoans";
            this.lstLoans.Size = new System.Drawing.Size(514, 504);
            this.lstLoans.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(827, 573);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(375, 64);
            this.label2.TabIndex = 22;
            this.label2.Text = "*Choose loan you want to close";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 705);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstLoans);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCloseBorrow);
            this.Controls.Add(this.btnBorrow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEditPublisher);
            this.Controls.Add(this.btnEditBook);
            this.Controls.Add(this.btnEditAuthor);
            this.Controls.Add(this.btnEditStudent);
            this.Controls.Add(this.btnPublisherDetails);
            this.Controls.Add(this.btnBookDetails);
            this.Controls.Add(this.btnAuthorDetails);
            this.Controls.Add(this.btnStudentDetails);
            this.Controls.Add(this.btnAddPublisher);
            this.Controls.Add(this.btnAddBook);
            this.Controls.Add(this.btnAddStudent);
            this.Controls.Add(this.btnAddAuthor);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddAuthor;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Button btnAddPublisher;
        private System.Windows.Forms.Button btnStudentDetails;
        private System.Windows.Forms.Button btnAuthorDetails;
        private System.Windows.Forms.Button btnBookDetails;
        private System.Windows.Forms.Button btnPublisherDetails;
        private System.Windows.Forms.Button btnEditStudent;
        private System.Windows.Forms.Button btnEditAuthor;
        private System.Windows.Forms.Button btnEditBook;
        private System.Windows.Forms.Button btnEditPublisher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBorrow;
        private System.Windows.Forms.Button btnCloseBorrow;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListBox lstLoans;
        private System.Windows.Forms.Label label2;
    }
}