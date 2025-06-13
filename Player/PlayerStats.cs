using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public CharacterScriptableObject characterData;

    
    [HideInInspector] public float currentRecovery;
    [HideInInspector] public float currentMoveSpeed;
    [HideInInspector] public float currentMight;
    [HideInInspector] public float currentProjectileSpeed;

    [Header("I-Frames")]
    public float invincibilityDuration;
    float invincibilityTimer;
    bool isInvincible;

    #region CurrentHealth
    float currentHealth;
    public float CurrentHealth {
        get { return currentHealth; }
        set {
            if (currentHealth != value){
                currentHealth = value;
                if(GameManager.instance != null){
                    GameManager.instance.currentHealthDisplay.text = "Health: " + currentHealth;
                }
            }
        }
    }
    #endregion

    void Awake()
    {
        characterData = CharacterSelector.GetData();
        CharacterSelector.instance.DestroySingleton();

        CurrentHealth = characterData.MaxHealth;
        currentRecovery = characterData.Recovery;
        currentMoveSpeed = characterData.MoveSpeed;
        currentMight = characterData.Might;
        currentProjectileSpeed = characterData.ProjectileSpeed;
    }

    void Start(){
        GameManager.instance.currentHealthDisplay.text = "Health: " + currentHealth;
    }

    void Update(){
        if(invincibilityTimer > 0){
            invincibilityTimer -= Time.deltaTime;
        }
        else if(isInvincible) {
            isInvincible = false;
        }
    }

    public void TakeDamage(float dmg){
        if(!isInvincible)
        {
            CurrentHealth -= dmg;

            invincibilityTimer = invincibilityDuration;
            isInvincible = true;
        }
        if(CurrentHealth <= 0){
            Kill();
        }
    }

    public void Kill(){
        if(!GameManager.instance.isGameOver){
            GameManager.instance.GameOver();
            currentMoveSpeed = 0f;
        }
    }
}
