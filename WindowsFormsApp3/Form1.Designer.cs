namespace ValidationApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Button btnSendResult;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Label lblSeparator;
        private System.Windows.Forms.Label lblPhoneLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.btnSendResult = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblPhoneLabel = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.lblSeparator = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 0, 139);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(194, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Валидация данных";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblPhoneLabel
            this.lblPhoneLabel.AutoSize = true;
            this.lblPhoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPhoneLabel.Location = new System.Drawing.Point(20, 60);
            this.lblPhoneLabel.Name = "lblPhoneLabel";
            this.lblPhoneLabel.Size = new System.Drawing.Size(126, 17);
            this.lblPhoneLabel.TabIndex = 1;
            this.lblPhoneLabel.Text = "Номер телефона:";

            // txtPhoneNumber
            this.txtPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtPhoneNumber.Location = new System.Drawing.Point(152, 56);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(280, 29);
            this.txtPhoneNumber.TabIndex = 2;
            this.txtPhoneNumber.ReadOnly = true;
            this.txtPhoneNumber.BackColor = System.Drawing.Color.White;
            this.txtPhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // btnGetData
            this.btnGetData.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnGetData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnGetData.ForeColor = System.Drawing.Color.White;
            this.btnGetData.Location = new System.Drawing.Point(152, 110);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(130, 40);
            this.btnGetData.TabIndex = 3;
            this.btnGetData.Text = "Получить данные";
            this.btnGetData.UseVisualStyleBackColor = false;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);

            // btnSendResult
            this.btnSendResult.BackColor = System.Drawing.Color.FromArgb(0, 175, 80);
            this.btnSendResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSendResult.ForeColor = System.Drawing.Color.White;
            this.btnSendResult.Location = new System.Drawing.Point(302, 110);
            this.btnSendResult.Name = "btnSendResult";
            this.btnSendResult.Size = new System.Drawing.Size(130, 40);
            this.btnSendResult.TabIndex = 4;
            this.btnSendResult.Text = "Отправить результат теста";
            this.btnSendResult.UseVisualStyleBackColor = false;
            this.btnSendResult.Click += new System.EventHandler(this.btnSendResult_Click);

            // lblResult
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblResult.Location = new System.Drawing.Point(20, 190);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(178, 18);
            this.lblResult.TabIndex = 5;
            this.lblResult.Text = "Ожидание загрузки...";
            this.lblResult.ForeColor = System.Drawing.Color.Gray;

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblStatus.Location = new System.Drawing.Point(20, 225);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(126, 15);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Готов к работе";
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;

            // panelMain
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.lblPhoneLabel);
            this.panelMain.Controls.Add(this.txtPhoneNumber);
            this.panelMain.Controls.Add(this.btnGetData);
            this.panelMain.Controls.Add(this.btnSendResult);
            this.panelMain.Controls.Add(this.lblResult);
            this.panelMain.Controls.Add(this.lblStatus);
            this.panelMain.Location = new System.Drawing.Point(12, 40);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(470, 260);
            this.panelMain.TabIndex = 7;

            // lblSeparator
            this.lblSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSeparator.Location = new System.Drawing.Point(12, 32);
            this.lblSeparator.Name = "lblSeparator";
            this.lblSeparator.Size = new System.Drawing.Size(470, 2);
            this.lblSeparator.TabIndex = 8;

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.ClientSize = new System.Drawing.Size(494, 315);
            this.Controls.Add(this.lblSeparator);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Валидация данных";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}