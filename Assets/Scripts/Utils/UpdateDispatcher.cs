using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.Events;

namespace Utils
{
    public class UpdateDispatcher : View
    {
        public UpdateDispacherBehaviour UpdateBehaviour
        {
            get
            {
                if (_updateBehaviour == null)
                {
                    var obj = new GameObject("UpdateDispacherBehaviour");
                    _updateBehaviour = obj.AddComponent<UpdateDispacherBehaviour>();
                }

                return _updateBehaviour;
            }
        }

        private UpdateDispacherBehaviour _updateBehaviour = null;
    }

    public class UpdateDispacherBehaviour : MonoBehaviour
    {
        public UnityEvent UpdateEvent = new UnityEvent();
        public UnityEvent FixedUpdateEvent = new UnityEvent();
        
        private void Update()
        {
            UpdateEvent.Invoke();
        }

        private void FixedUpdate()
        {
            FixedUpdateEvent.Invoke();
        }
    }
}