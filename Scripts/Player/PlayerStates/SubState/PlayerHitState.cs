using Player.PlayerStates.StateMachine;
using ScriptableObject;

namespace DefaultNamespace
{
    public class PlayerHitState : PlayerState
    {
        public PlayerHitState(PlayerController playerController, PlayerStateMachine stateMachine, PlayerMovementParameters movementParams, string animName) : base(playerController, stateMachine, movementParams, animName)
        {
        }
        
        public override void EnterState()
        {
            base.EnterState();
        }

        public override void UpdateState()
        {
            base.UpdateState();
        }

        public override void ExitState()
        {
            base.ExitState();   
        }
    }
}