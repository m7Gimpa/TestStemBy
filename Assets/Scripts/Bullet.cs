using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    
    private Vector2 _targetPosition;
    private int _damage;
    
    public void Initialize(Vector2 targetPosition, int damage)
    {
        _targetPosition = targetPosition;
        _damage = damage;
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
            Destroy(gameObject);
        }
    }
}