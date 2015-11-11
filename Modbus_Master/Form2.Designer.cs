namespace Modbus_Master
{
    partial class Write_0x06
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
            this.textBoxSlaveID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxResponse = new System.Windows.Forms.CheckBox();
            this.labelResponse = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSlaveID
            // 
            this.textBoxSlaveID.Location = new System.Drawing.Point(77, 12);
            this.textBoxSlaveID.Name = "textBoxSlaveID";
            this.textBoxSlaveID.Size = new System.Drawing.Size(56, 21);
            this.textBoxSlaveID.TabIndex = 0;
            this.textBoxSlaveID.TextChanged += new System.EventHandler(this.textBoxSlaveID_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Slave ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Value:";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(77, 37);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(56, 21);
            this.textBoxAddress.TabIndex = 0;
            this.textBoxAddress.TextChanged += new System.EventHandler(this.textBoxAddress_TextChanged);
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(77, 64);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(56, 21);
            this.textBoxValue.TabIndex = 0;
            this.textBoxValue.TextChanged += new System.EventHandler(this.textBoxValue_TextChanged);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(139, 15);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(139, 56);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxResponse);
            this.groupBox1.Controls.Add(this.labelResponse);
            this.groupBox1.Location = new System.Drawing.Point(12, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 67);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Result";
            // 
            // checkBoxResponse
            // 
            this.checkBoxResponse.AutoSize = true;
            this.checkBoxResponse.Location = new System.Drawing.Point(7, 41);
            this.checkBoxResponse.Name = "checkBoxResponse";
            this.checkBoxResponse.Size = new System.Drawing.Size(199, 16);
            this.checkBoxResponse.TabIndex = 2;
            this.checkBoxResponse.Text = "Close dialog on \"Response ok\"";
            this.checkBoxResponse.UseVisualStyleBackColor = true;
            // 
            // labelResponse
            // 
            this.labelResponse.AutoSize = true;
            this.labelResponse.Location = new System.Drawing.Point(6, 17);
            this.labelResponse.Name = "labelResponse";
            this.labelResponse.Size = new System.Drawing.Size(75, 12);
            this.labelResponse.TabIndex = 1;
            this.labelResponse.Text = "Result : N/A";
            // 
            // Write_0x06
            // 
            this.AcceptButton = this.buttonSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(233, 171);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxValue);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.textBoxSlaveID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Write_0x06";
            this.Opacity = 0.9D;
            this.Text = "Write Single Register";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSlaveID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxResponse;
        private System.Windows.Forms.Label labelResponse;
    }
}