using System;
using DG.Tweening;
using UnityEngine;

namespace ScarFramework.UI.ViewAnimators
{
    [Serializable]
    public class RotateUI : UIAnimator
    {
        [SerializeField] private Vector3 startValue = Vector3.one;
        [SerializeField] private Vector3 endValue = Vector3.one;

        protected override Tween AnimateInternal(UIView view)
        {
            var animationInternal = DOTween.Sequence();
            animationInternal
                .Append(view.Rect.DORotate(startValue, duration))
                .Append(view.Rect.DORotate(endValue, duration))
                .SetLoops(-1);

            return animationInternal;
        }


        protected override void OnStartAnimation(UIView view)
        {
        }

        protected override void OnEndAnimation()
        {
        }
    }
}