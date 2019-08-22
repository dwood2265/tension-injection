using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arms : MonoBehaviour
{

    private int armor;
    private int reactorCore;
    private int weapons;

    // 0 - Newledge
    // 1 - Faradian
    // 2 - Vanguard
    // 3 - Mastodon
    private int armType;


    // Start is called before the first frame update
    void Start()
    {
        setStats(2,2,2);
    }

    public void setStats(int armorIn, int reactorCoreIn, int weaponsIn) {
        //no stat can be greater than 4 on any mech part
        if((armorIn <= 4 && reactorCoreIn <= 4 && weaponsIn <= 4) && (armorIn + reactorCoreIn + weaponsIn == 6)) {
            armor = armorIn;
            reactorCore = reactorCoreIn;
            weapons = weaponsIn;
        } else {
            Debug.LogError("<setStats> Value passed to Mech Arms is invalid.");
        }
        this.setArmType();
    }

    private void setArmType()
    {
        //if armor 3 or 4, type is Mastodon
        if (armor > 2){
            armType = 3;
            Debug.Log("Arm is Mastodon");
            //TODO: Set Sprites and stuff
        }

        //if reactorCore 3 or 4, type is Neweledge
        else if (reactorCore > 2){
            armType = 0;
            Debug.Log("Arm is Newledge");
            //TODO: Set Sprites and stuff
        }

        //if weapons 3 or 4, type is Faradian
        else if (weapons > 2){
            armType = 1;
            Debug.Log("Arm is Faradian");
            //TODO: Set Sprites and stuff
        } 

        //else, all values are 2, and is Vanguard
        else {
            armType = 2;
            Debug.Log("Arm is Vanguard");
            //TODO: Set Sprites and stuff            
        }
    }

    internal int GetReactorCore()
    {
        return reactorCore;
    }

    internal int GetArmor()
    {
        return armor;
    }

    internal int GetWeapons()
    {
        return weapons;
    }
}
