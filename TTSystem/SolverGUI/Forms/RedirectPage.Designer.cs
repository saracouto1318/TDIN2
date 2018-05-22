namespace SolverGUI
{
    partial class RedirectPage
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.message = new System.Windows.Forms.RichTextBox();
            this.profileBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.logoutBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.ticketBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.ticketLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.title = new MaterialSkin.Controls.MaterialLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.redirectBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.departments = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // message
            // 
            this.message.Location = new System.Drawing.Point(84, 305);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(624, 162);
            this.message.TabIndex = 14;
            this.message.Text = "";
            // 
            // profileBtn
            // 
            this.profileBtn.Depth = 0;
            this.profileBtn.Location = new System.Drawing.Point(498, 95);
            this.profileBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.profileBtn.Name = "profileBtn";
            this.profileBtn.Primary = true;
            this.profileBtn.Size = new System.Drawing.Size(121, 28);
            this.profileBtn.TabIndex = 32;
            this.profileBtn.Text = "Main Page";
            this.profileBtn.UseVisualStyleBackColor = true;
            this.profileBtn.Click += new System.EventHandler(this.ProfileBtn_Click);
            // 
            // logoutBtn
            // 
            this.logoutBtn.Depth = 0;
            this.logoutBtn.Location = new System.Drawing.Point(642, 95);
            this.logoutBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Primary = true;
            this.logoutBtn.Size = new System.Drawing.Size(121, 28);
            this.logoutBtn.TabIndex = 31;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.LogoutBtn_Click);
            // 
            // ticketBtn
            // 
            this.ticketBtn.Depth = 0;
            this.ticketBtn.Location = new System.Drawing.Point(350, 95);
            this.ticketBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.ticketBtn.Name = "ticketBtn";
            this.ticketBtn.Primary = true;
            this.ticketBtn.Size = new System.Drawing.Size(121, 28);
            this.ticketBtn.TabIndex = 34;
            this.ticketBtn.Text = "Ticket Page";
            this.ticketBtn.UseVisualStyleBackColor = true;
            this.ticketBtn.Click += new System.EventHandler(this.TicketBtn_Click);
            // 
            // ticketLabel
            // 
            this.ticketLabel.AutoSize = true;
            this.ticketLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ticketLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ticketLabel.Location = new System.Drawing.Point(29, 91);
            this.ticketLabel.Name = "ticketLabel";
            this.ticketLabel.Size = new System.Drawing.Size(117, 29);
            this.ticketLabel.TabIndex = 33;
            this.ticketLabel.Text = "Ticket ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(79, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 25);
            this.label3.TabIndex = 37;
            this.label3.Text = "Message";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.title.Depth = 0;
            this.title.Font = new System.Drawing.Font("Roboto", 11F);
            this.title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.title.Location = new System.Drawing.Point(102, 144);
            this.title.MouseState = MaterialSkin.MouseState.HOVER;
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(35, 19);
            this.title.TabIndex = 36;
            this.title.Text = "title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 25);
            this.label2.TabIndex = 35;
            this.label2.Text = "Title";
            // 
            // redirectBtn
            // 
            this.redirectBtn.Depth = 0;
            this.redirectBtn.Location = new System.Drawing.Point(350, 492);
            this.redirectBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.redirectBtn.Name = "redirectBtn";
            this.redirectBtn.Primary = true;
            this.redirectBtn.Size = new System.Drawing.Size(121, 40);
            this.redirectBtn.TabIndex = 38;
            this.redirectBtn.Text = "Redirect";
            this.redirectBtn.UseVisualStyleBackColor = true;
            this.redirectBtn.Click += new System.EventHandler(this.RedirectBtn_Click);
            // 
            // departments
            // 
            this.departments.BackColor = System.Drawing.SystemColors.Window;
            this.departments.FormattingEnabled = true;
            this.departments.Location = new System.Drawing.Point(183, 192);
            this.departments.Name = "departments";
            this.departments.Size = new System.Drawing.Size(121, 21);
            this.departments.TabIndex = 39;
            this.departments.SelectedIndexChanged += new System.EventHandler(this.Departments_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 25);
            this.label1.TabIndex = 40;
            this.label1.Text = "Department";
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(328, 192);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(153, 20);
            this.textBox.TabIndex = 41;
            this.textBox.Text = "Other Department";
            this.textBox.Visible = false;
            // 
            // RedirectPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 544);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.departments);
            this.Controls.Add(this.redirectBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.title);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ticketBtn);
            this.Controls.Add(this.ticketLabel);
            this.Controls.Add(this.profileBtn);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.message);
            this.Name = "RedirectPage";
            this.Text = "Redirect Page";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RichTextBox message;
        private MaterialSkin.Controls.MaterialRaisedButton profileBtn;
        private MaterialSkin.Controls.MaterialRaisedButton logoutBtn;
        private MaterialSkin.Controls.MaterialRaisedButton ticketBtn;
        private System.Windows.Forms.Label ticketLabel;
        private System.Windows.Forms.Label label3;
        private MaterialSkin.Controls.MaterialLabel title;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialRaisedButton redirectBtn;
        private System.Windows.Forms.ComboBox departments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox;
    }
}