using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private WeaponManager[] weapons;

    private int currentWeaponIndex;




    // Start is called before the first frame update
    void Start()
    {
        currentWeaponIndex = 0;
        weapons[currentWeaponIndex].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TurnOnSelectedWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TurnOnSelectedWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TurnOnSelectedWeapon(2);
        }


    } //update

    public void TurnOnSelectedWeapon(int weaponIndex)
    {

        if (currentWeaponIndex == weaponIndex)
            return;


        //turn off current weapon
        weapons[currentWeaponIndex].gameObject.SetActive(false);
        //turn on new weapon
        weapons[weaponIndex].gameObject.SetActive(true);
        //update current weapon index
        currentWeaponIndex = weaponIndex;

    }//turn on selected weapon

    public WeaponManager GetCurrentWeapon()
    {
        return weapons[currentWeaponIndex];
    }

    public void RevButton()
    {
        TurnOnSelectedWeapon(0);
    }
    public void ShotgunButton()
    {
        TurnOnSelectedWeapon(1);
    }
    public void AKButton()
    {
        TurnOnSelectedWeapon(2);
    }


} //class
