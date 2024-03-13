using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CORE
{
    public class SpecModeCam : MonoBehaviour
    {
        [SerializeField] private float m_moveSpeed = 1.0f;
        [SerializeField] private float m_speedH = 2.0f;
        [SerializeField] private float m_speedV = 2.0f;
        private float m_yaw = 0.0f;
        private float m_pitch = 0.0f;
        
        //===================================================================

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            this.m_yaw += this.m_speedH * Input.GetAxis("Mouse X");
            this.m_pitch -= this.m_speedV * Input.GetAxis("Mouse Y");

            this.transform.eulerAngles = new Vector3(this.m_pitch, this.m_yaw, 0.0f);
            this.transform.position += (this.transform.TransformDirection(Vector3.forward) * v + this.transform.TransformDirection(Vector3.right) * h) * this.m_moveSpeed;

            this.ProcessInput();
        }

        //===================================================================
        
        private void ProcessInput()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                this.LockCursor(false);
            }

            if(Input.GetMouseButtonDown(0))
            {
                this.LockCursor(true);
            }
        }

        private void LockCursor(bool lockCursor)
        {
            if(lockCursor)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                return;
            }

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        //===================================================================
    }
}