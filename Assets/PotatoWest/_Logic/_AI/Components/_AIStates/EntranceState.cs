namespace PotatoWest._Logic._AI.Components._AIStates
{
    public class EntranceState : AiCharacterState
    {
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