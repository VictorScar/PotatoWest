using PotatoWest._Input.Data;
using UnityEngine;

namespace PotatoWest._Player._Components
{
    public interface IMover
    {
        void SetInputs(InputData inputData);
        float MoveSpeed { get; }
        float IsMoving { get; }
        Vector3 MoveDirection { get; }
        bool IsGrounded { get; }
    }
}