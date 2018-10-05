using Sokoban.Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
	public class OutputView
	{
		public void WelcomeScreen()
		{
			Console.WriteLine("______________________________________________________");
			Console.WriteLine("|  Welkom bij Sokoban                                |");
			Console.WriteLine("|                                                    |");
			Console.WriteLine("| betekenis van de symbolen   |  doel van het spel   |");
			Console.WriteLine("|                             |                      |");
			Console.WriteLine("| spatie : outerspace         |  duw met de truck    |");
			Console.WriteLine("|      █ : muur               |  de krat(ten)        |");
			Console.WriteLine("|      . : vloer              |  naar de bestemming  |");
			Console.WriteLine("|      O : krat               |                      |");
			Console.WriteLine("|      0 : krat op bestemming |                      |");
			Console.WriteLine("|      x : bestemming         |                      |");
			Console.WriteLine("|      @ : truck              |                      |");
			Console.WriteLine("|____________________________________________________|");
		}

		public void ChooseMaze()
		{
			Console.WriteLine();
			Console.WriteLine("Kies een doolhof (1 - 6), s = stop");
		}

		public void FileNotFound()
		{
			Console.WriteLine("Welk doolhof?");
		}

		public void DisplayMaze(string[] values)
		{
			Console.Clear();
			Console.WriteLine("┌─────────┐");
			Console.WriteLine("│ Sokoban │");
			Console.WriteLine("└─────────┘");
			Console.WriteLine();
			Console.WriteLine("──────────────────────────────────────────────────────────────────────────");
			foreach (string l in values)
			{
				Console.WriteLine(l);
			}
			Console.WriteLine("──────────────────────────────────────────────────────────────────────────");
			Console.WriteLine("> Gebruik pijltjestoetsen ");
		}
	}
}