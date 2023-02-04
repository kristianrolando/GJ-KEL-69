using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJam.Battle;


namespace GJ.Selection
{
    [CreateAssetMenu(fileName = "Selection Data")]
    public class SelectionData : ScriptableObject
    {
        public int totalSelection;

        public SelectionRace selectionRace;
        [Tooltip("WeaponType based of Race has been choosen")]
        public BundleWeaponType[] selectionWeaponType;
        [Tooltip("Weapon based of WeaponType has been choosen")]
        public BundleWeapon[] selectionWeapon;
        [Tooltip("Armour based of Weapon has been choosen")]
        public BundleArmour[] selectionArmour;
    }
    [System.Serializable]
    public class SelectionRace
    {
        public RaceSO[] race;
    }
    [System.Serializable]
    public class BundleWeaponType
    {
        public string nameBundle;
        public WeaponTypeSO[] weaponType;
    }
    [System.Serializable]
    public class BundleWeapon
    {
        public string nameBundle;
        public WeaponSO[] weapon;
    }
    [System.Serializable]
    public class BundleArmour
    {
        public string nameBundle;
        public ArmourSO[] armour;
    }

}

