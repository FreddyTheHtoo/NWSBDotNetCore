namespace NWSBDotNetCore.WindowFormApp
{
    partial class FrmBlog
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
            title = new Label();
            author = new Label();
            content = new Label();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtContent = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // title
            // 
            title.AutoSize = true;
            title.Location = new Point(238, 117);
            title.Name = "title";
            title.Size = new Size(35, 15);
            title.TabIndex = 0;
            title.Text = "Title :";
            // 
            // author
            // 
            author.AutoSize = true;
            author.Location = new Point(238, 190);
            author.Name = "author";
            author.Size = new Size(50, 15);
            author.TabIndex = 1;
            author.Text = "Author :";
            // 
            // content
            // 
            content.AutoSize = true;
            content.Location = new Point(238, 265);
            content.Name = "content";
            content.Size = new Size(56, 15);
            content.TabIndex = 2;
            content.Text = "Content :";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(238, 152);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(168, 23);
            txtTitle.TabIndex = 3;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(238, 217);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(168, 23);
            txtAuthor.TabIndex = 4;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(238, 283);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(168, 56);
            txtContent.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.ControlDark;
            btnSave.ForeColor = SystemColors.ControlLightLight;
            btnSave.Location = new Point(238, 345);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.OrangeRed;
            btnCancel.ForeColor = SystemColors.ControlLightLight;
            btnCancel.Location = new Point(331, 345);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // FrmBlog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtContent);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Controls.Add(content);
            Controls.Add(author);
            Controls.Add(title);
            Name = "FrmBlog";
            Text = "Blog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label title;
        private Label author;
        private Label content;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtContent;
        private Button btnSave;
        private Button btnCancel;
    }
}
