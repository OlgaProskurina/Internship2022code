using System.Collections;
using UnityEngine;

public class BigSpider : Enemy
{
    [SerializeField] private float _shootingDistance;
    [SerializeField] private Shooting _shooting;


    private void Update()
    {
        _targetPosition = _target.transform.position;
        float rotationAngle = Vector2.SignedAngle(Vector2.up, _targetPosition - transform.position);
        transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
        if (IsAttacking)
        {
            return;
        }
        if (Vector3.Distance(transform.position, _targetPosition) > _shootingDistance)
        {
            transform.position =
               Vector2.MoveTowards(transform.position, _targetPosition, _movementSO.Speed * Time.deltaTime);
        }
        else
        {
            StartCoroutine(ShootCoroutine());
        }        
    }


    private IEnumerator ShootCoroutine()
    {
        IsAttacking = true;
        yield return _shooting.ShootUpWithReload();
        IsAttacking = false;
    }




}
