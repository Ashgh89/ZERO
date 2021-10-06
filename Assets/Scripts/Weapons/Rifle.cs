using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Guns
{

    public GameObject Bullet_Emitter;

    [SerializeField]
    private GameObject Bullet3;

    private GameObject Bullet2;


    public float Bullet_Forward_Force;
    public GameObject oneShotPic;
    public GameObject autoShotPic;
    public int gunMode;
    public AudioClip shootSound2;

    [SerializeField]
    private AudioClip changeMode;



    // Start is called before the first frame update
    void Awake()
    {
        currentAmmo = maxAmmo;
        audioSource = GetComponent<AudioSource>();
        gunMode = 1;
        oneShotPic.SetActive(false);
        autoShotPic.SetActive(true);
        noAmmoAlert.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        GunMode();
    }

    public override void Fire()
    {
       // base.Fire();
        if (Time.timeScale != 0)
            if (Input.GetButton("Fire1") && !needReload && gunMode == 1 && canFire) 
            {
                weaponDamage = 2;
                playerShootSound();
                Shoot();
                muzzleFlash.Play();
                currentAmmo--;
                canFire = false;
                StartCoroutine(WeaponCoolDown());
                
            }

        if (Time.timeScale != 0)
            if (Input.GetButtonDown("Fire1") && !needReload && gunMode == 2 && canFire) 
            {
                weaponDamage = 10;
                playerShootSound2();
                Shoot();
                muzzleFlash.Play();
                currentAmmo--;
                canFire = false;
                StartCoroutine(WeaponCoolDown());
            }
            else if (Input.GetButtonUp("Fire1"))
                muzzleFlash.Stop();


            else if (Input.GetButtonDown("Fire1") && needReload && currentAmmo <= 0)
                Invoke("NoAmmoSound", 0.1f);


        // Reload when ammo is zero
        if (currentAmmo <= 0)
        {
            currentAmmo = 0;
            needReload = true;
            noAmmoAlert.SetActive(true);
        }

        if (Time.timeScale != 0)
            if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo)
            {
                Invoke("playerReloadSound", 0.8f);
                StartCoroutine(Reload());
            }

        ammoText.text = currentAmmo + "/" + maxAmmo;

    }

    public override void Shoot()
    {


        RaycastHit hit;

        

        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range, ~ignoreLayer))
        {



            if (gunMode == 2)
            {

                GameObject Temporary_Bullet_Handler;
                Temporary_Bullet_Handler = Instantiate(Bullet3, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
                Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);
                Rigidbody Temporary_RigidBody;
                Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

                //Tell the bullet to be pushed forward by an amount set by Bullet_Forward_Force.
                Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);
                Destroy(Temporary_Bullet_Handler, 1.0f);
                if (hit.transform.tag == "Ninja")
                {
                    ITakeDamage enemy = hit.collider.GetComponent<ITakeDamage>();

                    if (enemy != null)
                        enemy.TakeDamage(weaponDamage);
                }

                else if (hit.transform.tag == "Monster")
                {

                    ITakeDamage enemy = hit.collider.GetComponent<ITakeDamage>();

                    if (enemy != null)
                        enemy.TakeDamage(weaponDamage);

                }



                if (hit.transform.tag == "Zombie")
                {
                    ITakeDamage enemy = hit.collider.GetComponent<ITakeDamage>();

                    if (enemy != null)
                        enemy.TakeDamage(weaponDamage);
                }


            }

            if (bulletHole)
            {
                if ((hit.transform.tag == "Environment"))
                {
                    Bullet2 = Instantiate(bulletHole, hit.point + hit.normal * floatInFrontOfWall, Quaternion.LookRotation(hit.normal));
                }
                Destroy(Bullet2, 3f);
            }

            else if (hit.transform.tag == "Monster")
            {
                ITakeDamage enemy = hit.collider.GetComponent<ITakeDamage>();
                if (enemy != null)
                    enemy.TakeDamage(2);

            }




            if (hit.transform.tag == "Zombie")
            {
                ITakeDamage enemy = hit.collider.GetComponent<ITakeDamage>();
                if (enemy != null)
                    enemy.TakeDamage(3);


            }


        }

    }

    void GunMode()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ChangeModeSOund();
            if (gunMode < 2)
            {
                gunMode++;
                oneShotPic.SetActive(true);
                autoShotPic.SetActive(false);

            }
            else if (gunMode == 2)
            {
                gunMode = 1;
                oneShotPic.SetActive(false);
                autoShotPic.SetActive(true);


            }
        }
    }

    private void ChangeModeSOund()
    {
        audioSource.clip = changeMode;
        audioSource.Play();
    }

    public void playerShootSound2()
    {
        audioSource.clip = shootSound2;
        audioSource.Play();
    }
}
