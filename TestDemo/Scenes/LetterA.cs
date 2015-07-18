using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASCII;

namespace TestDemo.Scenes
{
	public class LetterA : Scene
	{
		protected override void Setup() {
			var letterA = new CHAR_INFO {
				AsciiChar = 'A',
			};

			letterA.Attributes = (UInt16)
				(FOREGROUND_RED | FOREGROUND_INTENSITY |
				 BACKGROUND_RED | BACKGROUND_GREEN | BACKGROUND_INTENSITY);

			var charBufSize = new COORD {
				X = 1,
				Y = 1,
			};
			var characterPos = new COORD {
				X = 0,
				Y = 0,
			};

			var writeArea = new SMALL_RECT {
				Left = 0,
				Top = 0,
				Right = 0,
				Bottom = 0,
			};

			WriteConsoleOutput(
				WriteHandle, new CHAR_INFO[] { letterA }, charBufSize, characterPos, ref writeArea);
			Console.Write("\n");
		}

		protected override void Present() { }
		protected override void TearDown() { }
	}
}
