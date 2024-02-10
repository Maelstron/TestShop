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
        CurrentInputHandler.UpdateDirectionalInput(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
