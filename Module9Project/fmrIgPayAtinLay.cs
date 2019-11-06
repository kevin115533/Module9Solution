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
                    if (isNonText(userMessage))
                    {
                        lblTranslatedMessage.Text = userMessage + "\nEntry is non text and cant be translated";
                    }
                    else
                    {
                        lblTranslatedMessage.Text = translate(userMessage);
                    }
                }
            }
            catch(Exception ex)
            {
                lblTranslatedMessage.Text = ex.Message + ex.GetType().ToString();
            }
        }

        private string translate(string userString)
        {
            string[] words = userString.Split(' ');
            string translatedString = "";
            for (int i = 0; i < words.Length; i++)
            {
                if (isVowel(words[i].Substring(0, 1))) {
                    words[i] = words[i] + "way";
                }
                else 
                {
                    words[i] = words[i].Substring(1, words[i].Length - 1) + words[i].Substring(0, 1) + "ay";
                }
            }

            translatedString = string.Join(" ", words);
            return translatedString;
        }

        private bool isVowel(string firstLetter)
        {
            switch (firstLetter)
            {
                case "a":
                case "e":
                case "i":
                case "o":
                case "u":
                case "A":
                case "E":
                case "I":
                case "O":
                case "U":
                    return true;
                default:
                    return false;
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
                isBlank(txtMessage);
        }

        private bool isBlank(TextBox txtMessage)
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

        private bool isNonText (string userString)
        {
            int n = 0;
            if (int.TryParse(userString, out n))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
