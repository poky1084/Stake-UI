using System;
using System.Drawing;
using System.Drawing.Text;
using System.Reflection;
using System.Runtime.InteropServices;

public static class FontHelper
{
    private static PrivateFontCollection _fonts = new PrivateFontCollection();
    public static FontFamily Montserrat { get; private set; }

    static FontHelper()
    {
        // Use the assembly where FontHelper is defined, not the executing one
        var assembly = typeof(FontHelper).Assembly;  // <-- fix

        using (var stream = assembly.GetManifestResourceStream("STAKE_UI.MINES.Fonts.Montserrat-Regular.ttf"))
        {
            if (stream == null)
            {
                // Debug: print all available resource names to find the correct one
                foreach (var name in assembly.GetManifestResourceNames())
                    System.Diagnostics.Debug.WriteLine(name);

                throw new Exception("Font resource not found. Check resource name above in Output window.");
            }

            byte[] data = new byte[stream.Length];
            stream.Read(data, 0, data.Length);
            IntPtr ptr = Marshal.AllocCoTaskMem(data.Length);
            Marshal.Copy(data, 0, ptr, data.Length);
            _fonts.AddMemoryFont(ptr, data.Length);
            Marshal.FreeCoTaskMem(ptr);
        }

        Montserrat = _fonts.Families[0];
    }
}