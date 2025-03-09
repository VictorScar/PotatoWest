using PotatoWest._Input.Data;
using PotatoWest._Logic._Configs;
using UnityEngine;
using UnityEngine.Serialization;

namespace PotatoWest._Player._Components
{
    public class PlayerMover : MonoBehaviour, IMover
    {
        [SerializeField] private CharacterController motor;
        private PlayerPawnConfig _config;

        public float MoveSpeed { get; }
        public float IsMoving { get; }
        public Vector3 MoveDirection { get; }
        public bool IsGrounded { get; }

        public void Init(PlayerPawnConfig config)
        {
            _config = config;
        }

        public void SetInputs(InputData inputData)
        {
           // Debug.Log("Mover Input" + inputData.FAxis);
            var movement = transform.forward * inputData.FAxis * _config.MoveSpeed;
            var rotatuon = inputData.RAxis * _config.RotateSpeed;

            motor.Move( movement * Time.deltaTime);
            motor.transform.rotation *= Quaternion.Euler(0, inputData.RAxis * _config.RotateSpeed * Time.deltaTime, 0);
        }
    }
}