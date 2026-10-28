namespace oop_lab2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 21 mod 3 = 0
            // 21 mod 2 = 1
            // 21 mod 4 = 1
            // 21 mod 5 = 1
            // 21 mod 6 = 3
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}