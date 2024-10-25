namespace form_app {
    partial class CreatePacket {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreatePacket));
            this.label1 = new System.Windows.Forms.Label();
            this.choose_packet_type_cb = new System.Windows.Forms.ComboBox();
            this.panel_show_details = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(119, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create packet";
            // 
            // choose_packet_type_cb
            // 
            this.choose_packet_type_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.choose_packet_type_cb.FormattingEnabled = true;
            this.choose_packet_type_cb.Location = new System.Drawing.Point(125, 76);
            this.choose_packet_type_cb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.choose_packet_type_cb.Name = "choose_packet_type_cb";
            this.choose_packet_type_cb.Size = new System.Drawing.Size(206, 21);
            this.choose_packet_type_cb.TabIndex = 1;
            this.choose_packet_type_cb.SelectedValueChanged += new System.EventHandler(this.parse_cb_change);
            // 
            // panel_show_details
            // 
            this.panel_show_details.Location = new System.Drawing.Point(125, 109);
            this.panel_show_details.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel_show_details.Name = "panel_show_details";
            this.panel_show_details.Size = new System.Drawing.Size(205, 193);
            this.panel_show_details.TabIndex = 2;
            // 
            // CreatePacket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 390);
            this.Controls.Add(this.panel_show_details);
            this.Controls.Add(this.choose_packet_type_cb);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreatePacket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreatePacket";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox choose_packet_type_cb;
        private System.Windows.Forms.FlowLayoutPanel panel_show_details;
    }
}