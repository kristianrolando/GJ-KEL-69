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

        [TextArea] public string questionRace;
        public SelectionRace selectionRace;

        [TextArea] public string questionWeaponType;
        [Tooltip("WeaponType based of Race has been choosen")]
        public BundleWeaponType[] selectionWeaponType;

        [TextArea] public string questionWeapon;
        [Tooltip("Weapon based of WeaponType has been choosen")]
        public BundleWeapon[] selectionWeapon;

        [TextArea] public string questionArmour;
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

