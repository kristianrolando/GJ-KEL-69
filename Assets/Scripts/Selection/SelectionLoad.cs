using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameJam.Battle;

namespace GJ.Selection
{
    public class SelectionLoad : MonoBehaviour
    {
        public static System.Action OnBattleStarted;

        [SerializeField] SelectionData data;

        [Header("UI")]
        [SerializeField] Button choiceButton1;
        [SerializeField] Button choiceButton2;

        [Header("Player Component")]
        [SerializeField] GameObject raceModel;
        [SerializeField] GameObject weaponModel;
        [SerializeField] GameObject armourModel;

        int idSession;
        int idB1;
        int idB2;

        BundleWeaponType _wType;
        BundleWeapon _weapon;
        BundleArmour _armour;

        enum SelectionState
        {
            race,
            weaponType,
            weapon,
            armour
        }
        private void Awake()
        {
            choiceButton1.onClick.AddListener(Choice1);
            choiceButton2.onClick.AddListener(Choice2);
            raceModel.SetActive(false);
            weaponModel.SetActive(false);
            armourModel.SetActive(false);
        }
        void Choice1()
        {
            LoadDataSelectionButton(idB1);
            //next selection
            LoadSelection();
        }
        void Choice2()
        {
            LoadDataSelectionButton(idB2);
            //next selection
            LoadSelection();
        }
        void LoadDataSelectionButton(int id)
        {
            switch (idSession)
            {
                case (int)SelectionState.race:
                    LoadRaceButton(id);
                    break;
                case (int)SelectionState.weaponType:
                    LoadWeaponTypeButton(id);
                    break;
                case (int)SelectionState.weapon:
                    LoadWeaponButton(id);
                    break;
                case (int)SelectionState.armour:
                    LoadArmourButton(id);
                    break;
            }
            idSession++;
            if(idSession >= data.totalSelection)
            {
                //OnBattleStarted?.Invoke();
                GameObject.FindObjectOfType<SelectManager>().GetComponent<SelectManager>().ManagerBattle();
            }
        }
        public void LoadSelection()
        {
            if (idSession >= data.totalSelection)
            {
                return;
            }

            switch(idSession)
            {
                case (int)SelectionState.race:
                    LoadRace();
                    break;
                case (int)SelectionState.weapon:
                    LoadWeapon();
                    break;
                case (int)SelectionState.weaponType:
                    LoadWeaponType();
                    break;
                case (int)SelectionState.armour:
                    LoadArmour();
                    break;
            }
        }

        

        void LoadRace()
        {
            if (data.selectionRace.race.Length <= 0)
            {
                return;
            }

            int id1 = Random.Range(0, data.selectionRace.race.Length);
            int id2 = Random.Range(0, data.selectionRace.race.Length);
            while (id1 == id2 && data.selectionRace.race.Length > 1)
            {
                id2 = Random.Range(0, data.selectionRace.race.Length);
            }
            var text1 = data.selectionRace.race[id1].name;
            var text2 = data.selectionRace.race[id2].name;
            idB1 = id1;
            idB2 = id2;
            LoadUIText(text1, text2);
        }
        void LoadWeaponType()
        {
            //find bundle weapon Type based race has been choosen
            _wType = System.Array.Find(data.selectionWeaponType, wType => wType.nameBundle.ToLower() == SelectionContainer.race.Name.ToLower());
            if (_wType.weaponType.Length <= 0)
            {
                return;
            }

            int id1 = Random.Range(0, _wType.weaponType.Length);
            int id2 = Random.Range(0, _wType.weaponType.Length);
            while (id1 == id2 && _wType.weaponType.Length > 1)
            {
                id2 = Random.Range(0, _wType.weaponType.Length);
            }
            var text1 = _wType.weaponType[id1].name;
            var text2 = _wType.weaponType[id2].name;

            idB1 = id1;
            idB2 = id2;
            LoadUIText(text1, text2);
        }
        void LoadWeapon()
        {
            //find bundle weapon based weapon Type has been choosen
            _weapon = System.Array.Find(data.selectionWeapon, weapon => weapon.nameBundle.ToLower() == SelectionContainer.weaponType.Name.ToLower());
            if (_weapon.weapon.Length <= 0)
            {
                return;
            }

            int id1 = Random.Range(0, _weapon.weapon.Length);
            int id2 = Random.Range(0, _weapon.weapon.Length);
            while (id1 == id2 && _weapon.weapon.Length > 1)
            {
                id2 = Random.Range(0, _weapon.weapon.Length);
            }
            var text1 = _weapon.weapon[id1].name;
            var text2 = _weapon.weapon[id2].name;

            idB1 = id1;
            idB2 = id2;
            LoadUIText(text1, text2);
        }
        void LoadArmour()
        {
            //find bundle armour based weapon has been choosen
            _armour = System.Array.Find(data.selectionArmour, armour => armour.nameBundle.ToLower() == SelectionContainer.weapon.name.ToLower());
            if (_armour.armour.Length <= 0)
            {
                return;
            }

            int id1 = Random.Range(0, _armour.armour.Length);
            int id2 = Random.Range(0, _armour.armour.Length);
            while (id1 == id2 && _armour.armour.Length > 1)
            {
                id2 = Random.Range(0, _armour.armour.Length);
            }
            var text1 = _armour.armour[id1].name;
            var text2 = _armour.armour[id2].name;

            idB1 = id1;
            idB2 = id2;
            LoadUIText(text1, text2);
        }          

        void LoadRaceButton(int id)
        {
            raceModel.SetActive(true);
            raceModel.GetComponent<SpriteRenderer>().sprite = data.selectionRace.race[id].raceSprite;
            SelectionContainer.race = data.selectionRace.race[id];
        }
        void LoadWeaponTypeButton(int id)
        {
            SelectionContainer.weaponType = _wType.weaponType[id];
        }
        void LoadWeaponButton(int id)
        {
            weaponModel.SetActive(true);
            weaponModel.GetComponent<SpriteRenderer>().sprite = _weapon.weapon[id].weaponSprite;
            SelectionContainer.weapon = _weapon.weapon[id];
        }
        void LoadArmourButton(int id)
        {
            armourModel.SetActive(true);
            armourModel.GetComponent<SpriteRenderer>().sprite = _armour.armour[id].armourSprite;
            SelectionContainer.armour = _armour.armour[id];
        }

        void LoadUIText(string choice1, string choice2)
        {
            choiceButton1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = choice1;
            choiceButton2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = choice2;
        }
    }
}


