using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DirtyWorks.GameBlocks
{
    /// <summary>
    /// A MonoBehaviour component that executes a sequence of predefined ActionBlocks.
    /// Attach this component to a GameObject to trigger composed gameplay actions or events configured through the Inspector.
    /// Developers can extend its functionality by creating custom ActionBlocks.
    /// </summary>
    public class GameActions : MonoBehaviour
    {
        public event Action onExecutionBegin, onExecutionFinished;

        [SerializeReference]
        public List<ActionBlock> actionBlocks = new List<ActionBlock>();

        public bool ExecuteOnEnable = false;
        public bool ExecuteOnStart = false;

#region Monobehaviour Lifecycles
        private void OnEnable()
        {
            if (ExecuteOnEnable)
                ExecuteList();
        }

        private void OnDisable()
        {
            StopList();
        }

        private void Start()
        {
            if (ExecuteOnEnable)
                return;

            if(ExecuteOnStart)
                ExecuteList();
        }
#endregion

        public void ExecuteList()
        {
            // Public method far calling. Execute all enabled actions from actionBlocks list in order.
            if (!CheckCanExecute())
                return;

            if(Application.isPlaying)
                StartCoroutine(ExecuteListCoroutine());
        }

        public void StopList()
        {
            // Stops the list of this instance, will stop an on-going actionBlocks list.
            StopAllCoroutines();
        }

        private bool CheckCanExecute() => (gameObject.activeSelf && enabled);

        private IEnumerator ExecuteListCoroutine()
        {
            // Execute each block from actionBlocks one by one.
            onExecutionBegin?.Invoke();
            foreach (var block in actionBlocks)
            {
                if(block.Enabled)
                    yield return block.RunCoroutine();
            }
            onExecutionFinished?.Invoke();
        }
    }
}