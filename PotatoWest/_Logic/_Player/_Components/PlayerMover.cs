using System;
using PotatoWest._Input.Data;
using PotatoWest._Logic._Configs;
using UnityEngine;
using UnityEngine.Serialization;

namespace PotatoWest._Player._Components
{
    public class PlayerMover : MonoBehaviour, IMover
    {
        private CharacterController _motor;
        private Vector3 _motion;
        private Vector3 _verticalMotion;
        [SerializeField] private float _verticalForce;
        [SerializeField] private float _gravityForce = 9.81f;
        [SerializeField] private bool isGrounded;
        private float _rotation;

        public float MoveSpeed { get; }
        public float IsMoving { get; }
        public Vector3 MoveDirection => _motion;

        public bool IsGrounded => IsGroundedInternal();

        private void Update()
        {
            if (_motor != null)
            {
                isGrounded = IsGrounded;
                _motor.Move((_motion + _verticalMotion) * Time.deltaTime);
                _motor.transform.rotation *= Quaternion.Euler(0, _rotation * Time.deltaTime, 0);
                UpdateVerticalMovement();
            }
        }


        public void Init(CharacterController motor)
        {
            _motor = motor;
        }

        public void Move(float fAxis, float moveSpeed)
        {
            _motion = transform.forward * fAxis * moveSpeed;
        }

        public void Rotate(float rotateDirection, float rotateSpeed)
        {
            _rotation = rotateDirection * rotateSpeed;
        }

        public void Jump(float jumpForce)
        {
            if (IsGrounded)
            {
                _verticalForce = jumpForce;
            }
        }

        private void UpdateVerticalMovement()
        {
            _verticalForce -= _gravityForce * _gravityForce * Time.deltaTime;
            _verticalMotion += transform.up * _verticalForce * Time.deltaTime;

            if (_verticalForce < 0 && IsGrounded)
            {
                _verticalForce = 0f;
                _verticalMotion = Vector3.zero;
            }
        }

        private bool IsGroundedInternal()
        {
            return Physics.Raycast(transform.position, -transform.up, 0.1f);
        }
    }
}