﻿namespace GUI.Forms
{
    partial class Questions
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
            this.label1 = new System.Windows.Forms.Label();
            this.myTicketsBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.openBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.profileBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.email = new MaterialSkin.Controls.MaterialLabel();
            this.name = new MaterialSkin.Controls.MaterialLabel();
            this.Load += new System.EventHandler(this.Questions_Load);
            this.SuspendLayout();
            // 
            // logoutBtn
            // 
            this.logoutBtn.Depth = 0;
            this.logoutBtn.Location = new System.Drawing.Point(642, 81);
            this.logoutBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Primary = true;
            this.logoutBtn.Size = new System.Drawing.Size(121, 28);
            this.logoutBtn.TabIndex = 46;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.LogoutBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(267, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "No questions registered";
            this.label1.Visible = false;
            // 
            // myTicketsBtn
            // 
            this.myTicketsBtn.Depth = 0;
            this.myTicketsBtn.Location = new System.Drawing.Point(655, 263);
            this.myTicketsBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.myTicketsBtn.Name = "myTicketsBtn";
            this.myTicketsBtn.Primary = true;
            this.myTicketsBtn.Size = new System.Drawing.Size(133, 35);
            this.myTicketsBtn.TabIndex = 48;
            this.myTicketsBtn.Text = "Closed Questions";
            this.myTicketsBtn.UseVisualStyleBackColor = true;
            this.myTicketsBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // openBtn
            // 
            this.openBtn.Depth = 0;
            this.openBtn.Location = new System.Drawing.Point(655, 210);
            this.openBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.openBtn.Name = "openBtn";
            this.openBtn.Primary = true;
            this.openBtn.Size = new System.Drawing.Size(133, 37);
            this.openBtn.TabIndex = 47;
            this.openBtn.Text = "Questions Open";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // profileBtn
            // 
            this.profileBtn.Depth = 0;
            this.profileBtn.Location = new System.Drawing.Point(496, 84);
            this.profileBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.profileBtn.Name = "profileBtn";
            this.profileBtn.Primary = true;
            this.profileBtn.Size = new System.Drawing.Size(121, 28);
            this.profileBtn.TabIndex = 53;
            this.profileBtn.Text = "Main Page";
            this.profileBtn.UseVisualStyleBackColor = true;
            this.profileBtn.Click += new System.EventHandler(this.ProfileBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(226, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "You don\'t have any question closed";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 57;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 56;
            this.label4.Text = "Name";
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.email.Depth = 0;
            this.email.Font = new System.Drawing.Font("Roboto", 11F);
            this.email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.email.Location = new System.Drawing.Point(97, 132);
            this.email.MouseState = MaterialSkin.MouseState.HOVER;
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(46, 19);
            this.email.TabIndex = 55;
            this.email.Text = "email";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.name.Depth = 0;
            this.name.Font = new System.Drawing.Font("Roboto", 11F);
            this.name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.name.Location = new System.Drawing.Point(97, 93);
            this.name.MouseState = MaterialSkin.MouseState.HOVER;
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(46, 19);
            this.name.TabIndex = 54;
            this.name.Text = "name";
            // 
            // Questions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.email);
            this.Controls.Add(this.name);
            this.Controls.Add(this.profileBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.myTicketsBtn);
            this.Controls.Add(this.openBtn);
            this.Name = "Questions";
            this.Text = "My Questions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton logoutBtn;
        private MaterialSkin.Controls.MaterialRaisedButton myTicketsBtn;
        private MaterialSkin.Controls.MaterialRaisedButton openBtn;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialRaisedButton profileBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private MaterialSkin.Controls.MaterialLabel email;
        private MaterialSkin.Controls.MaterialLabel name;
    }
}