using UnityEngine;
using UnityEngine.Events;

public class Damagaeble : MonoBehaviour
{
    [SerializeField] private HealthConfigSO _healthConfigSO;
    private Health _healthSO;

    public Health health => _healthSO;

    public UnityEvent OnDie;
    public UnityEvent<int> OnHealthChanged;


    private void Awake()
    {
        _healthSO = new Health();
        _healthSO.SetCurrentHealth(_healthConfigSO.Health);
        _healthSO.SetMaxHealth(_healthConfigSO.Health);     
    }


    public void TakeDamage(int damage)
    {
        _healthSO.ApplyDamage(damage);
        OnHealthChanged?.Invoke(_healthSO.CurrentHealth);
        if(_healthSO.CurrentHealth <= 0)
        {
            OnDie?.Invoke();
            _healthSO.SetCurrentHealth(_healthConfigSO.Health);
        }
    }
    

    public void Kill()
    {
        TakeDamage(_healthSO.CurrentHealth);
    }


    public void Cure(int addHealth)
    {
        _healthSO.RestoreHealth(addHealth);
        OnHealthChanged?.Invoke(_healthSO.CurrentHealth);
    }
}
