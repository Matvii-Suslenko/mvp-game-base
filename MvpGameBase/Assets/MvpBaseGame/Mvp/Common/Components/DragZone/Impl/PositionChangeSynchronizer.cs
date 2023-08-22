using UnityEngine;

namespace MvpBaseGame.Mvp.Common.Components.DragZone.Impl
{
    public class PositionChangeSynchronizer : MonoBehaviour
    {
        [SerializeField]
        private Transform _referenceObject;

        private Vector3 _differenceVector;

        private void Start()
        {
            _differenceVector = _referenceObject.position - gameObject.transform.position;
        }

        private void Update()
        {
            gameObject.transform.position = _referenceObject.position - _differenceVector;
        }
    }
}
