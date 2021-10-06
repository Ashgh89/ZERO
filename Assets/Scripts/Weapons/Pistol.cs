using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Guns
{
    // Start is called before the first frame update
    void Start()
    {
        // weaponDamage = 11;
        currentAmmo = maxAmmo;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    public override void Fire()
    {
        base.Fire();
    }

    public override void Shoot()
    {
        RaycastHit hit;
        

        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range, ~ignoreLayer))
        {


            if (bulletHole)
            {
                if ((hit.collider.tag == "Environment"))
                {
                    Bullet = Instantiate(bulletHole, hit.point + hit.normal * floatInFrontOfWall, Quaternion.LookRotation(hit.normal));
                    Destroy(Bullet, 3f);
                }
            }

            if (hit.transform.tag == "Zombie")
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


        }


    }



}
