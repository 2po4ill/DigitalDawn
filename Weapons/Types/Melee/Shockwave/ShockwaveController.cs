using UnityEngine;

public class ShockwaveController : WeaponController
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
        // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int chargeState = 0;
    BlasterState blasterState;

    public void ChangeState() {
        if (chargeState < 7)
        chargeState += 1;
        blasterState.ChangeState(chargeState);
    }
    protected override void Start()
    {
        base.Start();
        blasterState = FindObjectOfType<BlasterState>();
    }

    protected override void Attack()
    {
        if(chargeState >= 7){
            chargeState = 0;
            blasterState.Reset();
            base.Attack();
            GameObject spawnedShockwave = Instantiate(weaponData.Prefab);
            spawnedShockwave.transform.position = transform.position;
            spawnedShockwave.transform.parent = transform;
        }        
    }


}

  
