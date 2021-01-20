using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace SwingMeter
{
	class NoteCutTracker : MonoBehaviour
	{
		public event Action<NoteData, ISaberSwingRatingCounter> NoteCutFinished;

		public BeatmapObjectManager ObjectManager;

		private void OnWasNoteCut(NoteController noteController, NoteCutInfo cutInfo)
		{
			if (noteController is GameNoteController gameNote)
			{
				noteController.noteWasCutEvent -= OnWasNoteCut;

				if (cutInfo?.swingRatingCounter != null)
				{
					SwingSaberRatingDidFinishDelegate del = null;
					del = new SwingSaberRatingDidFinishDelegate((ISaberSwingRatingCounter afterCutRating) =>
					{
						OnNoteCutFinished(gameNote.noteData, afterCutRating);
						cutInfo.swingRatingCounter.didFinishEvent -= del;
					});
					cutInfo.swingRatingCounter.didFinishEvent += del;
				}
			}
		}

		private void OnNoteCutFinished(NoteData noteData, ISaberSwingRatingCounter afterCutRating)
		{
			NoteCutFinished?.Invoke(noteData, afterCutRating);
		}

		void Start()
		{
			ObjectManager.noteWasSpawnedEvent += NoteWasSpawnedEvent;
		}

		void OnDestroy()
		{
			ObjectManager.noteWasSpawnedEvent -= NoteWasSpawnedEvent;
		}

		private void NoteWasSpawnedEvent(NoteController note)
		{
			if (note is GameNoteController gameNote)
			{
				if (gameNote.noteData.colorType != ColorType.None)
				{
					gameNote.noteWasCutEvent += OnWasNoteCut;
				}
			}
		}
	}
}
