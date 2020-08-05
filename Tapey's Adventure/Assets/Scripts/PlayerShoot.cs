using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private float currentFireRate;

    public GameObject bulletPrefab;
    public Transform shootPos;
    public float fireRate = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightShift) && currentFireRate > fireRate)
        {
            Instantiate(bulletPrefab, shootPos.position, shootPos.rotation);
            currentFireRate = 0;
        }
        currentFireRate += Time.deltaTime;
    }
}
