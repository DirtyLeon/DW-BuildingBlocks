using System.Collections;
using UnityEngine;

namespace DirtyWorks.GameBlocks
{
    [System.Serializable]
    public abstract class ActionBlock
    {
        [HideInInspector]
        private bool enabled = true;

        public bool Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public abstract IEnumerator RunCoroutine();
    }
}