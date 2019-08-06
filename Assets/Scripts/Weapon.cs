using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    public string weaponName = "New Ability";
    public Sprite weaponSprite;
    public AudioClip weaponSound;
    public float weaponBaseCooldown = 1f;

    public abstract void Initialize(GameObject obj);
    public abstract void TriggerAbility();
}
