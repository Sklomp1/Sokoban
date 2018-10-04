using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban.Model_Layer
{
	class Empty : GamePiece
	{
		public Empty()
		{
			Type = "empty";
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
