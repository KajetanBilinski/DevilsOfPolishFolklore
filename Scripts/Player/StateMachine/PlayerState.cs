using ScriptableObject;
using UnityEngine;

namespace Player.PlayerStates.StateMachine
{
    public class PlayerState
    {
        protected PlayerController playerController;
        protected PlayerStateMachine stateMachine;
        protected PlayerMovementParameters movementParams;

        public string _animName;

        protected float startTime;

        protected bool isAnimFinished;
        

        public PlayerState(PlayerController playerController, PlayerStateMachine stateMachine,
            PlayerMovementParameters movementParams, string animName)
        {
            this.playerController = playerController;
            this.stateMachine = stateMachine;
            this.movementParams = movementParams;
            this._animName = animName;
        }

        public virtual void DoChecks()
        {
            
        }

        public virtual void EnterState()
        {
            DoChecks();
            this.startTime = Time.time;
            this.isAnimFinished = false;
        }

        public virtual void UpdateState()
        {
            
        }

        public virtual void ExitState()
        {
            
        }
    }
}