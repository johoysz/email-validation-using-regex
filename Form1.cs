using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace Buangjug_SF1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private void btnSubmit_Click(object sender, EventArgs e) {
            Regex emailValid = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);
            bool isConverted = int.TryParse(txtTickets.Text, out int ticket);
            try
            {
                if (string.IsNullOrEmpty(txtName.Text)) { lblNameError.Text = "*Enter your name"; } //temporary validation (1)
                else { lblNameError.Text = string.Empty; } // (2)
                if (!emailValid.IsMatch(txtEmail.Text)) { lblEmailError.Text = "*Invalid Email"; }
                else { lblEmailError.Text = string.Empty; }
                int.Parse(txtTickets.Text); 
                if(isConverted) { lblTicketsError.Text = string.Empty; }
            }
            catch (FormatException)
            {
                lblTicketsError.Text = "*Positive Number Only";
            }
            if(!string.IsNullOrEmpty(txtName.Text) && emailValid.IsMatch(txtEmail.Text) && isConverted && ticket > 0) {
                MessageBox.Show("Registration Confirm");
                txtName.Text = string.Empty; txtEmail.Text = string.Empty; txtTickets.Text = string.Empty;
                lblEmailError.Text = string.Empty; lblTicketsError.Text = string.Empty; comboBox.Text = string.Empty;
            }
        }
        private void Form1_Load(object sender, EventArgs e) {
            comboBox.Items.Add("Event 1"); comboBox.Items.Add("Event 2"); comboBox.Items.Add("Event 3");
        }
    }
}