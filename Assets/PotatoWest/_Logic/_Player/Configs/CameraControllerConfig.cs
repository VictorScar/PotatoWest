using System;
using UnityEngine;

namespace PotatoWest._Player.Configs
{
    [Serializable]
    public class CameraControllerConfig
    {
        [SerializeField] private float cameraRotationSpeed;
        public float CameraRotationSpeed => cameraRotationSpeed;
    }
}