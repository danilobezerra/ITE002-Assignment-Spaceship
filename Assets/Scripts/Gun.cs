using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Projectile projectilePrefab;
    public int municao = 10;

    void FireProjectile()
    {
        if (Input.GetButtonDown("Fire1") && municao > 0)
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            municao--;
        }
    }

    void ReloadGun()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            municao = 10;
        }
    }

    private void Update()
    {
        //FireProjectile();
        ReloadGun();
    }

}
