using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;
using System.Xml.Linq;
using LubriTech.Model.Supplier_Information;
using LubriTech.Model.Branch_Information;
using LubriTech.Model.Item_Information;

namespace LubriTech.Model.InventoryManagment_Information
{
    /// <summary>
    /// Represents a detail line related to an inventory managment document and an item.
    /// </summary>
    public class DetailLine
    {
        /// <summary>
        /// Item object related to the detail line.
        /// </summary>
        public Item Item { get; set; }

        /// <summary>
        /// Inventory managment object related to the detail line.
        /// </summary>
        public InventoryManagment InventoryManagment{ get; set; }

        /// <summary>
        /// Quantity of the item in the detail line.
        /// </summary>
        public double Quantity { get; set; }

        /// <summary>
        /// Total amount of the detail line.
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Unit cost of the item in the detail line.
        /// </summary>
        public double UnitCost { get; set; }

        /// <summary>
        /// Default constructor from the DetailLine class.
        /// </summary>
        public DetailLine() { }

        /// <summary>
        /// The constructor that initializes the properties with the given values.
        /// </summary>
        /// <param name="item">The item related to the detail line.</param>
        /// <param name="inventoryManagment">The inventory managment document related to the detail line.</param>
        /// <param name="quantity">The quantity of items in the detail line.</param>
        /// <param name="totalAmount">The total amount of the detail line.</param>
        public DetailLine(Item item, InventoryManagment inventoryManagment, double quantity, double totalAmount, double unitCost)
        {
            this.Item = item;
            this.InventoryManagment = inventoryManagment;
            this.Quantity = quantity;
            this.Amount = totalAmount;
            this.UnitCost = unitCost;
        }

        /// <summary>
        /// Gets the code of the related item.
        /// </summary>
        /// <returns>The item code.</returns>
        public string getItemCode()
        {
            return this.Item.code;
        }

        /// <summary>
        /// Gets the id of the related inventory managment document.
        /// </summary>
        /// <returns>The id of the inventory managment document.</returns>
        public int getInventoryManagmentId()
        {
            return this.InventoryManagment.Id;
        }

        /// <summary>
        /// Returns a string which represents the current object.
        /// </summary>
        /// <returns>A string that represents the document.</returns>
        public override string ToString()
        {
            return "Código de artículo: " + Item.code + " - Código de documento de gestión de inventario: " + InventoryManagment.Id;
        }

    }
}
