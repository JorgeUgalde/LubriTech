using LubriTech.Model;
using LubriTech.Model.InventoryManagment_Information;
using LubriTech.Model.items_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    /// <summary>
    /// Controller class that manages business logic regarding inventory managment.
    /// It uses the class model <see cref="InventoryManagment_Model"/> to obtain useful methods.
    /// </summary>
    public class InventoryManagment_Controller
    {

        InventoryManagment_Model inventoryManagmentModel = new InventoryManagment_Model();

        /// <summary>
        /// Retrieves all inventory managment documents.
        /// </summary>
        /// <returns>A list of all the inventory managment documents.</returns>
        public List<InventoryManagment> getAll()
        {
            return inventoryManagmentModel.loadAllInventoryManagments();
        }

        /// <summary>
        /// Inserts or updates an inventory managment document in the database.
        /// </summary>
        /// <param name="inventoryManagment">Inventory managment object to insert or update.</param>
        /// <returns>True if the operation was succesful, otherwise, false.</returns>
        public int upsert(InventoryManagment inventoryManagment)
        {
            return inventoryManagmentModel.upsertInventoryManagment(inventoryManagment);
        }

        /// <summary>
        /// Retrieves an inventory managment by its id.
        /// </summary>
        /// <param name="id">Identification of the inventory managment document.</param>
        /// <returns>Inventory managment object, or null if the inventory managment was not found.</returns>
        public InventoryManagment getInventoryManagment(int id)
        {
            return new InventoryManagment_Model().getInventoryManagment(id);
        }

        /// <summary>
        /// Deletes an inventory managment by its id.
        /// </summary>
        /// <param name="id">Identification of the inventory managment document.</param>
        /// <returns>True if the operation was succesful, otherwise, false.</returns>
        public Boolean delete(int id)
        {
            return new InventoryManagment_Model().deleteInventoryManagment(id);
        }
    }
}
