using STATEMACHINE;
using UNIT;
using UnityEngine;

namespace PEDESTRIAN
{
    [System.Serializable]
    public enum EPEDESTRAINSTATE
    {
        IDLE,
        WALK,
        FLEE
    }

    public class PedestrianStateMachine : StateManager<EPEDESTRAINSTATE>
    {
        [SerializeField] private APedestrain m_pedestrainSciprt = null;

        //==============================================================

        protected override void Awake() {
            base.Awake();
            this.InitializeStateMachine();
        }

        protected override void InitializeStateMachine()
        {
            PedestrianIdleState idleState = new PedestrianIdleState(this, this.m_pedestrainSciprt);
            PedestrainWalkState walkState = new PedestrainWalkState(this, this.m_pedestrainSciprt, this.m_pedestrainSciprt.GetMoveSpeed());
            PedestrianFleeState fleeState = new PedestrianFleeState(this, this.m_pedestrainSciprt, this.m_pedestrainSciprt.GetFleeMoveSpeed());

            this.m_statesDict.Add(idleState.StateKey, idleState);
            this.m_statesDict.Add(walkState.StateKey, walkState);
            this.m_statesDict.Add(fleeState.StateKey, fleeState);

            this.m_currentState = this.m_statesDict[EPEDESTRAINSTATE.IDLE];
        }

        //==============================================================

    }
}