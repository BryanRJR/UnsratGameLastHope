using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWave : MonoBehaviour
{
    [HideInInspector]
    public float speed;

    public GameObject deathEffect;

    private Rigidbody2D myBody;
    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }

}
