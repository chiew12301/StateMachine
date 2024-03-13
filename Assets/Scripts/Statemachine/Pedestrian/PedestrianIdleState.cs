using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using STATEMACHINE;
using UNIT;
using System.Runtime.InteropServices.WindowsRuntime;

namespace PEDESTRIAN
{
    public class PedestrianIdleState : BaseState<EPEDESTRAINSTATE>
    {
        private APedestrain m_pedestrainSciprt = null;

        private int m_dogFoundCount = 0;
        private Collider[] m_dogColliderFound = new Collider[3];
        //==============================================================

        public PedestrianIdleState(StateManager<EPEDESTRAINSTATE> sm, APedestrain aPedestrain) : base(EPEDESTRAINSTATE.IDLE, sm)
        {
            this.m_pedestrainSciprt = aPedestrain;
        }

        public override void EnterState()
        {
            this.m_mySM.SetDisplayText(this.StateKey.ToString());
            this.CheckIsCloseToDog();
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

        }

        private void CheckIsCloseToDog()
        {
            this.m_dogFoundCount = Physics.OverlapSphereNonAlloc(this.m_mySM.transform.position, this.m_pedestrainSciprt.GetDetectionRange(), this.m_dogColliderFound, this.m_pedestrainSciprt.GetDetectionLayerMask());

            if (this.m_dogFoundCount <= 0)
            {
                this.m_mySM.ChangeState(EPEDESTRAINSTATE.WALK);
                return;
            }

            for (int i = 0; i < this.m_dogColliderFound.Length; i++)
            {
                if (this.m_dogColliderFound[i] == null) continue;

                this.m_pedestrainSciprt.SetFleeDirection(this.m_mySM.transform.position - this.m_dogColliderFound[i].transform.position);
                this.m_mySM.ChangeState(EPEDESTRAINSTATE.FLEE);
                return;
            }

            this.m_mySM.ChangeState(EPEDESTRAINSTATE.WALK);
        }

        //==============================================================

    }
}