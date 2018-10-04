using Sokoban.Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
	public class Wall : GamePiece
	{
		public Wall()
		{
			Type = "wall";
		}

		public override void RemoveChest()
		{
			throw new NotImplementedException();
		}

		public override void RemoveTruck()
		{
			throw new NotImplementedException();
		}

		public override void SetChest()
		{
			throw new NotImplementedException();
		}

		public override void SetTruck()
		{
			throw new NotImplementedException();
		}
	}
}