using System.Runtime.InteropServices;

namespace StubHttpServer
{
    internal static class EnvironmentContext
    {
        public static bool IsWindows()
           => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        public static bool IsMac()
            => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
        
        public static bool IsLinux()
           => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
    }
}