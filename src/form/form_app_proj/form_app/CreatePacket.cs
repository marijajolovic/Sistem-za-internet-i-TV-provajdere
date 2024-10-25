using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using library.AppLogic;
using library.AppLogic.Interfaces;

namespace form_app {
    public partial class CreatePacket : Form {

        private IAppLogicFacade _appLogic = null;

        public CreatePacket(IAppLogicFacade aLogic) {
            InitializeComponent();
            _appLogic = aLogic;
            close_on_esc();
            fill_cb_packet_types();
        }

        private void close_on_esc()
        {
            this.KeyPreview = true;
            this.KeyDown += CreatePacket_KeyDown;
        }

        private void fill_cb_packet_types() {
            this.choose_packet_type_cb.Items.Clear();
            this.choose_packet_type_cb.Items.Add("Internet packet");
            this.choose_packet_type_cb.Items.Add("TV packet");
            this.choose_packet_type_cb.Items.Add("Combined packet");
        }

        private void parse_cb_change(object sender, EventArgs e) {
            ComboBox comboBox = (ComboBox)sender;
            object selectedValue = comboBox.SelectedItem;
            string selectedText = null;

            if (selectedValue != null) {
                selectedText = selectedValue.ToString();
            }

            switch (selectedText) {
                case "Internet packet":
                    show_internet_packet_creation_dialog();
                    break;

                case "TV packet":
                    show_tv_packet_creation_dialog();
                    break;

                case "Combined packet":
                    show_combined_packet_creation_dialog();
                    break;

                default:
                    break;
            }
        }

        private void show_internet_packet_creation_dialog() {

            panel_show_details.Controls.Clear();

            TextBox packetName = new TextBox();
            NumericUpDown packetPrice = new NumericUpDown();                
            NumericUpDown downloadSpeed = new NumericUpDown();  
            NumericUpDown uploadSpeed = new NumericUpDown();    

            packetPrice.Minimum = 0;
            packetPrice.Maximum = 20000;
            packetPrice.DecimalPlaces = 2;

            downloadSpeed.Maximum = 1000;
            uploadSpeed.Maximum = 1000;

            panel_show_details.Tag = "internetPacket";
            packetName.Tag = "packetName";
            packetPrice.Tag = "packetPrice";
            downloadSpeed.Tag = "downloadSpeed";
            uploadSpeed.Tag = "uploadSpeed";

            Label name = new Label();
            name.Text = "Name";
            name.AutoSize = false;
            name.Width = 50;
            name.TextAlign = ContentAlignment.MiddleLeft;

            Label price = new Label();
            price.Text = "Price";
            price.AutoSize = false;
            price.Width = 50;
            price.TextAlign = ContentAlignment.MiddleLeft;

            Label ds = new Label();
            ds.Text = "Download";
            ds.AutoSize = false;
            ds.Width = 60;
            ds.TextAlign = ContentAlignment.MiddleLeft;

            Label us = new Label();
            us.Text = "Upload";
            us.AutoSize = false;
            us.Width = 60;
            us.TextAlign = ContentAlignment.MiddleLeft;

            panel_show_details.Controls.Add(packetName);    panel_show_details.Controls.Add(name);
            panel_show_details.Controls.Add(packetPrice);   panel_show_details.Controls.Add(price);
            panel_show_details.Controls.Add(downloadSpeed); panel_show_details.Controls.Add(ds);
            panel_show_details.Controls.Add(uploadSpeed);   panel_show_details.Controls.Add(us);
            
            add_create_button(panel_show_details);
        }

