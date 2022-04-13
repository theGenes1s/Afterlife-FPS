using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private WeaponController weaponController;
    public float fireRate = 15f;
    private float nextTimeToFire;
    public float damage = 20f;

    private Animator zoomCameraAnim;

    private bool isZoomed;

    private Camera mainCam;

    private GameObject crosshair;

    private EnemyAnimator enemy_Anim;

    void Awake()
    {
        weaponController = GetComponent<WeaponController>();

        zoomCameraAnim = GameObject
            .FindGameObjectWithTag(Tags.ZOOM_CAMERA)
            .GetComponent<Animator>();

        crosshair = GameObject.FindWithTag(Tags.CROSSHAIR);

        mainCam = Camera.main;
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        WeaponShoot();
        ScopeZoom();
    } // end of Update

    void WeaponShoot()
    {
        // if assault is current weapon
        if (weaponController.GetCurrentWeapon().fireType == WeaponFireType.MULTIPLE)
        {
            // check if left mouse button is on hold
            if (Input.GetMouseButton(0) && Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 2f / fireRate;
                weaponController.GetCurrentWeapon().ShootAnimation();
                BulletFired();
            }
        }
        //if player is holding another weapon e.g single shot
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                // for Shoot
                if (weaponController.GetCurrentWeapon().bulletType == WeaponBulletType.BULLET)
                {
                    weaponController.GetCurrentWeapon().ShootAnimation();
                    BulletFired();
                }
            } // if input mouse button down 0
        } // end of else
    } //weapon shoot

    void ScopeZoom()
    {
        // zoomed AIM
        if (weaponController.GetCurrentWeapon().weapon_Aim == WeaponAim.AIM)
        {
            if (Input.GetMouseButtonDown(1))
            {
                zoomCameraAnim.Play(AnimationTags.ZOOM_IN_ANIM);
                crosshair.SetActive(false);
            } // end of if input mouse button down 1

            if (Input.GetMouseButtonUp(1))
            {
                zoomCameraAnim.Play(AnimationTags.ZOOM_OUT_ANIM);
                crosshair.SetActive(true);
            } // end of if input mouse button up 1
        }
    } // zoom in and out

    void BulletFired()
    {
        RaycastHit hit;
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit))
        {
            //print ("we hit : " + hit.transform.gameObject.name);
            if (hit.transform.tag == Tags.ENEMY_TAG)
            {
                print("we hit : " + hit.transform.gameObject.name);
                hit.transform.GetComponent<HealthScript>().ApplyDamage(damage);
            }
        }
    } // end of bullet fired
} //class
