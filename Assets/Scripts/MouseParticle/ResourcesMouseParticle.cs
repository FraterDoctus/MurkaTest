using System.Collections;
using UnityEngine;
using Utils.Executor;

namespace MouseParticle
{
    public class ResourcesMouseParticle : IMouseParticle
    {
        [Inject]
        public IExecutor Executor { get; private set; }

        private const string ParticlePath = "Prefabs/MouseParticle";
        private GameObject _particle = null;
        
        public void CreateMouseParticle(Vector3 position)
        {
            var prefab = Utils.ResourcesManager.Load<GameObject>(ParticlePath, true);
            
            if(_particle != null)
                Object.DestroyImmediate(_particle);

            _particle = Object.Instantiate(prefab, position, Quaternion.identity);
        }

        public void DestroyMouseParticle()
        {
            if (_particle == null)
                return;
            
            var system = _particle.GetComponent<ParticleSystem>();
            var systemEmission = system.emission;
            systemEmission.rateOverTime = new ParticleSystem.MinMaxCurve(0);
            
            Executor.Execute(DestroyAfterDelay(_particle, system.main.duration));
        }

        private static IEnumerator DestroyAfterDelay(Object obj, float delay)
        {
            yield return new WaitForSeconds(delay);
            
            Object.DestroyImmediate(obj);
        }
    }
}