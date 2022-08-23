using UnityEngine;

public class DropAfterEnemyDeath : MonoBehaviour
{
    [SerializeField] private GameObject _dropPrefab;

    [Tooltip("Drop rate from 0% to 100%")]
    [SerializeField] private int _dropRate;

    public void DropItemWithChance(Vector3 dropPosition)  
    {
        if( Random.Range(1, 100) <= _dropRate)
        {
            var drop = Instantiate(_dropPrefab);
            drop.transform.position = dropPosition;
        }
    }

}
