using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
	public class Controller
	{
		private InputView inputView;
		private OutputView outputView;
		public Parser parser { get; set; }

		public Controller()
		{
			inputView = new InputView();
			outputView = new OutputView();
			parser = new Parser();
		}

		public void StartGame()
		{
			inputView.WelcomeScreen();
			inputView.ChooseMaze();

			char choosenMaze = outputView.ReadLine();
			if (choosenMaze != 's')
				parser.ParseMaze(choosenMaze);
			else
				Environment.Exit(0);

			inputView.DisplayMaze(parser.Maze);
			Play();

			Console.ReadLine();
		}

		private void Play()
		{
			while (true)
			{
				var ch = Console.ReadKey().Key;
				parser.Maze.SwapFields(ch);
				inputView.DisplayMaze(parser.Maze);
			}
		}		
	}
}