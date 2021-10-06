using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class Guns : MonoBehaviour
{

    [SerializeField]
    protected Camera fpsCamera;

    [SerializeField]
    protected ParticleSystem muzzleFlash;

    [SerializeField]
    public GameObject bulletHole;


    [SerializeField]
    protected float range;

    [SerializeField]
    protected LayerMask ignoreLayer;

    [SerializeField]
    protected AudioClip noAmmoSound;

    [SerializeField]
    protected AudioClip shootSound;

    [SerializeField]
    protected AudioClip reloadSound;


    protected AudioSource audioSource;

    [SerializeField]
    protected Text ammoText;


    protected float floatInFrontOfWall = 0.001f;


    protected GameObject Bullet;


    




    [SerializeField]
    protected int currentAmmo ;

   public int CurrentAmmo
   {
       get
       {
           return currentAmmo;
       }
  
       set
       {
           currentAmmo = value;
       }
  
   }

    [SerializeField]
    protected int maxAmmo = 10;

    [SerializeField]
    protected int weaponDamage = 10;

    public int WeaponDamage
    {
        get
        {
            return weaponDamage;
        }

    }

    [SerializeField]
    protected float weaponCoolDown;

    protected bool canFire = true;
    protected bool needReload = false;

    [SerializeField]
    protected Animator animator;

    protected float reloadSpeed = 2f;

    [SerializeField]
    protected GameObject noAmmoAlert;



    public virtual void Fire()
    {
        if (canFire)
        {


            if (Time.timeScale != 0)
                if (Input.GetButtonDown("Fire1") && !needReload)
                {
                   playerShootSound();
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


        }




        if (Time.timeScale != 0)
            if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo)
            {
                 Invoke("playerReloadSound", 0.8f);
                 StartCoroutine(Reload());
            }

        ammoText.text = currentAmmo + "/" + maxAmmo;


    }




    public abstract void Shoot();



    protected IEnumerator WeaponCoolDown()
    {
        yield return new WaitForSeconds(weaponCoolDown);
        canFire = true;
    }
    


    protected IEnumerator Reload()
    {

        needReload = true;
        animator.SetBool("Reload", true);
        yield return new WaitForSeconds(reloadSpeed);
        animator.SetBool("Reload", false);
        currentAmmo = maxAmmo;
        noAmmoAlert.SetActive(false);
        yield return new WaitForSeconds(1f);
        needReload = false;
    }

    protected void NoAmmoSound()
    {
        audioSource.clip = noAmmoSound;
        audioSource.Play();
    }


    private void playerReloadSound()
    {
        audioSource.clip = reloadSound;
        audioSource.Play();
    }


    protected void playerShootSound()
    {
        audioSource.clip = shootSound;
        audioSource.Play();
    }

}
