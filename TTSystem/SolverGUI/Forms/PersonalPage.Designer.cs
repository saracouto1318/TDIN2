﻿namespace SolverGUI
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new MaterialSkin.Controls.MaterialLabel();
            this.tabControl = new System.Windows.Forms.TabPage();
            this.label1 = new MaterialSkin.Controls.MaterialLabel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label3 = new MaterialSkin.Controls.MaterialLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.name = new MaterialSkin.Controls.MaterialLabel();
            this.email = new MaterialSkin.Controls.MaterialLabel();
            this.logoutBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.closeBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.openBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.myTicketsBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.tabPage2.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(607, 246);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "My Trouble Tickets";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Depth = 0;
            this.label2.Font = new System.Drawing.Font("Roboto", 11F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(160, 117);
            this.label2.MouseState = MaterialSkin.MouseState.HOVER;
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(291, 19);
            this.label2.TabIndex = 36;
            this.label2.Text = "You don\'t have any trouble ticket assigned";
            this.label2.Visible = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.label1);
            this.tabControl.Location = new System.Drawing.Point(4, 27);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Windows.Forms.Padding(3);
            this.tabControl.Size = new System.Drawing.Size(607, 246);
            this.tabControl.TabIndex = 0;
            this.tabControl.Text = "Trouble Tickets";
            this.tabControl.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Depth = 0;
            this.label1.Font = new System.Drawing.Font("Roboto", 11F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(203, 108);
            this.label1.MouseState = MaterialSkin.MouseState.HOVER;
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "No trouble tickets registered";
            this.label1.Visible = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(607, 246);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "My Closed Trouble Tickets";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Depth = 0;
            this.label3.Font = new System.Drawing.Font("Roboto", 11F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(163, 108);
            this.label3.MouseState = MaterialSkin.MouseState.HOVER;
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(291, 19);
            this.label3.TabIndex = 37;
            this.label3.Text = "You don\'t have any trouble ticket assigned";
            this.label3.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabControl);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(40, 161);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(615, 277);
            this.tabControl1.TabIndex = 7;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.name.Depth = 0;
            this.name.Font = new System.Drawing.Font("Roboto", 11F);
            this.name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.name.Location = new System.Drawing.Point(49, 80);
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
            this.email.Location = new System.Drawing.Point(49, 115);
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
            // closeBtn
            // 
            this.closeBtn.Depth = 0;
            this.closeBtn.Location = new System.Drawing.Point(667, 330);
            this.closeBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Primary = true;
            this.closeBtn.Size = new System.Drawing.Size(121, 28);
            this.closeBtn.TabIndex = 34;
            this.closeBtn.Text = "Tickets Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // openBtn
            // 
            this.openBtn.Depth = 0;
            this.openBtn.Location = new System.Drawing.Point(667, 244);
            this.openBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.openBtn.Name = "openBtn";
            this.openBtn.Primary = true;
            this.openBtn.Size = new System.Drawing.Size(121, 28);
            this.openBtn.TabIndex = 33;
            this.openBtn.Text = "Tickets Open";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // myTicketsBtn
            // 
            this.myTicketsBtn.Depth = 0;
            this.myTicketsBtn.Location = new System.Drawing.Point(667, 287);
            this.myTicketsBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.myTicketsBtn.Name = "myTicketsBtn";
            this.myTicketsBtn.Primary = true;
            this.myTicketsBtn.Size = new System.Drawing.Size(121, 28);
            this.myTicketsBtn.TabIndex = 35;
            this.myTicketsBtn.Text = "My Tickets";
            this.myTicketsBtn.UseVisualStyleBackColor = true;
            this.myTicketsBtn.Click += new System.EventHandler(this.MyTicketsBtn_Click);
            // 
            // PersonalPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.myTicketsBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.email);
            this.Controls.Add(this.name);
            this.Controls.Add(this.tabControl1);
            this.Name = "PersonalPage";
            this.Text = "Personal Page";
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabControl.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabControl;
        private System.Windows.Forms.TabControl tabControl1;
        private MaterialSkin.Controls.MaterialLabel name;
        private MaterialSkin.Controls.MaterialLabel email;
        private MaterialSkin.Controls.MaterialRaisedButton logoutBtn;
        private MaterialSkin.Controls.MaterialRaisedButton closeBtn;
        private MaterialSkin.Controls.MaterialRaisedButton openBtn;
        private MaterialSkin.Controls.MaterialRaisedButton myTicketsBtn;
        private MaterialSkin.Controls.MaterialLabel label1;
        private MaterialSkin.Controls.MaterialLabel label2;
        private MaterialSkin.Controls.MaterialLabel label3;
    }
}