using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASCII
{
	public abstract class Demo
	{
		#region Fields & Constructors
		private SceneList _scenes = null;
		#endregion

		protected abstract SceneList SetupScenes();

		#region Public Interface
		public void Initialize(string title, int width, int height) {
			Scene.Initialize(title, width, height);
			_scenes = SetupScenes();
		}

		public void Run() {
			_scenes.ForEach(c => c.Run());
		}
		#endregion
	}
}
