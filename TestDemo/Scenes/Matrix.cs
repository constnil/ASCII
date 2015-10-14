using System;
using ASCII;

namespace TestDemo.Scenes
{
	public class Matrix : Scene
	{
		protected override void Setup() { }

		protected override void Present() {
				var position = new COORD {
					X = (short)Random.Next(Width),
					Y = (short)Random.Next(Height),
				};

				if (Random.Next() % 2 == 0) {
					SetConsoleTextAttribute(WriteHandle, 2);
				}
				else {
					SetConsoleTextAttribute(WriteHandle, 10);
				}

				SetConsoleCursorPosition(WriteHandle, position);

				if (Random.Next() % 2 == 0) {
					Console.Write("0");
				}
				else {
					Console.Write("1");
				}
		}

		protected override void TearDown() { }
	}
}
