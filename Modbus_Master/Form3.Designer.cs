namespace Modbus_Master
{
    partial class ChangeAddress
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSlaveID = new System.Windows.Forms.TextBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.buttonSetting = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Slave ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Quantity:";
            // 
            // textBoxSlaveID
            // 
            this.textBoxSlaveID.Location = new System.Drawing.Point(73, 6);
            this.textBoxSlaveID.Name = "textBoxSlaveID";
            this.textBoxSlaveID.Size = new System.Drawing.Size(58, 21);
            this.textBoxSlaveID.TabIndex = 1;
            this.textBoxSlaveID.TextChanged += new System.EventHandler(this.textBoxSlaveID_TextChanged);
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(73, 31);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(58, 21);
            this.textBoxAddress.TabIndex = 1;
            this.textBoxAddress.TextChanged += new System.EventHandler(this.textBoxAddress_TextChanged);
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(73, 56);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(58, 21);
            this.textBoxQuantity.TabIndex = 1;
            this.textBoxQuantity.TextChanged += new System.EventHandler(this.textBoxQuantity_TextChanged);
            // 
            // buttonSetting
            // 
            this.buttonSetting.Location = new System.Drawing.Point(14, 83);
            this.buttonSetting.Name = "buttonSetting";
            this.buttonSetting.Size = new System.Drawing.Size(54, 23);
            this.buttonSetting.TabIndex = 2;
            this.buttonSetting.Text = "Setting";
            this.buttonSetting.UseVisualStyleBackColor = true;
            this.buttonSetting.Click += new System.EventHandler(this.buttonSetting_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(77, 83);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(54, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // ChangeAddress
            // 
            this.AcceptButton = this.buttonSetting;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(139, 116);
            this.ControlBox = false;
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSetting);
            this.Controls.Add(this.textBoxQuantity);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.textBoxSlaveID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ChangeAddress";
            this.Opacity = 0.9D;
            this.ShowInTaskbar = false;
            this.Text = "Change Address";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSlaveID;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Button buttonSetting;
        private System.Windows.Forms.Button buttonClose;
    }
}