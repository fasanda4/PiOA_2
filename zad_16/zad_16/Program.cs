using System;
using System.Windows.Forms;

namespace ColorChangerApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ColorChangerForm сolorсhangerForm = new ColorChangerForm();
            Application.Run(сolorсhangerForm);

        }
    }
}