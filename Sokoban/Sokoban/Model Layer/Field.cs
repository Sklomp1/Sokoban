<<<<<<< HEAD
﻿using System;
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
=======
﻿using System;
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
>>>>>>> d268cc066d82912563e93974b5133e4bdb11c0e5
}