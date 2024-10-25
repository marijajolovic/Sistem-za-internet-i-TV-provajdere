using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using library.AppLogic.Interfaces;
using library.AppLogic.Packets;
using library.AppLogic.Clients;
using System.Runtime.InteropServices;

namespace form_app {
    public partial class ProviderApp : Form {

        private IAppLogicFacade appLogic = null;
        
        private string selectedClientID = null;                         // decide which user is currently selected
        private string selectedPacketID = null;                         // decide which packet is currently selected

        private IEnumerable<Client> clients = null;                     // list of clients. Updated when new client is registered
        private IEnumerable<Packet> packetsForSelectedClient = null;    // list of packets for currently selected user
        
        private Color selectColor = Color.LightGreen;                   // color used to display selected users and their packets
        private Color selectPacketColor = Color.DarkGreen;              // color used to display selected packets

        /* **************************** FORM COLOR ************************************* */

        private string ToBgr(Color c) => $"{c.B:X2}{c.G:X2}{c.R:X2}";

        [DllImport("DwmApi")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        const int DWWMA_CAPTION_COLOR = 35;
        const int DWWMA_BORDER_COLOR = 34;
        const int DWMWA_TEXT_COLOR = 36;
        public void CustomWindow(Color captionColor, Color fontColor, Color borderColor, IntPtr handle) {
            IntPtr hWnd = handle;
            //Change caption color
            int[] caption = new int[] { int.Parse(ToBgr(captionColor), System.Globalization.NumberStyles.HexNumber) };
            DwmSetWindowAttribute(hWnd, DWWMA_CAPTION_COLOR, caption, 4);
            //Change font color
            int[] font = new int[] { int.Parse(ToBgr(fontColor), System.Globalization.NumberStyles.HexNumber) };
            DwmSetWindowAttribute(hWnd, DWMWA_TEXT_COLOR, font, 4);
            //Change border color
            int[] border = new int[] { int.Parse(ToBgr(borderColor), System.Globalization.NumberStyles.HexNumber) };
            DwmSetWindowAttribute(hWnd, DWWMA_BORDER_COLOR, border, 4);
        }

        /* ***************************************************************************** */

        /* ********************************************************************
         * Konstruktor
         * Inicijalizacija komponenti
         * Izvrsava upit kako bi bili dostupni svi klijenti
         * Popunjava sve komponente
         * ******************************************************************** */
        public ProviderApp(IAppLogicFacade appLogicFacade) {
            InitializeComponent();

            appLogic = appLogicFacade;
            clients = appLogic.getAllClients("");
            packetsForSelectedClient = new List<Packet>();

            fill_components();
            this.filter_clients_tb.KeyUp += parse_keyup_filter_clients;
            this.btnDeactivate.Click += DeactivateButton_Click;
            this.btnActivate.Click += ActivateButton_Click;

            this.KeyPreview = true; // This allows the form to receive key events before they are passed to the focused control
            this.KeyDown += Form_KeyDown;

            CustomWindow(Color.LightGreen, Color.Black, Color.GreenYellow, Handle);
        }
        /* ********************************************************************
         * Event handler keydown
         * ******************************************************************** */
        private void Form_KeyDown(object sender, KeyEventArgs e) {
            if (e.Control && e.KeyCode == Keys.Z) { // Check if Ctrl+Z is pressed
                Undo();
            }

            if(e.Control && e.KeyCode == Keys.Y) {
                Redo();
            }
        }
        /* ********************************************************************
         * Undo metod
         * ******************************************************************** */
        private void Undo() {
            appLogic.restorePreviousState();
            
            clearAllSelections();
            clients = appLogic.getAllClients("");
            selectedPacketID = null;

            fill_components();
            filter_clients_tb.Text = string.Empty;

            if (selectedClientID != null) {
                Label selectedClientLabel = panelClients.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Tag.ToString() == selectedClientID);
                ClientLabel_Click(selectedClientLabel, EventArgs.Empty);
                ClientLabel_Click(selectedClientLabel, EventArgs.Empty);
            }
        }
        /* ********************************************************************
         * Redo metod
         * ******************************************************************** */
        private void Redo() {
            appLogic.redoPrevouslyRestoredState();

            clearAllSelections();
            clients = appLogic.getAllClients("");
            selectedPacketID = null;

            fill_components();
            filter_clients_tb.Text = string.Empty;

            if (selectedClientID != null) {
                Label selectedClientLabel = panelClients.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Tag.ToString() == selectedClientID);
                ClientLabel_Click(selectedClientLabel, EventArgs.Empty);
                ClientLabel_Click(selectedClientLabel, EventArgs.Empty);
            }
        }
        /* ********************************************************************
         * Popunjava sve komponente na strani
         * ******************************************************************** */
        private void fill_components() {
            fill_provider_name_label();
            fill_clients_panel();
            fill_internet_packets_panel();
            fill_tv_packets_panel();
            fill_comb_packets_panel();
        }
        /* ********************************************************************
         * Popunjava panel za klijente
         * ******************************************************************** */
        private void fill_clients_panel() {
            FlowLayoutPanel panel = this.panelClients;

            panel.Controls.Clear();

            foreach (var client in clients) {
                Label lb = new Label(); // Create label for client name
                lb.Text = client.Username.ToString();
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.AutoSize = false;
                lb.Width = 120; // Adjust width as needed
                lb.Height = 26;
                lb.Tag = client.ClientID;
                lb.MouseEnter += Lb_MouseEnter;
                lb.MouseLeave += Lb_MouseLeave;

                if (selectedClientID != null && lb.Tag.ToString() == selectedClientID) {
                    lb.BackColor = selectColor;
                }
                lb.Click += ClientLabel_Click;
                lb.BorderStyle = BorderStyle.FixedSingle;

                panel.Controls.Add(lb);
            }
        }
        /* ********************************************************************
        * Simulacija hover efekta kod panela za klijente
        * ******************************************************************** */
        private void Lb_MouseEnter(object sender, EventArgs e) {
            Label lb = sender as Label;
            lb.BackColor = Color.LightGray;
        }
        private void Lb_MouseLeave(object sender, EventArgs e) {
            Label lb = (Label)sender;
            if(selectedClientID != null && lb.Tag.ToString() == selectedClientID) {
                lb.BackColor = selectColor;
            }
            else {
                lb.BackColor = SystemColors.Window;
            }
        }
        /* ********************************************************************
        * Promena boje selektovanih paketa i korisnika
        * ******************************************************************** */
        private void clearAllSelections() {
            this.btnDeactivate.Visible = false;
            this.btnActivate.Visible = false;
            
            foreach (Label control in panelClients.Controls) {
                control.BackColor = SystemColors.Control;
            }

            foreach (Label lb in panelTVPackets.Controls) {
                lb.BackColor = SystemColors.Control;
                lb.ForeColor = SystemColors.ControlText;
            }

            foreach (Label lb in panelInternetPackets.Controls) {
                lb.BackColor = SystemColors.Control;
                lb.ForeColor = SystemColors.ControlText;
            }

            foreach (Label lb in panelCombinedPackets.Controls) {
                lb.BackColor = SystemColors.Control;
                lb.ForeColor= SystemColors.ControlText;
            }
        }
        /* ********************************************************************
         * Event selekcije korisnika
         * Na klik odredjenog korisnika iz prikaza selektuju se paketi koji su
         * mu dostupni. Ukoliko je korisnik vec selektovan onda se deselektuje.
         * ******************************************************************** */
        private void ClientLabel_Click(object sender, EventArgs e) {

            clearAllSelections();
            if (sender == null) return;

            Label clickedLabel = (Label)sender;

            if (clickedLabel.Tag.ToString() == selectedClientID) {
                selectedClientID = null;
                packetsForSelectedClient = null;
                return; // deselect
            }

            clickedLabel.BackColor = selectColor;
            this.selectedClientID = clickedLabel.Tag.ToString();

            packetsForSelectedClient = appLogic.getPacketsForClient(Convert.ToInt32(this.selectedClientID));


            foreach (var packet in packetsForSelectedClient) {
                var packetid = packet.PacketID.ToString();

                foreach (Label lb in panelTVPackets.Controls) {
                    if (lb.Tag.ToString() == packetid) lb.BackColor = selectColor;
                }

                foreach (Label lb in panelInternetPackets.Controls) {
                    if (lb.Tag.ToString() == packetid) lb.BackColor = selectColor;
                }

                foreach (Label lb in panelCombinedPackets.Controls) {
                    if (lb.Tag.ToString() == packetid) lb.BackColor = selectColor;
                }
            }

        }
        /* ********************************************************************
         * Promena selektovanog paketa
         * ******************************************************************** */
        private void clearSelectedPacket() {

            foreach (Label lb in panelTVPackets.Controls) {
                if (lb.Tag.ToString() == selectedPacketID) {
                    lb.BackColor = SystemColors.Control;
                    if (packetsForSelectedClient != null && packetsForSelectedClient.Any(packet => packet.PacketID.ToString() == selectedPacketID))
                        lb.BackColor = selectColor;
                        lb.ForeColor = SystemColors.ControlText;
                }
            }

            foreach (Label lb in panelInternetPackets.Controls) {
                if (lb.Tag.ToString() == selectedPacketID) {
                    lb.BackColor = SystemColors.Control;
                    if (packetsForSelectedClient != null && packetsForSelectedClient.Any(packet => packet.PacketID.ToString() == selectedPacketID))
                        lb.BackColor = selectColor;
                        lb.ForeColor = SystemColors.ControlText;
                }
            }

            foreach (Label lb in panelCombinedPackets.Controls) {
                if (lb.Tag.ToString() == selectedPacketID) {
                    lb.BackColor = SystemColors.Control;
                    if (packetsForSelectedClient != null && packetsForSelectedClient.Any(packet => packet.PacketID.ToString() == selectedPacketID))
                        lb.BackColor = selectColor;
                        lb.ForeColor = SystemColors.ControlText;
                }
            }
        }
        /* ********************************************************************
         * Event selekcije paketa
         * ******************************************************************** */
        private void PacketLabel_Click(object sender, EventArgs e) {

            if (selectedClientID == null) return;

            clearSelectedPacket();
            this.btnDeactivate.Visible = false;
            this.btnActivate.Visible = false;

            Label clickedLabel = (Label)sender;

            if (clickedLabel.Tag.ToString() == selectedPacketID) {
                clickedLabel.ForeColor = SystemColors.ControlText;
                selectedPacketID = null;
                return; // deselect
            }

            clickedLabel.BackColor = selectPacketColor;
            clickedLabel.ForeColor = SystemColors.Control;
            this.selectedPacketID = clickedLabel.Tag.ToString();

            // Ako klijent vec ima ovaj paket, prikazi dugme da Deaktivira paket
            if (selectedClientID != null && packetsForSelectedClient.Any(packet => packet.PacketID.ToString() == selectedPacketID)) {
                this.btnDeactivate.Visible = true;
            }
            // else, prikazi dugme da Aktivira paket
            else if(selectedClientID != null) {
                this.btnActivate.Visible = true;
            }
        }
        /* ********************************************************************
         * Popunjava panel odvojen za internet pakete
         * ******************************************************************** */
        private void fill_internet_packets_panel() {

            FlowLayoutPanel panel = this.panelInternetPackets;
            panel.Controls.Clear();

            var x = appLogic.getPacketsByType(library.AppLogic.Packets.Packet.PacketType.INTERNET);

            foreach (var packet in x) {
                Label lb = new Label();
                lb.Text = packet.Name.ToString() + " | " + packet.Price.ToString() + " | " + packet.Data["downloadSpeed"].ToString() + "/" + packet.Data["uploadSpeed"].ToString();
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.BorderStyle = BorderStyle.FixedSingle;
                lb.AutoSize = false;
                lb.Width = 160;
                lb.Height = 30;
                lb.Tag = packet.PacketID;
                lb.Click += PacketLabel_Click;

                panel.Controls.Add(lb);
            }

        }
        /* ********************************************************************
         * Popunjava panel odvojen za tv pakete
         * ******************************************************************** */
        private void fill_tv_packets_panel() {

            FlowLayoutPanel panel = this.panelTVPackets;
            panel.Controls.Clear();

            var x = appLogic.getPacketsByType(library.AppLogic.Packets.Packet.PacketType.TV);

            foreach (var packet in x) {
                Label lb = new Label();
                lb.Text = packet.Name.ToString() + " | " + packet.Price.ToString() + " | " + packet.Data["numberOfChannels"].ToString();
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.BorderStyle = BorderStyle.FixedSingle;
                lb.AutoSize = false;
                lb.Width = 160;
                lb.Height = 30;
                lb.Tag = packet.PacketID;
                lb.Click += PacketLabel_Click;

                panel.Controls.Add(lb);
            }
        }
        /* ********************************************************************
         * Popunjava panel odvojen za kombinovane pakete
         * ******************************************************************** */
        private void fill_comb_packets_panel() {

            FlowLayoutPanel panel = this.panelCombinedPackets;
            panel.Controls.Clear();

            var x = appLogic.getPacketsByType(library.AppLogic.Packets.Packet.PacketType.COMBINED);
            
            foreach (var packet in x) {
                Label lb = new Label();
                lb.Text = packet.Name.ToString() + " | " + packet.Price.ToString() + " | " + packet.Data["numberOfChannels"].ToString() + " | " + packet.Data["downloadSpeed"].ToString() + "/" + packet.Data["uploadSpeed"].ToString();
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.BorderStyle = BorderStyle.FixedSingle;
                lb.AutoSize = false;
                lb.Width = 160;
                lb.Height = 30;
                lb.Tag = packet.PacketID;
                lb.Click += PacketLabel_Click;

                panel.Controls.Add(lb);
            }
        }
        /* ********************************************************************
         * Popunjava naziv provajdera
         * ******************************************************************** */
        private void fill_provider_name_label() {
            Label labelref = this.providerName;
            labelref.Text = "Provider: ";
            try { labelref.Text += appLogic.getProviderName(); }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                labelref.Text += "NOT RECOGNIZED";
            }
        }
        /* ********************************************************************
         * Event handler za pretrazivanje klijenata po korisnickom imenu
         * ******************************************************************** */
        private void parse_keyup_filter_clients(object sender, KeyEventArgs e) {
            FlowLayoutPanel panel = this.panelClients;
            string like = this.filter_clients_tb.Text;

            panel.Controls.Clear();

            foreach (var client in clients) {
                if (!client.Username.ToString().ToLower().Contains(like.ToLower())) continue;

                Label lb = new Label(); // Create label for client name
                lb.Text = client.Username.ToString();
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.AutoSize = false;
                lb.Width = 120; // Adjust width as needed
                lb.Height = 26;
                lb.Tag = client.ClientID;
                lb.MouseEnter += Lb_MouseEnter;
                lb.MouseLeave += Lb_MouseLeave;

                if (selectedClientID != null && lb.Tag.ToString() == selectedClientID) {
                    lb.BackColor = selectColor;
                }
                lb.Click += ClientLabel_Click;
                lb.BorderStyle = BorderStyle.FixedSingle;

                panel.Controls.Add(lb);
            }

        }
        /* ********************************************************************
         * Poziva se nakon sto se zatvori prozor za dodavanje novog klijenta
         * ******************************************************************** */
        private void parse_register_client_form_closed(object sender, FormClosedEventArgs e) {
            clearAllSelections();
            selectedClientID = null;
            clients = appLogic.getAllClients("");
            fill_clients_panel();
        }
        /* ********************************************************************
         * Poziva se nakon sto se zatvori prozor za dodavanje novog paketa
         * ******************************************************************** */
        private void parse_create_packet_form_closed(object sender, FormClosedEventArgs e) {
            clearAllSelections();
            fill_internet_packets_panel();
            fill_tv_packets_panel();
            fill_comb_packets_panel();
        }
        /* ********************************************************************
         * Event klika dugmeta za dodavanje novog korisnika
         * ******************************************************************** */
        private void button_register_client_Click(object sender, EventArgs e) {
            var newForm = new AddUser(appLogic);
            newForm.FormClosed += parse_register_client_form_closed;
            newForm.ShowDialog();
        }
        /* ********************************************************************
         * Event klika dugmeta za dodavanje novog paketa
         * ******************************************************************** */
        private void button_create_packet_Click(object sender, EventArgs e) {
            var newForm = new CreatePacket(appLogic);
            newForm.FormClosed += parse_create_packet_form_closed;
            newForm.ShowDialog();
        }
        /* ********************************************************************
         * Deaktivacija paketa za korisnika
         * ******************************************************************** */
        private void DeactivateButton_Click(object sender, EventArgs e) {
            Label selectedPacketLabel = panelClients.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Tag.ToString() == selectedPacketID);
            if (selectedPacketLabel != null) {
                selectedPacketLabel.BackColor = SystemColors.Control;
                selectedPacketLabel.ForeColor = SystemColors.ControlText;
            }

            appLogic.deactivatePacket(Convert.ToInt32(selectedClientID), Convert.ToInt32(selectedPacketID));

            // Refreshovan prikaz nakon deaktivacije

            if (sender is Button deactivateButton) {
                deactivateButton.Visible = false;
            }

            Label selectedClientLabel = panelClients.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Tag.ToString() == selectedClientID);
            if (selectedClientLabel != null) {
                ClientLabel_Click(selectedClientLabel, EventArgs.Empty);
                ClientLabel_Click(selectedClientLabel, EventArgs.Empty);
                selectedPacketID = null;
            }
        }
        /* ********************************************************************
         * Aktivacija paketa za korisnika
         * ******************************************************************** */
        private void ActivateButton_Click(object sender, EventArgs e) {
            Label selectedPacketLabel = panelClients.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Tag.ToString() == selectedPacketID);
            if (selectedPacketLabel != null) {
                selectedPacketLabel.BackColor = SystemColors.Control;
                selectedPacketLabel.ForeColor = SystemColors.ControlText;
            }

            appLogic.activatePacket(Convert.ToInt32(selectedClientID), Convert.ToInt32(selectedPacketID));


            // Refreshovan prikaz nakon aktivacije

            if (sender is Button activateButton) {
                activateButton.Visible = false; 
            }

            Label selectedClientLabel = panelClients.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Tag.ToString() == selectedClientID);
            if (selectedClientLabel != null) {
                ClientLabel_Click(selectedClientLabel, EventArgs.Empty);
                ClientLabel_Click(selectedClientLabel, EventArgs.Empty);
                selectedPacketID = null;
            }
        }
        /* ********************************************************************
         * Undo button click handler
         * ******************************************************************** */
        private void picUndo_Click(object sender, EventArgs e) {
            Undo();
        }
        /* ********************************************************************
         * Redo button click handler
         * ******************************************************************** */
        private void picRedo_Click(object sender, EventArgs e) {
            Redo();
        }
    }
}
