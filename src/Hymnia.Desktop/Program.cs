using System;
using System.Runtime.InteropServices;
using Avalonia;

using Velopack;

namespace SDAHymns.Desktop;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        CheckArchitecture();
        VelopackApp.Build().Run();
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    private static void CheckArchitecture()
    {
        // Only run this check on Windows for now as per the user's installer context
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return;

        var osArch = RuntimeInformation.OSArchitecture;
        var processArch = RuntimeInformation.ProcessArchitecture;

#if TARGET_X64
        if (osArch == Architecture.Arm64)
        {
            NativeMethods.MessageBox(IntPtr.Zero, 
                "You are running the x64 version of Hymnia on an ARM64 machine. \n\nPlease download the ARM64 version for better performance and battery life.", 
                "Hymnia - Architecture Mismatch", 0x00000030); // 0x30 = Warning icon
        }
#elif TARGET_ARM64
        if (osArch == Architecture.X64)
        {
            NativeMethods.MessageBox(IntPtr.Zero, 
                "You are trying to run the ARM64 version of Hymnia on an x64 machine. \n\nThis version is not compatible with your processor. Please download the x64 version for stability.", 
                "Hymnia - Architecture Mismatch", 0x00000030); // 0x30 = Warning icon
        }
#endif
    }

    private static class NativeMethods
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .With(new Win32PlatformOptions
            {
                RenderingMode = new[] { Win32RenderingMode.AngleEgl, Win32RenderingMode.Wgl, Win32RenderingMode.Software }
            })
            .LogToTrace();
}
