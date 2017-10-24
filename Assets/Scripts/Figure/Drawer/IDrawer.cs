using UnityEngine;

namespace Figure.Drawer
{
    public interface IDrawer
    {
        void StartDrawing();
        void PauseDrawing();
        bool DrawingEnable();
    }
}