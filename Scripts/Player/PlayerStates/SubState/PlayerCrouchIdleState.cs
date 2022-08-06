using Player.PlayerStates.StateMachine;
using ScriptableObject;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerCrouchIdleState : PlayerState
    {
        public PlayerCrouchIdleState(PlayerController playerController, PlayerStateMachine stateMachine, PlayerMovementParameters movementParams, string animName) : base(playerController, stateMachine, movementParams, animName)
        {
        }
        
        public override void EnterState()
        {
            base.EnterState();
        }

        public override void UpdateState()
        {
            base.UpdateState();
            if (Input.GetButtonDown("Crouch") && playerController.CheckForGrounded())
            {
                stateMachine.ChangeState(playerController.IdleState,playerController._animator);
            }
            else if (Input.GetButton("Horizontal") && playerController.CheckForGrounded())
            {
                stateMachine.ChangeState(playerController.CrouchMoveState,playerController._animator);
            }
            else if (playerController.CheckForGrounded() && playerController.CurrentVelocity.y != 0)
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