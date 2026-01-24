using System.Collections;
using UnityEngine;

namespace DirtyWorks.GameBlocks
{
    public abstract class BaseGameActionActions : ActionBlock
    {
        public GameActions targetGameActions;

        public abstract void DoAction();

        public virtual void Run() => DoAction();

        public override IEnumerator RunCoroutine()
        {
            Run();
            yield break;
        }
    }

    [ActionBlock("GameActions")]
    public class ExecuteList : BaseGameActionActions, IGameBlock
    {
        public override void DoAction()
        {
            targetGameActions.ExecuteList();
        }
    }

    [ActionBlock("GameActions")]
    public class StopList : BaseGameActionActions, IGameBlock
    {
        public override void DoAction()
        {
            targetGameActions.StopList();
        }
    }
}
