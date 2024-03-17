using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CORE
{
    public class WaypointsManager : MonoBehaviour
    {
        [Header("References Waypoints")]
        [SerializeField] private List<Transform> m_waypointList = new List<Transform>();

        private static WaypointsManager _INSTANCE = null;

        //====================================================

        private void Awake()
        {
            if(_INSTANCE == null)
            {
                _INSTANCE = this;
                return;
            }

            Destroy(this.gameObject);
        }

        private void Start()
        {
            if(this.m_waypointList.Count <= 0)
            {
                this.m_waypointList = this.GetComponentsInChildren<Transform>().ToList();
            }
        }

        //====================================================

        public WaypointsManager GetInstance()
        {
            return _INSTANCE;
        }

        //====================================================
    }
}