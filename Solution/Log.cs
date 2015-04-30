using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public delegate void LogEventHandler(String message);

namespace WaveManagerApp
{

	class Log
	{
		public static event LogEventHandler logEvent;

		public static void info(string message)
		{
			log("info",message);
		}

		public static void error(string message)
		{
			log("error", message);
		}

		private static void log(string type, string message)
		{
			string date = DateTime.Now.ToString("MM/dd/yyyy - HH:mm:ss");
			Console.Write(type+": "+message);
			if (logEvent != null)
				logEvent(date+": "+message);
		}
	}

}
