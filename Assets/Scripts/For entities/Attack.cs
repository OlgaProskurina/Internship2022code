using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private AttackSO _attackConfigSO;
    private WaitForSeconds _reload;


    private void Awake()
    {
        _reload = new WaitForSeconds(_attackConfigSO.AttackReload);
    }


    public WaitForSeconds AttackTarget(Damagaeble target)
    {
        target.TakeDamage(_attackConfigSO.Damage);
        return _reload;
    }

}
    

        
