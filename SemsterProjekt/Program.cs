namespace SemsterProjekt
{
    /// <summary>
    /// Enthält den Einstiegspunkt der Anwendung.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt der Anwendung. Initialisiert die Anwendungskonfiguration
        /// und startet das Hauptfenster <see cref="Form1"/>.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}