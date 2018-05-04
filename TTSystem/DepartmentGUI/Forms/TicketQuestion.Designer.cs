namespace DepartmentGUI
{
    partial class TicketQuestion
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
            this.label3 = new System.Windows.Forms.Label();
            this.answerBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.logoutBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.ticketTitle = new MaterialSkin.Controls.MaterialLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.ticketID = new System.Windows.Forms.Label();
            this.question = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 25);
            this.label3.TabIndex = 41;
            this.label3.Text = "Question";
            // 
            // answerBtn
            // 
            this.answerBtn.Depth = 0;
            this.answerBtn.Location = new System.Drawing.Point(333, 398);
            this.answerBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.answerBtn.Name = "answerBtn";
            this.answerBtn.Primary = true;
            this.answerBtn.Size = new System.Drawing.Size(121, 40);
            this.answerBtn.TabIndex = 40;
            this.answerBtn.Text = "Answer";
            this.answerBtn.UseVisualStyleBackColor = true;
            // 
            // logoutBtn
            // 
            this.logoutBtn.Depth = 0;
            this.logoutBtn.Location = new System.Drawing.Point(644, 99);
            this.logoutBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Primary = true;
            this.logoutBtn.Size = new System.Drawing.Size(121, 28);
            this.logoutBtn.TabIndex = 38;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = true;
            // 
            // ticketTitle
            // 
            this.ticketTitle.AutoSize = true;
            this.ticketTitle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ticketTitle.Depth = 0;
            this.ticketTitle.Font = new System.Drawing.Font("Roboto", 11F);
            this.ticketTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ticketTitle.Location = new System.Drawing.Point(105, 146);
            this.ticketTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.ticketTitle.Name = "ticketTitle";
            this.ticketTitle.Size = new System.Drawing.Size(35, 19);
            this.ticketTitle.TabIndex = 37;
            this.ticketTitle.Text = "title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 25);
            this.label2.TabIndex = 36;
            this.label2.Text = "Title";
            // 
            // ticketID
            // 
            this.ticketID.AutoSize = true;
            this.ticketID.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ticketID.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ticketID.Location = new System.Drawing.Point(32, 95);
            this.ticketID.Name = "ticketID";
            this.ticketID.Size = new System.Drawing.Size(117, 29);
            this.ticketID.TabIndex = 35;
            this.ticketID.Text = "Ticket ID";
            // 
            // question
            // 
            this.question.AutoSize = true;
            this.question.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.question.Depth = 0;
            this.question.Font = new System.Drawing.Font("Roboto", 11F);
            this.question.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.question.Location = new System.Drawing.Point(35, 248);
            this.question.MouseState = MaterialSkin.MouseState.HOVER;
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(68, 19);
            this.question.TabIndex = 42;
            this.question.Text = "question";
            // 
            // TicketQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.question);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.answerBtn);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.ticketTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ticketID);
            this.Name = "TicketQuestion";
            this.Text = "Response Ticket";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private MaterialSkin.Controls.MaterialRaisedButton answerBtn;
        private MaterialSkin.Controls.MaterialRaisedButton logoutBtn;
        private MaterialSkin.Controls.MaterialLabel ticketTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ticketID;
        private MaterialSkin.Controls.MaterialLabel question;
    }
}