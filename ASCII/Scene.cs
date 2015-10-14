using System.Threading;
using System;

namespace ASCII
{
	public abstract partial class Scene
	{
		#region Statics
		protected static IntPtr WriteHandle { get; private set; }
		protected static IntPtr ReadHandle { get; private set; }

		protected static Random Random { get; private set; }
		protected static short Width { get; private set; }
		protected static short Height { get; private set; }

		protected static SMALL_RECT WindowSize;
		protected static COORD BufferSize;

		public static void Initialize(string title, int width, int height) {
			WriteHandle = GetStdHandle(STD_OUTPUT_HANDLE);
			Console.Title = title;

			Random = new Random(Guid.NewGuid().GetHashCode());
			Width = (short)width;
			Height = (short)height;

			WindowSize = new SMALL_RECT {
				Left = 0,
				Top = 0,
				Right = (short)(width - 1),
				Bottom = (short)(height - 1),
			};
			SetConsoleWindowInfo(WriteHandle, true, ref WindowSize);

			BufferSize = new COORD {
				X = 80,
				Y = 50,
			};
			SetConsoleScreenBufferSize(WriteHandle, BufferSize);
		}
		#endregion

		#region Fields & Constructors
		#endregion

		#region Template Methods
		protected abstract void Setup();
		protected abstract void Present();
		protected abstract void TearDown();

		protected virtual bool Quit() {
			if (Console.KeyAvailable) {
				Console.ReadKey(true);
				return true;
			}
			return false;
		}
		#endregion

		#region Public Interface
		public void Run() {
			Setup();
			while (!Quit()) {
				Present();
				Thread.Sleep(1);
			}
			TearDown();
		}
		#endregion
	}
}
