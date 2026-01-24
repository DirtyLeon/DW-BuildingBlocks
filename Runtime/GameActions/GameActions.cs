using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DirtyWorks.GameBlocks
{
    public class GameActions : MonoBehaviour
    {
        [SerializeReference]
        public List<ActionBlock> actionBlocks = new List<ActionBlock>();

        public bool ExecuteOnEnable = false;
        public bool ExecuteOnStart = false;

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

        private bool CheckCanExecute() => (!gameObject.activeSelf || !enabled);

        public void ExecuteList()
        {
            if (!CheckCanExecute())
                return;

            if(Application.isPlaying)
                StartCoroutine(ExecuteListCoroutine());
        }

        public void StopList()
        {
            StopAllCoroutines();
        }

        IEnumerator ExecuteListCoroutine()
        {
            foreach (var block in actionBlocks)
            {
                if(block.enabled)
                    yield return block.RunCoroutine();
            }
        }
    }
}