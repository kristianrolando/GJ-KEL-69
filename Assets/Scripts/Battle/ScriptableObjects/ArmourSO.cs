using UnityEngine;

namespace GameJam.Battle
{
    /// <summary>
    /// Armour with its attributes.
    /// </summary>
    [CreateAssetMenu(fileName = "NewArmour", menuName = "Player Attribute/Armour")]
    public class ArmourSO : ScriptableObject
    {
        //==============================================================================
        // Variables
        //==============================================================================
        [SerializeField] public string Name;
        [TextArea] [SerializeField] public string Hint;
        [SerializeField] public Sprite armourSprite;
        [SerializeField] public ArmourType Type;
        [SerializeField] public float Weight;
        [SerializeField] public float PhysicalResistance;
        [SerializeField] public float MagicalResistance;
    }
}