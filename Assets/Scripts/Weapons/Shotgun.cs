using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Guns
{
    // Start is called before the first frame update
    void Start()
    {
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
        


        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward * Time.deltaTime, out hit, range, ~ignoreLayer))
        {
            if (hit.transform.tag == "Alien")
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
                    enemy.TakeDamage(20);
            }


        }

        //left
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward + new Vector3(-3f, 0f, 0f) * Time.deltaTime, out hit, range, ~ignoreLayer))
        {
            if (bulletHole)
            {
                if ((hit.collider.tag == "Environment"))
                {
                    Bullet = Instantiate(bulletHole, hit.point + hit.normal * floatInFrontOfWall, Quaternion.LookRotation(hit.normal));
                }
                Destroy(Bullet, 3f);
            }
        }


        //right
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward + new Vector3(3f, 0f, 0f) * Time.deltaTime, out hit, range, ~ignoreLayer))
        {
            if (bulletHole)
            {
                if ((hit.collider.tag == "Environment"))
                {
                    Bullet = Instantiate(bulletHole, hit.point + hit.normal * floatInFrontOfWall, Quaternion.LookRotation(hit.normal));
                }
                Destroy(Bullet, 3f);
            }
        }


        //up
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward + new Vector3(0f, 4f, 0f) * Time.deltaTime, out hit, range, ~ignoreLayer))
        {
            if (bulletHole)
            {
                if ((hit.collider.tag == "Environment"))
                {
                    Bullet = Instantiate(bulletHole, hit.point + hit.normal * floatInFrontOfWall, Quaternion.LookRotation(hit.normal));
                }
                Destroy(Bullet, 3f);
            }
        }



        //down
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward + new Vector3(0f, -4f, 0f) * Time.deltaTime, out hit, range, ~ignoreLayer))
        {
            if (bulletHole)
            {
                if ((hit.collider.tag == "Environment"))
                {
                    Bullet = Instantiate(bulletHole, hit.point + hit.normal * floatInFrontOfWall, Quaternion.LookRotation(hit.normal));
                }
                Destroy(Bullet, 3f);
            }
        }

    }
}
