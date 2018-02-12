using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MegaDesk_4_Makram_Ibrahim
{
    public partial class SearchQuotes : Form
    {
        public SearchQuotes()
        {
            InitializeComponent();
            List<SurfaceMaterials> MaterialNameList = Enum.GetValues(typeof(SurfaceMaterials))
                .Cast<SurfaceMaterials>().ToList();
            SearchBox.DataSource = MaterialNameList;



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

            try
            {
                string QuoteFile = @"quotes.json";
                using (StreamReader sr = new StreamReader(QuoteFile))
                {
                    string[] line = File.ReadAllLines(QuoteFile);

                    foreach (var i in line)
                    {
                        searchOutput.Items.Add(i); ;
                    }

                    sr.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Error reading the file");
            }

        }
    }
}
