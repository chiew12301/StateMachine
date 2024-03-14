using UnityEngine;
using UnityEngine.AI;

namespace UNIT
{
    public class AnUnit : MonoBehaviour
    {
        [SerializeField] private float m_moveSpeed = 2.0f;
        [SerializeField] private NavMeshAgent m_agent = null;

        //==========================================================

        private void Start()
        {
            if(this.m_agent == null)
            {
                this.m_agent = this.GetComponent<NavMeshAgent>();
            }
        }

        //==========================================================

        public float GetMoveSpeed() => this.m_moveSpeed;

        public NavMeshAgent GetAgent() => this.m_agent;

        public void SetDestination(Vector3 des)
        {
            this.m_agent.destination = des;
        }

        public void SetMoveSpeed(float speed)
        {
            this.m_agent.speed = speed;
        }

        //==========================================================
    }
}