using System.Collections.Generic;
using UnityEngine;

public class ShockwaveBehaviour : MeleeWeaponBehaviour
{
    List<GameObject> markedEnemies;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    const string ENEMY = "Enemy";
    protected override void Start()
    {
       base.Start(); 
       markedEnemies = new List<GameObject>();
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag(ENEMY) && !markedEnemies.Contains(collider.gameObject)){
            EnemyStats enemy = collider.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage);

            markedEnemies.Add(collider.gameObject);
        }
    }
}
    // Update is called once per frame
