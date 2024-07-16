using UnityEngine;
public class Weapon : MonoBehaviour
{
    public int Damage { get; private set; }
    public int BulletsPerShot { get; private set; }

    public void Init(WeaponConfig config)
    {
        Damage = config.damage;
        BulletsPerShot = config.bulletsPerShot;
    }
}