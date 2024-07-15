using UnityEngine;
public class Weapon : MonoBehaviour
{
    protected WeaponConfig weaponConfig;  
    public void Init(WeaponConfig config)
    {
        weaponConfig = config;
    }
    public virtual void Shoot(GameObject target)
    {
        Debug.Log("Base weapon: Shooting at " + target.name + " with damage " + weaponConfig.damage);
    }
}