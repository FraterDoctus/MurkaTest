using UnityEngine;

namespace MouseParticle
{
    public interface IMouseParticle
    {
        void CreateMouseParticle(Vector3 position);
        void DestroyMouseParticle();
    }
}