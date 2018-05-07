namespace SolverGUI
{
    partial class TicketPage
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.title = new MaterialSkin.Controls.MaterialLabel();
            this.ticketLabel = new System.Windows.Forms.Label();
            this.date = new MaterialSkin.Controls.MaterialLabel();
            this.description = new MaterialSkin.Controls.MaterialLabel();
            this.solveBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.redirectBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.logoutBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.profileBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.assignBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.status = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(39, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "Date";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.title.Depth = 0;
            this.title.Font = new System.Drawing.Font("Roboto", 11F);
            this.title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.title.Location = new System.Drawing.Point(112, 156);
            this.title.MouseState = MaterialSkin.MouseState.HOVER;
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(35, 19);
            this.title.TabIndex = 18;
            this.title.Text = "title";
            // 
            // ticketLabel
            // 
            this.ticketLabel.AutoSize = true;
            this.ticketLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ticketLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ticketLabel.Location = new System.Drawing.Point(30, 97);
            this.ticketLabel.Name = "ticketLabel";
            this.ticketLabel.Size = new System.Drawing.Size(117, 29);
            this.ticketLabel.TabIndex = 19;
            this.ticketLabel.Text = "Ticket ID";
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.date.Depth = 0;
            this.date.Font = new System.Drawing.Font("Roboto", 11F);
            this.date.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.date.Location = new System.Drawing.Point(112, 199);
            this.date.MouseState = MaterialSkin.MouseState.HOVER;
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(38, 19);
            this.date.TabIndex = 20;
            this.date.Text = "date";
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.description.Depth = 0;
            this.description.Font = new System.Drawing.Font("Roboto", 11F);
            this.description.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.description.Location = new System.Drawing.Point(40, 290);
            this.description.MouseState = MaterialSkin.MouseState.HOVER;
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(84, 19);
            this.description.TabIndex = 21;
            this.description.Text = "description";
            // 
            // solveBtn
            // 
            this.solveBtn.Depth = 0;
            this.solveBtn.Location = new System.Drawing.Point(393, 387);
            this.solveBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.solveBtn.Name = "solveBtn";
            this.solveBtn.Primary = true;
            this.solveBtn.Size = new System.Drawing.Size(121, 40);
            this.solveBtn.TabIndex = 22;
            this.solveBtn.Text = "Solve";
            this.solveBtn.UseVisualStyleBackColor = true;
            this.solveBtn.Click += new System.EventHandler(this.SolveBtn_Click);
            // 
            // redirectBtn
            // 
            this.redirectBtn.Depth = 0;
            this.redirectBtn.Location = new System.Drawing.Point(567, 387);
            this.redirectBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.redirectBtn.Name = "redirectBtn";
            this.redirectBtn.Primary = true;
            this.redirectBtn.Size = new System.Drawing.Size(121, 40);
            this.redirectBtn.TabIndex = 23;
            this.redirectBtn.Text = "Redirect";
            this.redirectBtn.UseVisualStyleBackColor = true;
            this.redirectBtn.Click += new System.EventHandler(this.RedirectBtn_Click);
            // 
            // logoutBtn
            // 
            this.logoutBtn.Depth = 0;
            this.logoutBtn.Location = new System.Drawing.Point(653, 101);
            this.logoutBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Primary = true;
            this.logoutBtn.Size = new System.Drawing.Size(121, 28);
            this.logoutBtn.TabIndex = 24;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.LogoutBtn_Click);
            // 
            // profileBtn
            // 
            this.profileBtn.Depth = 0;
            this.profileBtn.Location = new System.Drawing.Point(509, 101);
            this.profileBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.profileBtn.Name = "profileBtn";
            this.profileBtn.Primary = true;
            this.profileBtn.Size = new System.Drawing.Size(121, 28);
            this.profileBtn.TabIndex = 25;
            this.profileBtn.Text = "Profile";
            this.profileBtn.UseVisualStyleBackColor = true;
            this.profileBtn.Click += new System.EventHandler(this.ProfileBtn_Click);
            // 
            // assignBtn
            // 
            this.assignBtn.Depth = 0;
            this.assignBtn.Location = new System.Drawing.Point(218, 387);
            this.assignBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.assignBtn.Name = "assignBtn";
            this.assignBtn.Primary = true;
            this.assignBtn.Size = new System.Drawing.Size(121, 40);
            this.assignBtn.TabIndex = 26;
            this.assignBtn.Text = "Assign";
            this.assignBtn.UseVisualStyleBackColor = true;
            this.assignBtn.Click += new System.EventHandler(this.AssignBtn_Click);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.status.Depth = 0;
            this.status.Font = new System.Drawing.Font("Roboto", 11F);
            this.status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.status.Location = new System.Drawing.Point(181, 101);
            this.status.MouseState = MaterialSkin.MouseState.HOVER;
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(51, 19);
            this.status.TabIndex = 28;
            this.status.Text = "status";
            // 
            // TicketPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.status);
            this.Controls.Add(this.assignBtn);
            this.Controls.Add(this.profileBtn);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.redirectBtn);
            this.Controls.Add(this.solveBtn);
            this.Controls.Add(this.description);
            this.Controls.Add(this.date);
            this.Controls.Add(this.ticketLabel);
            this.Controls.Add(this.title);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "TicketPage";
            this.Text = "Ticket Page";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private MaterialSkin.Controls.MaterialLabel title;
        private System.Windows.Forms.Label ticketLabel;
        private MaterialSkin.Controls.MaterialLabel date;
        private MaterialSkin.Controls.MaterialLabel description;
        private MaterialSkin.Controls.MaterialRaisedButton solveBtn;
        private MaterialSkin.Controls.MaterialRaisedButton redirectBtn;
        private MaterialSkin.Controls.MaterialRaisedButton logoutBtn;
        private MaterialSkin.Controls.MaterialRaisedButton profileBtn;
        private MaterialSkin.Controls.MaterialRaisedButton assignBtn;
        private MaterialSkin.Controls.MaterialLabel status;
    }
}