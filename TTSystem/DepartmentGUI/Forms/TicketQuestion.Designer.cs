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
            this.ticketID = new System.Windows.Forms.Label();
            this.question = new MaterialSkin.Controls.MaterialLabel();
            this.departmentBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.Load += new System.EventHandler(this.TicketQuestion_Load);
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 186);
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
            this.answerBtn.Click += new System.EventHandler(this.AnswerBtn_Click);
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
            this.question.Location = new System.Drawing.Point(33, 238);
            this.question.MouseState = MaterialSkin.MouseState.HOVER;
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(68, 19);
            this.question.TabIndex = 42;
            this.question.Text = "question";
            // 
            // departmentBtn
            // 
            this.departmentBtn.Depth = 0;
            this.departmentBtn.Location = new System.Drawing.Point(604, 99);
            this.departmentBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.departmentBtn.Name = "departmentBtn";
            this.departmentBtn.Primary = true;
            this.departmentBtn.Size = new System.Drawing.Size(121, 28);
            this.departmentBtn.TabIndex = 43;
            this.departmentBtn.Text = "Department";
            this.departmentBtn.UseVisualStyleBackColor = true;
            this.departmentBtn.Click += new System.EventHandler(this.DepartmentBtn_Click);
            // 
            // TicketQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.departmentBtn);
            this.Controls.Add(this.question);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.answerBtn);
            this.Controls.Add(this.ticketID);
            this.Name = "TicketQuestion";
            this.Text = "Response Ticket";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private MaterialSkin.Controls.MaterialRaisedButton answerBtn;
        private System.Windows.Forms.Label ticketID;
        private MaterialSkin.Controls.MaterialLabel question;
        private MaterialSkin.Controls.MaterialRaisedButton departmentBtn;
    }
}