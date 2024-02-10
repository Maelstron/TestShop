using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputManager : MonoBehaviour
{
    [SerializeField]
    private IInputHandler currentInputHandler;

    public static GameInputManager instance;

	public IInputHandler CurrentInputHandler { get => currentInputHandler; set => currentInputHandler = value; }

	private void Awake()
    {
        if (GameInputManager.instance == null)
        {
            GameInputManager.instance = this;
        }
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleOnKeyDown();
        HandleOnKeyUp();
        CurrentInputHandler.UpdateDirectionalInput(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void HandleOnKeyDown()
	{
        if (Input.GetKeyDown(KeyCode.Z))
        {
            currentInputHandler.OnKeyPressed(KeyCode.Z);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            currentInputHandler.OnKeyPressed(KeyCode.X);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentInputHandler.OnKeyPressed(KeyCode.C);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentInputHandler.OnKeyPressed(KeyCode.DownArrow);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentInputHandler.OnKeyPressed(KeyCode.UpArrow);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentInputHandler.OnKeyPressed(KeyCode.RightArrow);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentInputHandler.OnKeyPressed(KeyCode.LeftArrow);
        }
    }

    private void HandleOnKeyUp()
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            currentInputHandler.OnKeyReleased(KeyCode.Z);
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            currentInputHandler.OnKeyReleased(KeyCode.X);
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            currentInputHandler.OnKeyReleased(KeyCode.C);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            currentInputHandler.OnKeyReleased(KeyCode.DownArrow);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            currentInputHandler.OnKeyReleased(KeyCode.UpArrow);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            currentInputHandler.OnKeyReleased(KeyCode.RightArrow);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            currentInputHandler.OnKeyReleased(KeyCode.LeftArrow);
        }
    }
}
