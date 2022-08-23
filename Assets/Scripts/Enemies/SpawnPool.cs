using UnityEngine;

public class SpawnPool 
{
    private SpawnSO _spawnSO;
    private GameObject[] _entities;
    private int NowOnScene = 0;

    public SpawnSO Spawn => _spawnSO;

    public void SetSpawnSO(SpawnSO spawn)
    {
        _spawnSO = spawn;
        _entities = new GameObject[spawn.SpawnAmount];
    }


    public void InstantiateAll()
    {
        for(int i = 0; i < _spawnSO.SpawnAmount; i++)
        {
            _entities[i] = GameObject.Instantiate(_spawnSO.Entity);
            _entities[i].SetActive(false);
        }
    }


    public void MakeAllNotActive()
    {
        foreach(var entity in _entities)
        {
            entity.SetActive(false);
        }
        NowOnScene = 0;
    }


    public bool TrySpawnOnScene(Vector3 position)
    {
        if(NowOnScene > _entities.Length - 1)
        {
            return false;
        }
        else
        {
            _entities[NowOnScene].transform.position = position;
            _entities[NowOnScene].SetActive(true);
            NowOnScene++;
            return true;
        }
    }


}
