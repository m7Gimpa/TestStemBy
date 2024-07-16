using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private GameObject _hitEffectPistol; 
    [SerializeField] private GameObject _hitEffectShotgun; 

    private Vector2 _targetPosition;
    private int _damage;
    private string _weaponType; 

    public void Initialize(Vector2 targetPosition, int damage, string weaponType)
    {
        _targetPosition = targetPosition;
        _damage = damage;
        _weaponType = weaponType; 
        Destroy(gameObject, 5f); 
    }

    private void Update()
    {
        Vector2 position = Vector2.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
        transform.position = position;

        if ((Vector2)transform.position == _targetPosition)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out var enemy))
        {
            enemy.TakeDamage(_damage);

            switch (_weaponType)
            {
                case "Pistol":
                    if (_hitEffectPistol != null)
                        Instantiate(_hitEffectPistol, transform.position, Quaternion.identity);
                    break;
                case "Shotgun":
                    if (_hitEffectShotgun != null)
                        Instantiate(_hitEffectShotgun, transform.position, Quaternion.identity);
                    break;
            }
            Destroy(gameObject);
        }
    }
}