﻿using LubriTech.Model.Item_Information;
using LubriTech.Model.items_Information;
using LubriTech.Model.Vehicle_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    /// <summary>
    ///Controller class that manages business logic regarding items.
    /// It uses the class model <see cref="Item_Model"/> to obtain useful methods.
    /// </summary>
    public class Item_Controller
    {
        /// <summary>
        /// Retrieves all items.
        /// </summary>
        /// <returns>A list of all items.</returns>
        public List<Item> getAll()
        {
            return new Item_Model().loadAllitems();
        }

        /// <summary>
        /// Retrieves an item by its code.
        /// </summary>
        /// <param name="code">Code of the item.</param>
        /// <returns>Itemn object, or null if the item was not found.</returns>
        public Item get(string code)
        {
            return new Item_Model().getItem(code);
        }

        /// <summary>
        /// Inserts or updates an item in the database.
        /// </summary>
        /// <param name="item">Item object to update or insert.</param>
        /// <returns>True if the operation was succesful, otherwise false.</returns>
        public bool UpSert(Item item)
        {
            return new Item_Model().UpSertItem(item);
        }
    
    }
}
