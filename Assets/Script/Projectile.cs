using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 20f;
    public GameObject impactEffect;
    public int damage = 40;

    private Rigidbody2D rigidbody;

    public AudioSource zombieDieEffect;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = transform.right * projectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            zombieDieEffect.Play();
            Destroy(gameObject);
        }

        
    }
}
