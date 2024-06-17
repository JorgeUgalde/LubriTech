using LubriTech.Model.Supplier_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    /// <summary>
    /// Controlador que maneja la lógica de negocio relacionada con los proveedores. Utiliza el modelo <see cref="Supplier_Model"/> para obtener la información
    /// </summary>
    public class Supplier_Controller
    {
        /// <summary>
        /// Obtiene todos los proveedores.
        /// </summary>
        /// <returns>Lista de todos los proveedores.</returns>
        public List<Supplier> getAll()
        {
            return new Supplier_Model().loadAllSuppliers();
        }

        /// <summary>
        /// Obtiene un proveedor por su identificador.
        /// </summary>
        /// <param name="id">Identificador del proveedor a obtener.</param>
        /// <returns>Proveedor encontrado, o null si no se encuentra.</returns>
        public Supplier GetSupplier(string id)
        {
            return new Supplier_Model().getSupplier(id);
        }

        /// <summary>
        /// Actualiza o inserta un proveedor en la base de datos.
        /// </summary>
        /// <param name="supplier">Objeto Supplier que representa al proveedor a actualizar o insertar.</param>
        /// <returns>true si la operación se realizó con éxito, false si falló.</returns>
        public Boolean Upsert(Supplier supplier)
        {
            return new Supplier_Model().upsertSupplier(supplier);
        }

        /// <summary>
        /// Elimina un proveedor.
        /// </summary>
        /// <param name="supplierId">Identificador del proveedor a eliminar.</param>
        public void Delete(string supplierId)
        {
            new Supplier_Model().deleteSupplier(supplierId);
        }
    }
}
