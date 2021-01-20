using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace SwingMeter
{
	class GameManager : IInitializable, IDisposable
	{
        public static bool IsEnabled => ConfigHelper.Config.Enabled;

        private BeatmapObjectManager _objectManager;
        private NoteCutTracker _nextNoteTracker;
        private SwingMeterManager _swingMeterManager;

        // Ask for the BeatmapObjectManager polietly. The BeatmapObjectManager is a MonoBehaviour that's already injected by the base game. As long as you know it's injected, you can ask for it!
        public GameManager(BeatmapObjectManager beatmapObjectManager)
        {
            _objectManager = beatmapObjectManager;
        }

        public void Initialize()
        {
            if (!IsEnabled)
            {
                return;
            }

            _swingMeterManager = new GameObject("Swing Meter Manager").AddComponent<SwingMeterManager>();
            _nextNoteTracker = new GameObject("Next Note Tracker").AddComponent<NoteCutTracker>();
            _nextNoteTracker.ObjectManager = _objectManager;
            _nextNoteTracker.NoteCutFinished += _swingMeterManager.OnNoteCut;
        }

        public void Dispose()
        {
            if (!IsEnabled)
            {
                return;
            }

            _nextNoteTracker.NoteCutFinished -= _swingMeterManager.OnNoteCut;
        }
    }
}
