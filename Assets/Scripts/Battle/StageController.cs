using UnityEngine;
using UnityEngine.SceneManagement;
using GJ.Selection;

namespace GameJam.Battle
{
    /// <summary>
    /// Handles the battle gameplay.
    /// </summary>
    public class StageController : MonoBehaviour
    {
        [SerializeField] private EnemySO[] enemyPool;

        //==============================================================================
        // Functions
        //==============================================================================
        public static void OnPlayerDeath()
        {
            SetHighScore();
            
        }



        public static void OnEnemyDeath(string nextScene)
        {
            DataManager.playerScore += 1;
            SceneManager.LoadScene(nextScene);
        }



        public void InitiateStage(EntityStatus player, EntityStatus enemy)
        {
            SetPlayerAttribute(player);
            SetEnemyAttribute(enemy);
        }



        public void SetPlayerAttribute(EntityStatus player)
        {
            player.Race = SelectionContainer.race;
            player.Weapon = SelectionContainer.weapon;
            player.Armour = SelectionContainer.armour;

            SetSprites(player);
            player.Spawn();
        }



        private EnemySO RandomizeEnemyPool()
        {
            int pick = Random.Range(0, enemyPool.Length);
            return enemyPool[pick];
        }



        public void SetEnemyAttribute(EntityStatus enemy)
        {
            EnemySO enemyPreset = RandomizeEnemyPool();

            enemy.Race = enemyPreset.Race;
            enemy.Weapon = enemyPreset.Weapon;
            enemy.Armour = enemyPreset.Armour;

            SetSprites(enemy);
            enemy.Spawn();
        }



        private static void SetSprites(EntityStatus entity)
        {
            entity.RaceSlot.sprite = entity.Race.raceSprite;
            entity.WeaponSlot.sprite = entity.Weapon.weaponSprite;
            entity.ArmourSlot.sprite = entity.Armour.armourSprite;
        }



        private static void SetHighScore()
        {
            if (PlayerPrefs.HasKey("highscore"))
            {
                if (PlayerPrefs.GetInt("highscore") < DataManager.playerScore) PlayerPrefs.SetInt("highscore", DataManager.playerScore);
            }
        
            else
            {
                PlayerPrefs.SetInt("highscore", DataManager.playerScore);
            }
        }
    }
}