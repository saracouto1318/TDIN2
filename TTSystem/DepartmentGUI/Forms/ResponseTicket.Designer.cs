namespace DepartmentGUI
{
    partial class ResponseTicket
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
            this.message = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sendBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.ticketID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // message
            // 
            this.message.Location = new System.Drawing.Point(87, 228);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(624, 162);
            this.message.TabIndex = 34;
            this.message.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(82, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 25);
            this.label3.TabIndex = 41;
            this.label3.Text = "Message";
            // 
            // sendBtn
            // 
            this.sendBtn.Depth = 0;
            this.sendBtn.Location = new System.Drawing.Point(333, 398);
            this.sendBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Primary = true;
            this.sendBtn.Size = new System.Drawing.Size(121, 40);
            this.sendBtn.TabIndex = 40;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.SendBtn_Click);
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
            // ResponseTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.ticketID);
            this.Controls.Add(this.message);
            this.Name = "ResponseTicket";
            this.Text = "Response Ticket";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox message;
        private System.Windows.Forms.Label label3;
        private MaterialSkin.Controls.MaterialRaisedButton sendBtn;
        private System.Windows.Forms.Label ticketID;
    }
}