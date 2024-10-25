using System.ComponentModel;
using System.Windows.Forms;

namespace form_app
{
    partial class AddUser
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUser));
            this.register_client_label = new System.Windows.Forms.Label();
            this.button_register_user = new System.Windows.Forms.Button();
            this.errorUsername = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorFirstName = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorLastName = new System.Windows.Forms.ErrorProvider(this.components);
            this.input_username = new System.Windows.Forms.TextBox();
            this.input_firstname = new System.Windows.Forms.TextBox();
            this.input_lastname = new System.Windows.Forms.TextBox();
            this.label_username = new System.Windows.Forms.Label();
            this.label_firstname = new System.Windows.Forms.Label();
            this.label_lastname = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorLastName)).BeginInit();
            this.SuspendLayout();
            // 
            // register_client_label
            // 
            this.register_client_label.AutoSize = true;
            this.register_client_label.BackColor = System.Drawing.Color.Transparent;
            this.register_client_label.Font = new System.Drawing.Font("Sylfaen", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.register_client_label.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.register_client_label.Location = new System.Drawing.Point(14, 16);
            this.register_client_label.Name = "register_client_label";
            this.register_client_label.Size = new System.Drawing.Size(331, 62);
            this.register_client_label.TabIndex = 0;
            this.register_client_label.Text = "Register client";
            // 
            // button_register_user
            // 
            this.button_register_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_register_user.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.button_register_user.Location = new System.Drawing.Point(82, 255);
            this.button_register_user.Name = "button_register_user";
            this.button_register_user.Size = new System.Drawing.Size(171, 44);
            this.button_register_user.TabIndex = 1;
            this.button_register_user.Text = "Register";
            this.button_register_user.UseVisualStyleBackColor = true;
            this.button_register_user.Click += new System.EventHandler(this.buttonRegisterUserClick);
            // 
            // errorUsername
            // 
            this.errorUsername.ContainerControl = this;
            // 
            // errorFirstName
            // 
            this.errorFirstName.ContainerControl = this;
            // 
            // errorLastName
            // 
            this.errorLastName.ContainerControl = this;
            // 
            // input_username
            // 
            this.input_username.BackColor = System.Drawing.SystemColors.Control;
            this.input_username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.input_username.Location = new System.Drawing.Point(73, 115);
            this.input_username.Name = "input_username";
            this.input_username.Size = new System.Drawing.Size(192, 20);
            this.input_username.TabIndex = 0;
            this.input_username.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // input_firstname
            // 
            this.input_firstname.BackColor = System.Drawing.SystemColors.Control;
            this.input_firstname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.input_firstname.Location = new System.Drawing.Point(73, 163);
            this.input_firstname.Name = "input_firstname";
            this.input_firstname.Size = new System.Drawing.Size(192, 20);
            this.input_firstname.TabIndex = 1;
            this.input_firstname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // input_lastname
            // 
            this.input_lastname.BackColor = System.Drawing.SystemColors.Control;
            this.input_lastname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.input_lastname.ForeColor = System.Drawing.SystemColors.WindowText;
            this.input_lastname.Location = new System.Drawing.Point(73, 223);
            this.input_lastname.Name = "input_lastname";
            this.input_lastname.Size = new System.Drawing.Size(192, 20);
            this.input_lastname.TabIndex = 2;
            this.input_lastname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.BackColor = System.Drawing.Color.Transparent;
            this.label_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_username.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_username.Location = new System.Drawing.Point(117, 89);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(105, 24);
            this.label_username.TabIndex = 3;
            this.label_username.Text = "Username";
            // 
            // label_firstname
            // 
            this.label_firstname.AutoSize = true;
            this.label_firstname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_firstname.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_firstname.Location = new System.Drawing.Point(117, 136);
            this.label_firstname.Name = "label_firstname";
            this.label_firstname.Size = new System.Drawing.Size(111, 24);
            this.label_firstname.TabIndex = 4;
            this.label_firstname.Text = "First Name";
            // 
            // label_lastname
            // 
            this.label_lastname.AutoSize = true;
            this.label_lastname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_lastname.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_lastname.Location = new System.Drawing.Point(120, 196);
            this.label_lastname.Name = "label_lastname";
            this.label_lastname.Size = new System.Drawing.Size(108, 24);
            this.label_lastname.TabIndex = 5;
            this.label_lastname.Text = "Last Name";
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(338, 362);
            this.Controls.Add(this.register_client_label);
            this.Controls.Add(this.button_register_user);
            this.Controls.Add(this.label_lastname);
            this.Controls.Add(this.label_firstname);
            this.Controls.Add(this.label_username);
            this.Controls.Add(this.input_lastname);
            this.Controls.Add(this.input_username);
            this.Controls.Add(this.input_firstname);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.Color.SlateBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            ((System.ComponentModel.ISupportInitialize)(this.errorUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorLastName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label register_client_label;
        private Button button_register_user;
        private ErrorProvider errorUsername;
        private ErrorProvider errorFirstName;
        private ErrorProvider errorLastName;
        private Label label_lastname;
        private Label label_firstname;
        private Label label_username;
        private TextBox input_lastname;
        private TextBox input_firstname;
        private TextBox input_username;
    }
}