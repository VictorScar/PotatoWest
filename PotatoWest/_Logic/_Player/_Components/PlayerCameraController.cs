using PotatoWest._Player.Configs;
using UnityEngine;

namespace PotatoWest._Player
{
    public class PlayerCameraController : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        [SerializeField] private Transform horizontalHolder;
        private CameraControllerConfig _config;
        public Camera PlayerCamera => cam;

        public void Init(CameraControllerConfig config)
        {
            _config = config;
        }

        public void SetInputs(ViewInputData inputData)
        {
           
        }
    }
}