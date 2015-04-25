using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveManagerApp
{
	class Preferences
	{
		private static Color _waveColor = Color.Green;
		private static Color _waveBgColor = Color.Red;
		private static float _thickness = 1;

		public static Color WaveBgColor 
		{
			get { return _waveBgColor; }
			set { _waveBgColor = value; }
		}
		public static Color WaveColor
		{
			get { return _waveColor; }
			set { _waveColor = value; }
		}

		public static float Thickness
		{
			get { return _thickness; }
			set { _thickness = value; }
		}

		public static Pen PenForWave()
		{
			return new Pen(Preferences.WaveColor,_thickness);
		}

	}
}
