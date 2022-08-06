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

        public void ChangeState(PlayerState newState,Animator animator)
        {
            CurrentState.ExitState();
            CurrentState = newState;
            CurrentState.EnterState();
            animator.Play(newState._animName);
        }
    }
}