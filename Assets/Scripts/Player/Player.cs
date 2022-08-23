using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private Animator _hitAmination;


    public void OnHit()
    {
        _hitAmination.SetTrigger("OnHit");
    }
}
