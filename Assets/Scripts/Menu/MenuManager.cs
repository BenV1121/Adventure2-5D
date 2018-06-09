using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject itemsMenu;
    public bool menuOn;

    public TextBoxManager textBoxManager;
    public PlayerController playerController;

	// Use this for initialization
	void Start ()
    {
        itemsMenu = GameObject.Find("ItemsMenu");
        itemsMenu.SetActive(false);

        menuOn = false;

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
    }
}
