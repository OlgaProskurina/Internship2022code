using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected Damagaeble _damagaeble;
    [SerializeField] protected MovementSO _movementSO;
    [SerializeField] protected Animator _enemyAnimator;

    protected GameObject _target;
    protected Vector3 _targetPosition;
    protected bool IsAttacking = false;

    public static event Action<int> OnKilledScoreCost = delegate { };
    public static event Action<GameObject> OnKilled = delegate { };


    private void Awake()
    {
        _damagaeble.OnDie.AddListener(Die);
        _damagaeble.OnHealthChanged.AddListener(OnHit);
    }

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
        
    }

    private void Die()
    {
        DoBeforeDeath();
        OnKilledScoreCost(_damagaeble.health.MaxHealth);
        OnKilled(gameObject);
    }


    private void OnHit(int value)
    {
        _enemyAnimator.SetTrigger("OnHit");
    }


    virtual protected void DoBeforeDeath()
    {
        // override in child
    }


    private void OnDestroy()
    {
        _damagaeble.OnDie.RemoveListener(Die);
        _damagaeble.OnHealthChanged.RemoveListener(OnHit);
    }
}
