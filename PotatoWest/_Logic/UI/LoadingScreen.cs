using System;
using ScarFramework.UI;
using UnityEngine;

namespace PotatoWest._Logic.UI
{
    public class LoadingScreen : UIScreen
    {
        [SerializeField] private RectTransform loadingIcon;
        [SerializeField] private float speed;

        private void Update()
        {
            loadingIcon.Rotate(loadingIcon.forward, speed * Time.deltaTime);
        }
    }
}