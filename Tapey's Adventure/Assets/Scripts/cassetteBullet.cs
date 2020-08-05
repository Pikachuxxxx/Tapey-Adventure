using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cassetteBullet : MonoBehaviour
{

    private Rigidbody2D bulletRB;

    public float bulletSpeed = 10f;
    public float rotationSpeed = -200f;
    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        bulletRB.velocity = transform.right * bulletSpeed;
        bulletRB.AddTorque(rotationSpeed);
        Destroy(gameObject, 5f);
    }
}
