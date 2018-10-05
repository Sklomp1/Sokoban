using Sokoban.Model_Layer;
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
		private Parser parser;
		private Maze maze;

		public Controller()
		{
			inputView = new InputView();
			outputView = new OutputView();
			parser = new Parser();
		}

		public void StartGame()
		{
			outputView.WelcomeScreen();
			outputView.ChooseMaze();

			maze = parser.ParseMaze(inputView.ReadLine());
			ShowMaze();

			Play();
		}

		private void ShowMaze()
		{
			Console.Clear();

			for (int i = 0; i < maze.FieldDoublyDoublyLinkedList.RowFirst.Length; i++)
			{
				string value = "";
				FieldDoublyDoublyLink item = new FieldDoublyDoublyLink();
				item = maze.FieldDoublyDoublyLinkedList.RowFirst[i];

				while (item != null)
				{
					switch (item.Floor.Type)
					{
						case "floor":
							if (item.Floor.Truck != null)
								value += '@';
							else if (item.Floor.Chest != null)
								value += 'O';
							else
								value += '.';
							break;
						case "destination":
							if (item.Floor.Truck != null)
								value += '@';
							else if (item.Floor.Chest != null)
								value += '0';
							else
								value += 'X';
							break;
						case "wall":
							value += '█';
							break;
						case "empty":
							value += ' ';
							break;
						default:
							break;
					}
					item = item.Next;
				}
				Console.WriteLine(value);
			}

		}

		private void Play()
		{
			bool play = true;
			while (play)
			{
				parser.Maze.MoveTruck(inputView.ReadKey());
				ShowMaze();
				play = CheckWinner();
			}
			Console.ReadLine();
		}

		private bool CheckWinner()
		{
			if (parser.Maze.Isfinished())
			{
				Console.WriteLine("You win the game!");
				return false;
			}
			return true;
		}
	}
}