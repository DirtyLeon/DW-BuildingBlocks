using System.Collections;
using UnityEngine;

namespace DirtyWorks.GameBlocks
{
    public abstract class BaseTransformAction : ActionBlock
    {
        public Transform targetTransform;
        public bool setLocal;

        public abstract void DoAction();

        public virtual void Run() => DoAction();

        public override IEnumerator RunCoroutine()
        {
            Run();
            yield break;
        }
    }

    [ActionBlock("Transform")]
    public class SetPosition : BaseTransformAction, IGameBlock
    {
        public Vector3 position;

        public override void DoAction()
        {
            if (setLocal)
                targetTransform.localPosition = position;
            else
                targetTransform.position = position;
        }
    }

    [ActionBlock("Transform")]
    public class SetEularAngle : BaseTransformAction, IGameBlock
    {
        public Vector3 eularAngle;
        public override void DoAction()
        {
            if (setLocal)
                targetTransform.localEulerAngles = eularAngle;
            else
                targetTransform.eulerAngles = eularAngle;
        }
    }

    [ActionBlock("Transform")]
    public class SetScale : BaseTransformAction, IGameBlock
    {
        public Vector3 scale;

        public override void DoAction()
        {
            targetTransform.localScale = scale;
        }
    }
}
