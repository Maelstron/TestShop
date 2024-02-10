using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerCharacter player;
    private ShopItemReference itemDb;

    public static GameManager instance = null;

	public PlayerCharacter Player { get => player; }
	public ShopItemReference ItemDb { get => itemDb; }

	private void Awake()
	{
        if (GameManager.instance == null)
        {
            GameManager.instance = this;
            itemDb = Resources.Load<ShopItemReference>("ShopItemData");
        }
        DontDestroyOnLoad(this);
    }

	// Start is called before the first frame update
	void Start()
    {
        GameInputManager.instance.CurrentInputHandler = player.GetComponent<PlayerInputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
