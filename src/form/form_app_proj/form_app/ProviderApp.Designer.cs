using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;

namespace form_app {
    partial class ProviderApp {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProviderApp));
            this.panelClients = new System.Windows.Forms.FlowLayoutPanel();
            this.label_clients = new System.Windows.Forms.Label();
            this.panelTVPackets = new System.Windows.Forms.FlowLayoutPanel();
            this.panelInternetPackets = new System.Windows.Forms.FlowLayoutPanel();
            this.panelCombinedPackets = new System.Windows.Forms.FlowLayoutPanel();
            this.label_tv_packets = new System.Windows.Forms.Label();
            this.label_internet_packets = new System.Windows.Forms.Label();
            this.label_comb_packets = new System.Windows.Forms.Label();
            this.button_register_client = new System.Windows.Forms.Button();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.providerName = new System.Windows.Forms.Label();
            this.filter_clients_tb = new System.Windows.Forms.TextBox();
            this.filter_clients_label = new System.Windows.Forms.Label();
            this.button_create_packet = new System.Windows.Forms.Button();
            this.btnDeactivate = new System.Windows.Forms.Button();
            this.btnActivate = new System.Windows.Forms.Button();
            this.picRedo = new System.Windows.Forms.PictureBox();
            this.picUndo = new System.Windows.Forms.PictureBox();
            this.label_undo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRedo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUndo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelClients
            // 
            this.panelClients.AutoScroll = true;
            this.panelClients.Location = new System.Drawing.Point(27, 128);
            this.panelClients.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelClients.Name = "panelClients";
            this.panelClients.Size = new System.Drawing.Size(215, 293);
            this.panelClients.TabIndex = 8;
            // 
            // label_clients
            // 
            this.label_clients.AutoSize = true;
            this.label_clients.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_clients.Location = new System.Drawing.Point(23, 103);
            this.label_clients.Name = "label_clients";
            this.label_clients.Size = new System.Drawing.Size(72, 25);
            this.label_clients.TabIndex = 9;
            this.label_clients.Text = "Clients";
            // 
            // panelTVPackets
            // 
            this.panelTVPackets.AutoScroll = true;
            this.panelTVPackets.Location = new System.Drawing.Point(273, 128);
            this.panelTVPackets.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelTVPackets.Name = "panelTVPackets";
            this.panelTVPackets.Size = new System.Drawing.Size(251, 187);
            this.panelTVPackets.TabIndex = 10;
            // 
            // panelInternetPackets
            // 
            this.panelInternetPackets.AutoScroll = true;
            this.panelInternetPackets.Location = new System.Drawing.Point(532, 128);
            this.panelInternetPackets.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelInternetPackets.Name = "panelInternetPackets";
            this.panelInternetPackets.Size = new System.Drawing.Size(251, 187);
            this.panelInternetPackets.TabIndex = 11;
            // 
            // panelCombinedPackets
            // 
            this.panelCombinedPackets.AutoScroll = true;
            this.panelCombinedPackets.Location = new System.Drawing.Point(792, 128);
            this.panelCombinedPackets.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelCombinedPackets.Name = "panelCombinedPackets";
            this.panelCombinedPackets.Size = new System.Drawing.Size(245, 187);
            this.panelCombinedPackets.TabIndex = 12;
            // 
            // label_tv_packets
            // 
            this.label_tv_packets.AutoSize = true;
            this.label_tv_packets.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_tv_packets.Location = new System.Drawing.Point(269, 103);
            this.label_tv_packets.Name = "label_tv_packets";
            this.label_tv_packets.Size = new System.Drawing.Size(114, 25);
            this.label_tv_packets.TabIndex = 13;
            this.label_tv_packets.Text = "TV Packets";
            // 
            // label_internet_packets
            // 
            this.label_internet_packets.AutoSize = true;
            this.label_internet_packets.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_internet_packets.Location = new System.Drawing.Point(529, 103);
            this.label_internet_packets.Name = "label_internet_packets";
            this.label_internet_packets.Size = new System.Drawing.Size(150, 25);
            this.label_internet_packets.TabIndex = 14;
            this.label_internet_packets.Text = "Internet packets";
            // 
            // label_comb_packets
            // 
            this.label_comb_packets.AutoSize = true;
            this.label_comb_packets.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_comb_packets.Location = new System.Drawing.Point(789, 103);
            this.label_comb_packets.Name = "label_comb_packets";
            this.label_comb_packets.Size = new System.Drawing.Size(175, 25);
            this.label_comb_packets.TabIndex = 15;
            this.label_comb_packets.Text = "Combined packets";
            // 
            // button_register_client
            // 
            this.button_register_client.Location = new System.Drawing.Point(273, 348);
            this.button_register_client.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_register_client.Name = "button_register_client";
            this.button_register_client.Size = new System.Drawing.Size(148, 41);
            this.button_register_client.TabIndex = 16;
            this.button_register_client.Text = "Register client";
            this.button_register_client.UseVisualStyleBackColor = true;
            this.button_register_client.Click += new System.EventHandler(this.button_register_client_Click);
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.providerName);
            this.headerPanel.Location = new System.Drawing.Point(27, 12);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1012, 71);
            this.headerPanel.TabIndex = 17;
            // 
            // providerName
            // 
            this.providerName.AutoSize = true;
            this.providerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.providerName.Location = new System.Drawing.Point(3, 16);
            this.providerName.Name = "providerName";
            this.providerName.Size = new System.Drawing.Size(0, 38);
            this.providerName.TabIndex = 0;
            // 
            // filter_clients_tb
            // 
            this.filter_clients_tb.Location = new System.Drawing.Point(112, 442);
            this.filter_clients_tb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filter_clients_tb.Name = "filter_clients_tb";
            this.filter_clients_tb.Size = new System.Drawing.Size(129, 22);
            this.filter_clients_tb.TabIndex = 18;
            this.filter_clients_tb.KeyUp += new System.Windows.Forms.KeyEventHandler(this.parse_keyup_filter_clients);
            // 
            // filter_clients_label
            // 
            this.filter_clients_label.AutoSize = true;
            this.filter_clients_label.Location = new System.Drawing.Point(25, 446);
            this.filter_clients_label.Name = "filter_clients_label";
            this.filter_clients_label.Size = new System.Drawing.Size(80, 16);
            this.filter_clients_label.TabIndex = 19;
            this.filter_clients_label.Text = "Filter clients:";
            // 
            // button_create_packet
            // 
            this.button_create_packet.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_create_packet.Location = new System.Drawing.Point(427, 348);
            this.button_create_packet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_create_packet.Name = "button_create_packet";
            this.button_create_packet.Size = new System.Drawing.Size(148, 41);
            this.button_create_packet.TabIndex = 20;
            this.button_create_packet.Text = "Create packet";
            this.button_create_packet.UseVisualStyleBackColor = true;
            this.button_create_packet.Click += new System.EventHandler(this.button_create_packet_Click);
            // 
            // btnDeactivate
            // 
            this.btnDeactivate.BackColor = System.Drawing.SystemColors.Info;
            this.btnDeactivate.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDeactivate.Location = new System.Drawing.Point(581, 348);
            this.btnDeactivate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeactivate.Name = "btnDeactivate";
            this.btnDeactivate.Size = new System.Drawing.Size(148, 41);
            this.btnDeactivate.TabIndex = 23;
            this.btnDeactivate.Text = "Deactivate packet";
            this.btnDeactivate.UseVisualStyleBackColor = false;
            this.btnDeactivate.Visible = false;
            // 
            // btnActivate
            // 
            this.btnActivate.BackColor = System.Drawing.SystemColors.Info;
            this.btnActivate.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnActivate.Location = new System.Drawing.Point(581, 348);
            this.btnActivate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnActivate.Size = new System.Drawing.Size(148, 41);
            this.btnActivate.TabIndex = 24;
            this.btnActivate.Text = "Activate packet";
            this.btnActivate.UseVisualStyleBackColor = false;
            this.btnActivate.Visible = false;
            // 
            // picRedo
            // 
            this.picRedo.Image = global::form_app.Properties.Resources.redo_img_small;
            this.picRedo.InitialImage = global::form_app.Properties.Resources.redo_img_small;
            this.picRedo.Location = new System.Drawing.Point(945, 348);
            this.picRedo.Name = "picRedo";
            this.picRedo.Size = new System.Drawing.Size(54, 41);
            this.picRedo.TabIndex = 26;
            this.picRedo.TabStop = false;
            this.picRedo.Click += new System.EventHandler(this.picRedo_Click);
            // 
            // picUndo
            // 
            this.picUndo.Image = global::form_app.Properties.Resources.undo_img_small;
            this.picUndo.InitialImage = ((System.Drawing.Image)(resources.GetObject("picUndo.InitialImage")));
            this.picUndo.Location = new System.Drawing.Point(872, 348);
            this.picUndo.Name = "picUndo";
            this.picUndo.Size = new System.Drawing.Size(43, 41);
            this.picUndo.TabIndex = 25;
            this.picUndo.TabStop = false;
            this.picUndo.Click += new System.EventHandler(this.picUndo_Click);
            // 
            // label_undo
            // 
            this.label_undo.AutoSize = true;
            this.label_undo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_undo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label_undo.Location = new System.Drawing.Point(864, 404);
            this.label_undo.Name = "label_undo";
            this.label_undo.Size = new System.Drawing.Size(50, 13);
            this.label_undo.TabIndex = 27;
            this.label_undo.Text = "CTRL + Z";
            this.label_undo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(944, 404);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "CTRL + Y";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProviderApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 480);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_undo);
            this.Controls.Add(this.picRedo);
            this.Controls.Add(this.picUndo);
            this.Controls.Add(this.btnActivate);
            this.Controls.Add(this.btnDeactivate);
            this.Controls.Add(this.button_create_packet);
            this.Controls.Add(this.filter_clients_label);
            this.Controls.Add(this.filter_clients_tb);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.button_register_client);
            this.Controls.Add(this.label_comb_packets);
            this.Controls.Add(this.panelCombinedPackets);
            this.Controls.Add(this.label_internet_packets);
            this.Controls.Add(this.label_tv_packets);
            this.Controls.Add(this.panelInternetPackets);
            this.Controls.Add(this.panelTVPackets);
            this.Controls.Add(this.label_clients);
            this.Controls.Add(this.panelClients);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProviderApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TIM1 Provider App";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRedo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUndo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void BtnDeactivate_Click(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        #endregion
        private FlowLayoutPanel panelClients;
        private Label label_clients;
        private FlowLayoutPanel panelTVPackets;
        private FlowLayoutPanel panelInternetPackets;
        private FlowLayoutPanel panelCombinedPackets;
        private Label label_tv_packets;
        private Label label_internet_packets;
        private Label label_comb_packets;
        private Button button_register_client;
        private Panel headerPanel;
        private Label providerName;
        private TextBox filter_clients_tb;
        private Label filter_clients_label;
        private Button button_create_packet;
        private Button button1;
        private Button btnDeactivate;
        private Button btnActivate;
        private PictureBox picUndo;
        private PictureBox picRedo;
        private Label label_undo;
        private Label label1;
    }
}

