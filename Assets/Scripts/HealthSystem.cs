

public class HealthSystem
{
    private int currentHealth;
    private int maxHealth;
    

    public HealthSystem(int maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        
        
    }

    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }

    public void damage(int damage)
    {
        CurrentHealth -= damage;
    }

    public void heal(int healAmount)
    {
        CurrentHealth += healAmount;
    }
    
}
