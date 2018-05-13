namespace SolverGUI
{
    partial class PersonalPage
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
            this.name = new MaterialSkin.Controls.MaterialLabel();
            this.email = new MaterialSkin.Controls.MaterialLabel();
            this.logoutBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.ttBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.questionBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.ticketsOpen = new MaterialSkin.Controls.MaterialLabel();
            this.tickets = new MaterialSkin.Controls.MaterialLabel();
            this.questionsOpen = new MaterialSkin.Controls.MaterialLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.name.Depth = 0;
            this.name.Font = new System.Drawing.Font("Roboto", 11F);
            this.name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.name.Location = new System.Drawing.Point(112, 94);
            this.name.MouseState = MaterialSkin.MouseState.HOVER;
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(46, 19);
            this.name.TabIndex = 8;
            this.name.Text = "name";
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.email.Depth = 0;
            this.email.Font = new System.Drawing.Font("Roboto", 11F);
            this.email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.email.Location = new System.Drawing.Point(112, 133);
            this.email.MouseState = MaterialSkin.MouseState.HOVER;
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(46, 19);
            this.email.TabIndex = 9;
            this.email.Text = "email";
            // 
            // logoutBtn
            // 
            this.logoutBtn.Depth = 0;
            this.logoutBtn.Location = new System.Drawing.Point(654, 94);
            this.logoutBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Primary = true;
            this.logoutBtn.Size = new System.Drawing.Size(121, 28);
            this.logoutBtn.TabIndex = 18;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.LogoutBtn_Click);
            // 
            // ttBtn
            // 
            this.ttBtn.Depth = 0;
            this.ttBtn.Location = new System.Drawing.Point(256, 302);
            this.ttBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.ttBtn.Name = "ttBtn";
            this.ttBtn.Primary = true;
            this.ttBtn.Size = new System.Drawing.Size(131, 44);
            this.ttBtn.TabIndex = 34;
            this.ttBtn.Text = "Trouble Tickets";
            this.ttBtn.UseVisualStyleBackColor = true;
            this.ttBtn.Click += new System.EventHandler(this.TtBtn_Click);
            // 
            // questionBtn
            // 
            this.questionBtn.Depth = 0;
            this.questionBtn.Location = new System.Drawing.Point(452, 302);
            this.questionBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.questionBtn.Name = "questionBtn";
            this.questionBtn.Primary = true;
            this.questionBtn.Size = new System.Drawing.Size(132, 44);
            this.questionBtn.TabIndex = 35;
            this.questionBtn.Text = "Secondary Questions";
            this.questionBtn.UseVisualStyleBackColor = true;
            this.questionBtn.Click += new System.EventHandler(this.QuestionBtn_Click);
            // 
            // ticketsOpen
            // 
            this.ticketsOpen.AutoSize = true;
            this.ticketsOpen.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ticketsOpen.Depth = 0;
            this.ticketsOpen.Font = new System.Drawing.Font("Roboto", 11F);
            this.ticketsOpen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ticketsOpen.Location = new System.Drawing.Point(211, 208);
            this.ticketsOpen.MouseState = MaterialSkin.MouseState.HOVER;
            this.ticketsOpen.Name = "ticketsOpen";
            this.ticketsOpen.Size = new System.Drawing.Size(17, 19);
            this.ticketsOpen.TabIndex = 36;
            this.ticketsOpen.Text = "0";
            // 
            // tickets
            // 
            this.tickets.AutoSize = true;
            this.tickets.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tickets.Depth = 0;
            this.tickets.Font = new System.Drawing.Font("Roboto", 11F);
            this.tickets.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tickets.Location = new System.Drawing.Point(427, 209);
            this.tickets.MouseState = MaterialSkin.MouseState.HOVER;
            this.tickets.Name = "tickets";
            this.tickets.Size = new System.Drawing.Size(17, 19);
            this.tickets.TabIndex = 37;
            this.tickets.Text = "0";
            // 
            // questionsOpen
            // 
            this.questionsOpen.AutoSize = true;
            this.questionsOpen.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.questionsOpen.Depth = 0;
            this.questionsOpen.Font = new System.Drawing.Font("Roboto", 11F);
            this.questionsOpen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.questionsOpen.Location = new System.Drawing.Point(663, 209);
            this.questionsOpen.MouseState = MaterialSkin.MouseState.HOVER;
            this.questionsOpen.Name = "questionsOpen";
            this.questionsOpen.Size = new System.Drawing.Size(17, 19);
            this.questionsOpen.TabIndex = 38;
            this.questionsOpen.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 39;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 40;
            this.label2.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 20);
            this.label3.TabIndex = 41;
            this.label3.Text = "Tickets Unassigned";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(315, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 42;
            this.label4.Text = "My Tickets";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(527, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 20);
            this.label5.TabIndex = 43;
            this.label5.Text = "My Questions";
            // 
            // PersonalPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.questionsOpen);
            this.Controls.Add(this.tickets);
            this.Controls.Add(this.ticketsOpen);
            this.Controls.Add(this.questionBtn);
            this.Controls.Add(this.ttBtn);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.email);
            this.Controls.Add(this.name);
            this.Name = "PersonalPage";
            this.Text = "Personal Page";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialLabel name;
        private MaterialSkin.Controls.MaterialLabel email;
        private MaterialSkin.Controls.MaterialRaisedButton logoutBtn;
        private MaterialSkin.Controls.MaterialRaisedButton ttBtn;
        private MaterialSkin.Controls.MaterialRaisedButton questionBtn;
        private MaterialSkin.Controls.MaterialLabel ticketsOpen;
        private MaterialSkin.Controls.MaterialLabel tickets;
        private MaterialSkin.Controls.MaterialLabel questionsOpen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}