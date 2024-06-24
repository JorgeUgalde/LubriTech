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
        /// Punto de entrada principal para la aplicación. El usuario debe autenticarse antes de poder acceder a la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //frmLogin login = new frmLogin();

            //// Mostrar el formulario de login
            //Application.Run(login);

            //// Si el formulario de login está cerrado y no se ha autenticado, salir de la aplicación
            //if (!login.IsLogged())
            //{
            //    return;
            //}

            // Continuar con la ejecución de la aplicación si el login fue exitoso
            Application.Run(new MDI_View());
        }

    }
}