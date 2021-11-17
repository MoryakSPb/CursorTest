using System.IO;
using System.Windows.Input;
using CursorTest.Properties;

namespace CursorTest;

public class CustomCursors
{
    static CustomCursors()
    {
        using Stream streamYellow = new MemoryStream(Resources.yellow);
        YellowCursor = new(streamYellow, false);
        streamYellow.Position = 0;
        YellowCursorWithDpiScale = new(streamYellow, true);
        using Stream streamGreen = new MemoryStream(Resources.green);
        GreenCursor = new(streamGreen, false);
        streamGreen.Position = 0;
        GreenCursorWithDpiScale = new(streamGreen, true);
    }

    public static Cursor YellowCursor { get; }
    public static Cursor YellowCursorWithDpiScale { get; }
    public static Cursor GreenCursor { get; }
    public static Cursor GreenCursorWithDpiScale { get; }
}