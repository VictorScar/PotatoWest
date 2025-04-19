using PotatoWest._Logic._Scenarios;

namespace PotatoWest._Logic._Level._Scenarios
{
    public abstract class LevelScenarioPart : GameScenarioBase
    {
        protected LevelScenarioData _data;

        public void Init(LevelScenarioData data)
        {
            _data = data;
            OnInit();
        }
    }
}
