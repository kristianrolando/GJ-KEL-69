using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GJ.Selection
{
    public class SelectManager : MonoBehaviour
    {
        [SerializeField] GameObject hintEnemy;
        [SerializeField] GameObject selectionMenu;

        [SerializeField] SelectionLoad load;

        enum PageState
        {
            hintPage,
            selectionPage,
            battlePage
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
                    StartCoroutine(SelectionPageDelay(1f));
                    break;
                case PageState.selectionPage:
                    hintEnemy.SetActive(false);
                    selectionMenu.SetActive(true);
                    load.LoadSelection();
                    break;
                case PageState.battlePage:
                    break;
            }
        }
        IEnumerator SelectionPageDelay(float time)
        {
            yield return new WaitForSeconds(time);
            StatePage(PageState.selectionPage);
        }
    }
}


