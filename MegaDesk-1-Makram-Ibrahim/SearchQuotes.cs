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
    public partial class SearchQuotes : Form
    {
        public SearchQuotes()
        {
            InitializeComponent();
            List<SurfaceMaterials> ListOfMaterial = Enum.GetValues(typeof(SurfaceMaterials))
                .Cast<SurfaceMaterials>().ToList();
            SearchBox.DataSource = ListOfMaterial;
        }

        private void CancelSearchBtn_Click(object sender, MouseEventArgs e)
        {
            var mainMenu = (MainMenu)Tag;
            mainMenu.Show();
            Close();
        }

        private void SearchMaterial(object sender, EventArgs e)
        {
            searchOutput.Items.Clear();
            SurfaceMaterials MaterialName;
            string searchInput = SearchBox.SelectedItem.ToString();
            Enum.TryParse(searchInput, out MaterialName);
            DeskQuote deskQuote = new DeskQuote();

            List<DeskQuote> searchDiskQuote = new List<DeskQuote>();

            try
            {
                string QuoteFile = @"quotes.json";
                using (StreamReader sr = new StreamReader(QuoteFile))
                {
                    string line = sr.ReadToEnd();
                    searchDiskQuote = JsonConvert.DeserializeObject<List<DeskQuote>>(line);
                }

                foreach (DeskQuote deskQuotee in searchDiskQuote)
                {
                    string materialNames = deskQuotee.desk.surfMaterials.ToString();
                    if (materialNames.Contains(MaterialName.ToString()))
                    {
                        searchOutput.Items.Add(searchDiskQuote);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Error, can't read the file");
            }
        }
    }
}
