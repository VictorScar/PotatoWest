using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using ScarFramework.UI;
using ScarFramework.UI.ViewAnimators;
using TMPro;
using UnityEngine;

public class NPCSayDisplay : MonoBehaviour
{
    [SerializeField] private float showTime = 2f;
    [SerializeField] private TMP_Text displayText;
    [SerializeField] private UIView _view;

    private Sequence _animation;

    public void Init()
    {
        _view.Init();
    }

    public void ShowSayText(string message, float startDelay = 0f)
    {
        if (_animation != null)
        {
            _animation.Kill(true);
        }

        displayText.text = message;
        _animation = DOTween.Sequence();
        _animation
            .Append(_view.Show().SetDelay(startDelay))
            .Append(_view.Hide().SetDelay(showTime));
    }
}