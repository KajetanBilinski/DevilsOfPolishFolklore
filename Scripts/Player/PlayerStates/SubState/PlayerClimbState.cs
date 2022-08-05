using Player.PlayerStates.StateMachine;
using ScriptableObject;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerClimbState : PlayerState
    {
        public PlayerClimbState(PlayerController playerController, PlayerStateMachine stateMachine, PlayerMovementParameters movementParams, string animName) : base(playerController, stateMachine, movementParams, animName)
        {
        }
        
        public override void EnterState()
        {
            base.EnterState();
            playerController.rb.gravityScale = 0;
            // wyłączyć grawitacje
        }

        public override void UpdateState()
        {
            base.UpdateState();
            this.playerController.CheckFlip();
            if (!Input.GetButton("Horizontal"))
            {
                this.playerController.SetVelocityX(0);
            }
            else
            {
                this.playerController.SetVelocityX(this.movementParams.MOVING_SPEED*playerController.xInput);
            }
            if (!Input.GetButton("Vertical"))
            {
                this.playerController.SetVelocityY(0);
            }
            else
            {
                this.playerController.SetVelocityY(this.movementParams.MOVING_SPEED*playerController.yInput);
            }
          
            if (!playerController.CheckForLadder() && !playerController.CheckForGrounded())
            {
                stateMachine.ChangeState(playerController.InAirState);
                playerController.rb.gravityScale = 1;
            }
            else if (!playerController.CheckForLadder() && playerController.CheckForGrounded())
            {
                stateMachine.ChangeState(playerController.IdleState);
                playerController.rb.gravityScale = 1;
            }
        }

        public override void ExitState()
        {
            base.ExitState();
        }
    }
}