using STATEMACHINE;
using UNIT;
using UnityEngine;

namespace DOG
{
    public class DogIdleState : BaseState<EDOGSTATE>
    {
        private ADog m_dogScript = null;

        //==============================================================
        public DogIdleState(StateManager<EDOGSTATE> sm, ADog dogscript) : base(EDOGSTATE.IDLE, sm) 
        {
            this.m_dogScript = dogscript;
        }

        public override void EnterState()
        {
            this.m_mySM.SetDisplayText(this.StateKey.ToString());
        }

        public override void ExitState()
        {

        }

        public override EDOGSTATE GetNextState()
        {
            return EDOGSTATE.PATROL;
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
            if(this.m_dogScript.GetIsStaminaFull())
            {
                this.m_mySM.ChangeState(EDOGSTATE.PATROL);
                return;
            }

            this.m_dogScript.AddStamina();
        }
    }
}