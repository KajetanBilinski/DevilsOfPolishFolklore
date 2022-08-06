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
                // drop || place
                playerController.DropItem();
                stateMachine.ChangeState(playerController.IdleState,playerController._animator);
            }
            else if (!Input.GetButton("Horizontal") && playerController.CheckForGrounded())
            {
                stateMachine.ChangeState(playerController.CarryIdleState,playerController._animator);
            }
            else if (!playerController.CheckForGrounded() && playerController.CurrentVelocity.y != 0)
            {
                // drop
                playerController.DropItem();
                stateMachine.ChangeState(playerController.InAirState,playerController._animator);
            }
        }

        public override void ExitState()
        {
            base.ExitState();
        }
    }
}