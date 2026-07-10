using UnityEngine;
using System.Collections;

namespace DirtyWorks.GameBlocks
{
    /// <summary>
    /// Base class for ActionBlocks that modify a Transform component.
    ///
    /// Provides common Transform-related properties such as the target Transform
    /// and whether the action should operate on local or world space.
    ///
    /// To create a new Transform-based ActionBlock:
    /// 1. Inherit from this class.
    /// 2. Implement DoAction() with the desired Transform behavior.
    /// 3. Add the ActionBlock attribute so it appears in the GameBlocks system.
    /// </summary>
    public abstract class BaseTransformAction : ActionBlock
    {
        // The Transform component that this ActionBlock will modify.
        public Transform targetTransform;

        /// <summary>
        /// Determines whether the action uses local space or world space values.
        ///
        /// For example:
        /// - Position uses Transform.localPosition when enabled.
        /// - Position uses Transform.position when disabled.
        /// </summary>
        public bool setLocal;

        // Executes the specific Transform operation implemented by derived classes.
        public abstract void DoAction();

        // Interface from IGameBlock.
        public virtual void Run() => DoAction();

        // Executes this ActionBlock as a coroutine. GameAction class will call this method to execute the function.
        public override IEnumerator RunCoroutine()
        {
            Run();
            yield break;
        }
    }

    /// <summary>
    /// Sets the position of a Transform.
    ///
    /// This ActionBlock can be used as a simple example when creating custom
    /// Transform-based behaviours. The target Transform will immediately move
    /// to the specified position when executed.
    /// </summary>
    [ActionBlock("Transform")]
    public class SetPosition : BaseTransformAction, IGameBlock
    {
        /// <summary>
        /// The position value to apply to the target Transform.
        /// Uses local or world coordinates depending on setLocal.
        /// </summary>
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
    public class SetEulerAngle : BaseTransformAction, IGameBlock
    {
        public Vector3 eulerAngle;
        public override void DoAction()
        {
            if (setLocal)
                targetTransform.localEulerAngles = eulerAngle;
            else
                targetTransform.eulerAngles = eulerAngle;
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
