using DG.Tweening;
using ScarFramework.Button;
using ScarFramework.UI.ViewAnimators;
using UnityEngine;

namespace ScarFramework.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class UIView : MonoBehaviour
    {
        [Header("Default References")] [SerializeField]
        protected RectTransform rect;

        [SerializeField] private CanvasGroup cg;

        [Header("Animations")] [SerializeField]
        private UIAnimator showInAnimator;

        [SerializeField] private UIAnimator hideInAnimator;


        public RectTransform Rect => rect;
        public CanvasGroup CG => cg;

        public void Init()
        {
            if (!cg)
            {
                cg = GetComponent<CanvasGroup>();
            }
            
            showInAnimator?.Init(this);
           hideInAnimator?.Init(this);

            OnInit();
        }

        [Button("Show")]
        public void DebugShow()
        {
            Show();
        }

        [Button("Hide")]
        public void DebugHide()
        {
            Hide();
        }

        [Button("Init")]
        public void DebugInit()
        {
            Init();
        }

        [Button("Kill")]
        public void DebugKill()
        {
            showInAnimator?.Kill();
            hideInAnimator?.Kill();
        }

        public Tween Show(bool immediately = false)
        {
            ShowInternal();
            
            if (!immediately)
            {
                if (showInAnimator)
                {
                    return showInAnimator.PlayAnimation(this).OnKill(ShowInternal);
                }
            }

            return null;
        }

        public Tween Hide(bool immediately = false)
        {
            showInAnimator?.Kill(true);

            if (!immediately)
            {
                if (hideInAnimator)
                {
                    return hideInAnimator.PlayAnimation(this).OnKill(HideInternal);
                }
                else
                {
                    HideInternal();
                    return null;
                }
            }
            else
            {
                HideInternal();
                return null;
            }
        }

        private void ShowInternal()
        {
            gameObject.SetActive(true);
            OnShow();
        }

        private void HideInternal()
        {
            gameObject.SetActive(false);
            OnHide();
        }

        protected virtual void OnInit()
        {
        }

        protected virtual void OnShow()
        {
            // Debug.Log("OnShow");
        }

        protected virtual void OnHide()
        {
            // Debug.Log("OnHide");
        }
    }
}