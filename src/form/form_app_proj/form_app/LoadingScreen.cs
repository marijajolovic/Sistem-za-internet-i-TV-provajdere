using library.AppLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace form_app {
    public partial class LoadingScreen : Form {
        private Timer timer;
        private int progress;

        public LoadingScreen() {
            InitializeComponent();

            InitializeTimer();
        }

        private void InitializeTimer() {
            timer = new Timer();
            timer.Interval = 10; // Set the interval to 500 milliseconds (adjust as needed)
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e) {
            progress++;

            if (progress > 100) {
                timer.Stop();
                SwitchForm();
            }
            else {
                progressBar.PerformStep();
                progressBar.Value = progress;
                loading_label.Text = "Loading... " + progress + "%";
            }
        }

        private void SwitchForm() {
            ProviderApp winForm = new ProviderApp(new AppLogic());
            winForm.Show();

            winForm.FormClosed += (object sender, FormClosedEventArgs e) => {
                Close();
            };

            Hide();
        }
    }
}
