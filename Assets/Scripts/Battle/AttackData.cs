using UnityEngine;

namespace GameJam.Battle
{
    /// <summary>
    /// Contains single attack data.
    /// </summary>
    public class AttackData : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private EntityStatus entityStatus;
        public GameObject Attacker;
        public float Damage;

        [Header("Multipliers")]
        [SerializeField] private float bluntAttackMultiplier = 2f;
        // [SerializeField] private float slashAttackMultiplier = 2f;
        // [SerializeField] private float pierceAttackMultiplier = 2f;

        [Header("Penalties")]
        [SerializeField] private float bluntAttackPenalty = 0.8f;
        // [SerializeField] private float slashAttackPenalty = 0.8f;
        // [SerializeField] private float pierceAttackPenalty = 0.8f;



        //==============================================================================
        // Functions
        //==============================================================================
        public void SetAttributes(EntityStatus _entityStatus)
        {
            entityStatus = _entityStatus;
            Attacker = entityStatus.gameObject;
            CalculateTotalDamage();
        }



        private void CalculateTotalDamage()
        {
            CalculatePhysical();
            CalculateWeaponTypeMultiplier();
        }



        private void CalculatePhysical()
        {
            float physicalResistance = entityStatus.AttackTarget.Armour.PhysicalResistance;
            Damage = entityStatus.Weapon.PhysicalDamage - physicalResistance;
        }


        
        private void CalculateWeaponTypeMultiplier()
        {
            AttackType playerAttackType = entityStatus.Weapon.AttackType;
            ArmourType enemyArmourType = entityStatus.AttackTarget.Armour.Type;

            if (playerAttackType == AttackType.Blunt && enemyArmourType == ArmourType.Heavy)
            {
                Damage *= bluntAttackMultiplier;
            }

            if (playerAttackType == AttackType.Blunt && enemyArmourType == ArmourType.Light)
            {
                Damage *= bluntAttackPenalty;
            }
        }
    }
}

