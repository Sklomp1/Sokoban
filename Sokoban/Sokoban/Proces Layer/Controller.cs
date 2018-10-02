﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
	public class Controller
	{
		private InputView inputView;
		private OutputView outputView;
		private Game game;

		public Controller()
		{
			inputView = new InputView();
			outputView = new OutputView();
			game = new Game();
		}

		public void startGame()
		{
			inputView.WelcomeScreen();
			inputView.ChooseMaze();

			char choosenMaze = outputView.ReadLine();
			if (choosenMaze != 's')
				parseMaze(choosenMaze);
			else
				Environment.Exit(0);


			Console.ReadLine();
		}

		public void parseMaze(char mazeNumber)
		{

		}
	}
}