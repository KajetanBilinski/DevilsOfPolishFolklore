using Player.PlayerStates.StateMachine;
using ScriptableObject;
using UnityEngine;


namespace DefaultNamespace
{
    public class PlayerIdleState : PlayerState
    {
        public PlayerIdleState(PlayerController playerController, PlayerStateMachine stateMachine, PlayerMovementParameters movementParams, string animName) : base(playerController, stateMachine, movementParams, animName)
        {
        }
        
        
        public override void EnterState()
        {
            base.EnterState();
            this.playerController.SetVelocityX(0f);
        }

        public override void UpdateState()
        {
            base.UpdateState();
            if (Input.GetButtonDown("Horizontal") && playerController.CheckForGrounded())
            {
                stateMachine.ChangeState(playerController.MoveState,playerController._animator);
            }
            else if (Input.GetButtonDown("Jump") && playerController.CheckForGrounded())
            {
                stateMachine.ChangeState(playerController.JumpState,playerController._animator);
            }
            else if (!playerController.CheckForGrounded() && playerController.CurrentVelocity.y < 0)
            {
                stateMachine.ChangeState(playerController.InAirState,playerController._animator);
            }
            else if (playerController.CheckForGrounded() && playerController.CheckForPickupItem() && Input.GetButtonDown("Take") )
            {
                stateMachine.ChangeState(playerController.CarryIdleState,playerController._animator);
            }
            else if (playerController.CheckForGrounded() && Input.GetButtonDown("Crouch"))
            {
                stateMachine.ChangeState(playerController.CrouchIdleState,playerController._animator);
            }
            else if (playerController.CheckForGrounded() && Input.GetButtonDown("Hit"))
            {
                stateMachine.ChangeState(playerController.HitState,playerController._animator);
            }
            else if (playerController.CheckForLadder() && Input.GetButtonDown("Vertical"))
            {
                stateMachine.ChangeState(playerController.ClimbState,playerController._animator);
            }
            

        }

        
        

        public override void ExitState()
        {
            base.ExitState();
        }
    }
}