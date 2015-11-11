namespace Modbus_Master
{
    partial class Write_0x10
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
            this.textBoxAddr = new System.Windows.Forms.TextBox();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.listBoxAddress = new System.Windows.Forms.ListBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "SlaveID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Quantity:";
            // 
            // textBoxSlaveID
            // 
            this.textBoxSlaveID.Location = new System.Drawing.Point(56, 6);
            this.textBoxSlaveID.Name = "textBoxSlaveID";
            this.textBoxSlaveID.Size = new System.Drawing.Size(100, 21);
            this.textBoxSlaveID.TabIndex = 1;
            this.textBoxSlaveID.TextChanged += new System.EventHandler(this.textBoxSlaveID_TextChanged);
            // 
            // textBoxAddr
            // 
            this.textBoxAddr.Location = new System.Drawing.Point(56, 42);
            this.textBoxAddr.Name = "textBoxAddr";
            this.textBoxAddr.Size = new System.Drawing.Size(100, 21);
            this.textBoxAddr.TabIndex = 1;
            this.textBoxAddr.TextChanged += new System.EventHandler(this.textBoxAddr_TextChanged);
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(56, 79);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(100, 21);
            this.textBoxQuantity.TabIndex = 1;
            this.textBoxQuantity.TextChanged += new System.EventHandler(this.textBoxQuantity_TextChanged);
            // 
            // listBoxAddress
            // 
            this.listBoxAddress.FormattingEnabled = true;
            this.listBoxAddress.ItemHeight = 12;
            this.listBoxAddress.Location = new System.Drawing.Point(162, 6);
            this.listBoxAddress.Name = "listBoxAddress";
            this.listBoxAddress.Size = new System.Drawing.Size(165, 208);
            this.listBoxAddress.TabIndex = 2;
            this.listBoxAddress.DoubleClick += new System.EventHandler(this.listBoxAddress_DoubleClick);
            this.listBoxAddress.Enter += new System.EventHandler(this.listBoxAddress_Enter);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(333, 4);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 3;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(333, 40);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(333, 77);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // Write_0x10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(417, 217);
            this.ControlBox = false;
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.listBoxAddress);
            this.Controls.Add(this.textBoxQuantity);
            this.Controls.Add(this.textBoxAddr);
            this.Controls.Add(this.textBoxSlaveID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Write_0x10";
            this.Text = "Write Multi Single";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSlaveID;
        private System.Windows.Forms.TextBox textBoxAddr;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.ListBox listBoxAddress;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonEdit;
    }
}