using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GJ.Selection
{
    public class SelectManager : MonoBehaviour
    {
        [SerializeField] float timeForReadHint = 3f;

        [SerializeField] SelectionLoad load;

        [SerializeField] GameObject hintEnemy;
        [SerializeField] GameObject selectionMenu;
        [SerializeField] GameObject[] battleObj;
        [SerializeField] GameObject playerModel;


        enum PageState
        {
            hintPage,
            selectionPage,
            battlePage
        }
        private void OnEnable()
        {
            SelectionLoad.OnBattleStarted += () => { StatePage(PageState.battlePage); };
        }
        private void OnDestroy()
        {
            SelectionLoad.OnBattleStarted -= () => { StatePage(PageState.battlePage); };
        }
        private void Start()
        {
            StatePage(PageState.hintPage);
        }

        void StatePage(PageState state)
        {
            switch(state)
            {
                case PageState.hintPage:
                    hintEnemy.SetActive(true);
                    selectionMenu.SetActive(false);
                    SetActiveObjBattle(false);
                    StartCoroutine(SelectionPageDelay(timeForReadHint));
                    break;
                case PageState.selectionPage:
                    hintEnemy.SetActive(false);
                    selectionMenu.SetActive(true);
                    load.LoadSelection();
                    break;
                case PageState.battlePage:
                    selectionMenu.SetActive(false);
                    SetActiveObjBattle(true);
                    break;
            }
        }
        IEnumerator SelectionPageDelay(float time)
        {
            yield return new WaitForSeconds(time);
            StatePage(PageState.selectionPage);
        }
        void SetActiveObjBattle(bool isActive)
        {
            if(!isActive)
            {
                for (int i = 0; i < battleObj.Length; i++)
                {
                    battleObj[i].SetActive(false);
                }
            }
            else if(isActive)
            {
                for (int i = 0; i < battleObj.Length; i++)
                {
                    battleObj[i].SetActive(true);
                }

                DeactivatePlayerModel();
            }

        }

        void DeactivatePlayerModel()
        {
            playerModel.SetActive(false);
        }
    }
}


