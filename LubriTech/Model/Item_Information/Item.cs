using LubriTech.Model.Supplier_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Item_Information
{
    /// <summary>
    /// Representa un artículo el cuál puede ser un producto o servicio en el sistema.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Código único del artículo.
        /// </summary>
        public string code { set; get; }

        /// <summary>
        /// Nombre del artículo.
        /// </summary>
        public string name { set; get; }

        /// <summary>
        /// Precio de venta del artículo, es decir, el monto por el cuál se vende a clientes.
        /// </summary>
        public double sellPrice { set; get; }

        /// <summary>
        /// Obtiene o establece la unidad de medida del artículo.
        /// </summary>
        public string measureUnit { set; get; }

        /// <summary>
        /// Estado del artículo (activo o inactivo).
        /// </summary>
        public string state { set; get; }

        /// <summary>
        /// Cantidad en inventario del artículo.
        /// </summary>
        public double stock { set; get; }

        /// <summary>
        /// Precio de compra del artículo, es decir, el monto por el cuál se compra el artículo.
        /// </summary>
        public double purchasePrice { set; get; }

        /// <summary>
        /// Tipo del artículo (producto o servicio).
        /// </summary>
        public string type { set; get; }

        /// <summary>
        /// Recorrido recomendado para el artículo.
        /// </summary>
        public double recommendedServiceInterval { set; get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Item"/>.
        /// </summary>
        public Item()
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Item"/> con los valores especificados.
        /// </summary>
        /// <param name="code">El código del artículo.</param>
        /// <param name="name">El nombre del artículo.</param>
        /// <param name="sellPrice">El precio de venta del artículo.</param>
        /// <param name="measureUnit">La unidad de medida del artículo.</param>
        /// <param name="state">El estado del artículo (activo o inactivo).</param>
        /// <param name="stock">El stock del artículo.</param>
        /// <param name="purchasePrice">El precio de compra del artículo.</param>
        /// <param name="type">El tipo del artículo (producto o servicio).</param>
        /// param name="recommendedServiceInterval">El recorrido recomendado para el artículo.</param>
        public Item(string code, string name, double sellPrice, string measureUnit, string state, double stock, double purchasePrice, string type, double recommendedServiceInterval)
        {
            this.code = code;
            this.name = name;
            this.sellPrice = sellPrice;
            this.measureUnit = measureUnit;
            this.state = state;
            this.stock = stock;
            this.purchasePrice = purchasePrice;
            this.type = type;
            this.recommendedServiceInterval = recommendedServiceInterval;
        }

        /// <summary>
        /// Devuelve una cadena que representa el objeto actual.
        /// </summary>
        /// <returns>El nombre del artículo.</returns>
        public override string ToString()
        {
            return name;
        }
    }
}
