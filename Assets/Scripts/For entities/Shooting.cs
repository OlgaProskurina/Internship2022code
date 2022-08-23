using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform _firePosition;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private float _speed;
    [SerializeField] private float _shootReloadTime;
    private WaitForSeconds _reloading;


    private void Awake()
    {
        _reloading = new WaitForSeconds(_shootReloadTime);
    }

   
    public void ShootUpWithoutReload()
    {
        GameObject bullet = Instantiate(_projectilePrefab, _firePosition.position, _firePosition.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(_firePosition.up * _speed, ForceMode2D.Impulse);
    }

    public WaitForSeconds ShootUpWithReload()
    {
        ShootUpWithoutReload();
        return _reloading;
    }
}
