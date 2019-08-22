using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech : MonoBehaviour
{
    //Mech Statistics
    private int armor;
    private int weapons;
    private int tech;
    private int reactorCore;
    private int capacitorCore;

    //Mech Parts
    private Arms myArms;
    private Legs myLegs;
    private Shoulders myShoulders;
    private Cockpit myCockpit;

    //Mech Weapons
    public Ability[] myAbilities = new Ability[4];

    //Mech Tech Upgrades
    public JumpTech myJumpTech;
    public Jetpack myJetpack;
    public DashTech myDashTech;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Setters used to initialize a new mech
    public void SetStats(int armorIn, int weaponsIn, int techIn, int reactorCoreIn, int capacitorCoreIn) {
        armor = armorIn;
        weapons = weaponsIn;
        tech = techIn;
        reactorCore = reactorCoreIn;
        capacitorCore = capacitorCoreIn;
    }

    public void SetParts(Arms myArmsIn, Legs myLegsIn, Shoulders myShouldersIn, Cockpit myCockpitIn) {
        myArms = myArmsIn;
        myLegs = myLegsIn;
        myShoulders = myShouldersIn;
        myCockpit = myCockpitIn;
        this.refreshStats();
    }

    public void SetWeapons(Ability[] abilitiesIn){
        if(abilitiesIn.Length == 4){
            myAbilities = abilitiesIn;
        }
        else{
            Debug.LogError("Ability array not the correct length.");
        }
    }

    public void SetTech(JumpTech myJumpIn, Jetpack myJetpackIn, DashTech myDashIn) {
        myJumpTech = myJumpIn;
        myJetpack = myJetpackIn;
        myDashTech = myDashIn;
    }

    //a mech's stats are the sum of its parts
    //All parts have armor.
    //Cockpit   - Reactor Core  and Capacitor Core
    //Arms      - Reactor Core  and Weapons
    //Legs      - Tech Upgrades and Capacitor Core
    //Shoulders - Tech Upgrades and Weapons
    public void refreshStats()
    {
        armor = myArms.GetArmor() + myCockpit.GetArmor() + myLegs.GetArmor() + myShoulders.GetArmor();
        reactorCore = myArms.GetReactorCore() + myCockpit.GetReactorCore();
        capacitorCore = myLegs.GetCapacitorCore() + myCockpit.GetCapacitorCore();
        weapons = myArms.GetWeapons() + myShoulders.GetWeapons();
        tech = myLegs.GetTech() + myShoulders.GetTech();
    }

    //Mech Behaviours
    public void OnAbility1Trigger () {
        myAbilities[0].Activate();
    }

    public void OnAbility2Trigger () {
        myAbilities[1].Activate();

    }

    public void OnAbility3Trigger () {
        myAbilities[2].Activate();

    }

    public void OnAbility4Trigger () {
        myAbilities[3].Activate();
    }

    public void OnJumpTrigger () {
        myJumpTech.Jump();
    }

    public void OnJetpackTrigger () {
        myJetpack.Fly();
    }

    public void OnDashTrigger () {
        myDashTech.Dash();
    }

    //getters
    public int GetReactorCore()
    {
        return reactorCore;
    }

    public int GetArmor()
    {
        return armor;
    }

    public int GetWeapons()
    {
        return weapons;
    }

    public int GetCapacitorCore()
    {
        return capacitorCore;
    }

    public int GetTech()
    {
        return tech;;
    }
}
