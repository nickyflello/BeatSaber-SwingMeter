using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace SwingMeter
{
	public class NoteCutTracker : MonoBehaviour, INoteControllerNoteWasCutEvent, ISaberSwingRatingCounterDidFinishReceiver
	{
		public event Action<NoteData, ISaberSwingRatingCounter> NoteCutFinished;

		public BeatmapObjectManager ObjectManager;

		private Dictionary<ISaberSwingRatingCounter, GameNoteController> _notesBeingCut = new Dictionary<ISaberSwingRatingCounter, GameNoteController>();

		public void HandleSaberSwingRatingCounterDidFinish(ISaberSwingRatingCounter swingRatingCounter)
		{
			GameNoteController gameNote = _notesBeingCut[swingRatingCounter];
			OnNoteCutFinished(gameNote.noteData, swingRatingCounter);

			_notesBeingCut.Remove(swingRatingCounter);
			swingRatingCounter.UnregisterDidFinishReceiver(this);
		}

		public void HandleNoteControllerNoteWasCut(NoteController noteController, in NoteCutInfo cutInfo)
		{
			if (noteController is GameNoteController gameNote)
			{
				//noteController.noteWasCutEvent -= OnWasNoteCut;
				noteController.noteWasCutEvent.Remove(this);

				if (cutInfo.swingRatingCounter != null)
				{
					_notesBeingCut[cutInfo.swingRatingCounter] = gameNote;
					cutInfo.swingRatingCounter.RegisterDidFinishReceiver(this);
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
					gameNote.noteWasCutEvent.Add(this);
				}
			}
		}
	}
}
