namespace GUI.Forms
{
    partial class QuestionPage
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
            this.status = new MaterialSkin.Controls.MaterialLabel();
            this.profileBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.logoutBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.question = new MaterialSkin.Controls.MaterialLabel();
            this.date = new MaterialSkin.Controls.MaterialLabel();
            this.ticketLabel = new System.Windows.Forms.Label();
            this.ticketID = new MaterialSkin.Controls.MaterialLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.response = new MaterialSkin.Controls.MaterialLabel();
            this.Load += new System.EventHandler(this.QuestionPage_Load);
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.status.Depth = 0;
            this.status.Font = new System.Drawing.Font("Roboto", 11F);
            this.status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.status.Location = new System.Drawing.Point(179, 123);
            this.status.MouseState = MaterialSkin.MouseState.HOVER;
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(51, 19);
            this.status.TabIndex = 38;
            this.status.Text = "status";
            // 
            // profileBtn
            // 
            this.profileBtn.Depth = 0;
            this.profileBtn.Location = new System.Drawing.Point(507, 123);
            this.profileBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.profileBtn.Name = "profileBtn";
            this.profileBtn.Primary = true;
            this.profileBtn.Size = new System.Drawing.Size(121, 28);
            this.profileBtn.TabIndex = 37;
            this.profileBtn.Text = "Main Page";
            this.profileBtn.UseVisualStyleBackColor = true;
            this.profileBtn.Click += new System.EventHandler(this.ProfileBtn_Click);
            // 
            // logoutBtn
            // 
            this.logoutBtn.Depth = 0;
            this.logoutBtn.Location = new System.Drawing.Point(651, 123);
            this.logoutBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Primary = true;
            this.logoutBtn.Size = new System.Drawing.Size(121, 28);
            this.logoutBtn.TabIndex = 36;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.LogoutBtn_Click);
            // 
            // question
            // 
            this.question.AutoSize = true;
            this.question.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.question.Depth = 0;
            this.question.Font = new System.Drawing.Font("Roboto", 11F);
            this.question.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.question.Location = new System.Drawing.Point(38, 326);
            this.question.MouseState = MaterialSkin.MouseState.HOVER;
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(84, 19);
            this.question.TabIndex = 35;
            this.question.Text = "description";
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.date.Depth = 0;
            this.date.Font = new System.Drawing.Font("Roboto", 11F);
            this.date.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.date.Location = new System.Drawing.Point(104, 227);
            this.date.MouseState = MaterialSkin.MouseState.HOVER;
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(38, 19);
            this.date.TabIndex = 34;
            this.date.Text = "date";
            // 
            // ticketLabel
            // 
            this.ticketLabel.AutoSize = true;
            this.ticketLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ticketLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ticketLabel.Location = new System.Drawing.Point(28, 119);
            this.ticketLabel.Name = "ticketLabel";
            this.ticketLabel.Size = new System.Drawing.Size(150, 29);
            this.ticketLabel.TabIndex = 33;
            this.ticketLabel.Text = "Question ID";
            // 
            // ticketID
            // 
            this.ticketID.AutoSize = true;
            this.ticketID.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ticketID.Depth = 0;
            this.ticketID.Font = new System.Drawing.Font("Roboto", 11F);
            this.ticketID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ticketID.Location = new System.Drawing.Point(154, 178);
            this.ticketID.MouseState = MaterialSkin.MouseState.HOVER;
            this.ticketID.Name = "ticketID";
            this.ticketID.Size = new System.Drawing.Size(61, 19);
            this.ticketID.TabIndex = 32;
            this.ticketID.Text = "ticketID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(28, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 25);
            this.label6.TabIndex = 31;
            this.label6.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 25);
            this.label3.TabIndex = 30;
            this.label3.Text = "Question";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 25);
            this.label2.TabIndex = 29;
            this.label2.Text = "Ticket ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 403);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 39;
            this.label1.Text = "Response";
            // 
            // response
            // 
            this.response.AutoSize = true;
            this.response.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.response.Depth = 0;
            this.response.Font = new System.Drawing.Font("Roboto", 11F);
            this.response.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.response.Location = new System.Drawing.Point(38, 440);
            this.response.MouseState = MaterialSkin.MouseState.HOVER;
            this.response.Name = "response";
            this.response.Size = new System.Drawing.Size(84, 19);
            this.response.TabIndex = 40;
            this.response.Text = "description";
            // 
            // QuestionPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 548);
            this.Controls.Add(this.response);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.status);
            this.Controls.Add(this.profileBtn);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.question);
            this.Controls.Add(this.date);
            this.Controls.Add(this.ticketLabel);
            this.Controls.Add(this.ticketID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "QuestionPage";
            this.Text = "Question";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel status;
        private MaterialSkin.Controls.MaterialRaisedButton profileBtn;
        private MaterialSkin.Controls.MaterialRaisedButton logoutBtn;
        private MaterialSkin.Controls.MaterialLabel question;
        private MaterialSkin.Controls.MaterialLabel date;
        private System.Windows.Forms.Label ticketLabel;
        private MaterialSkin.Controls.MaterialLabel ticketID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialLabel response;
    }
}