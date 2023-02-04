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

        [Header("Attack Data")]
        [SerializeField] public float Damage;
        [SerializeField] public DamageType damageType;
        [SerializeField] public GameObject Attacker;

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
            //CalculateWeaponTypeMultiplier();
            CalculateMiss();
            CalculateDodge();
        }



        private void CalculatePhysical()
        {
            float targetPhysicalResistance = entityStatus.AttackTarget.Armour.PhysicalResistance + entityStatus.Race.PhysicalDefense;
            float attackerPhysicalDamage = entityStatus.Weapon.PhysicalDamage + entityStatus.Race.PhysicalAttack;
            Damage = attackerPhysicalDamage - targetPhysicalResistance;
            if (Damage < 0) Damage = 1;

            damageType = DamageType.Physical;
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



        private void CalculateMiss()
        {
            float attackerAccuracy = entityStatus.Weapon.Accuracy;
            float calculatedMiss = Random.Range(0f, 1f);

            if (calculatedMiss > attackerAccuracy)
            {
                Damage = 0;
                damageType = DamageType.Miss;
            }
        }



        private void CalculateDodge()
        {
            float targetEvasion = entityStatus.AttackTarget.Race.Evasion - entityStatus.Weapon.Accuracy;
            float calculatedDodged = Random.Range(0f, 1f);

            if (calculatedDodged < targetEvasion)
            {
                Damage = 0;
                if (damageType != DamageType.Miss) damageType = DamageType.Dodged;
            }
        }
    }
}

