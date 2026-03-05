using UnityEngine;

namespace PotatoWest._Logic._AI.Components._AIStates
{
    public class PanicRun : AiCharacterState
    {
        [SerializeField] private float waitTime = 1f;
        [SerializeField] private float speedModifier = 3f;
        private float _elapsedTime;
        private bool isEscape;

        public override void Enter()
        {
            _elapsedTime = 0f;
            isEscape = false;
        }

        public override void UpdateState(float deltaTime)
        {
            base.UpdateState(deltaTime);

            if (_elapsedTime < waitTime)
            {
                _elapsedTime += deltaTime;
            }
            else if (!isEscape)
            {
                var spawnPoint = Context.SpawnData.SpawnPoint;
                Context.Mover.RotateTo(spawnPoint);
                Context.Mover.WaypointData = new WaypointData
                    { Waypoints = new[] { new Waypoint { Point = spawnPoint } } };
                Context.Parameters.SetModifierValue(ModifiersDict.MoveSpeedMod, speedModifier);
                isEscape = true;
            }
            else
            {
                if (!Context.Mover.IsMoving)
                {
                    Context.Character.RemoveCharacter();
                }
            }
            
        }
    }
}