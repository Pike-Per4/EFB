using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public int maxAmmo = 1000;
    public int currentAmmo;


    [SerializeField] GameObject ammoText;


    private void Start()
    {
        currentAmmo = PlayerPrefs.GetInt("gunAmmo") == 0 ? 100 : PlayerPrefs.GetInt("gunAmmo");
        var ammo = ammoText.GetComponent<TextMeshProUGUI>();
        ammo.text = currentAmmo.ToString();
    }


    public GameObject impactEffect;

    public Camera fpsCam;
    public ParticleSystem muzzleflush;

    private float nextTimeToFire = 0f;

    // Update is called once per frame
    void Update()
    {
        if (currentAmmo <= 0)
        {
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire) 
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
        var ammo = ammoText.GetComponent<TextMeshProUGUI>();
        ammo.text = currentAmmo.ToString();

    }

    void Shoot()
    {
        muzzleflush.Play();
        currentAmmo--;
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) 
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null) 
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null) 
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
