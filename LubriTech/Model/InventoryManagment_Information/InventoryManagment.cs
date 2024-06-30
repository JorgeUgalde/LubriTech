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

namespace LubriTech.Model.InventoryManagment_Information
{
    /// <summary>
    /// Represents an inventory managment document.
    /// </summary>
    public class InventoryManagment
    {
        /// <summary>
        /// Document Id which is an identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Date of the document.
        /// </summary>
        public DateTime DocumentDate { get; set; }

        /// <summary>
        /// The supplier to which the document is related.
        /// </summary>
        public Supplier Supplier { get; set; }

        /// <summary>
        /// State of the document (active-inactive).
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Total amount of the document.
        /// </summary>
        public double TotalAmount { get; set; }

        /// <summary>
        /// The branch to which the document is related.
        /// </summary>
        public Branch Branch { get; set; }

        /// <summary>
        /// The type of the document.
        /// </summary>
        public string DocumentType { get; set; }

        /// <summary>
        /// Default constructor from the inventory managment class.
        /// </summary>
        public InventoryManagment() { }

        /// <summary>
        /// The constructor that initializes the properties with the given values.
        /// </summary>
        /// <param name="id">The identification of the document.</param>
        /// <param name="documentDate">The date of the document.</param>
        /// <param name="supplier">The supplier related to the document.</param>
        /// <param name="state">The state of the document.</param>
        /// <param name="totalAmount">The total amount of the document.</param>
        /// <param name="branch">The branch related to the document.</param>
        /// <param name="documentType">The document type.</param>
        public InventoryManagment(int id, DateTime documentDate, Supplier supplier, string state, double totalAmount, Branch branch, string documentType)
        {
            this.Id = id;
            this.DocumentDate = documentDate;
            this.Supplier = supplier;
            this.State = state;
            this.TotalAmount = totalAmount;
            this.Branch = branch;
            this.DocumentType = documentType;
        }

        /// <summary>
        /// Gets the id of the related supplier.
        /// </summary>
        /// <returns>The supplier id.</returns>
        public string getSupplierId()
        {
            return this.Supplier.id;
        }

        /// <summary>
        /// Gets the id of the related branch.
        /// </summary>
        /// <returns>The id of the branch.</returns>
        public int getBranchId()
        {
            return this.Branch.Id;
        }

        /// <summary>
        /// Returns a string which represents the current object.
        /// </summary>
        /// <returns>A string that represents the document.</returns>
        public override string ToString()
        {
            return Id + "\n" + DocumentDate + "\n" + Supplier.name + "\n" + State + "\n" + TotalAmount + "\n" + Branch.Name + "\n" + DocumentType;
        }

    }
}
