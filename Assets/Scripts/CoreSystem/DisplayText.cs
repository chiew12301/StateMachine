using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CORE
{
    public class DisplayText : MonoBehaviour
    {
        [SerializeField] private Camera m_camToLook = null;
        [SerializeField] private Vector3 m_offSet = new Vector3(0.0f, 180.0f, 0.0f);

        //==============================================================

        private void Start()
        {
            if(this.m_camToLook == null)
            {
                this.m_camToLook = Camera.main;
            }
        }

        private void Update()
        {
            this.transform.LookAt(this.m_camToLook.transform);
            this.transform.Rotate(this.m_offSet);
        }

        //==============================================================

        //==============================================================
    }
}