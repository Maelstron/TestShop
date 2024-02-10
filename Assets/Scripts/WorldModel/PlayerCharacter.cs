using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField]
    private Inventory inventory;
    private Equipment equipment;

    [SerializeField]
    private GameObject defaultOutfit;

    [SerializeField]
    private GameObject hairObject;
    [SerializeField]
    private GameObject outfitObject;
    [SerializeField]
    private GameObject baseBodyObject;
    //If there is time we implement the hat support.
    //[SerializeField]
    //private GameObject baseBody;


    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        hairObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateAnimationFromMovement(float horizontalAxis, float verticalaxis)
	{
        Debug.Log("Movement X: " + horizontalAxis + ", Y: " + verticalaxis);
        bool isHorizontalSpeedAbsBigger = Mathf.Abs(horizontalAxis) > Mathf.Abs(verticalaxis);
        // Animate hair.
        Animator hairAnimator = hairObject.GetComponent<Animator>();
        if (hairAnimator)
		{
            hairAnimator.SetBool("IsHorizontalSpeedAbsBigger", isHorizontalSpeedAbsBigger);
            hairAnimator.SetFloat("HorizontalAxis", horizontalAxis);
            hairAnimator.SetFloat("VerticalAxis", verticalaxis);
        }
        // Animate body.
        Animator bodyAnimator = baseBodyObject.GetComponent<Animator>();
        if (bodyAnimator)
        {
            bodyAnimator.SetBool("IsHorizontalSpeedAbsBigger", isHorizontalSpeedAbsBigger);
            bodyAnimator.SetFloat("HorizontalAxis", horizontalAxis);
            bodyAnimator.SetFloat("VerticalAxis", verticalaxis);
        }
        // Animate outfit.
        Animator outfitAnimator = outfitObject.GetComponent<Animator>();
        if (outfitAnimator)
        {
            outfitAnimator.SetBool("IsHorizontalSpeedAbsBigger", isHorizontalSpeedAbsBigger);
            outfitAnimator.SetFloat("HorizontalAxis", horizontalAxis);
            outfitAnimator.SetFloat("VerticalAxis", verticalaxis);
        }
    }
}
