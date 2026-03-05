using UnityEngine;

namespace PotatoWest._Logic._AI.Components._AIStates
{
    public class EntranceState : AiCharacterState
    {
        [SerializeField] private float speedMultiplier = 1.5f;
        
        public override void Enter()
        {
            var entrancePoint = Context.SpawnData.EntrancePoint;
            Context.Mover.WaypointData = new WaypointData
            {
                Waypoints = new[]
                {
                    new Waypoint { Point = entrancePoint }
                }
            };
            
            Context.Parameters.SetModifierValue(ModifiersDict.MoveSpeedMod, speedMultiplier);
        }

        public override void Exit()
        {
            Context.Parameters.ResetModifier(ModifiersDict.MoveSpeedMod);
        }

        public override void UpdateState(float deltaTime)
        {
            base.UpdateState(deltaTime);

            if (!Context.Mover.IsMoving)
            {
                StateController.SetNextState();
            }
        }
    }
}