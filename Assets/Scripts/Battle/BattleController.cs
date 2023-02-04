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
        [SerializeField] private GameObject attackLog;
        [SerializeField] private string gameSceneName;



        //==============================================================================
        // Functions
        //==============================================================================
        private void Start()
        {
            StageController.InitiateStage(player, enemy);
        }



        private void Update()
        {
            PlayTurn();
            OnDeathEvent();
        }


        
        private void PlayTurn()
        {
            if (turnData.Count <= 0)
            {
                FillTurnData();
            }

            if (!isIteratorRunning)
            {
                StartCoroutine(IterateTurn());
            }
        }



        private void FillTurnData()
        {
            AttackData playerAttack =  Instantiate(attackDataPrefab, new Vector3(0, 0, 0), Quaternion.identity, attackLog.transform).GetComponent<AttackData>();

            playerAttack.SetAttributes(player);
            turnData.Add(playerAttack);

            AttackData enemyAttack =  Instantiate(attackDataPrefab, new Vector3(0, 0, 0), Quaternion.identity, attackLog.transform).GetComponent<AttackData>();
            
            enemyAttack.SetAttributes(enemy);
            turnData.Add(enemyAttack);
        }



        private IEnumerator IterateTurn()
        {
            isIteratorRunning = true;

            foreach (AttackData attack in turnData)
            {
                float damage = attack.Damage;
                DamageType damageType = attack.damageType;

                DamageData damageData = new DamageData(damage, damageType);

                attack.Attacker.GetComponent<EntityStatus>().Attack(damageData);
                yield return new WaitForSeconds(1f);
            }

            turnData.Clear();

            isIteratorRunning = false;
        }



        private void OnDeathEvent()
        {
            if (enemy.HealthPoint <= 0 || player.HealthPoint <= 0)
            {
                if (enemy.HealthPoint > player.HealthPoint) StageController.OnPlayerDeath();
                else StageController.OnEnemyDeath(gameSceneName);

                gameObject.GetComponent<BattleController>().enabled = false;
            }
        }
    }
}

