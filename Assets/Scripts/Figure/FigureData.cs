using FigureRecognizing;
using UnityEngine;

namespace Figure
{
    public class FigureData : ScriptableObject
    {
        public Polygon Polygon = new Polygon();
        public float MaxPassingLen = 0.5f;
    }
}