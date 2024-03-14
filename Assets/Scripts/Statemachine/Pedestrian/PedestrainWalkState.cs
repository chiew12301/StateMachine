using UnityEngine;
using STATEMACHINE;
using UNIT;
using Unity.VisualScripting;

namespace PEDESTRIAN
{
    public class PedestrainWalkState : BaseState<EPEDESTRAINSTATE>
    {
        private Transform m_curerntWaypoint = null;
        private int m_currentWaypointIndex = 0;
        private APedestrain m_pedestrainSciprt = null;
        private float m_moveSpeed = 0.0f;

        private int m_dogFoundCount = 0;
        private Collider[] m_dogColliderFound = new Collider[3];
        //==============================================================

        public PedestrainWalkState(StateManager<EPEDESTRAINSTATE> sm, APedestrain aPedestrain, float speed) : base(EPEDESTRAINSTATE.WALK, sm)
        {
            this.m_pedestrainSciprt = aPedestrain;
            this.m_moveSpeed = speed;
        }

        public override void EnterState()
        {
            this.m_mySM.SetDisplayText(this.StateKey.ToString());
            this.m_curerntWaypoint = this.m_mySM.wayPoints[this.m_currentWaypointIndex];
            this.m_pedestrainSciprt.SetMoveSpeed(this.m_moveSpeed);
        }

        public override void ExitState()
        {

        }

        public override EPEDESTRAINSTATE GetNextState()
        {
            return EPEDESTRAINSTATE.WALK;
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
            this.CheckIsCloseToDog();
            this.CheckDistanceAndMove();
        }

        private void CheckDistanceAndMove()
        {
            Vector3 direction = this.m_curerntWaypoint.position - this.m_mySM.transform.position;
            direction.y = 0.0f; //Ensure won't sleep

            if(direction != Vector3.zero)
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

            this.m_pedestrainSciprt.SetDestination(this.m_curerntWaypoint.position);
        }

        private void CheckIsCloseToDog()
        {
            this.m_dogFoundCount = Physics.OverlapSphereNonAlloc(this.m_mySM.transform.position, this.m_pedestrainSciprt.GetDetectionRange(), this.m_dogColliderFound, this.m_pedestrainSciprt.GetDetectionLayerMask());

            if (this.m_dogFoundCount <= 0) return;

            for(int i = 0; i < this.m_dogColliderFound.Length; i++)
            {
                if (this.m_dogColliderFound[i] == null) continue;

                this.m_pedestrainSciprt.SetFleeDirection(this.m_mySM.transform.position - this.m_dogColliderFound[i].transform.position);
                this.m_pedestrainSciprt.SetLastDetectedPosition(this.m_dogColliderFound[i].transform.position);
                this.m_mySM.ChangeState(EPEDESTRAINSTATE.FLEE);
                return;
            }
        }

        //==============================================================

    }
}