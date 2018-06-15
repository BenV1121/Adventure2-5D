using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject itemsMenu;
    public bool menuOn;

    public GameObject shopMenu;
    public bool shopMenuOn;

    public TextBoxManager textBoxManager;
    public PlayerController playerController;

    public ShopSelector shopSelector;

	// Use this for initialization
	void Start ()
    {
        itemsMenu = GameObject.Find("ItemsMenu");
        itemsMenu.SetActive(false);

        shopMenu = GameObject.Find("ShopUI");
        shopMenu.SetActive(false);

        textBoxManager = TextBoxManager.FindObjectOfType<TextBoxManager>();
        playerController = PlayerController.FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P) && !textBoxManager.isActive)
        { 
            menuOn = !menuOn;

            if (menuOn)
            {
                itemsMenu.SetActive(true);
                playerController.canMove = false;
                Time.timeScale = 0;
            }
            else
            {
                itemsMenu.SetActive(false);
                playerController.canMove = true;
                Time.timeScale = 1;
            }
        }

        if(shopMenuOn)
        {
            shopSelector.menuManager = GetComponent<MenuManager>();
            playerController.canMove = false;
            Time.timeScale = 0;
        }
        else
        {
            shopMenu.SetActive(false);
            playerController.canMove = true;
            Time.timeScale = 1;
        }
    }
}
