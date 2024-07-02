using LubriTech.Model;
using LubriTech.Model.InventoryManagment_Information;
using LubriTech.Model.items_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LubriTech.Controller
{
    /// <summary>
    /// Controller class that manages business logic regarding detail lines.
    /// It uses the class model <see cref="DetailLine_Model"/> to obtain useful methods.
    /// </summary>
    public class DetailLine_Controller
    {

        DetailLine_Model detailLineModel = new DetailLine_Model();

        /// <summary>
        /// Retrieves all detail lines.
        /// </summary>
        /// <returns>A list of all the detail lines.</returns>
        public List<DetailLine> getAll()
        {
            return detailLineModel.loadAllDetailLines();
        }

        /// <summary>
        /// Inserts or updates a detail line in the database.
        /// </summary>
        /// <param name="detailLine">Detail line object to insert or update.</param>
        /// <returns>True if the operation was succesful, otherwise, false.</returns>
        public Boolean upsert(DetailLine detailLine)
        {
            return detailLineModel.upsertDetailLine(detailLine);
        }

        /// <summary>
        /// Retrieves a detail line by the code of the item and id of the inventory managment.
        /// </summary>
        /// <param name="itemCode">Item of the detail line.</param>
        /// <param name="inventoryManagmentId">Inventory managment of the detail line.</param>
        /// <returns>Detail line object, or null if the detail line was not found.</returns>
        public DetailLine getInventoryManagment(string itemCode, int inventoryManagmentId)
        {
            return new DetailLine_Model().getDetailLine(itemCode, inventoryManagmentId);
        }
    }
}
