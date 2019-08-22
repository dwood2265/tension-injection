using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legs : MonoBehaviour
{
    
    private int armor;
    private int tech;
    private int capacitorCore;

    // 0 - Newledge
    // 1 - Faradian
    // 2 - Vanguard
    // 3 - Mastodon
    private int LegType;


    // Start is called before the first frame update
    void Start()
    {
        setStats(2,2,2);
    }

    public void setStats(int armorIn, int techIn, int capacitorCoreIn) {
        //no stat can be greater than 4 on any mech part
        if((armorIn <= 4 && techIn <= 4 && capacitorCoreIn <= 4) && (armorIn + techIn + capacitorCoreIn == 6)) {
            armor = armorIn;
            tech = techIn;
            capacitorCore = capacitorCoreIn;
        } else {
            Debug.LogError("<setStats> Value passed to Mech Legs is invalid.");
        }
        this.setLegType();
    }

    private void setLegType()
    {
        //if armor 3 or 4, type is Mastodon
        if (armor > 2){
            LegType = 3;
            Debug.Log("Leg is Mastodon");
            //TODO: Set Sprites and stuff
        }

        //if tech  3 or 4, type is Neweledge
        else if (tech > 2){
            LegType = 0;
            Debug.Log("Leg is Newledge");
            //TODO: Set Sprites and stuff
        }

        //if weapons 3 or 4, type is Faradian
        else if (capacitorCore > 2){
            LegType = 1;
            Debug.Log("Leg is Faradian");
            //TODO: Set Sprites and stuff
        } 

        //else, all values are 2, and is Vanguard
        else {
            LegType = 2;
            Debug.Log("Leg is Vanguard");
            //TODO: Set Sprites and stuff            
        }
    }

    internal int GetArmor()
    {
        return armor;
    }

    internal int GetCapacitorCore()
    {
        return capacitorCore;
    }

    internal int GetTech()
    {
        return tech;;
    }
}
