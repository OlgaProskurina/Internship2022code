using UnityEngine;

[CreateAssetMenu(fileName = "HealthConfig", menuName = "Config/Health config")]
public class HealthConfigSO : ScriptableObject
{
    [SerializeField] private int _health;

    public int Health => _health;
}
