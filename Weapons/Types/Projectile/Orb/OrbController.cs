using UnityEngine;


    public class OrbController : WeaponController
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedOrb = Instantiate(weaponData.Prefab);
        spawnedOrb.transform.position = transform.position;
        spawnedOrb.GetComponent<OrbBehaviour>().DirectionChecker(closestEnemyPosition, player.transform.position);
    }

    }

