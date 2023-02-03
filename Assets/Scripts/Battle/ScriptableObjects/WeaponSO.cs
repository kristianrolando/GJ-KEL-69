using UnityEngine;

namespace GameJam.Battle
{
    /// <summary>
    /// Weapon with its attributes.
    /// </summary>
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "Player Attribute/Weapon")]
    public class WeaponSO : ScriptableObject
    {
        //==============================================================================
        // Variables
        //==============================================================================
        [SerializeField] public string Name;
        [SerializeField] public WeaponType Type;
        [SerializeField] public AttackType AttackType;
        [SerializeField] public float PhysicalDamage;
    }
}