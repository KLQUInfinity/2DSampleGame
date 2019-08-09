using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour
{

    public float damage;
    public float damageRate;
    public float pushBackForce;

    private float nextDamage;

    // Use this for initialization
    void Start()
    {
        nextDamage = 0f;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag.Equals("Player") && nextDamage < Time.time)
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.addDamage(damage);
            nextDamage = Time.time + damageRate;

            pushBack(other.transform);
        }
    }

    void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, 1f);
        pushDirection *= pushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
