using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Gw2Runes
{
    internal static class Program
    {
        const string Resource = "Gw2Runes.Resources.Libraries.AndaForce.dll";

        /// <summary>
        ///     Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            using (Stream stm = Assembly.GetExecutingAssembly().GetManifestResourceStream(Resource))
            {
                var ba = new byte[(int) stm.Length];
                stm.Read(ba, 0, (int) stm.Length);

                return Assembly.Load(ba);
            }
        }
    }
}