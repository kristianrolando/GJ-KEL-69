using UnityEngine;
using GJ.Selection;

namespace GameJam.Battle
{
    /// <summary>
    /// Handles the battle gameplay.
    /// </summary>
    public class StageController : MonoBehaviour
    {
        //==============================================================================
        // Functions
        //==============================================================================
        


        public static void OnPlayerDeath()
        {
            Debug.Log("GAME OVER");
        }



        public static void OnEnemyDeath()
        {
            Debug.Log("PREPARING NEXT STAGE");
        }



        public static void InitiateStage(EntityStatus player, EntityStatus enemy)
        {
            SetPlayerAttribute(player);
            SetEnemyAttribute(enemy);
        }



        public static void SetPlayerAttribute(EntityStatus player)
        {
            player.Race = SelectionContainer.race;
            player.Weapon = SelectionContainer.weapon;
            player.Armour = SelectionContainer.armour;

            SetSprites(player);
        }



        public static void SetEnemyAttribute(EntityStatus enemy)
        {
            enemy.Race = SelectionContainer.race;
            enemy.Weapon = SelectionContainer.weapon;
            enemy.Armour = SelectionContainer.armour;

            SetSprites(enemy);
        }



        private static void SetSprites(EntityStatus entity)
        {
            entity.RaceSlot.sprite = entity.Race.raceSprite;
            entity.WeaponSlot.sprite = entity.Weapon.weaponSprite;
            entity.ArmourSlot.sprite = entity.Armour.armourSprite;
        }
    }
}

