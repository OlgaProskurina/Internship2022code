using UnityEngine;

[CreateAssetMenu(fileName = "Movement", menuName = "Scriptable Object/Movement")]
public class MovementSO : ScriptableObject
{   
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    public float Speed => _speed;
    public float RotationSpeed => _rotationSpeed;  
}
