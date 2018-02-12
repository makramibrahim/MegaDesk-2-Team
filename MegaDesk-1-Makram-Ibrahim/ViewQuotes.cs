using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MegaDesk_4_Makram_Ibrahim
{
    public partial class ViewQuotes : Form
    {
        public ViewQuotes()
        {
            InitializeComponent();

            //string line;
            try
            {
                string QuoteFile = @"quotes.json";
                using (StreamReader sr = new StreamReader(QuoteFile))
                {
                    string[] line = File.ReadAllLines(QuoteFile);

                    foreach(var i in line)
                    {
                        ViewQuotesBox.Items.Add(i);
                    }

                    sr.Close();
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Error reading the file");
            }
        }

        private void CancelViewQuotesBtn_Click(object sender, MouseEventArgs e)
        {
            var mainMenu = (MainMenu)Tag;
            mainMenu.Show();
            Close();
        }
    }
}
