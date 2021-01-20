using HMUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SwingMeter
{
	class SwingMeterManager : MonoBehaviour
	{
		Canvas _canvas;

		SwingMeterRenderer _leftTop;
		SwingMeterRenderer _leftBottom;
		SwingMeterRenderer _rightTop;
		SwingMeterRenderer _rightBottom;

		Vector2 meterSize = new Vector2(ConfigHelper.Config.SizeX, ConfigHelper.Config.SizeY);
		Vector3 canvasPosition = new Vector3(0f, 0f, ConfigHelper.Config.OffsetZ);
		Vector2 meterPositionLeft = new Vector3(-ConfigHelper.Config.OffsetX, 0f, 0f);
		Vector2 meterPositionRight = new Vector3(ConfigHelper.Config.OffsetX, 0f, 0f);

		bool ShowPreSwing => ConfigHelper.Config.ShowPreSwing;
		bool ShowPostSwing => ConfigHelper.Config.ShowPostSwing;

		void Start()
		{
			_canvas = new GameObject("Swing Meter Canvas").AddComponent<Canvas>();
			_canvas.renderMode = RenderMode.WorldSpace;
			_canvas.transform.position = canvasPosition;
			_canvas.gameObject.AddComponent<CurvedCanvasSettings>();

			_leftTop = SwingMeterRenderer.Create(_canvas, meterSize, UnityEngine.UI.Slider.Direction.BottomToTop);
			_leftBottom = SwingMeterRenderer.Create(_canvas, meterSize, UnityEngine.UI.Slider.Direction.TopToBottom);
			_rightTop = SwingMeterRenderer.Create(_canvas, meterSize, UnityEngine.UI.Slider.Direction.BottomToTop);
			_rightBottom = SwingMeterRenderer.Create(_canvas, meterSize, UnityEngine.UI.Slider.Direction.TopToBottom);

			_leftTop.transform.localPosition = meterPositionLeft;
			_leftBottom.transform.localPosition = meterPositionLeft;

			_rightTop.transform.localPosition = meterPositionRight;
			_rightBottom.transform.localPosition = meterPositionRight;
		}

		public void OnNoteCut(NoteData noteData, ISaberSwingRatingCounter cutRating)
		{
			ColorType noteColor = noteData.colorType;
			NoteCutDirection cutDirection = noteData.cutDirection;

			bool cutDirectionIsUp = (
				cutDirection == NoteCutDirection.UpLeft ||
				cutDirection == NoteCutDirection.Up ||
				cutDirection == NoteCutDirection.UpRight);

			bool cutDirectionIsDown = (
				cutDirection == NoteCutDirection.DownLeft ||
				cutDirection == NoteCutDirection.Down ||
				cutDirection == NoteCutDirection.DownRight);


			if (noteColor == ColorType.ColorA) // Left
			{
				if (cutDirectionIsUp)
				{
					if (ShowPreSwing)
					{
						_leftBottom.SetScore(cutRating.beforeCutRating);
					}
					if (ShowPostSwing)
					{
						_leftTop.SetScore(cutRating.afterCutRating);
					}
				}
				else if (cutDirectionIsDown)
				{
					if (ShowPreSwing)
					{
						_leftTop.SetScore(cutRating.beforeCutRating);
					}
					if (ShowPostSwing)
					{
						_leftBottom.SetScore(cutRating.afterCutRating);
					}
				}
			}
			else if (noteColor == ColorType.ColorB) // Right
			{
				if (cutDirectionIsUp)
				{
					if (ShowPreSwing)
					{
						_rightBottom.SetScore(cutRating.beforeCutRating);
					}
					if (ShowPostSwing)
					{
						_rightTop.SetScore(cutRating.afterCutRating);
					}
				}
				else if (cutDirectionIsDown)
				{
					if (ShowPreSwing)
					{
						_rightTop.SetScore(cutRating.beforeCutRating);
					}
					if (ShowPostSwing)
					{
						_rightBottom.SetScore(cutRating.afterCutRating);
					}
				}
			}
		}
	}
}
