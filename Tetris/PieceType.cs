﻿using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Tetris;

namespace Tetris
{
	public enum PieceType
	{
		B = 0,
		T = 1,
		O = 2,
		L = 3,
		S = 4,
		Z = 5,
		J = 7,
		I = 8
	}


	public class PieceColor
	{
		public static Color GetPieceColor(PieceType type)
		{
			switch (type)
			{
				case PieceType.B: return Color.White;
                case PieceType.T: return Color.Purple;
                case PieceType.O: return Color.Orange;
                case PieceType.L: return Color.LightBlue;
                case PieceType.S: return Color.Green;
                case PieceType.Z: return Color.Red;
                case PieceType.J: return Color.Blue;
                case PieceType.I: return Color.Orange;
                default: return Color.White;
			}
		}
	}
}

