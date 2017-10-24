﻿using Figure;
using Figure.FiguresComparer;
using FigureRecognizing;
using strange.extensions.command.impl;
using UnityEngine;

namespace Commands
{
	public class UserDrawedPolygonCommand : Command 
	{
		[Inject]
		public IFigureComparer FigureComparer { get; private set; }

		[Inject]
		public Polygon DrawedPolygon { get; private set; }

		[Inject]
		public GameController GameController { get; private set; }

		public override void Execute()
		{
			if (FigureComparer.IsFiguresEqual(GameController.CurrentFigure.Polygon, DrawedPolygon,
				GameController.CurrentFigure.MaxPassingLen))
			{
				GameController.LoadNextFigure();
				
				//TODO Add score
				//TODO Update Timer
				Debug.Log("TODO HERE! Score + Timer");
			}
		}
	}
}
