using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
        [SerializeField] public float HealthPoint;
        private float maxHealthPoint;
        [SerializeField] public RaceSO Race;
        [HideInInspector] public Animator Animator;
        [SerializeField] public EntityStatus AttackTarget;
        [SerializeField] public WeaponSO Weapon;
        [SerializeField] public ArmourSO Armour;
        [SerializeField] private Transform weaponTransform;
        [SerializeField] TextMeshPro damageText;
        [SerializeField] Slider healthSlider;

        private DamageData damageData;



        //==============================================================================
        // Functions
        //==============================================================================
        private void Awake()
        {
            Animator = gameObject.GetComponent<Animator>();
            HealthPoint = Race.HealthPoint;
            maxHealthPoint = HealthPoint;
        }



        private void Update()
        {
            SyncSlider();
        }



        private void SyncSlider()
        {
            healthSlider.maxValue = maxHealthPoint;
            healthSlider.value = HealthPoint;
        }



        public void Attack(DamageData _damageData)
        {
            WeaponType weaponType = Weapon.Type;
            damageData = _damageData;

            if (weaponType == WeaponType.Melee)
            {
                MeleeAttack();
            }

            if (weaponType == WeaponType.Ranged)
            {
                RangedAttack();
            }
        }



        private void RangedAttack()
        {
            Projectile projectile = Instantiate(Weapon.Projectile, weaponTransform.position, Quaternion.Euler(0, 0, 0), weaponTransform).GetComponent<Projectile>();
            projectile.AttackTarget = AttackTarget;
            projectile.damageData = damageData;

            float travelSpeed = projectile.TravelSpeed;

            Vector3 positionDifference = AttackTarget.transform.position - weaponTransform.position;
            if (positionDifference.x > 0)
            {
                projectile.Rb.AddForce(transform.right * travelSpeed);
                projectile.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            }

            else
            {
                projectile.Rb.AddForce((transform.right * -1) * travelSpeed);
                projectile.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            }
        }



        private void MeleeAttack()
        {
            Animator.SetTrigger("Attack");
        }



        private void HurtTarget()
        {
            AttackTarget.TakeDamage(damageData);
        }



        public void TakeDamage(DamageData _damageData)
        {
            HealthPoint -= _damageData.damage;

            if (_damageData.damageType == DamageType.Miss)
            {
                damageText.text = "Miss";
                damageText.color = new Color(255f, 255f, 100f, damageText.color.a);
            }

            if (_damageData.damageType == DamageType.Dodged)
            {
                damageText.text = "Dodged";
                damageText.color = new Color(255f, 255f, 100f, damageText.color.a);
            }

            if (_damageData.damageType == DamageType.Physical)
            {
                int damageFloored = (int)_damageData.damage;
                damageText.text = damageFloored.ToString();
                damageText.color = new Color(255f, 0f, 0f, damageText.color.a);
            }

            if (_damageData.damage > 0)
            {
                Animator.SetTrigger("Hurt");
            }
            
            damageText.gameObject.GetComponent<Animator>().SetTrigger("Hurt");
        }



    }
}

