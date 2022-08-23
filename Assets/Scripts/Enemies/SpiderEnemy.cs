using System.Collections;
using UnityEngine;


public class SpiderEnemy : Enemy
{
    [SerializeField] private Attack _attack;

    private void Update()
    {     
        if (IsAttacking)
        {
            return;
        }
        _targetPosition = _target.transform.position;
        float rotationAngle = Vector2.SignedAngle(Vector2.up, _targetPosition - transform.position);
        transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);        
        transform.position =
              Vector2.MoveTowards(transform.position, _targetPosition, _movementSO.Speed * Time.deltaTime);
       
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(_target.tag))
        {
            StartCoroutine(AttackCoroutine());
        }
    }


    private IEnumerator AttackCoroutine()
    {
        IsAttacking = true;        
        yield return _attack.AttackTarget(_target.GetComponent<Damagaeble>());
        IsAttacking = false;
    }   

}
