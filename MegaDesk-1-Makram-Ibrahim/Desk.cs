/*****************************************************************
 * Author: Makram Ibrahim
 * Instructor: Brother Blazzard
 * CIT 365 - .NET Software Development
 * Date: Feb 9, 2018
 * Summary:
 *  this programming exercise is to apply additional concepts
 *  presented in the readings and content to the MegaDesk application. 
 *  Those requirements call for modifying your previous version 
 *  of MegaDesk and adding features such as two-dimensional arrays,
 *  JSON serialization, and adding library references as needed.
 * ***************************************************************/

namespace MegaDesk_4_Makram_Ibrahim
{
    struct Desk
    {
        public decimal Width                  { get; set; }
        public decimal Depth                  { get; set; }
        public int NumOfDrawers               { get; set; }
        public SurfaceMaterials surfMaterials { get; set; }

        public const decimal MIN_WIDTH = 24;
        public const decimal MAX_WIDTH = 96;
        public const decimal MIN_DEPTH = 12;
        public const decimal MAX_DEPTH = 48;
    }

    /***********************
     * Set our own data type 
     **********************/
    public enum SurfaceMaterials
    {
        Laminate = 100,
        Oak = 200,
        Rosewood = 300,
        Veneer = 125,
        Pine = 50
    };
}

