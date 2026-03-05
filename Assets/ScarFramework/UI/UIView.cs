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

        [Header("Animations")] [SerializeReference, SerializeField]
        private UIAnimator showInAnimator;

        [SerializeReference, SerializeField] private UIAnimator hideInAnimator;


        public RectTransform Rect => rect;

        public CanvasGroup CG
        {
            get
            {
                if (!cg)
                {
                    cg = GetComponent<CanvasGroup>();
                }

                return cg;
            }
        }

        public void Init()
        {
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
            gameObject.SetActive(true);

            if (!immediately)
            {
                if (showInAnimator != null)
                {
                    return showInAnimator.PlayAnimation(this).OnComplete(OnShow);
                }
            }

            return null;
        }

        public Tween Hide(bool immediately = false)
        {
            showInAnimator?.Kill(true);

            if (!immediately)
            {
                if (hideInAnimator != null)
                {
                    return hideInAnimator.PlayAnimation(this).OnComplete(HideInternal);
                }
            }

            HideInternal();
            return null;
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