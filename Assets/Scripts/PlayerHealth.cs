using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    public float fullHealth;
    public GameObject deathFX;

    private float currentHealth;

    private PlayerController controlMovement;

    void Start()
    {
        currentHealth = fullHealth;

        controlMovement = GetComponent<PlayerController>();
    }

    public void addDamage(float damage)
    {
        if (damage <= 0)
        {
            return;
        }
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            makeDead();
        }
    }

    void makeDead()
    {
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
