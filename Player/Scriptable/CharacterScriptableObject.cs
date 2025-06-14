using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObjectScript", menuName = "Character/CharacterScriptableObjectScript")]
public class CharacterScriptableObject : ScriptableObject
{   
    
    [SerializeField] GameObject startingWeapon;
    public GameObject StartingWeapon { get => startingWeapon; private set => startingWeapon = value;}

    [SerializeField] float maxHealth;
    public float MaxHealth { get => maxHealth; private set => maxHealth = value;}

    [SerializeField] float recovery;
    public float Recovery { get => recovery; private set => recovery = value;}

    [SerializeField] float moveSpeed;
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value;}

    [SerializeField] float might;
    public float Might { get => might; private set => might = value;}

    [SerializeField] float projectileSpeed;
    public float ProjectileSpeed { get => projectileSpeed; private set => projectileSpeed = value;}


}
