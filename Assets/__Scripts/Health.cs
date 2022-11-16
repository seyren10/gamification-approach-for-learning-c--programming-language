using UnityEngine;
using UnityEngine.Events;
public class Health : MonoBehaviour
{
    //configuration
    [SerializeField] private int maxHealth;

    //state
    private int currentHealth;

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        //event trigger:
        OnTakeDamage?.Invoke();
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    private int GetMaxHealth()
    {
        return maxHealth;
    }

    //events
    [HideInInspector] public UnityEvent OnTakeDamage;
    [HideInInspector] public UnityEvent OnKill;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;

        //event trigger:
        OnTakeDamage?.Invoke();

        //check if health is less than or equal to zero
        if (currentHealth <= 0)
        {
            //Dead, take action

            //event trigger:
            OnKill?.Invoke();

            //remove this instance
            Destroy(gameObject);

        }
    }



    private void OnDestroy()
    {
        //clear all listeners to avoid memory leaks
        Debug.Log("destroyed");
        OnKill.RemoveAllListeners();
        OnTakeDamage.RemoveAllListeners();
    }
}