        private void show_tv_packet_creation_dialog() {
            panel_show_details.Controls.Clear();

            TextBox packetName = new TextBox();
            NumericUpDown packetPrice = new NumericUpDown();
            NumericUpDown numberOfChannels = new NumericUpDown();

            packetPrice.Minimum = 0;
            packetPrice.Maximum = 20000;
            packetPrice.DecimalPlaces = 2;

            numberOfChannels.Maximum = 10000;

            panel_show_details.Tag = "tvPacket";
            packetName.Tag = "packetName";
            packetPrice.Tag = "packetPrice";
            numberOfChannels.Tag = "numberOfChannels";

            Label name = new Label();
            name.Text = "Name";
            name.AutoSize = false;
            name.Width = 50;
            name.TextAlign = ContentAlignment.MiddleLeft;

            Label price = new Label();
            price.Text = "Price";
            price.AutoSize = false;
            price.Width = 50;
            price.TextAlign = ContentAlignment.MiddleLeft;

            Label channels = new Label();
            channels.Text = "Channels";
            channels.AutoSize = false;
            channels.Width = 60;
            channels.TextAlign = ContentAlignment.MiddleLeft;

            panel_show_details.Controls.Add(packetName);        panel_show_details.Controls.Add(name);
            panel_show_details.Controls.Add(packetPrice);       panel_show_details.Controls.Add(price);
            panel_show_details.Controls.Add(numberOfChannels);  panel_show_details.Controls.Add(channels);

            add_create_button(panel_show_details);
        }

        private void show_combined_packet_creation_dialog() {
            panel_show_details.Controls.Clear();

            TextBox packetName = new TextBox();
            NumericUpDown packetPrice = new NumericUpDown();
            ComboBox internetPacket = new ComboBox();
            ComboBox tvPacket = new ComboBox();

            packetPrice.Minimum = 0;
            packetPrice.Maximum = 20000;
            packetPrice.DecimalPlaces = 2;

            panel_show_details.Tag = "combinedPacket";
            packetName.Tag = "packetName";
            packetPrice.Tag = "packetPrice";
            internetPacket.Tag = "internetPacketComboBox";
            tvPacket.Tag = "tvPacketComboBox";

            internetPacket.DropDownStyle = ComboBoxStyle.DropDownList;
            tvPacket.DropDownStyle = ComboBoxStyle.DropDownList;

            fill_available_internet_packets(internetPacket);
            fill_available_tv_packets(tvPacket);

            Label name = new Label();
            name.Text = "Name";
            name.AutoSize = false;
            name.Width = 50;
            name.TextAlign = ContentAlignment.MiddleLeft;

            Label price = new Label();
            price.Text = "Price";
            price.AutoSize = false;
            price.Width = 50;
            price.TextAlign = ContentAlignment.MiddleLeft;

            Label internet = new Label();
            internet.Text = "Internet";
            internet.AutoSize = false;
            internet.Width = 50;
            internet.TextAlign = ContentAlignment.MiddleLeft;

            Label tv = new Label();
            tv.Text = "TV";
            tv.AutoSize = false;
            tv.Width = 50;
            tv.TextAlign = ContentAlignment.MiddleLeft;

            panel_show_details.Controls.Add(packetName);        panel_show_details.Controls.Add(name);
            panel_show_details.Controls.Add(packetPrice);       panel_show_details.Controls.Add(price);
            panel_show_details.Controls.Add(internetPacket);    panel_show_details.Controls.Add(internet);
            panel_show_details.Controls.Add(tvPacket);          panel_show_details.Controls.Add(tv);

            add_create_button(panel_show_details);
        }

        private void add_create_button(Panel panelRef) {
            Button createButton = new Button();
            createButton.Text = "Create";
            createButton.Cursor = Cursors.Arrow;

            createButton.Click += (sender, e) => {
                query_create_packet(panelRef);
            };

            panelRef.Controls.Add(createButton);
        }

        private void query_create_packet(Panel panelReference) {
            string selectedPanel = panelReference.Tag.ToString();

            switch(selectedPanel) {
                case "internetPacket":
                    query_create_packet_internetPacket(panelReference);
                    break;

                case "tvPacket":
                    query_create_packet_tvPacket(panelReference);
                    break;

                case "combinedPacket":
                    query_create_packet_combinedPacket(panelReference);
                    break;

                default:
                    break;
            }
        }

