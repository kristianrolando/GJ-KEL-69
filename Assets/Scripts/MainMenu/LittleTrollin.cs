using UnityEngine;
using UnityEngine.EventSystems;

public class LittleTrollin : MonoBehaviour
{
    private bool isTrolledBefore = false;
    private Vector3 initialPosition;
    [SerializeField] private GameObject noButton;
    private bool mouseHover = false;
    private PointerEventData eventData;



    private void Awake()
    {
        initialPosition = transform.position;
    }



    public void OnClick()
    {
        if (!isTrolledBefore) SwapButton();
        else Application.Quit();
    }



    public void SwapButton()
    {
        transform.position = noButton.transform.position;
        noButton.transform.position = initialPosition;

        initialPosition = transform.position;
    }



    public void NoTrollin()
    {
        isTrolledBefore = true;
        SwapButton();
    }
}
