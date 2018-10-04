﻿using Sokoban.Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
	public class InputView
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
			Console.WriteLine("Kies een doolhof (1 - 4), s = stop");
		}

		public void DisplayMaze(Maze maze)
		{
			Console.Clear();

			for (int i = 0; i < maze.FieldDoublyDoublyLinkedList.RowFirst.Length; i++)
			{
				FieldDoublyDoublyLink item = new FieldDoublyDoublyLink();
				item = maze.FieldDoublyDoublyLinkedList.RowFirst[i];

				while (item != null)
				{
					switch (item.GamePiece.Type)
					{
						case "floor":
							if(item.GamePiece.HasTruck)
								Console.Write("@");
							else if(item.GamePiece.HasChest)
								Console.Write("O");
							else
								Console.Write(".");
							break;
						case "destination":
							if (item.GamePiece.HasTruck)
								Console.Write("@");
							else if (item.GamePiece.HasChest)
								Console.Write("0");
							else
								Console.Write("X");
							break;
						case "wall":
							Console.Write("█");
							break;
						case "empty":
							Console.Write(" ");
							break;
						default:
							break;
					}
					item = item.Next;
				}
				Console.WriteLine();
			}
		}

	}
}