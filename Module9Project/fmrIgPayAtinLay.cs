using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module9Project
{
    public partial class fmrIgPayAtinLay : Form
    {
        public fmrIgPayAtinLay()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMessage.Text = "";
            lblTranslatedMessage.Text = "";
            txtMessage.Focus();
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            string userMessage = txtMessage.Text;

            try
            {
                if (validateData())
                {
                    lblTranslatedMessage.Text = userMessage;
                }
            }
            catch(Exception ex)
            {
                lblTranslatedMessage.Text = ex.Message + ex.GetType().ToString();
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fmrIgPayAtinLay_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        public bool validateData()
        {
            return
                isBlank(txtMessage) &&
                isText(txtMessage);
        }

        private bool isText(TextBox txtMessage)
        {
            if (txtMessage.Text == "")
            {
                lblTranslatedMessage.Text = "Entry box is blank, please enter a message";
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool isBlank(TextBox txtMessage)
        {
            throw new NotImplementedException();
        }
    }
}
