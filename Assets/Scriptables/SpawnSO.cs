using UnityEngine;

[CreateAssetMenu(fileName = "Spawn", menuName = "Scriptable Object/Entities spawn")]
public class SpawnSO : ScriptableObject
{
    [SerializeField] private GameObject _entityToSpawn;
    [SerializeField] private int _spawnAmount;
    [SerializeField] private float _timeBtwnSpawns;
    [SerializeField] private float _timeBeforeThisSpawn;

    public GameObject Entity => _entityToSpawn;
    public int SpawnAmount => _spawnAmount;
    public float TimeBtwnSpawns => _timeBtwnSpawns;
    public float TimeBeforeThisSpawn => _timeBeforeThisSpawn;

}