        private void query_create_packet_internetPacket(Panel panelReference) {
            string packetName = null;
            double packetPrice = 0.0;
            int downloadSpeed = 0;
            int uploadSpeed = 0;
            
            foreach(Control control in panelReference.Controls) {

                if(control.Tag == null) continue;

                switch(control.Tag.ToString()) {
                    case "packetName":
                        packetName = control.Text;
                        break;

                    case "packetPrice":
                        packetPrice = Convert.ToDouble(control.Text);
                        break;

                    case "downloadSpeed":
                        downloadSpeed = Convert.ToInt32(control.Text);
                        break;

                    case "uploadSpeed":
                        uploadSpeed = Convert.ToInt32(control.Text);
                        break;

                    default:
                        break;
                }
            }

            if(packetName == "") {
                MessageBox.Show("Please enter packet name!");
                return;
            }

            //label_debug.Text = packetName + " " + packetPrice + " " + downloadSpeed + " " + uploadSpeed;
            
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("downloadSpeed", downloadSpeed);
            data.Add("uploadSpeed", uploadSpeed);
            try {
                _appLogic.createNewPacket(packetName, packetPrice, library.AppLogic.Packets.Packet.PacketType.INTERNET, data);
                MessageBox.Show("Query executed successfully!");
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Query did not execute successfully!");
            }

            closeFrom();
        }

        private void query_create_packet_tvPacket(Panel panelReference) {
            string packetName = null;
            double packetPrice = 0.0;
            int numberOfChannels = 0;

            foreach (Control control in panelReference.Controls) {

                if (control.Tag == null) continue;

                switch (control.Tag.ToString()) {
                    case "packetName":
                        packetName = control.Text;
                        break;

                    case "packetPrice":
                        packetPrice = Convert.ToDouble(control.Text);
                        break;

                    case "numberOfChannels":
                        numberOfChannels = Convert.ToInt32(control.Text);
                        break;

                    default:
                        break;
                }
            }

            if(packetName == "") {
                MessageBox.Show("Please enter packet name!");
                return;
            }

            //label_debug.Text = packetName + " " + packetPrice + " " + numberOfChannels;
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("numberOfChannels", numberOfChannels);
            try {
                _appLogic.createNewPacket(packetName, packetPrice, library.AppLogic.Packets.Packet.PacketType.TV, data);
                MessageBox.Show("Query executed successfully!");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Query did not execute successfully!");
            }

            closeFrom();
        }

        private void query_create_packet_combinedPacket(Panel panelReference) {
            string packetName = null;
            double packetPrice = 0.0;
            string internetPacketName = null;
            string tvPacketName = null;

            foreach (Control control in panelReference.Controls) {

                if (control.Tag == null) continue;

                switch (control.Tag.ToString()) {
                    case "packetName":
                        packetName = control.Text;
                        break;

                    case "packetPrice":
                        packetPrice = Convert.ToDouble(control.Text);
                        break;

                    case "internetPacketComboBox":
                        internetPacketName = control.Text;
                        break;

                    case "tvPacketComboBox":
                        tvPacketName = control.Text;
                        break;

                    default:
                        break;
                }
            }

            //label_debug.Text = packetName + " " + packetPrice + " " + internetPacketName + " " + tvPacketName;
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("internetpacketname", internetPacketName);
            data.Add("tvpacketname", tvPacketName);

            if(packetName == "") {
                MessageBox.Show("Please enter packet name!");
                return;
            }

            if (internetPacketName == "") { // nije selektovan internet paket
                MessageBox.Show("Please select Internet packet!");
                return;
            }

            if(tvPacketName == "") { // nije selektovan tv paket
                MessageBox.Show("Please select TV packet!");
                return;
            }

            try {
                _appLogic.createNewPacket(packetName, packetPrice, library.AppLogic.Packets.Packet.PacketType.COMBINED, data);
                MessageBox.Show("Query executed successfully!");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Query did not execute successfully!");
            }

            closeFrom();
        }

        private void closeFrom() {
            this.Close();
        }

        private void CreatePacket_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                closeFrom();
            }
        }

        private void fill_available_internet_packets(ComboBox reference) {
            var x = _appLogic.getPacketsByType(library.AppLogic.Packets.Packet.PacketType.INTERNET);

            foreach (var packet in x) {
                reference.Items.Add(packet.Name);
            }
        }

        private void fill_available_tv_packets(ComboBox reference) {
            var x = _appLogic.getPacketsByType(library.AppLogic.Packets.Packet.PacketType.TV);

            foreach (var packet in x) {
                reference.Items.Add(packet.Name);
            }
        }
    }
}
