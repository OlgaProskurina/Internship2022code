using System.Collections;
using UnityEngine.Events;
using UnityEngine;


public class Spawner : MonoBehaviour
{ 
    [SerializeField] private Vector3 _spawnPosition;
    [SerializeField] public SpawnSO[] ToSpawn;

    private WaitForSeconds timeBeforeSpawn;
    private WaitForSeconds timeBtwSpawns;
    private SpawnPool[] _spawnPools;
    private int _spawnCounter = -1;

    public UnityEvent OnSpawnObject;


    private void Awake()
    {       
        _spawnPools = new SpawnPool[ToSpawn.Length];
        for (int i = 0; i < ToSpawn.Length; i++)
        {
            _spawnPools[i] = new SpawnPool();
            _spawnPools[i].SetSpawnSO(ToSpawn[i]);
        }
        _spawnPosition = transform.position;
    }


    private void Start()
    {
        SwitchToNextSpawn();
    }


    private void SpawnEntity()
    {
      
        if (_spawnPools[_spawnCounter].TrySpawnOnScene(_spawnPosition))
        {
            OnSpawnObject?.Invoke();
        }
        else
        {
            StopAllCoroutines();
            SwitchToNextSpawn();
        }
            
    }


    private void SwitchToNextSpawn()
    {
        if (_spawnCounter < ToSpawn.Length - 1)
        {
            _spawnCounter++;           
            _spawnPools[_spawnCounter].InstantiateAll();
            timeBeforeSpawn = new WaitForSeconds(_spawnPools[_spawnCounter].Spawn.TimeBeforeThisSpawn);
            timeBtwSpawns = new WaitForSeconds(_spawnPools[_spawnCounter].Spawn.TimeBtwnSpawns);
            StartCoroutine(Spawn());
        }
        else
        {
            StopCoroutine(Spawn());
        }
    }


    private IEnumerator Spawn()
    {       
        yield return timeBeforeSpawn;
        while (true)
        {
            yield return timeBtwSpawns;
            SpawnEntity();
        }
    }

}
