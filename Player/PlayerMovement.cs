using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    [HideInInspector] public bool isRunning = false;
    [HideInInspector] public Vector2 moveDir;
    
    [HideInInspector] public float lastX;
    
    [HideInInspector] public float lastY;

    PlayerStats player;


    void Start()
    {
        player = GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        InputManagement();
    }

    void FixedUpdate()
    {
        Move();
    }

    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        if (moveDir.x != 0)
        {
            lastX = moveDir.x;
        }

        if (moveDir.y != 0)
        {
            lastY = moveDir.y;
        }
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(moveDir.x * player.currentMoveSpeed, moveDir.y * player.currentMoveSpeed);
        if (Mathf.Abs(moveDir.x) > 0 || Mathf.Abs(moveDir.y) > 0) {
            isRunning = true;
        }
        else {
            isRunning = false;
        }
    }

    public bool IsRunning(){
        return isRunning;
    }
    
}
