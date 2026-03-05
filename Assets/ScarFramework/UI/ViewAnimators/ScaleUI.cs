using System;
using DG.Tweening;
using UnityEngine;

namespace ScarFramework.UI.ViewAnimators
{
    [Serializable]
    public class ScaleUI : UIAnimator
    {
        [SerializeField] protected float startValue = 1f;
        [SerializeField] protected float endValue = 1f;


        protected override Tween AnimateInternal(UIView view)
        {
            Debug.Log("ScaleUI start");
            var animationInternal = DOTween.Sequence();
            animationInternal
                .Append(view.Rect.DOScale(endValue, duration).SetEase(ease));
            return animationInternal;
        }


        protected override void OnStartAnimation(UIView view)
        {
            view.Rect.localScale = new Vector3(startValue, startValue, startValue);
        }

        protected override void OnEndAnimation()
        {
            //_view.Rect.localScale = new Vector3(endValue, endValue, endValue);
            Debug.Log("ScaleUI end");
        }
    }
}