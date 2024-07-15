using UnityEngine;
using UnityEngine.Serialization;

public class HeroPlayer : MonoBehaviour
{
    [SerializeField] private Pistol _pistol;  
    [SerializeField] private Shotgun _shotgun; 
    [SerializeField] private WeaponConfig _pistolConfig;  
    [SerializeField] private WeaponConfig _shotgunConfig;  
    
    private Weapon _currentWeapon;
    private CharacterController _characterController;
    
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>(); 
        Pistol pistol = new Pistol();
        pistol.Init(_pistolConfig);
        _currentWeapon = pistol;
    }

    private void FindNearestEnemy()
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
        
        if (_currentWeapon != null)
        {
            _currentWeapon.Shoot(nearestEnemy);
        }
    }
    
    public void Shoot()
    {
        FindNearestEnemy();
    }

    public void SwitchToPistol()
    {
        _renderer.material.color = Color.blue;  
        _currentWeapon = _pistol;  
    }

    public void SwitchToShotGun()
    {
        _renderer.material.color = Color.red;  
        _currentWeapon = _shotgun;  
    }
}
