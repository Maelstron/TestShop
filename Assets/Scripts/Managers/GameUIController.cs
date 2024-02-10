using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIController : MonoBehaviour
{
    // TODO include health and energy support.
    [SerializeField]
    private TextMeshProUGUI money;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        money.text = "Money: " + GameManager.instance.Player.Inventory.Money;
    }
}
