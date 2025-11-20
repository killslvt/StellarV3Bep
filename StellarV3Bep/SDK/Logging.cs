namespace StellarV3Bep.SDK
{
    internal class Logging
    {
        public static void Log(string msg, LType type = LType.Info)
        {
            Main._logSource.LogMessage($"[{type}] {msg}");
        }


        /*public static ConsoleColor GetColor(LType type)
        {
            return type switch
            {
                LType.Info => ConsoleColor.White,
                LType.Warning => ConsoleColor.Yellow,
                LType.Error => ConsoleColor.Red,
                LType.Success => ConsoleColor.Green,
                LType.Debug => ConsoleColor.Cyan,
                LType.Join => ConsoleColor.Green,
                LType.Leave => ConsoleColor.Red,
                _ => ConsoleColor.Gray,
            };
        }*/
    }

    internal enum LType
    {
        Info,
        Warning,
        Error,
        Success,
        Debug,
        Join,
        Leave
    }
}
