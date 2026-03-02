using Cysharp.Threading.Tasks;

namespace PotatoWest._Logic._AI
{
  public class InnocentCivilian : CharacterAI
  {
    protected async override UniTask DoAction()
    {
      _mover.MoveToWaypoint(transform.position + transform.forward * 5f, 5f);
      
    }
  }
}
