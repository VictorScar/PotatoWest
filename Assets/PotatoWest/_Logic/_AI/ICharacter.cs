using Cysharp.Threading.Tasks;

namespace PotatoWest._Logic._AI
{
    public interface ICharacter
    {
        void Say(float startDelay = 0f);
        void RemoveCharacter();
    }
}
