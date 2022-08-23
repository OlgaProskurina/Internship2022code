using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "Scriptable Object/Attack")]
public class AttackSO : ScriptableObject
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackReload;

    public int Damage => _damage;
    public float AttackReload => _attackReload;
}
