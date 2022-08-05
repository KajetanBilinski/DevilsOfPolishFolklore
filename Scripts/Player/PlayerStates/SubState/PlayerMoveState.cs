using Player.PlayerStates.StateMachine;
using ScriptableObject;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerMoveState : PlayerState
    {
        public PlayerMoveState(PlayerController playerController, PlayerStateMachine stateMachine, PlayerMovementParameters movementParams, string animName) : base(playerController, stateMachine, movementParams, animName)
        {
        }
        
        public override void EnterState()
        {
            base.EnterState();
        }

        public override void UpdateState()
        {
            base.UpdateState();
            this.playerController.CheckFlip();
            this.playerController.SetVelocityX(this.movementParams.MOVING_SPEED*playerController.xInput);
            
            if (!Input.GetButton("Horizontal"))
            {
                this.playerController.SetVelocityX(0f);
                this.stateMachine.ChangeState(playerController.IdleState);
            }
            else if (Input.GetButtonDown("Jump") && playerController.CheckForGrounded())
            {
                stateMachine.ChangeState(playerController.JumpState);
            }
            else if (!playerController.CheckForGrounded() && playerController.CurrentVelocity.y < 0)
            {
                stateMachine.ChangeState(playerController.InAirState);
            }
            else if (playerController.CheckForGrounded() && playerController.CheckForPickupItem() && Input.GetButtonDown("Take") )
            {
                stateMachine.ChangeState(playerController.CarryIdleState);
            }
            else if (playerController.CheckForGrounded() && Input.GetButtonDown("Crouch"))
            {
                stateMachine.ChangeState(playerController.CrouchIdleState);
            }
            else if (playerController.CheckForGrounded() && Input.GetButtonDown("Hit"))
            {
                stateMachine.ChangeState(playerController.HitState);
            }
            else if (playerController.CheckForLadder() && Input.GetButtonDown("Vertical"))
            {
                stateMachine.ChangeState(playerController.ClimbState);
            }
        }

        public override void ExitState()
        {
            base.ExitState();
        }
    }
}