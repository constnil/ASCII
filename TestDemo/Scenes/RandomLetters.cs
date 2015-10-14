using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASCII;

namespace TestDemo.Scenes
{
	public class RandomLetters : Scene
	{
		protected override void Setup() {
			var consoleBuffer = new CHAR_INFO[Width * Height];

			for (int h = 0; h < Height; ++h) {
				for (int w = 0; w < Width; ++w) {
					consoleBuffer[w + Width * h].AsciiChar = 'A'/*(char)Random.Next(256)*/;
					consoleBuffer[w + Width * h].Attributes = (UInt16)Random.Next(256);
				}
			}

			var charBufSize = new COORD {
				X = Width,
				Y = Height,
			};
			var characterPos = new COORD {
				X = 0,
				Y = 0,
			};

			WriteConsoleOutput(
				WriteHandle, consoleBuffer, charBufSize, characterPos, ref WindowSize);
		}

		protected override void Present() { }
		protected override void TearDown() { }
	}
}
