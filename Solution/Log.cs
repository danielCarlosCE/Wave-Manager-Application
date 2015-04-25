using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public delegate void ErrorEventHandler(String message);

namespace WaveManagerApp
{

	class Log
	{
		public static event ErrorEventHandler errorEvent;


		public static void error(string message)
		{
			Console.Write(message);
			if (errorEvent != null)
				errorEvent(message);
		}
	}

}
