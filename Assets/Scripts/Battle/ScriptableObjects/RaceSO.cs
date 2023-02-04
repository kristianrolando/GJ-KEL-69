using UnityEngine;

namespace GameJam.Battle
{
    /// <summary>
    /// Weapon with its attributes.
    /// </summary>
    [CreateAssetMenu(fileName = "NewRace", menuName = "Player Attribute/Race")]
    public class RaceSO : ScriptableObject
    {
        //==============================================================================
        // Variables
        //==============================================================================
        [SerializeField] public string Name;
        [SerializeField] public Sprite raceSprite;
        [SerializeField] public float HealthPoint;
        [SerializeField] public float PhysicalAttack;
        [SerializeField] public float MagicAttack;
        [SerializeField] public float PhysicalDefense;
        [SerializeField] public float MagicDefense;
        [SerializeField] public float EvadeChance;
    }
}