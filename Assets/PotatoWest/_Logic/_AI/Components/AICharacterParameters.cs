using UnityEngine;

namespace PotatoWest._Logic._AI.Components
{
    public class AICharacterParameters : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 2f;
        [SerializeField] private int maxHealth = 100;
        public float MoveSpeed => moveSpeed;
        public int MaxHealth => maxHealth;
    }
}