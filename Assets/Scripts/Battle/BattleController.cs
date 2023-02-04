using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace GameJam.Battle
{
    /// <summary>
    /// Handles the battle gameplay.
    /// </summary>
    public class BattleController : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private bool isIteratorRunning = false;
        [HideInInspector] public List<AttackData> turnData = new List<AttackData>();
        [SerializeField] private EntityStatus player;
        [SerializeField] private EntityStatus enemy;
        [SerializeField] private GameObject attackDataPrefab;



        //==============================================================================
        // Functions
        //==============================================================================
        private void Update()
        {
            PlayTurn();
        }


        
        private void PlayTurn()
        {
            if (turnData.Count <= 0)
            {
                turnData = new List<AttackData>();
                FillTurnData();
            }

            if (!isIteratorRunning)
            {
                StartCoroutine(IterateTurn());
            }
        }



        private void FillTurnData()
        {
            AttackData playerAttack =  Instantiate(attackDataPrefab).GetComponent<AttackData>();

            playerAttack.SetAttributes(player);
            turnData.Add(playerAttack);

            AttackData enemyAttack =  Instantiate(attackDataPrefab).GetComponent<AttackData>();
            
            enemyAttack.SetAttributes(enemy);
            turnData.Add(enemyAttack);
        }



        private IEnumerator IterateTurn()
        {
            isIteratorRunning = true;

            foreach (AttackData attack in turnData)
            {
                float damage = attack.Damage;
                attack.Attacker.GetComponent<EntityStatus>().Attack(damage);
                yield return new WaitForSeconds(1f);
            }

            foreach(AttackData attack in turnData)
            {
                if (attack.gameObject == null)
                {
                    Destroy(attack.gameObject);
                }
            }

            isIteratorRunning = false;
        }
    }
}

