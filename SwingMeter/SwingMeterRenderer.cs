using HMUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace SwingMeter
{
	class SwingMeterRenderer : MonoBehaviour
	{
		ImageView _backgroundImage;
		ImageView _foregroundImage;
		Slider _slider;

		RectTransform rectTransform => (RectTransform)transform;

		public static SwingMeterRenderer Create(Canvas canvas, Vector2 size, Slider.Direction direction)
		{
			SwingMeterRenderer meter = new GameObject("Swing Meter").AddComponent<SwingMeterRenderer>();
			meter._slider.direction = direction;
			meter.transform.SetParent(canvas.transform);

			meter.rectTransform.sizeDelta = size;

			switch (direction)
			{
				case Slider.Direction.BottomToTop: meter.rectTransform.pivot = new Vector2(0.5f, 0f); break;
				case Slider.Direction.TopToBottom: meter.rectTransform.pivot = new Vector2(0.5f, 1f); break;
				case Slider.Direction.LeftToRight: meter.rectTransform.pivot = new Vector2(1f, 0.5f); break;
				case Slider.Direction.RightToLeft: meter.rectTransform.pivot = new Vector2(0f, 0.5f); break;
			}

			return meter;
		}

		// Start is called before the first frame update
		void Awake()
		{
			_backgroundImage = gameObject.AddComponent<ImageView>();
			_backgroundImage.material = Utilities.UiNoGlow;
			_backgroundImage.color = new Color(0.7f, 0.7f, 0.7f);

			_foregroundImage = new GameObject().AddComponent<ImageView>();
			_foregroundImage.material = Utilities.UiNoGlow;
			_foregroundImage.transform.SetParent(_backgroundImage.transform);
			_foregroundImage.color = new Color(1f, 0f, 0f);

			_slider = gameObject.AddComponent<Slider>();
			_slider.fillRect = _foregroundImage.rectTransform;

			_foregroundImage.rectTransform.anchorMin = new Vector2(0f, 0f);
			_foregroundImage.rectTransform.anchorMax = new Vector2(1f, 1f);
			_foregroundImage.rectTransform.offsetMin = new Vector2(0f, 0f);
			_foregroundImage.rectTransform.offsetMax = new Vector2(0f, 0f);
		}

		public void SetScore(float score)
		{
			_slider.value = score;

			if (score >= 0.9999f)
			{
				_foregroundImage.color = new Color(0f, 1f, 0f);
			}
			else
			{
				Color badColor = new Color(1f, 0f, 0f);
				Color okayColor = new Color(1f, 1f, 0f);
				_foregroundImage.color = Color.Lerp(badColor, okayColor, score);
			}
		}
	}
}
