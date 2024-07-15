using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Custom/Weapon Data", order = 1)]
public class WeaponConfig : ScriptableObject
{
    public int damage = 10;  
    public int bulletsPerShot = 1; 
}