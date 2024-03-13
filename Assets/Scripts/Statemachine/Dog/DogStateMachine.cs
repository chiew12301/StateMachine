using STATEMACHINE;
using UNIT;
using UnityEngine;

namespace DOG
{
    [System.Serializable]
    public enum EDOGSTATE
    {
        IDLE,
        PATROL
    }

    public class DogStateMachine : StateManager<EDOGSTATE>
    {
        [SerializeField] private ADog m_dogScript = null;

        //==============================================================

        protected override void Awake()
        {
            base.Awake();
            this.InitializeStateMachine();
        }

        protected override void InitializeStateMachine()
        {
            DogIdleState idleState = new DogIdleState(this, this.m_dogScript);
            DogPatrolState patrolState = new DogPatrolState(this, this.m_dogScript, this.m_dogScript.GetMoveSpeed());

            this.m_statesDict.Add(idleState.StateKey, idleState);
            this.m_statesDict.Add(patrolState.StateKey, patrolState);

            this.m_currentState = this.m_statesDict[EDOGSTATE.IDLE];
        }

        //==============================================================
    }
}