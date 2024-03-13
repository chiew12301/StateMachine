using UnityEngine;

namespace UNIT
{
    public class AnUnit : MonoBehaviour
    {
        [SerializeField] private float m_moveSpeed = 2.0f;

        //==========================================================

        //==========================================================

        public float GetMoveSpeed() => this.m_moveSpeed;

        //==========================================================
    }
}