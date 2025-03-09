using DG.Tweening;
using ScarFramework.Button;
using ScarFramework.UI.ViewAnimators;
using UnityEngine;

namespace ScarFramework.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    [RequireComponent(typeof(RectTransform))]
    public class UIView : MonoBehaviour
    {
        [Header("Default References")] [SerializeField]
        private RectTransform rect;

        [SerializeField] private CanvasGroup cg;

        [Header("Animations")] [SerializeField]
        private UIAnimator showInAnimator;

        [SerializeField] private UIAnimator showOutAnimator;
        [SerializeField] private UIAnimator hideInAnimator;
        [SerializeField] private UIAnimator hideOutAnimator;

        public RectTransform Rect => rect;
        public CanvasGroup CG => cg;

        public void Init()
        {
            if (!rect)
            {
                GetComponent<RectTransform>();
            }

            if (!cg)
            {
                cg = GetComponent<CanvasGroup>();
            }
            
            showInAnimator?.Init(this);
            showOutAnimator?.Init(this);
            hideInAnimator?.Init(this);
            hideOutAnimator?.Init(this);

            OnInit();
        }

        [Button("Show")]
        public void Show(bool immediately = false)
        {
            if (!immediately)
            {
                gameObject.SetActive(true);
                showInAnimator?.PlayAnimation().OnComplete(OnShow);
                
            }
            else
            {
                gameObject.SetActive(true);
                OnShow();
            }
           
        }
   
        [Button("Hide")]
        public void Hide(bool immediately = false)
        {
            if (!immediately)
            {
                gameObject.SetActive(false);
                hideInAnimator?.PlayAnimation().OnComplete(OnHide);
                
            }
            else
            {
                gameObject.SetActive(false);
                OnHide();
            }
        }

        protected virtual void OnInit()
        {
        }

        protected virtual void OnShow()
        {
        }

        protected virtual void OnHide()
        {
        }
    }
}