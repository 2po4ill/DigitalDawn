using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "Enemy/EnemyScriptableObject")]
public class EnemyScriptableObject : ScriptableObject
{
    [SerializeField] float moveSpeed;
    [SerializeField] float maxHealth;
    [SerializeField] float damage;
    [SerializeField] bool hasRangeAttack;
    [SerializeField] GameObject projPrefab;
    
    public float MoveSpeed {get => moveSpeed; private set => moveSpeed = value;}
    public float MaxHealth {get => maxHealth; private set => maxHealth = value;}
    public float Damage {get => damage; private set => damage = value;}
    public bool HasRangeAttack {get => hasRangeAttack; private set => hasRangeAttack = value;}
    public GameObject ProjPrefab {get => projPrefab; private set => projPrefab = value;}
}
