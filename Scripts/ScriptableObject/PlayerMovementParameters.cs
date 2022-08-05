using UnityEngine;

namespace ScriptableObject
{
    [CreateAssetMenu(fileName = "PlayerMovementParams", menuName = "Diabelki/Player/PlayerMovementParams", order = 1 )]
    public class PlayerMovementParameters : UnityEngine.ScriptableObject
    {
        [Header("Basic Parameters")] 
        public float MOVING_SPEED = 3;
        public float CARRYING_SPEED = 1;
        public float CROUCHING_SPEED = 2;
        public float JUMP_POWER = 3;
        public float GRAVITY_SCALE = 3;
        [Space(3)]
        [Header("Modifiers")]
        public float WATER_WALK_MOD = 0.75f;
        public float WATER_JUMP_MOD = 0.5f;
        [Space(3)]
        [Header("Check variables")]
        public float GROUND_CHECK_RADIUS = 0.2f;
        public LayerMask GROUND_LAYER;
        public float ITEM_CHECK_RADIUS = 0.01f;
        public LayerMask ITEM_LAYER;
        public float LADDER_CHECK_RADIUS = 0.01f;
        public LayerMask LADDER_LAYER;
    }
}