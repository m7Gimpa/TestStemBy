using UnityEngine;

public class Shotgun : Weapon
{
    public override void Shoot(GameObject target)
    {
        for (int i = 0; i < weaponConfig.bulletsPerShot; i++)
        {
            Debug.Log("Shotgun: Shooting at " + target.name + " with damage " + weaponConfig.damage);
        }
    }
}