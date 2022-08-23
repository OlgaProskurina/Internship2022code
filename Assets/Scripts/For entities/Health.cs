
public class Health
{
    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }

    public void SetMaxHealth(int value)
    {
        MaxHealth = value;
    }


    public void SetCurrentHealth(int value)
    {
        CurrentHealth = value;
    }
    

    public void RestoreHealth(int addValue)
    {
        CurrentHealth += addValue;
        if(CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }

    }


    public void ApplyDamage(int damage)
    {
        CurrentHealth -= damage;
    }
}
