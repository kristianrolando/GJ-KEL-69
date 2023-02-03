using UnityEngine;

namespace GameJam.Battle
{
    /// <summary>
    /// Contains entity attributes and methods.
    /// </summary>
    public class EntityStatus : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        [SerializeField] public float Healthpoint;
        private Animator animator;
        [SerializeField] public EntityStatus AttackTarget;
        [SerializeField] public WeaponSO Weapon;
        [SerializeField] public ArmourSO Armour;



        //==============================================================================
        // Functions
        //==============================================================================
        private void Awake()
        {
            animator = gameObject.GetComponent<Animator>();
        }



        public void Attack(float damage)
        {
            WeaponType weaponType = Weapon.Type;

            if (weaponType == WeaponType.Melee)
            {
                MeleeAttack(damage);
            }

            if (weaponType == WeaponType.Ranged)
            {
                RangedAttack(damage);
            }
        }



        private void RangedAttack(float damage)
        {
            
        }



        private void MeleeAttack(float damage)
        {
            AttackTarget.Healthpoint -= damage;
            animator.SetTrigger("Attack");
        }
    }
}

