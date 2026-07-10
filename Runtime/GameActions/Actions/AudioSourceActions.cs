using System.Collections;
using UnityEngine;

namespace DirtyWorks.GameBlocks
{
    public abstract class BaseAudioSourceAction : ActionBlock
    {
        public AudioSource audioSource;

        public abstract void DoAction();

        public virtual void Run() => DoAction();

        public override IEnumerator RunCoroutine()
        {
            Run();
            yield break;
        }
    }

    [ActionBlock("AudioSource")]
    public class AudioPlay : BaseAudioSourceAction, IGameBlock
    {
        public override void DoAction()
        {
            audioSource.Play();
        }
    }

    [ActionBlock("AudioSource")]
    public class AudioStop : BaseAudioSourceAction, IGameBlock
    {
        public override void DoAction()
        {
            audioSource.Stop();
        }
    }

    [ActionBlock("AudioSource")]
    public class AudioPlayOneShot : BaseAudioSourceAction, IGameBlock
    {
        public AudioClip clip;
        public override void DoAction()
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
