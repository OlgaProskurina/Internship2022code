using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Damagaeble _damagaeble;

    private void Start()
    {
        _damagaeble.OnHealthChanged.AddListener((newValue) =>
        {
            _slider.value = newValue;
        });
        _slider.maxValue = _damagaeble.health.MaxHealth;
        _slider.value = _slider.maxValue;    
    }
}
