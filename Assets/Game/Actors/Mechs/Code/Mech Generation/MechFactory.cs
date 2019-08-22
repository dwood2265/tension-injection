using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechFactory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Mech GenerateRandomMech() {
        //Need to set Parts, Abilities, and Tech Upgrades before returning
        Mech generatedMech = new Mech ();

        //Generate and set Mech Parts
        Arms generatedArms = new Arms ();
        Legs generatedLegs = new Legs ();
        Cockpit generatedCockpit = new Cockpit ();
        Shoulders generatedShoulders = new Shoulders ();

        int[] armStats = GenerateStats();
        int[] legStats = GenerateStats();
        int[] shoulderStats = GenerateStats();
        int[] cockpitStats = GenerateStats();

        generatedArms.setStats(armStats[0], armStats[1], armStats[2]);
        generatedLegs.setStats(legStats[0], legStats[1], legStats[2]);
        generatedShoulders.setStats(shoulderStats[0], shoulderStats[1], shoulderStats[2]);
        generatedCockpit.setStats(cockpitStats[0], cockpitStats[1], cockpitStats[2]);

        generatedMech.SetParts(generatedArms, generatedLegs, generatedShoulders, generatedCockpit);

        //Generate and set Mech Abilities
        int weaponsPoints = generatedMech.GetWeapons();
        Ability[] mechWeapons = new Ability[4];
        mechWeapons = GenerateAbilities(weaponsPoints);
        

        //Generate and set Mech Tech Upgrades

        return generatedMech;
    }

    //Generate 3 random numbers between 1-4 and they all add up to 6.
    public int[] GenerateStats(){
        int total = 6;
        int[] stats = new int[3];

        stats[0] = UnityEngine.Random.Range(1,4);
        total = total - stats[0];

        if (total > 4) {
            stats[1] = UnityEngine.Random.Range(1,4);
        } else {
            stats[1] = UnityEngine.Random.Range(1,total);
        }

        stats[2] = total;

        return stats;
    }

    private Ability[] GenerateAbilities(int abilityPointsLeft)
    {
        Ability[] generatedAbilities = new Ability[4];

        //Calculate how many weapons the mech can legally have (abilityPoints/3 rounded up is the minimum, 4 is the max unless there is less than 4 points.)
        float minNumberOfAbilities = abilityPointsLeft/3;
        int maxNumberofAbilities = (abilityPointsLeft>4)?4:abilityPointsLeft;
        int numberOfAbilities = UnityEngine.Random.Range(Mathf.CeilToInt(minNumberOfAbilities), maxNumberofAbilities);

        //Create an array where the size is the number of abilities the mech will have.
        //Populate the array with numbers in range 1-3 to determine the power of the abilities. (ex: 7 weapon stat = [1,2,3,1] OR [3,3,1] OR [3,2,2])
        int[] abilityPower = new int[numberOfAbilities];

        //Set the minimum to 1 for all indices
        for(int i=0; i<abilityPower.Length; i++){
            abilityPower[i] = 1;
        }

        //Remove the points from the number of points left
        abilityPointsLeft = abilityPointsLeft - numberOfAbilities;

        //While there are still ability points left to spend, put one into a random index. 3 is max.
        while(abilityPointsLeft > 0){
            int index = UnityEngine.Random.Range(0,numberOfAbilities-1);
            if(abilityPower[index] < 3){
                abilityPower[index] = abilityPower[index] + 1;
                abilityPointsLeft --;
            }
        }

        //We now have an array of <=4 numbers that add up to the point buy cost. We can now 'buy' abilities with these numbers
        //Heavy = 3; Medium =2; Light = 1;

        /* 
         * WEAPON  TYPES
         * 0 - Defensive
         * 1 - Support
         * 2 - Ballistic
         * 3 - Incendiary
         * 4 - Energy
         * 5 - Rocket
         *
         * A Mech may not have 2 weapons of the same type.
         */

        //We will generate a weapon type for each ability slot, and combine it with the power values to get the corresponding abilities.
        
        //Record what types have been used by marking the index with -1.
        
        int[] possibleTypes = new int[6];
        for(int i=0; i<possibleTypes.Length; i++){
            possibleTypes[i] = i;
        }

        int[] abilityTypes = new int[numberOfAbilities];
        for(int i = 0; i<abilityTypes.Length; i++){
            int randIndex = UnityEngine.Random.Range(0,5);
            while(possibleTypes[randIndex] == -1){
                randIndex = UnityEngine.Random.Range(0,5);
            }

        }
        
        //TODO: Use this to generate an array of type Ability






        return generatedAbilities;
    }
}
