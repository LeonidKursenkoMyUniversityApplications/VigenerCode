using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LR05.Controller;

namespace LR05
{
    public partial class Form1 : Form
    {
        private VigController _vigController;

        public Form1()
        {
            InitializeComponent();
            string alphabet = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя" +
                              "abcdefghijklmnopqrstuvwxyz" +
                              "0123456789. ";

            _vigController = new VigController(alphabet.ToList());
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                string sourceMessage = sourceRichTextBox.Text;
                string key = keyTextBox.Text;
                string encryptMessage = _vigController.Encrypt(sourceMessage, key);
                encryptRichTextBox.Text = encryptMessage;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                string encryptMessage = encryptRichTextBox.Text;
                string key = keyTextBox.Text;
                string sourceMessage = _vigController.Decrypt(encryptMessage, key);
                sourceRichTextBox.Text = sourceMessage;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }
    }
}
