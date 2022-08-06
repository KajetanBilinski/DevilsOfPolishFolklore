using Player.PlayerStates.StateMachine;
using ScriptableObject;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerCarryIdleState : PlayerState
    {
        public PlayerCarryIdleState(PlayerController playerController, PlayerStateMachine stateMachine, PlayerMovementParameters movementParams, string animName) : base(playerController, stateMachine, movementParams, animName)
        {
        }
        
        public override void EnterState()
        {
            base.EnterState();
        }

        public override void UpdateState()
        {
            base.UpdateState();
            if (playerController.CheckForGrounded() && Input.GetButtonDown("Take"))
            {
                // DROP 
                playerController.DropItem();
                stateMachine.ChangeState(playerController.IdleState,playerController._animator);
            }
            else if (playerController.CheckForGrounded() && Input.GetButton("Horizontal"))
            {
                stateMachine.ChangeState(playerController.CarryMoveState,playerController._animator);
            }
            else if (!playerController.CheckForGrounded() && playerController.CurrentVelocity.y != 0)
            {
                // DROP 
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