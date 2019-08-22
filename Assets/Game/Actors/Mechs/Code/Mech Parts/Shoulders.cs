using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoulders : MonoBehaviour
{
    
    private int armor;
    private int tech;
    private int weapons;

    // 0 - Newledge
    // 1 - Faradian
    // 2 - Vanguard
    // 3 - Mastodon
    private int shoulderType;


    // Start is called before the first frame update
    void Start()
    {
        setStats(2,2,2);
    }

    public void setStats(int armorIn, int techIn, int weaponsIn) {
        //no stat can be greater than 4 on any mech part
        if((armorIn <= 4 && techIn <= 4 && weaponsIn <= 4) && (armorIn + techIn + weaponsIn == 6)) {
            armor = armorIn;
            tech = techIn;
            weapons = weaponsIn;
        } else {
            Debug.LogError("<setStats> Value passed to Mech Shoulders is invalid.");
        }
        this.setShoulderType();
    }

    private void setShoulderType()
    {
        //if armor 3 or 4, type is Mastodon
        if (armor > 2){
            shoulderType = 3;
            Debug.Log("Shoulder is Mastodon");
            //TODO: Set Sprites and stuff
        }

        //if reactorCore 3 or 4, type is Neweledge
        else if (tech > 2){
            shoulderType = 0;
            Debug.Log("Shoulder is Newledge");
            //TODO: Set Sprites and stuff
        }

        //if weapons 3 or 4, type is Faradian
        else if (weapons > 2){
            shoulderType = 1;
            Debug.Log("Shoulder is Faradian");
            //TODO: Set Sprites and stuff
        } 

        //else, all values are 2, and is Vanguard
        else {
            shoulderType = 2;
            Debug.Log("Shoulder is Vanguard");
            //TODO: Set Sprites and stuff            
        }
    }

    internal int GetArmor()
    {
        return armor;
    }

    internal int GetWeapons()
    {
        return weapons;
    }

    internal int GetTech()
    {
        return tech;
    }
}
