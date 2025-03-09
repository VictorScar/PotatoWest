using DG.Tweening;
using UnityEngine;

namespace ScarFramework.UI.ViewAnimators
{
    public class FadeUI : UIAnimator
    {
        [SerializeField] private float fadeValue = 1;
        [SerializeField] private Ease ease = Ease.Linear;
        public override Tween PlayAnimation()
        {
            return _view.CG.DOFade(fadeValue, duration).SetEase(ease).OnComplete(OnAnimationComplete);
        }

        private void OnAnimationComplete()
        {
            
        }
    }
}
