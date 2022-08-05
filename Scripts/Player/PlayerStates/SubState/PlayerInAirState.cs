using Player.PlayerStates.StateMachine;
using ScriptableObject;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerInAirState : PlayerState
    {
        public PlayerInAirState(PlayerController playerController, PlayerStateMachine stateMachine, PlayerMovementParameters movementParams, string animName) : base(playerController, stateMachine, movementParams, animName)
        {
        }
        
        public override void EnterState()
        {
            base.EnterState();
        }

        public override void UpdateState()
        {
            if (playerController.CheckForGrounded() && this.playerController.CurrentVelocity.y == 0 && !Input.GetButton("Horizontal"))
            {
                this.stateMachine.ChangeState(this.playerController.IdleState);
            }
            else if (playerController.CheckForGrounded() && this.playerController.CurrentVelocity.y == 0 && Input.GetButton("Horizontal"))
            {
                this.stateMachine.ChangeState(this.playerController.MoveState);
            }
            else if (playerController.CheckForLadder())
            {
                this.stateMachine.ChangeState(this.playerController.ClimbState);
            }
            else
            {
                this.playerController.CheckFlip();
                this.playerController.SetVelocityX(this.movementParams.MOVING_SPEED * playerController.xInput);
                //this.playerController.Anim.SetFloat("yVelocity", this.playerController.CurrentVelocity.y);
                //this.playerController.Anim.SetFloat("xVelocity", Mathf.Abs(this.playerController.CurrentVelocity.x));
            }
        }

        public override void ExitState()
        {
            base.ExitState();
        }
    }
}