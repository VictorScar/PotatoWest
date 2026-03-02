using UnityEngine;

namespace PotatoWest._Player.Configs
{
    public class CameraControllerConfig
    {
        [SerializeField] private float cameraRotationSpeed;
        public float CameraRotationSpeed => cameraRotationSpeed;
    }
}