using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_4_Makram_Ibrahim
{
    public partial class ViewQuotes : Form
    {
        public ViewQuotes()
        {
            InitializeComponent();

            string line;
            try
            {
                string QuoteFile = @"quotes.json";
                StreamReader sr = new StreamReader(QuoteFile);

                while ((line = sr.ReadLine()) != null)
                {
                    DeskQuote json = JsonConvert.DeserializeObject<DeskQuote>(line);
                    ViewQuotesBox.Items.Add(json.ClientName);
                }
                sr.Close();
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
