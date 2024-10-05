using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DesignPatterns.Creational
{
	internal class SingletonDemo
	{
		static void Main(string[] args)
		{
			var c = Logger.getInstance();
			Console.WriteLine(c == null);
		}
	}
	class Logger
	{
		static Logger logger { get; set; }
		public static Logger getInstance()
		{
			if (logger == null)
			{
				logger = new Logger();
			}
			return logger;
		}
	}

}
