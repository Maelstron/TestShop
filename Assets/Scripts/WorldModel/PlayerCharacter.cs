using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField]
    private Inventory inventory;
    private Equipment equipment;

    [SerializeField]
    private ShopItem defaultOutfit;

    [SerializeField]
    private GameObject hairObject;
    [SerializeField]
    private GameObject outfitObject;
    [SerializeField]
    private GameObject baseBodyObject;

    //TODO If there is time we implement the hat support.
    //[SerializeField]
    //private GameObject hatObject;

    internal Inventory Inventory { get => inventory; set => inventory = value; }
	public Equipment Equipment { get => equipment; set => equipment = value; }
	public ShopItem DefaultOutfit { get => defaultOutfit; }


	private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        equipment = new Equipment();
        equipment.EquipOutfit(defaultOutfit);
        UpdateOutfit();
    }

    // Start is called before the first frame update
    void Start()
    {
        hairObject.SetActive(true);
        outfitObject.SetActive(true);
        baseBodyObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateOutfit()
    {
        outfitObject.SetActive(false);
        GameObject outfitComponent = this.transform.Find("PlayerOutfit").gameObject;
        if (Equipment.Outfit.ItemName == "Leather Armor")
		{
            outfitObject = outfitComponent.transform.Find("Leather").gameObject;
        }
        else if (Equipment.Outfit.ItemName == "Plate Armor")
        {
            outfitObject = outfitComponent.transform.Find("Plate").gameObject;
        }
        else if (Equipment.Outfit.ItemName == "Male Underwear")
        {
            outfitObject = outfitComponent.transform.Find("MaleUnderwear").gameObject;
        }
        outfitObject.SetActive(true);
    }

    public void UpdateAnimationFromMovement(float horizontalAxis, float verticalaxis)
	{
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
