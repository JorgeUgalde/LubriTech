﻿using LubriTech.Model.Supplier_Information;
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
        /// Obtiene o establece la unidad de medida del artículo.
        /// </summary>
        public string measureUnit { set; get; }

        /// <summary>
        /// Estado del artículo (activo o inactivo).
        /// </summary>
        public string state { set; get; }

        /// <summary>
        /// Recorrido recomendado para el artículo.
        /// </summary>
        public double recommendedServiceInterval { set; get; }

        /// <summary>
        /// Tipo del artículo (producto o servicio).
        /// </summary>
        public ItemType itemType { set; get; }

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
        /// <param name="type">El tipo del artículo (producto o servicio).</param>
        /// param name="recommendedServiceInterval">El recorrido recomendado para el artículo.</param>
        public Item(string code, string name, string measureUnit, string state, double recommendedServiceInterval, ItemType itemType)
        {
            this.code = code;
            this.name = name;
            this.measureUnit = measureUnit;
            this.state = state;
            this.itemType = itemType;
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
