using System.Collections;
using UnityEngine;

namespace DirtyWorks.GameBlocks
{
    public abstract class BaseGameObjectActions : ActionBlock
    {
        public GameObject targetGameObject;
        public abstract void DoAction();
        public virtual void Run() => DoAction();

        public override IEnumerator RunCoroutine()
        {
            Run();
            yield break;
        }
    }

    [ActionBlock("GameObject")]
    public class InvertActive : BaseGameObjectActions, IGameBlock
    {
        public override void DoAction()
        {
            targetGameObject.SetActive(!targetGameObject.activeSelf);
        }
    }

    [ActionBlock("GameObject")]
    public class SetActive : BaseGameObjectActions, IGameBlock
    {
        public bool setActive = false;
        public override void DoAction()
        {
            targetGameObject.SetActive(setActive);
        }
    }
}
