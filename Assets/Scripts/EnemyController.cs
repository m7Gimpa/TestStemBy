public class EnemyController
{
    private EnemyModel _model;
    private EnemyView _view;

    public EnemyController(EnemyModel model, EnemyView view)
    {
        _model = model;
        _view = view;
        _model.HealthChanged += OnHealthChanged;
    }

    public void TakeDamage(int damage)
    {
        _model.TakeDamage(damage);
        _view.ShowDamage(damage);
    }

    private void OnHealthChanged(int currentHealth)
    {
    }
}