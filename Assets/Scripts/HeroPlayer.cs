using UnityEngine;

public class HeroPlayer : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private WeaponConfig _pistolConfig;
    [SerializeField] private WeaponConfig _shotgunConfig;
    [SerializeField] private SpriteRenderer _weaponSprite;
    [SerializeField] private GameObject[] _bulletPrefab;

    private Weapon _currentWeapon;
    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        SwitchToPistol();
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
        for (int i = 0; i < _currentWeapon.BulletsPerShot; i++)
        {
            int bulletIndex = (_currentWeapon is Pistol) ? 0 : 1;
        
            GameObject bulletObject = Instantiate(_bulletPrefab[bulletIndex], _firePoint.position, Quaternion.identity);
            Bullet bullet = bulletObject.GetComponent<Bullet>();
            bullet.Initialize(target.transform.position, _currentWeapon.Damage);
        }
        Debug.Log("Shooting at " + target.name);
    }
    
    public void SwitchToPistol()
    {
        _weaponSprite.sprite = _pistolConfig.WeaponSpriteRenderer;
        Pistol pistol = new Pistol();
        pistol.Init(_pistolConfig);
        _currentWeapon = pistol;
    }

    public void SwitchToShotGun()
    {
        _weaponSprite.sprite = _shotgunConfig.WeaponSpriteRenderer;
        Shotgun shotgun = new Shotgun();
        shotgun.Init(_shotgunConfig);
        _currentWeapon = shotgun;
    }
}
