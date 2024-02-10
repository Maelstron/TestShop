using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryNavigationController : MonoBehaviour
{
    [SerializeField]
    private List<Image> playerInventoryDisplay;
    [SerializeField]
    private Image selectionCursor;

    private int selectionIndex = 0;
    private bool isOnBackpack = true;

    public int SelectionIndex { get => selectionIndex; set => selectionIndex = value; }
    public bool IsOnPlayerSide { get => isOnBackpack; set => isOnBackpack = value; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isOnBackpack)
        {
            selectionCursor.transform.position = playerInventoryDisplay[selectionIndex].transform.position;
        }
        else
        {
        }
    }
}
