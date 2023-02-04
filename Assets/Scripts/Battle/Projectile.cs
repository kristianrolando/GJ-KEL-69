using UnityEngine;

namespace GameJam.Battle
{
    /// <summary>
    /// Contains single attack data.
    /// </summary>
    public class Projectile : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        [HideInInspector] public Rigidbody2D Rb;
        [HideInInspector] public EntityStatus AttackTarget;
        [SerializeField] public DamageData damageData;
        [SerializeField] public float TravelSpeed = 500;



        //==============================================================================
        // Functions
        //==============================================================================
        private void Awake()
        {
            Rb = gameObject.GetComponent<Rigidbody2D>();
        }



        private void OnTriggerEnter2D(Collider2D collider) 
        {
            AttackTarget.TakeDamage(damageData);
            Destroy(gameObject);
        }
    }
}

