using Player.PlayerStates.StateMachine;
using ScriptableObject;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerJumpState : PlayerState
    {
        public bool isAbilityFinished;
        public PlayerJumpState(PlayerController playerController, PlayerStateMachine stateMachine, PlayerMovementParameters movementParams, string animName) : base(playerController, stateMachine, movementParams, animName)
        {
        }
        
        public override void EnterState()
        {
            base.EnterState();
            isAbilityFinished = true;
            playerController.rb.AddForce(new Vector2(0,movementParams.JUMP_POWER),ForceMode2D.Impulse);
        }

        public override void UpdateState()
        {
            base.UpdateState();
            if (this.isAbilityFinished)
            {
                if (playerController.CheckForGrounded() && this.playerController.CurrentVelocity.y < Mathf.Epsilon)
                {
                    this.stateMachine.ChangeState(this.playerController.IdleState,playerController._animator);
                }
                else
                {
                    this.stateMachine.ChangeState(this.playerController.InAirState,playerController._animator);
                }
            }
        }

        public override void ExitState()
        {
            base.ExitState();
        }
    }
}