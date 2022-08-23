using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Pentagram : MonoBehaviour
{    
    [SerializeField] private Animator _activatedAnimation;

    public void ActivateAnimation()
    {
        _activatedAnimation.SetTrigger("OnActivated");
    }
}
