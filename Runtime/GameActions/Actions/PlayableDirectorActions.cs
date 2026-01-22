using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

namespace DirtyWorks.GameBlocks
{
    public abstract class BasePlayableDirectorAction : ActionBlock
    {
        public PlayableDirector targetDirector;

        public abstract void DoAction();

        public virtual void Run() => DoAction();

        public override IEnumerator RunCoroutine()
        {
            Run();
            yield break;
        }
    }

    [ActionBlock("PlayableDirector")]
    public class Play : BasePlayableDirectorAction, IGameBlock
    {
        public override void DoAction()
        {
            targetDirector.Play();
        }
    }

    [ActionBlock("PlayableDirector")]
    public class Pause : BasePlayableDirectorAction, IGameBlock
    {
        public override void DoAction()
        {
            targetDirector.Pause();
        }
    }

    [ActionBlock("PlayableDirector")]
    public class Stop:BasePlayableDirectorAction, IGameBlock
    {
        public override void DoAction()
        {
            targetDirector.Stop();
        }
    }
}
