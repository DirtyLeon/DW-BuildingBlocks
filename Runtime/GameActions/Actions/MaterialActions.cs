using System.Collections;
using UnityEngine;

namespace DirtyWorks.GameBlocks
{
    public abstract class BaseMaterialActions : ActionBlock
    {
        public Material targetMaterial;
        public abstract void DoAction();
        public virtual void Run() => DoAction();

        public override IEnumerator RunCoroutine()
        {
            Run();
            yield break;
        }
    }
}
