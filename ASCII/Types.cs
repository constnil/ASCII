using System;
using System.Runtime.InteropServices;
using System.Drawing;

namespace ASCII
{
	[StructLayout(LayoutKind.Sequential)]
	public struct COORD
	{
		public short X;
		public short Y;
	}

	public struct SMALL_RECT
	{
		public short Left;
		public short Top;
		public short Right;
		public short Bottom;
	}

	public struct CONSOLE_SCREEN_BUFFER_INFO
	{
		public COORD dwSize;
		public COORD dwCursorPosition;
		public short wAttributes;
		public SMALL_RECT srWindow;
		public COORD dwMaximumWindowSize;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct CONSOLE_SCREEN_BUFFER_INFO_EX
	{
		public uint cbSize;
		public COORD dwSize;
		public COORD dwCursorPosition;
		public short wAttributes;
		public SMALL_RECT srWindow;
		public COORD dwMaximumWindowSize;

		public ushort wPopupAttributes;
		public bool bFullscreenSupported;

		//[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		//public COLORREF ColorTable[16];

		public static CONSOLE_SCREEN_BUFFER_INFO_EX Create() {
			return new CONSOLE_SCREEN_BUFFER_INFO_EX { cbSize = 96 };
		}
	}

	//[StructLayout(LayoutKind.Sequential)]
	//struct COLORREF
	//{
	//    public byte R;
	//    public byte G;
	//    public byte B;
	//}

	[StructLayout(LayoutKind.Sequential)]
	public struct COLORREF
	{
		public uint ColorDWORD;

		public COLORREF(Color color) {
			ColorDWORD = (uint)color.R + (((uint)color.G) << 8) + (((uint)color.B) << 16);
		}

		public Color GetColor() {
			return Color.FromArgb((int)(0x000000FFU & ColorDWORD),
			   (int)(0x0000FF00U & ColorDWORD) >> 8, (int)(0x00FF0000U & ColorDWORD) >> 16);
		}

		public void SetColor(Color color) {
			ColorDWORD = (uint)color.R + (((uint)color.G) << 8) + (((uint)color.B) << 16);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct CONSOLE_FONT_INFO
	{
		public int nFont;
		public COORD dwFontSize;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct CONSOLE_FONT_INFO_EX
	{
		public uint cbSize;
		public uint nFont;
		public COORD dwFontSize;
		public ushort FontFamily;
		public ushort FontWeight;

		const uint LF_FACESIZE = 32;
		fixed char FaceName[(int)LF_FACESIZE];
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct INPUT_RECORD
	{
		[FieldOffset(0)]
		public ushort EventType;
		[FieldOffset(4)]
		public KEY_EVENT_RECORD KeyEvent;
		[FieldOffset(4)]
		public MOUSE_EVENT_RECORD MouseEvent;
		[FieldOffset(4)]
		public WINDOW_BUFFER_SIZE_RECORD WindowBufferSizeEvent;
		[FieldOffset(4)]
		public MENU_EVENT_RECORD MenuEvent;
		[FieldOffset(4)]
		public FOCUS_EVENT_RECORD FocusEvent;
	};

	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct KEY_EVENT_RECORD
	{
		[FieldOffset(0), MarshalAs(UnmanagedType.Bool)]
		public bool bKeyDown;
		[FieldOffset(4), MarshalAs(UnmanagedType.U2)]
		public ushort wRepeatCount;
		[FieldOffset(6), MarshalAs(UnmanagedType.U2)]
		//public VirtualKeys wVirtualKeyCode;
		public ushort wVirtualKeyCode;
		[FieldOffset(8), MarshalAs(UnmanagedType.U2)]
		public ushort wVirtualScanCode;
		[FieldOffset(10)]
		public char UnicodeChar;
		[FieldOffset(12), MarshalAs(UnmanagedType.U4)]
		//public ControlKeyState dwControlKeyState;
		public uint dwControlKeyState;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct MOUSE_EVENT_RECORD
	{
		public COORD dwMousePosition;
		public uint dwButtonState;
		public uint dwControlKeyState;
		public uint dwEventFlags;
	}

	public struct WINDOW_BUFFER_SIZE_RECORD
	{
		public COORD dwSize;

		public WINDOW_BUFFER_SIZE_RECORD(short x, short y) {
			dwSize = new COORD();
			dwSize.X = x;
			dwSize.Y = y;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct MENU_EVENT_RECORD
	{
		public uint dwCommandId;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct FOCUS_EVENT_RECORD
	{
		public uint bSetFocus;
	}

	//CHAR_INFO struct, which was a union in the old days
	// so we want to use LayoutKind.Explicit to mimic it as closely
	// as we can
	[StructLayout(LayoutKind.Explicit)]
	public struct CHAR_INFO
	{
		[FieldOffset(0)]
		public char UnicodeChar;
		[FieldOffset(0)]
		public char AsciiChar;
		[FieldOffset(2)] //2 bytes seems to work properly
		public UInt16 Attributes;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct CONSOLE_CURSOR_INFO
	{
		public uint Size;
		public bool Visible;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct CONSOLE_HISTORY_INFO
	{
		public ushort cbSize;
		public ushort HistoryBufferSize;
		public ushort NumberOfHistoryBuffers;
		public uint dwFlags;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct CONSOLE_SELECTION_INFO
	{
		public uint Flags;
		public COORD SelectionAnchor;
		public SMALL_RECT Selection;

		// Flags values:
		public const uint CONSOLE_MOUSE_DOWN = 0x0008; // Mouse is down
		public const uint CONSOLE_MOUSE_SELECTION = 0x0004; //Selecting with the mouse
		public const uint CONSOLE_NO_SELECTION = 0x0000; //No selection
		public const uint CONSOLE_SELECTION_IN_PROGRESS = 0x0001; //Selection has begun
		public const uint CONSOLE_SELECTION_NOT_EMPTY = 0x0002; //Selection rectangle is not empty
	}

	// Enumerated type for the control messages sent to the handler routine
	public enum CtrlTypes : uint
	{
		CTRL_C_EVENT = 0,
		CTRL_BREAK_EVENT,
		CTRL_CLOSE_EVENT,
		CTRL_LOGOFF_EVENT = 5,
		CTRL_SHUTDOWN_EVENT,
	}
}
