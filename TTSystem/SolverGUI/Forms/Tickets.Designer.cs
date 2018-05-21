namespace GUI.Forms
{
    partial class Tickets
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
            this.logoutBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.myTicketsBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.closeBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.openBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.profileBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.questionsOpen = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.email = new MaterialSkin.Controls.MaterialLabel();
            this.name = new MaterialSkin.Controls.MaterialLabel();
            this.Load += new System.EventHandler(this.Tickets_Load);
            this.SuspendLayout();
            // 
            // logoutBtn
            // 
            this.logoutBtn.Depth = 0;
            this.logoutBtn.Location = new System.Drawing.Point(640, 81);
            this.logoutBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Primary = true;
            this.logoutBtn.Size = new System.Drawing.Size(121, 28);
            this.logoutBtn.TabIndex = 39;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.LogoutBtn_Click);
            // 
            // myTicketsBtn
            // 
            this.myTicketsBtn.Depth = 0;
            this.myTicketsBtn.Location = new System.Drawing.Point(615, 253);
            this.myTicketsBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.myTicketsBtn.Name = "myTicketsBtn";
            this.myTicketsBtn.Primary = true;
            this.myTicketsBtn.Size = new System.Drawing.Size(159, 39);
            this.myTicketsBtn.TabIndex = 42;
            this.myTicketsBtn.Text = "My Tickets Without Questions";
            this.myTicketsBtn.UseVisualStyleBackColor = true;
            this.myTicketsBtn.Click += new System.EventHandler(this.MyTicketsBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Depth = 0;
            this.closeBtn.Location = new System.Drawing.Point(615, 364);
            this.closeBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Primary = true;
            this.closeBtn.Size = new System.Drawing.Size(159, 40);
            this.closeBtn.TabIndex = 41;
            this.closeBtn.Text = "Tickets Closed";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // openBtn
            // 
            this.openBtn.Depth = 0;
            this.openBtn.Location = new System.Drawing.Point(615, 199);
            this.openBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.openBtn.Name = "openBtn";
            this.openBtn.Primary = true;
            this.openBtn.Size = new System.Drawing.Size(159, 39);
            this.openBtn.TabIndex = 40;
            this.openBtn.Text = "Tickets Unassigned";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(155, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(380, 18);
            this.label3.TabIndex = 37;
            this.label3.Text = "You don\'t have any trouble ticket assigned closed";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(155, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(325, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "You don\'t have any trouble ticket assigned";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(258, 261);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "No trouble tickets registered";
            this.label1.Visible = false;
            // 
            // profileBtn
            // 
            this.profileBtn.Depth = 0;
            this.profileBtn.Location = new System.Drawing.Point(479, 81);
            this.profileBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.profileBtn.Name = "profileBtn";
            this.profileBtn.Primary = true;
            this.profileBtn.Size = new System.Drawing.Size(121, 28);
            this.profileBtn.TabIndex = 47;
            this.profileBtn.Text = "Main Page";
            this.profileBtn.UseVisualStyleBackColor = true;
            this.profileBtn.Click += new System.EventHandler(this.ProfileBtn_Click);
            // 
            // questionsOpen
            // 
            this.questionsOpen.Depth = 0;
            this.questionsOpen.Location = new System.Drawing.Point(615, 309);
            this.questionsOpen.MouseState = MaterialSkin.MouseState.HOVER;
            this.questionsOpen.Name = "questionsOpen";
            this.questionsOpen.Primary = true;
            this.questionsOpen.Size = new System.Drawing.Size(159, 39);
            this.questionsOpen.TabIndex = 48;
            this.questionsOpen.Text = "My Tickets With Questions Open";
            this.questionsOpen.UseVisualStyleBackColor = true;
            this.questionsOpen.Click += new System.EventHandler(this.QuestionsOpen_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(81, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(476, 18);
            this.label4.TabIndex = 49;
            this.label4.Text = "You don\'t have any tickets with questions waiting for response";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 61;
            this.label5.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(30, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 20);
            this.label6.TabIndex = 60;
            this.label6.Text = "Name";
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.email.Depth = 0;
            this.email.Font = new System.Drawing.Font("Roboto", 11F);
            this.email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.email.Location = new System.Drawing.Point(91, 129);
            this.email.MouseState = MaterialSkin.MouseState.HOVER;
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(46, 19);
            this.email.TabIndex = 59;
            this.email.Text = "email";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.name.Depth = 0;
            this.name.Font = new System.Drawing.Font("Roboto", 11F);
            this.name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.name.Location = new System.Drawing.Point(91, 90);
            this.name.MouseState = MaterialSkin.MouseState.HOVER;
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(46, 19);
            this.name.TabIndex = 58;
            this.name.Text = "name";
            // 
            // Tickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.email);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.questionsOpen);
            this.Controls.Add(this.profileBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.myTicketsBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.openBtn);
            this.Name = "Tickets";
            this.Text = "Tickets";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton logoutBtn;
        private MaterialSkin.Controls.MaterialRaisedButton myTicketsBtn;
        private MaterialSkin.Controls.MaterialRaisedButton closeBtn;
        private MaterialSkin.Controls.MaterialRaisedButton openBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialRaisedButton profileBtn;
        private MaterialSkin.Controls.MaterialRaisedButton questionsOpen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private MaterialSkin.Controls.MaterialLabel email;
        private MaterialSkin.Controls.MaterialLabel name;
    }
}