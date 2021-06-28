
namespace CryptoCurrencyMonitor.WinFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_get_data = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.editor_address = new System.Windows.Forms.TextBox();
            this.label_quantity = new System.Windows.Forms.Label();
            this.label_delta_quantity = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_timestamp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_get_data
            // 
            this.button_get_data.Location = new System.Drawing.Point(96, 127);
            this.button_get_data.Name = "button_get_data";
            this.button_get_data.Size = new System.Drawing.Size(108, 43);
            this.button_get_data.TabIndex = 0;
            this.button_get_data.Text = "Get Data";
            this.button_get_data.UseVisualStyleBackColor = true;
            this.button_get_data.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(221, 127);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 43);
            this.button2.TabIndex = 1;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Quantity:";
            // 
            // editor_address
            // 
            this.editor_address.Location = new System.Drawing.Point(87, 29);
            this.editor_address.Name = "editor_address";
            this.editor_address.Size = new System.Drawing.Size(316, 23);
            this.editor_address.TabIndex = 4;
            // 
            // label_quantity
            // 
            this.label_quantity.AutoSize = true;
            this.label_quantity.Location = new System.Drawing.Point(87, 65);
            this.label_quantity.Name = "label_quantity";
            this.label_quantity.Size = new System.Drawing.Size(0, 17);
            this.label_quantity.TabIndex = 5;
            // 
            // label_delta_quantity
            // 
            this.label_delta_quantity.AutoSize = true;
            this.label_delta_quantity.Location = new System.Drawing.Point(172, 65);
            this.label_delta_quantity.Name = "label_delta_quantity";
            this.label_delta_quantity.Size = new System.Drawing.Size(0, 17);
            this.label_delta_quantity.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Timestamp:";
            // 
            // label_timestamp
            // 
            this.label_timestamp.AutoSize = true;
            this.label_timestamp.Location = new System.Drawing.Point(97, 100);
            this.label_timestamp.Name = "label_timestamp";
            this.label_timestamp.Size = new System.Drawing.Size(0, 17);
            this.label_timestamp.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 193);
            this.Controls.Add(this.label_timestamp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_delta_quantity);
            this.Controls.Add(this.label_quantity);
            this.Controls.Add(this.editor_address);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_get_data);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_get_data;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox editor_address;
        private System.Windows.Forms.Label label_quantity;
        private System.Windows.Forms.Label label_delta_quantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_timestamp;
    }
}

