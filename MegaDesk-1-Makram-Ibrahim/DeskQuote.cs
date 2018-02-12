using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_4_Makram_Ibrahim
{
    class DeskQuote
    {
        /*************************
        * Declare some variables 
        *************************/
        public string ClientName  { get; set; }
        public DateTime QuoteDate { get; set; }
        public int RushDays       { get; set; }
        public decimal QuotePrice { get; set; }
        public Desk desk = new Desk();
        public decimal Surface = 0;
        int[,] array2D = new int[3,3];
       


        //Priced items with fiexed values
        private const int BASE_PRICE = 200;
        private const int BASE_SIZE = 1000;
        private const int DRAWER_PRICE = 50;
        private const int PRICE_PER_INCH = 1;
        private const int RUSH_DAYS1 = 3;
        private const int RUSH_DAYS2 = 5;
        private const int RUSH_DAYS3 = 7;
        private const int RUSH_HOLD = 2000;

        /******************************
        * Overloaded Constructor
        * ***************************/
        public DeskQuote( string name, DateTime quoteDate, decimal width, decimal depth,
                          int drawers, SurfaceMaterials material, int rushDays)
        {
            ClientName = name;
            QuoteDate = quoteDate;
            desk.Width = width;
            desk.Depth = depth;
            desk.surfMaterials = material;
            desk.NumOfDrawers = drawers;
            RushDays = rushDays;

            Surface = desk.Width * desk.Depth;
        }

        /*******************************
       * Defalut Constructor
       * ***************************/
        public DeskQuote() { }


        /************************************
       * Display the desk surface area
       * **********************************/
        public decimal CalQuoteTotal()
        {
            return BASE_PRICE + SurfaceArea() + DrawerCost() + (int)desk.surfMaterials + RushOrderCost();
        }

        private decimal SurfaceArea()
        {
            decimal extraCost = 0;
            if (Surface > BASE_SIZE)
            {
                extraCost = (Surface - BASE_SIZE) * PRICE_PER_INCH;

            }
            return extraCost;
        }

        private decimal DrawerCost()
        {
            return desk.NumOfDrawers * DRAWER_PRICE;
        }
        /************************************
        * Read File from RushDaus costs
        ***********************************/
        public int[,] getRushDaysOrder()
        {
            try
            {
                string rushOrderQuote = @"rushOrderPrices.txt";
                string[] array = File.ReadAllLines(rushOrderQuote);
                StreamReader reader = new StreamReader(rushOrderQuote);

                for (int i = 0; i < array.Length; i++)
                {
                    int row = i / 3;
                    int col = i % 3;

                    array2D[row, col] = int.Parse(array[i]);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Error, reading the file");
            }

            return array2D;
        }

        /************************************
        * Get Rush Days cost. 
        ***********************************/
        public int RushOrderCost()
        {
            int rushDays = 0;
            int[,] rushList = getRushDaysOrder();
            int rushRow = 0;
            int rushCol =  0;

            if (Surface < BASE_SIZE)
            {
                if (RushDays == RUSH_DAYS1)
                {
                    rushRow = 0;
                }
                else if (RushDays == RUSH_DAYS2)
                {
                    rushRow = 1;
                }
                else if(RushDays == RUSH_DAYS3)
                {
                    rushRow = 2;
                }
                else
                {
                    rushDays = 0;
                }
               
            }
            else if (Surface > BASE_SIZE || Surface < 2000)
            {
                if (RushDays == RUSH_DAYS1)
                {
                    rushCol = 0;
                }
                else if (RushDays == RUSH_DAYS2)
                {
                    rushCol = 1;
                }
                else if (RushDays == RUSH_DAYS3)
                {
                    rushCol = 2;
                }
                else
                {
                    rushDays = 0;
                }
            }
            return rushDays = rushList[rushRow, rushCol];
            
        }
        
       
    }

}
