using UnityEngine;
using System.Collections;

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
        [SerializeField] public RaceSO Race;
        [HideInInspector] public Animator Animator;
        [SerializeField] public EntityStatus AttackTarget;
        [SerializeField] public WeaponSO Weapon;
        [SerializeField] public ArmourSO Armour;
        [SerializeField] private Transform weaponTransform;



        //==============================================================================
        // Functions
        //==============================================================================
        private void Awake()
        {
            Animator = gameObject.GetComponent<Animator>();
        }



        private void Update()
        {
            OnDeathEvent();
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
            Projectile projectile = Instantiate(Weapon.Projectile, weaponTransform.position, Quaternion.Euler(new Vector3(0, 0, 90)), weaponTransform).GetComponent<Projectile>();
            projectile.AttackTarget = AttackTarget;
            projectile.Damage = damage;
            projectile.Rb.AddForce(transform.right * 1500);
        }



        private void MeleeAttack(float damage)
        {
            AttackTarget.TakeDamage(damage);
            Animator.SetTrigger("Attack");
        }



        public void TakeDamage(float damage)
        {
            Race.HealthPoint -= damage;
        }



        public void FlashRedTargetOnHit()
        {
            AttackTarget.Animator.SetTrigger("Hurt");
        }



        private void OnDeathEvent()
        {
            if (Race.HealthPoint <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

