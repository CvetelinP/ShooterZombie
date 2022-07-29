using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Camera FpcCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 5f;
    [SerializeField] ParticleSystem fireEffect;
    [SerializeField] ParticleSystem fireEffect2;
    [SerializeField] GameObject hitEffect;
    [SerializeField] AmmoType ammoType;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] TextMeshProUGUI ammoText;
    RaycastHit hit;

    [SerializeField] float timeBetweenShots = 0.5f;

    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {

            StartCoroutine(Shoot());

        }

    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            fireEffect.Play();
            fireEffect2.Play();
            ProcessRaycast();
            ammoSlot.ReduceAmmo(ammoType);

        }

        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    public void ProcessRaycast ()
    {
        if (Physics.Raycast(FpcCamera.transform.position, FpcCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            if (target == null)
            {
                return;
            }
            target.TakeDamage(damage);


        }
        else
        {
            return;
        }
    }

    public void CreateHitImpact(RaycastHit hit)
    {

        GameObject inpact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(inpact, 20);

    }
}
