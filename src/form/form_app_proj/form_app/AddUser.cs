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


namespace form_app
{
    public partial class AddUser : Form
    {
        private IAppLogicFacade appLogic;

        public AddUser(IAppLogicFacade aLogic)
        {
            InitializeComponent();
            close_on_esc();
            appLogic = aLogic;
        }

        private void closeFrom()
        {
            this.Close();
        }


        private void close_on_esc()
        {
            this.KeyPreview = true;
            this.KeyDown += AddUser_KeyDown;
        }

        private void AddUser_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Escape)
                {
                    closeFrom();
                }
        }

        private void buttonRegisterUserClick(object sender, EventArgs e)
        {
            bool isValid = true; // Track overall validation status
            string username = input_username.Text;
            string firstName = input_firstname.Text;
            string lastName = input_lastname.Text;

            // Validate name TextBox
            if (string.IsNullOrWhiteSpace(username))
            {
                errorUsername.SetError(input_username, "Username is required.");
                isValid = false;
            }
            else
            {
                errorUsername.SetError(input_username, ""); // Clear error message
            }

            // Validate firstname TextBox
            if (string.IsNullOrWhiteSpace(firstName))
            {
                errorFirstName.SetError(input_firstname, "First name is required.");
                isValid = false;
            }
            else
            {
                errorFirstName.SetError(input_firstname, ""); // Clear error message
            }

            // Validate last name TextBox
            if (string.IsNullOrWhiteSpace(lastName))
            {
                errorLastName.SetError(input_lastname, "Last name is required.");
                isValid = false;
            }
            else
            {
                errorLastName.SetError(input_lastname, ""); // Clear error message
            }

            if (isValid)
            {
                try {
                    appLogic.registerClient(username, firstName, lastName);
                    MessageBox.Show("Query executed successfully!");
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("Query did not execute successfully!");
                }

                this.Close();
            }
        }
    }
}
