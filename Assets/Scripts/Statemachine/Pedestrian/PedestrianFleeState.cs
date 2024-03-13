using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using STATEMACHINE;
using UNIT;

namespace PEDESTRIAN
{
    public class PedestrianFleeState : BaseState<EPEDESTRAINSTATE>
    {
        private APedestrain m_pedestrainSciprt = null;
        private float m_moveSpeed = 0.0f;

        private int m_dogFoundCount = 0;
        private Collider[] m_dogColliderFound = new Collider[3];
        //==============================================================

        public PedestrianFleeState(StateManager<EPEDESTRAINSTATE> sm, APedestrain aPedestrain, float speed) : base(EPEDESTRAINSTATE.FLEE, sm)
        {
            this.m_pedestrainSciprt = aPedestrain;
            this.m_moveSpeed = speed;
        }

        public override void EnterState()
        {
            this.m_mySM.SetDisplayText(this.StateKey.ToString());
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
            if(!this.CheckIsCloseToDog())
            {
                this.m_mySM.ChangeState(EPEDESTRAINSTATE.IDLE);
                return;
            }
            this.m_mySM.transform.position = Vector3.MoveTowards(this.m_mySM.transform.position, this.m_mySM.transform.position + this.m_pedestrainSciprt.GetFleeDirection() * this.m_pedestrainSciprt.GetFleeDistance(), Time.deltaTime * this.m_moveSpeed);
        }

        private bool CheckIsCloseToDog()
        {
            this.m_dogFoundCount = Physics.OverlapSphereNonAlloc(this.m_mySM.transform.position, this.m_pedestrainSciprt.GetDetectionRange(), this.m_dogColliderFound, this.m_pedestrainSciprt.GetDetectionLayerMask());

            if (this.m_dogFoundCount <= 0) return false;

            for (int i = 0; i < this.m_dogColliderFound.Length; i++)
            {
                if (this.m_dogColliderFound[i] == null) continue;

                this.m_pedestrainSciprt.SetFleeDirection(this.m_mySM.transform.position - this.m_dogColliderFound[i].transform.position);
                return true;
            }

            return false;
        }

        //==============================================================
    }
}