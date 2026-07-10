using System.Collections;
using UnityEngine;

namespace DirtyWorks.GameBlocks
{
    public abstract class BaseAnimatorAction : ActionBlock
    {
        public Animator anim;

        public abstract void DoAction();

        public virtual void Run() => DoAction();

        public override IEnumerator RunCoroutine()
        {
            Run();
            yield break;
        }
    }

    [ActionBlock("Animator")]
    public class AnimatorPlay : BaseAnimatorAction, IGameBlock
    {
        public string state;
        public override void DoAction()
        {
            anim.Play(state);
        }
    }

    [ActionBlock("Animator")]
    public class AnimatorSetTrigger : BaseAnimatorAction, IGameBlock
    {
        public string triggerName;
        public override void DoAction()
        {
            anim.SetTrigger(triggerName);
        }
    }
}
