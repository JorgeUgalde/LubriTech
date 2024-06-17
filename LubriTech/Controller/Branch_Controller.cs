using LubriTech.Model.Branch_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    /// <summary>
    /// Controlador que maneja la lógica de negocio relacionada con las sucursales. Utiliza el modelo <see cref="Branch_Model"/> para obtener la información.
    /// </summary>
    public class Branch_Controller
    {
        /// <summary>
        /// Obtiene todas las sucursales.
        /// </summary>
        /// <returns>Lista de todas las sucursales.</returns>
        public List<Branch> getAll()
        {
            return new Branch_Model().loadAllBranches();
        }

        /// <summary>
        /// Obtiene una sucursal por su ID.
        /// </summary>
        /// <param name="Id">Identificacion de la sucursal a obtener.</param>
        /// <returns>Sucursal encontrada, o null si no se encuentra.</returns>
        public Branch get(int Id)
        {
            return new Branch_Model().GetBranch(Id);
        }

        /// <summary>
        /// Actualiza o inserta una sucursal en la base de datos.
        /// </summary>
        /// <param name="branch">Objeto Branch que representa la sucursal a actualizar o insertar.</param>
        /// <returns>true si la operación se realizó con éxito, false si falló.</returns>
        public bool Upsert(Branch branch)
        {
            return new Branch_Model().UpsertBranch(branch);
        }
    }
}
