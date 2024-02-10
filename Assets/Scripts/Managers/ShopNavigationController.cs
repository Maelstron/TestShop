using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopNavigationController : MonoBehaviour
{
    [SerializeField]
    private List<Image> playerInventoryDisplay;
    [SerializeField]
    private List<Image> shopInventoryDisplay;
    [SerializeField]
    private Image selectionCursor;

    private int selectionIndex;
    private bool isOnPlayerSide;

	public int SelectionIndex { get => selectionIndex; set => selectionIndex = value; }
	public bool IsOnPlayerSide { get => isOnPlayerSide; set => isOnPlayerSide = value; }

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
