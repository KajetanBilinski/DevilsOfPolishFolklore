using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Player;
using Player.PlayerStates.StateMachine;
using ScriptableObject;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public PlayerStateMachine StateMachine;
    public PlayerIdleState IdleState;
    public PlayerMoveState MoveState;
    public PlayerCarryIdleState CarryIdleState;
    public PlayerCarryMoveState CarryMoveState;
    public PlayerCrouchIdleState CrouchIdleState;
    public PlayerCrouchMoveState CrouchMoveState;
    public PlayerClimbState ClimbState;
    public PlayerJumpState JumpState;
    public PlayerDeadState DeadState;
    public PlayerInAirState InAirState;
    public PlayerHitState HitState;

    [SerializeField] private PlayerMovementParameters _movementParameters;
    [SerializeField] public Animator _animator;

    public Rigidbody2D rb;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform itemCheck;
    [SerializeField] private Transform ladderCheck;

    public Vector2 CurrentVelocity;
    public Vector2 CurrentPosition;
    public Vector2 TmpVec;

    public int xInput;
    public int yInput;
    public int FacingDirection;

    private GameObject closestItem;
    private GameObject carryingItem;

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this,this.StateMachine,this._movementParameters,"Idle");
        MoveState = new PlayerMoveState(this,this.StateMachine,this._movementParameters,"Move");
        CarryIdleState = new PlayerCarryIdleState(this,this.StateMachine,this._movementParameters,"CarryIdle");
        CarryMoveState = new PlayerCarryMoveState(this,this.StateMachine,this._movementParameters,"CarryMove");
        CrouchIdleState = new PlayerCrouchIdleState(this,this.StateMachine,this._movementParameters,"CrouchIdle");
        CrouchMoveState = new PlayerCrouchMoveState(this,this.StateMachine,this._movementParameters,"CrouchMove");
        ClimbState = new PlayerClimbState(this,this.StateMachine,this._movementParameters,"Climb");
        JumpState = new PlayerJumpState(this,this.StateMachine,this._movementParameters,"Jump");
        DeadState = new PlayerDeadState(this,this.StateMachine,this._movementParameters,"Dead");
        InAirState = new PlayerInAirState(this,this.StateMachine,this._movementParameters,"InAir");
        HitState = new PlayerHitState(this,this.StateMachine,this._movementParameters,"Hit");
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FacingDirection = 1;
        StateMachine.Initialize(IdleState);
    }

    // Update is called once per frame
    private void Update()
    {
        this.CurrentVelocity = this.rb.velocity;
        this.CurrentPosition = this.transform.position;
        this.StateMachine.CurrentState.UpdateState();
        GetInputs();
       
    }
    

    private void GetInputs()
    {
        var xI = Input.GetAxis("Horizontal");
        var yI = Input.GetAxis("Vertical");
        xInput = xI > 0 ? 1 : xI < 0 ? -1 : 0;
        yInput = yI > 0 ? 1 : yI < 0 ? -1 : 0;
    }

    private void FixedUpdate()
    {
        //StateMachine.CurrentState.PhysicsUpdate();
    }
    
    public void SetVelocityX(float velocity)
    {
        this.TmpVec.Set(velocity, this.CurrentVelocity.y);
        this.rb.velocity = this.TmpVec;
        this.CurrentVelocity = this.TmpVec;
    }

    public void SetVelocityY(float velocity)
    {
        this.TmpVec.Set(this.CurrentVelocity.x, velocity);
        this.rb.velocity = this.TmpVec;
        this.CurrentVelocity = this.TmpVec;
    }
    
    public bool CheckForGrounded()
    {
        return Physics2D.OverlapCircle(this.groundCheck.position, this._movementParameters.GROUND_CHECK_RADIUS,
            this._movementParameters.GROUND_LAYER);
    }

    public void CheckFlip()
    {
        if (xInput != 0 && xInput != this.FacingDirection)
        {
            Flip();
        }
    }

    public bool CheckForPickupItem()
    {
        return Physics2D.OverlapCircle(this.itemCheck.position, this._movementParameters.ITEM_CHECK_RADIUS,
            this._movementParameters.ITEM_LAYER);
    }

    public bool CheckForLadder()
    {
        return Physics2D.OverlapCircle(this.ladderCheck.position, this._movementParameters.LADDER_CHECK_RADIUS,
            this._movementParameters.LADDER_LAYER);
    }

    private void Flip()
    {
        this.FacingDirection *= -1;
        this.transform.Rotate(0.0f, 180, 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col != null && closestItem != col.gameObject)
            closestItem = col.gameObject;
        if (col.gameObject.CompareTag("Apple"))
        {
            Destroy(col.gameObject);
            PlayerData.instance.AddMoney(1);
        }
    }

    private void OnTriggerStay2D(Collider2D col) => OnTriggerEnter2D(col);

    public void DropItem()
    {
        if(carryingItem==null )
            return;
        carryingItem.transform.position = gameObject.transform.position;
        carryingItem.SetActive(true);
        carryingItem = null;
    }

    public bool PickUp()
    {
        if (closestItem == null && carryingItem!=null)
            return false;
        else
        {
            closestItem.SetActive(false);
            carryingItem = closestItem;
            closestItem = null;
            return true;
        }
    }
}
