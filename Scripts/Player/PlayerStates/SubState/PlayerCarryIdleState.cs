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
                stateMachine.ChangeState(playerController.IdleState);
            }
            else if (playerController.CheckForGrounded() && Input.GetButton("Horizontal"))
            {
                stateMachine.ChangeState(playerController.CarryMoveState);
            }
            else if (!playerController.CheckForGrounded() && playerController.CurrentVelocity.y != 0)
            {
                // DROP 
                stateMachine.ChangeState(playerController.InAirState);
            }
        }

        public override void ExitState()
        {
            base.ExitState();
        }
    }
}