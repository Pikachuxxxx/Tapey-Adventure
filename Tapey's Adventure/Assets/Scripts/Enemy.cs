using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform target;
    public Transform eShootPos;
    public GameObject eBullet;
    public float eBulletLife = 5;
    public float eBulletSpeed = 10f;
    public float eBulletFireRate = 2f;

    [Space]
    [Header("Enemy Death FX")]
    public GameObject deathVFX;

    private float currentFireRate;
    private TimeBody tb;

    // Start is called before the first frame update
    void Start()
    {
        tb = GetComponent<TimeBody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFireRate > eBulletFireRate && !tb.isRewinding)
        {
            GameObject bullets = Instantiate(eBullet) as GameObject;
            bullets.transform.position = eShootPos.transform.position;

            Rigidbody2D rb = bullets.GetComponent<Rigidbody2D>();
            rb.velocity =  (target.position - bullets.transform.position).normalized * eBulletSpeed;
            Destroy(bullets, eBulletLife);
            currentFireRate = 0;
        }
        currentFireRate += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            print("Enemy says KrrKrr....");
            Instantiate(deathVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
