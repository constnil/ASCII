using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASCII;
using TestDemo.Scenes;

namespace TestDemo
{
	public class TestDemo : Demo
	{
		protected override SceneList SetupScenes() {
			return new SceneList() {
				new Empty(),
				new LetterA(),
				new RandomLetters(),
				new Matrix(),
			};
		}
	}
}
