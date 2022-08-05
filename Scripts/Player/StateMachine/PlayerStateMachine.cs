using UnityEngine;

namespace Player.PlayerStates.StateMachine
{
    public class PlayerStateMachine
    {
        public PlayerState CurrentState { get; private set; }

        public void Initialize(PlayerState startState)
        {
            CurrentState = startState;
            CurrentState.EnterState();
            //Debug.Log(CurrentState);
            //.Log("=======================");
        }

        public void ChangeState(PlayerState newState)
        {
            CurrentState.ExitState();
            CurrentState = newState;
            CurrentState.EnterState();
            Debug.Log(CurrentState);
            Debug.Log("=======================");
        }
    }
}