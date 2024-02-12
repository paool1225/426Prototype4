using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzleFlashPrefab;
    public Transform firePoint;
    public float fireForce = 20f;

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
        Effect();
    }

    void Effect()
    {
        Transform muzzleFlashInstance = Instantiate(muzzleFlashPrefab, firePoint.position, firePoint.rotation) as Transform;
        muzzleFlashInstance.parent = firePoint;
        float size = Random.Range(0.6f, 0.9f);
        muzzleFlashInstance.localScale = new Vector3(size, size, size);
    }
}