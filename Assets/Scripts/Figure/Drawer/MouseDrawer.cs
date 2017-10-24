using FigureRecognizing;
using UnityEngine;
using Utils;

namespace Figure.Drawer
{
    public class MouseDrawer : IDrawer
    {
        [Inject]
        public UpdateDispatcher UpdateDispatcher { get; private set; }

        [Inject]
        public UserDrawedPolygonSignal UserDrawedPolygonSignal { get; private set; }

        private bool _drawingEnable = false;
        private Polygon _drawPolygon = null;
        private bool _isDrawing = false;
        
        public void StartDrawing()
        {
            _drawingEnable = true;
            UpdateDispatcher.UpdateBehaviour.UpdateEvent.AddListener(Update);
        }

        public void PauseDrawing()
        {
            _drawingEnable = false;
            UpdateDispatcher.UpdateBehaviour.UpdateEvent.RemoveListener(Update);
        }

        public bool DrawingEnable()
        {
            return _drawingEnable;
        }

        private void Update()
        {
            if (!_drawingEnable) return;
            
            if (Input.GetMouseButtonDown(0))
            {
                _drawPolygon = new Polygon();
                _isDrawing = true;
            }

            if (_isDrawing)
            {
                _drawPolygon.AddNextVertex(Camera.main.ScreenToWorldPoint(Input.mousePosition));

                if (!Input.GetMouseButton(0))
                {
                    _isDrawing = false;
                    UserDrawedPolygonSignal.Dispatch(_drawPolygon);
                }
            }
                
        }

        private void AddNextVertex()
        {
            
        }
    }
}