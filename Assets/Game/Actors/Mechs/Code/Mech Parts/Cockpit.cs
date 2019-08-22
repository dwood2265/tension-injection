using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cockpit : MonoBehaviour
{
    
    private int armor;
    private int reactorCore;
    private int capacitorCore;

    // 0 - Newledge
    // 1 - Faradian
    // 2 - Vanguard
    // 3 - Mastodon
    private int cockpitType;


    // Start is called before the first frame update
    void Start()
    {
        setStats(2,2,2);
    }

    public void setStats(int armorIn, int reactorCoreIn, int capacitorCoreIn) {
        //no stat can be greater than 4 on any mech part
        if((armorIn <= 4 && reactorCoreIn <= 4 && capacitorCoreIn <= 4) && (armorIn + reactorCoreIn + capacitorCoreIn == 6)) {
            armor = armorIn;
            reactorCore = reactorCoreIn;
            capacitorCore = capacitorCoreIn;
        } else {
            Debug.LogError("<setStats> Value passed to Mech Cockpit is invalid.");
        }
        this.setCockpitType();
    }

    private void setCockpitType()
    {
        //if armor 3 or 4, type is Mastodon
        if (armor > 2){
            cockpitType = 3;
            Debug.Log("Cockpit is Mastodon");
            //TODO: Set Sprites and stuff
        }

        //if reactorCore 3 or 4, type is Neweledge
        else if (reactorCore > 2){
            cockpitType = 0;
            Debug.Log("Cockpit is Newledge");
            //TODO: Set Sprites and stuff
        }

        //if capacitorCore 3 or 4, type is Faradian
        else if (capacitorCore > 2){
            cockpitType = 1;
            Debug.Log("Cockpit is Faradian");
            //TODO: Set Sprites and stuff
        } 

        //else, all values are 2, and is Vanguard
        else {
            cockpitType = 2;
            Debug.Log("Cockpit is Vanguard");
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

    internal int GetCapacitorCore()
    {
        return capacitorCore;
    }
}
