using LubriTech.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LubriTech
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicaci�n. El usuario debe autenticarse antes de poder acceder a la aplicaci�n.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //frmLogin login = new frmLogin();

            //// Mostrar el formulario de login
            //Application.Run(login);

            //// Si el formulario de login est� cerrado y no se ha autenticado, salir de la aplicaci�n
            //if (!login.IsLogged())
            //{
            //    return;
            //}

            // Continuar con la ejecuci�n de la aplicaci�n si el login fue exitoso
            Application.Run(new MDI_View());
        }

    }
}