namespace Modbus_Slave
{
    partial class Form3
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
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSetting = new System.Windows.Forms.Button();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxSlaveID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(77, 84);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(54, 23);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonSetting
            // 
            this.buttonSetting.Location = new System.Drawing.Point(14, 84);
            this.buttonSetting.Name = "buttonSetting";
            this.buttonSetting.Size = new System.Drawing.Size(54, 23);
            this.buttonSetting.TabIndex = 10;
            this.buttonSetting.Text = "Setting";
            this.buttonSetting.UseVisualStyleBackColor = true;
            this.buttonSetting.Click += new System.EventHandler(this.buttonSetting_Click);
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(73, 57);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(58, 21);
            this.textBoxQuantity.TabIndex = 6;
            this.textBoxQuantity.TextChanged += new System.EventHandler(this.textBoxQuantity_TextChanged);
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(73, 32);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(58, 21);
            this.textBoxAddress.TabIndex = 7;
            this.textBoxAddress.TextChanged += new System.EventHandler(this.textBoxAddress_TextChanged);
            // 
            // textBoxSlaveID
            // 
            this.textBoxSlaveID.Location = new System.Drawing.Point(73, 7);
            this.textBoxSlaveID.Name = "textBoxSlaveID";
            this.textBoxSlaveID.Size = new System.Drawing.Size(58, 21);
            this.textBoxSlaveID.TabIndex = 8;
            this.textBoxSlaveID.TextChanged += new System.EventHandler(this.textBoxSlaveID_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Quantity:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Address:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Slave ID:";
            // 
            // Form3
            // 
            this.AcceptButton = this.buttonSetting;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(142, 113);
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
            this.Name = "Form3";
            this.Opacity = 0.9D;
            this.ShowInTaskbar = false;
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonSetting;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.TextBox textBoxSlaveID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}