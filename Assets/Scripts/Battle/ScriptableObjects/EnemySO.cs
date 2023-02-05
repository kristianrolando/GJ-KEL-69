using UnityEngine;

namespace GameJam.Battle
{
    /// <summary>
    /// Enemy preset.
    /// </summary>
    [CreateAssetMenu(fileName = "NewEnemy", menuName = "Enemy Attribute/New Enemy")]
    public class EnemySO : ScriptableObject
    {
        //==============================================================================
        // Variables
        //==============================================================================
        [SerializeField] public string Name;
        [SerializeField] public RaceSO Race;
        [SerializeField] public WeaponSO Weapon;
        [SerializeField] public ArmourSO Armour;
        [TextArea] [SerializeField] public string Hint;
    }
}