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
            if (entityStatus.Weapon.AttackType == AttackType.Magic) CalculateMagical();
            else CalculatePhysical();

            CalculateWeaponTypeMultiplier();
            CalculateMiss();
            CalculateDodge();
        }



        private void CalculatePhysical()
        {
            float targetPhysicalResistance = entityStatus.AttackTarget.Armour.PhysicalResistance + entityStatus.Race.PhysicalDefense;
            float attackerPhysicalDamage = entityStatus.Weapon.PhysicalDamage + entityStatus.Race.PhysicalAttack;
            float randomDamageBonus = attackerPhysicalDamage *= 0.1f;

            randomDamageBonus = Random.Range(0f, randomDamageBonus);

            Damage = attackerPhysicalDamage - targetPhysicalResistance + randomDamageBonus;
            if (Damage < 0) Damage = 1;

            damageType = DamageType.Physical;
        }



        private void CalculateMagical()
        {
            float targetMagicalResistance = entityStatus.AttackTarget.Armour.MagicalResistance + entityStatus.Race.MagicDefense;
            float attackerMagicalDamage = entityStatus.Weapon.MagicDamage + entityStatus.Race.MagicAttack;
            float randomDamageBonus = attackerMagicalDamage *= 0.1f;

            randomDamageBonus = Random.Range(0f, randomDamageBonus);

            Damage = attackerMagicalDamage - targetMagicalResistance + randomDamageBonus;
            if (Damage < 0) Damage = 1;

            damageType = DamageType.Magical;
        }


        
        private void CalculateWeaponTypeMultiplier()
        {
            AttackType playerAttackType = entityStatus.Weapon.AttackType;
            ArmourType enemyArmourType = entityStatus.AttackTarget.Armour.Type;

            if (playerAttackType == AttackType.Slash && enemyArmourType == ArmourType.Light) Damage *= entityStatus.Weapon.damageBonus;
            if (playerAttackType == AttackType.Blunt && enemyArmourType == ArmourType.Light) Damage /= 2;
            if (playerAttackType == AttackType.Pierce && enemyArmourType == ArmourType.Medium) Damage *= entityStatus.Weapon.damageBonus;
            if (playerAttackType == AttackType.Slash && enemyArmourType == ArmourType.Medium) Damage /= 2;
            if (playerAttackType == AttackType.Blunt && enemyArmourType == ArmourType.Heavy) Damage *= entityStatus.Weapon.damageBonus;
            if (playerAttackType == AttackType.Pierce && enemyArmourType == ArmourType.Heavy) Damage /= 2;
            if (playerAttackType == AttackType.Magic && enemyArmourType == ArmourType.Magic) Damage /= 2;
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

