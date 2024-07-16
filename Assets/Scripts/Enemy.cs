using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyModel _model;
    private EnemyView _view;
    private EnemyController _controller;

    private void Awake()
    {
        _model = GetComponent<EnemyModel>();
        _view = GetComponent<EnemyView>();
        _controller = new EnemyController(_model, _view);
    }

    public void TakeDamage(int damage)
    {
        _controller.TakeDamage(damage);
    }
}