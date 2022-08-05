using Player.PlayerStates.StateMachine;
using ScriptableObject;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerCarryMoveState : PlayerState
    {
        public PlayerCarryMoveState(PlayerController playerController, PlayerStateMachine stateMachine, PlayerMovementParameters movementParams, string animName) : base(playerController, stateMachine, movementParams, animName)
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
            this.playerController.SetVelocityX(this.movementParams.CARRYING_SPEED*playerController.xInput);
            if (Input.GetButtonDown("Take") && playerController.CheckForGrounded())
            {
                stateMachine.ChangeState(playerController.IdleState);
            }
            else if (!Input.GetButtonDown("Horizontal") && playerController.CheckForGrounded())
            {
                // drop || place
                stateMachine.ChangeState(playerController.CarryIdleState);
            }
            else if (playerController.CheckForGrounded() && playerController.CurrentVelocity.y != 0)
            {
                // drop
                stateMachine.ChangeState(playerController.InAirState);
            }
        }

        public override void ExitState()
        {
            base.ExitState();
        }
    }
}