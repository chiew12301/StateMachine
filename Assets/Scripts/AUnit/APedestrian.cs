using Unity.VisualScripting;
using UnityEngine;

namespace UNIT
{
    public class APedestrian : AnUnit
    {
        [SerializeField] private float m_fleeSpeed = 4.0f;
        [SerializeField] private float m_detectionRange = 3.0f;
        [SerializeField] private float m_fleeDistance = 4.0f;
        [SerializeField] private LayerMask m_detectionLayerMask;

        private Vector3 m_fleeDirection = Vector3.zero;
        private Vector3 m_lastDetectPosition = Vector3.zero;
        //==========================================================
        //==========================================================

        public void SetFleeDirection(Vector3 fleeDirection)
        {
            this.m_fleeDirection = fleeDirection;
        }

        public void SetLastDetectedPosition(Vector3 lastPos)
        {
            this.m_lastDetectPosition = lastPos;
        }

        public Vector3 GetLastdetectedPosition() => this.m_lastDetectPosition;

        public Vector3 GetFleeDirection() => this.m_fleeDirection;

        public float GetFleeDistance() => this.m_fleeDistance;

        public LayerMask GetDetectionLayerMask() => this.m_detectionLayerMask;

        public float GetDetectionRange() => this.m_detectionRange;

        public float GetFleeMoveSpeed() => this.m_fleeSpeed;

        //==========================================================
    }

}
