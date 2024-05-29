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
            btnEdit = new Button();
            SuspendLayout();
            // 
            // title
            // 
            title.AutoSize = true;
            title.Location = new Point(272, 156);
            title.Name = "title";
            title.Size = new Size(45, 20);
            title.TabIndex = 0;
            title.Text = "Title :";
            // 
            // author
            // 
            author.AutoSize = true;
            author.Location = new Point(272, 253);
            author.Name = "author";
            author.Size = new Size(61, 20);
            author.TabIndex = 1;
            author.Text = "Author :";
            // 
            // content
            // 
            content.AutoSize = true;
            content.Location = new Point(272, 353);
            content.Name = "content";
            content.Size = new Size(68, 20);
            content.TabIndex = 2;
            content.Text = "Content :";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(272, 203);
            txtTitle.Margin = new Padding(3, 4, 3, 4);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(191, 27);
            txtTitle.TabIndex = 3;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(272, 289);
            txtAuthor.Margin = new Padding(3, 4, 3, 4);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(191, 27);
            txtAuthor.TabIndex = 4;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(272, 377);
            txtContent.Margin = new Padding(3, 4, 3, 4);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(191, 73);
            txtContent.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.ControlDark;
            btnSave.ForeColor = SystemColors.ControlLightLight;
            btnSave.Location = new Point(272, 460);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(86, 31);
            btnSave.TabIndex = 6;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.OrangeRed;
            btnCancel.ForeColor = SystemColors.ControlLightLight;
            btnCancel.Location = new Point(378, 460);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(86, 31);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = SystemColors.HotTrack;
            btnEdit.ForeColor = SystemColors.ControlLightLight;
            btnEdit.Location = new Point(272, 460);
            btnEdit.Margin = new Padding(3, 4, 3, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(86, 31);
            btnEdit.TabIndex = 8;
            btnEdit.Text = "&Update";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Visible = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // FrmBlog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnEdit);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtContent);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Controls.Add(content);
            Controls.Add(author);
            Controls.Add(title);
            Margin = new Padding(3, 4, 3, 4);
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
        private Button btnEdit;
    }
}
