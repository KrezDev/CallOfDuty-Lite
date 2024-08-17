using UnityEngine;

public class Pistol : MonoBehaviour
{
    public string pistolName = "Pistol";
    public int maxAmmo = 10; 
    public int currentAmmo;  
    public float fireRate = 0.2f; 
    public float bulletForce = 500f; 
    public GameObject bulletPrefab; 
    public Transform firePoint; 
    public float reloadTime = 1f; 
    public AudioSource shootSound; 
    public AudioSource reloadSound;

    private bool isReloading = false;
    private float nextFireTime = 0f;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (isReloading)
            return;

        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
        }

        if (Input.GetButtonDown("Reload"))
        {
            Reload();
        }
    }

    void Shoot()
    {
        if (currentAmmo <= 0)
        {
            Debug.Log("Out of ammo! Reload to continue.");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            bulletRb.AddForce(firePoint.forward * bulletForce);
        }

        if (shootSound != null)
        {
            shootSound.Play();
        }

        currentAmmo--;
        nextFireTime = Time.time + fireRate; 
        Debug.Log("Fired! Ammo left: " + currentAmmo);
    }

    void Reload()
    {
        if (currentAmmo >= maxAmmo || isReloading)
            return;

        StartCoroutine(ReloadCoroutine());
    }

    System.Collections.IEnumerator ReloadCoroutine()
    {
        isReloading = true;

        if (reloadSound != null)
        {
            reloadSound.Play();
        }

        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;

        isReloading = false;
        Debug.Log("Reloaded! Ammo count: " + currentAmmo);
    }
}
