using System;
using DG.Tweening;
using UnityEngine;

namespace ScarFramework.UI.ViewAnimators
{
    [Serializable]
    public abstract class UIAnimator
    {
        [SerializeField] protected float duration = 0.2f;
        [SerializeField] protected Ease ease = Ease.OutQuad;

        private Sequence _animation;
        protected UIView _cashedView;

        public void Init(UIView view)
        {
            OnInit(view);
        }

        public Tween PlayAnimation(UIView view)
        {
            _cashedView = view;
            OnStartAnimation(view);
            _animation = DOTween.Sequence();
            _animation.Append(AnimateInternal(view).OnKill(OnEndAnimation));
            return _animation;
        }

        protected abstract Tween AnimateInternal(UIView view);

        public void Kill(bool isComplete = false)
        {
            _animation?.Kill(isComplete);
        }

        protected abstract void OnStartAnimation(UIView view);
        protected abstract void OnEndAnimation();

        protected virtual void OnInit(UIView view)
        {
        }

        //public abstract UIAnimator GetInstance();
    }
}