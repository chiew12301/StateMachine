using STATEMACHINE;
using System.Collections;
using System.Collections.Generic;
using UNIT;
using UnityEngine;

namespace DOG
{
    public class DogPatrolState : BaseState<EDOGSTATE>
    {
        private Transform m_curerntWaypoint = null;
        private int m_currentWaypointIndex = 0;
        private ADog m_dogScript = null;

        private float m_moveSpeed = 0.0f;

        private float m_staminaCost = 20.0f;

        //==============================================================

        public DogPatrolState(StateManager<EDOGSTATE> sm, ADog dogscript, float speed) : base(EDOGSTATE.PATROl, sm)
        {
            this.m_dogScript = dogscript;
            this.m_moveSpeed = speed;
        }

        public override void EnterState()
        {
            this.m_curerntWaypoint = this.m_mySM.wayPoints[this.m_currentWaypointIndex];
            this.m_mySM.SetDisplayText(this.StateKey.ToString());
        }

        public override void ExitState()
        {

        }

        public override EDOGSTATE GetNextState()
        {
            return EDOGSTATE.IDLE;
        }

        public override void OnCollisionEnter(Collision other)
        {

        }

        public override void OnCollisionExit(Collision other)
        {

        }

        public override void OnCollisionStay(Collision other)
        {

        }

        public override void OnTriggerEnter(Collider other)
        {

        }

        public override void OnTriggerExit(Collider other)
        {

        }

        public override void OnTriggerStay(Collider other)
        {

        }

        public override void UpdateState()
        {
            this.CheckDistanceAndMove();
        }

        private void CheckDistanceAndMove()
        {
            if(this.m_dogScript.GetIsOutOfStamina(this.m_staminaCost))
            {
                this.m_mySM.ChangeState(EDOGSTATE.IDLE);
                return;
            }

            Vector3 direction = this.m_curerntWaypoint.position - this.m_mySM.transform.position;
            direction.y = 0.0f; //Ensure won't sleep

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                this.m_mySM.transform.rotation = Quaternion.Slerp(this.m_mySM.transform.rotation, targetRotation, Time.deltaTime * 5.0f);
            }

            float distanceToWaypoint = Vector3.Distance(this.m_mySM.transform.position, this.m_curerntWaypoint.position);
            if (distanceToWaypoint <= 0.1f)
            {
                this.m_currentWaypointIndex = (this.m_currentWaypointIndex + 1) % this.m_mySM.wayPoints.Length;
                this.m_curerntWaypoint = this.m_mySM.wayPoints[this.m_currentWaypointIndex];
            }

            this.m_mySM.transform.position = Vector3.MoveTowards(this.m_mySM.transform.position, this.m_curerntWaypoint.position, Time.deltaTime * this.m_moveSpeed);
            this.m_dogScript.DeductStamina(this.m_staminaCost);
        }

        //==============================================================

    }
}