using UnityEngine;

namespace GameJam.Battle
{
    /// <summary>
    /// Weapon with its attributes.
    /// </summary>
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "Player Attribute/Weapon Type")]
    public class WeaponTypeSO : ScriptableObject
    {
        //==============================================================================
        // Variables
        //==============================================================================
        [SerializeField] public string Name;
    }
}