using UnityEngine;
public class Pistol : Weapon
{
    public override void Shoot(GameObject target)
    {
        for (int i = 0; i < weaponConfig.bulletsPerShot; i++)
        {
            Debug.Log("Pistol: Shooting at " + target.name + " with damage " + weaponConfig.damage);
        }
    }
}