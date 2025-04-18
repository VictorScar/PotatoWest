namespace PotatoWest._Logic._AI
{
    public class Health
    {
        private float _health;

        public float Value => _health;
    
        public Health(float startHealth)
        {
            _health = startHealth;
        }

        public void DoDamage(float damage)
        {
            if (_health >= damage)
            {
                _health -= damage;
            }
            else
            {
                _health = 0f;
            }
        }

  
    }
}
