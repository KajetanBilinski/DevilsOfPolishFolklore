using Player.PlayerStates.StateMachine;
using ScriptableObject;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerCrouchMoveState : PlayerState
    {
        public PlayerCrouchMoveState(PlayerController playerController, PlayerStateMachine stateMachine, PlayerMovementParameters movementParams, string animName) : base(playerController, stateMachine, movementParams, animName)
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
            this.playerController.SetVelocityX(this.movementParams.CROUCHING_SPEED*playerController.xInput);
            if (Input.GetButtonDown("Crouch") && playerController.CheckForGrounded())
            {
                stateMachine.ChangeState(playerController.IdleState,playerController._animator);
            }
            else if (!Input.GetButton("Horizontal") && playerController.CheckForGrounded())
            {
                stateMachine.ChangeState(playerController.CrouchIdleState,playerController._animator);
            }
            else if (!playerController.CheckForGrounded() && playerController.CurrentVelocity.y != 0)
            {
                stateMachine.ChangeState(playerController.InAirState,playerController._animator);
            }
        }

        public override void ExitState()
        {
            base.ExitState();
        }
        
        
    }
}