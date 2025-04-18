using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace PotatoWest._Logic._AI
{
    public class AIMover : MonoBehaviour
    {
        [SerializeField] private CharacterController body;
        private CancellationToken _cancellation;

        public void Init(CancellationToken cancellationToken)
        {
            _cancellation = cancellationToken;
        }

        public void MoveTo(Vector3 position, float speed)
        {
            MoveToInternal(position, speed, _cancellation);
        }

        private async UniTask MoveToInternal(Vector3 position, float speed, CancellationToken token)
        {
            while (token.IsCancellationRequested || Mathf.Abs(Vector3.Distance(body.transform.position, position)) > 0.01f)
            {
                body.Move(position - body.transform.position * speed);
                await UniTask.Yield(token);
            }
           
        }
    }
}