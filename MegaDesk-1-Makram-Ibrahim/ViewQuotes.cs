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

            //string line;
            try
            {
                string QuoteFile = @"quotes.json";
                using (StreamReader sr = new StreamReader(QuoteFile))
                {
                    string json = sr.ReadToEnd();
                    List<DeskQuote> deskView = JsonConvert.DeserializeObject<List<DeskQuote>>(json);

                    dynamic array = JsonConvert.DeserializeObject(json);

                    foreach(var arr in array)
                    {
                        ViewQuotesBox.Items.Add(arr);
                    }

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
