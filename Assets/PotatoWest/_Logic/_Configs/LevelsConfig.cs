using UnityEngine;

namespace PotatoWest._Logic._Configs
{
    [CreateAssetMenu(menuName = "Configs/Levels", fileName = "LevelConfig")]
    public class LevelsConfig : ScriptableObject
    {
        [SerializeField] private LevelConfigData[] levels;

        public bool GetLevelData(int levelNumber, out LevelConfigData configData)
        {
            if (levels != null)
            {
                if (levelNumber >= 0 && levelNumber < levels.Length)
                {
                    configData = levels[levelNumber];
                    return true;
                }
            }

            configData = new LevelConfigData();
            return false;
        }
    }
}
