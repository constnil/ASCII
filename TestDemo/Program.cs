using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASCII;

namespace TestDemo
{
	class Program
	{
		private const int WIDTH = 80;
		private const int HEIGHT = 50;

		static void Main(string[] args) {
			var demo = new TestDemo();
			demo.Initialize("ASCII Demo", WIDTH, HEIGHT);
			demo.Run();
		}
	}
}
