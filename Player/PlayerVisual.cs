using System;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;
    PlayerMovement playerMovement;


    const string IS_RUNNING = "IsRunning";
    const string IS_DEAD = "IsDead";

    void Start(){
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void Update() {
        if(!GameManager.instance.isGameOver){
        animator.SetBool(IS_RUNNING, playerMovement.IsRunning());
        AdjustPlayerPositionDirection();
    }
    else{
        animator.SetBool(IS_DEAD, true);
    }
    }

    void AdjustPlayerPositionDirection() {
        if (playerMovement.lastX < 0) {
            spriteRenderer.flipX = true;
        }
        else {
            spriteRenderer.flipX = false;
        }
    }
}
