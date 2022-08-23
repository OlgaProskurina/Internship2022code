using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class PlayerShooting : Shooting
{    
    [SerializeField] private Animator _shootAnimation;


    public void OnShoot(InputAction.CallbackContext context)
    {
        _shootAnimation.SetTrigger("OnShoot"); 
        ShootUpWithoutReload();
    }    
}
