using LubriTech.Model.Item_Information;
using LubriTech.Model.items_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    /// <summary>
    /// Controlador que maneja la lógica de negocio relacionada con los ítems. Utiliza el modelo <see cref="Item_Model"/> para obtener la información
    /// </summary>
    public class Item_Controller
    {
        /// <summary>
        /// Obtiene todos los ítems.
        /// </summary>
        /// <returns>Lista de todos los ítems.</returns>
        public List<Item> getAll()
        {
            return new Item_Model().loadAllitems();
        }

        /// <summary>
        /// Obtiene un ítem por su código.
        /// </summary>
        /// <param name="code">Código del ítem a obtener.</param>
        /// <returns>Ítem encontrado, o null si no se encuentra.</returns>
        public Item get(string code)
        {
            return new Item_Model().getItem(code);
        }

        /// <summary>
        /// Actualiza o inserta un ítem en la base de datos.
        /// </summary>
        /// <param name="item">Objeto Item que representa al ítem a actualizar o insertar.</param>
        /// <returns>true si la operación se realizó con éxito, false si falló.</returns>
        public bool UpSert(Item item)
        {
            return new Item_Model().UpSertItem(item);
        }
    
    }
}
