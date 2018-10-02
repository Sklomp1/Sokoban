using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
	public class Field
	{

		public int y { get; set; }
		public int x { get; set; }


		private List<GamePiece> gamePieces;

		public Field()
		{
			gamePieces = new List<GamePiece>();
		}
	}
}