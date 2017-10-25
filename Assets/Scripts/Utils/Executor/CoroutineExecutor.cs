using System.Collections;
using UnityEngine;

namespace Utils.Executor
{
    public class CoroutineExecutor : IExecutor
    {
        private static EmptyMonoBehaviour EmptyMonoBehaviour
        {
            get
            {
                if (_emptyMonoBehaviour == null)
                {
                    var obj = new GameObject("Coroutine Executor");
                    _emptyMonoBehaviour = obj.AddComponent<EmptyMonoBehaviour>();
                }

                return _emptyMonoBehaviour;
            }
        }
        private static EmptyMonoBehaviour _emptyMonoBehaviour = null;
        
        
        public void Execute(IEnumerator coroutine)
        {
            EmptyMonoBehaviour.StartCoroutine(coroutine);
        }
    }

    public class EmptyMonoBehaviour : MonoBehaviour { }
}