namespace ardpad
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 

        public static string openedFilePath = "";

        [STAThread]
        static void Main(string[] args)
        {
            if(args.Length > 0) //birlikte açýldýysa
                openedFilePath = args[0];
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}