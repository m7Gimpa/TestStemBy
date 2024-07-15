using UnityEngine;
using UnityEngine.Serialization;

public class HeroPlayer : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;  
    [SerializeField] private WeaponConfig _pistolConfig;  
    [SerializeField] private WeaponConfig _shotgunConfig;
    [SerializeField] private SpriteRenderer _weaponSprite;
   
    private Weapon _currentWeapon;
    private CharacterController _characterController;
    
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _characterController = GetComponent<CharacterController>();
        Pistol pistol = new Pistol();
        pistol.Init(_pistolConfig);
        _currentWeapon = pistol;
    }

    private GameObject FindNearestEnemy()
    {
        GameObject nearestEnemy = null;
        float minDistance = Mathf.Infinity;  
        Vector2 position = transform.position;  

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(position, _characterController.radius);
        
        foreach (Collider2D hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent<Enemy>(out var enemy))
            {
                float distance = Vector2.Distance(position, hitCollider.transform.position);
                
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestEnemy = hitCollider.gameObject;
                }
            }
        }

        return nearestEnemy;
    }
    
    public void Shoot()
    {
        GameObject nearestEnemy = FindNearestEnemy();
        if (nearestEnemy != null)
        {
            Shoot(nearestEnemy);
        }
    }

    private void Shoot(GameObject target)
    {
        Debug.Log("Shooting at " + target.name);
    }

    public void SwitchToPistol()
    {
        _weaponSprite.sprite = _pistolConfig.WeaponSpriteRenderer;
    }

    public void SwitchToShotGun()
    {
        _weaponSprite.sprite = _shotgunConfig.WeaponSpriteRenderer;
    }
}
