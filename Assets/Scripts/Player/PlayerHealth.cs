using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void Heal(int amount) 
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        Debug.Log(currentHealth);
    }

    public void ReduceHealth(int amount) 
    {
        currentHealth -= amount;
        Debug.Log(currentHealth);
    }

}
