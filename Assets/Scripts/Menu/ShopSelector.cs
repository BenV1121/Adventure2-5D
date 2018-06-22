using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSelector : MonoBehaviour
{
    public Transform[] item;

    int row = 0;
    int col = 0;

    int maxRow = 3;
    int maxCol = 1;
    int minRow = 0;
    int minCol = 0;

    private bool m_xAxisInUse = false;
    private bool m_yAxisInUse = false;

    public MenuManager menuManager;

    PlayerController playerController;

    EquipGet equipGet;

    TextBoxManager textBoxManager;

    // Use this for initialization
    void Start ()
    {
        transform.position = item[0].position;
        playerController = FindObjectOfType<PlayerController>();
        equipGet = FindObjectOfType<EquipGet>();
        menuManager = FindObjectOfType<MenuManager>();
        textBoxManager = FindObjectOfType<TextBoxManager>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetAxisRaw("Vertical") > 0 && textBoxManager.isActive == false) // W
        {
            if (m_yAxisInUse == false)
            {
                if (col > minCol)
                    col--;

                Debug.Log(col);

                m_yAxisInUse = true;
            }
        }
        else if (Input.GetAxisRaw("Horizontal") < 0 && textBoxManager.isActive == false) // A
        {
            if (m_xAxisInUse == false)
            {
                if (row > minRow)
                    row--;

                Debug.Log(row);

                m_xAxisInUse = true;
            }
        }
        else if (Input.GetAxisRaw("Vertical") < 0 && textBoxManager.isActive == false) // S
        {
            if (m_yAxisInUse == false)
            {
                if (col < maxCol)
                    col++;

                Debug.Log(col);

                m_yAxisInUse = true;
            }
        }
        else if (Input.GetAxisRaw("Horizontal") > 0 && textBoxManager.isActive == false) // D
        {
            if (m_xAxisInUse == false)
            {
                if (row < maxRow)
                    row++;

                Debug.Log(row);

                m_xAxisInUse = true;
            }
        }

        if (Input.GetAxisRaw("Vertical") == 0)
            m_yAxisInUse = false;
        if (Input.GetAxisRaw("Horizontal") == 0)
            m_xAxisInUse = false;

        if (row == 0 && col == 0)
            transform.position = item[0].position;
        else if (row == 1 && col == 0)
            transform.position = item[1].position;
        else if (row == 2 && col == 0)
            transform.position = item[2].position;
        else if (row == 3 && col == 0)
            transform.position = item[3].position;
        else if (row >= 0 && col == 1)
            transform.position = item[4].position;

        if (Input.GetKeyDown(KeyCode.Mouse0) && textBoxManager.isActive == false)
        {
            if (row >= 0 && col == 1)
            {
                menuManager.shopMenuOn = false;
                menuManager.shopMenu.SetActive(false);
                menuManager.playerController.canMove = true;

                row = 0;
                col = 0;
                Time.timeScale = 1;
            }

            if (row == 0 && col == 0)
            {
                if(playerController.emiNumber >= 1)
                {
                    playerController.emiNumber -= 1;
                    playerController.health += 10;
                    playerController.SetEmiAmount();
                    playerController.SetHealthAmount();
                }
            }
            if (row == 3 && col == 0)
            {
                if(playerController.emiNumber >= 50)
                {
                    playerController.emiNumber -= 50;
                    item[3].gameObject.SetActive(false);
                    playerController.SetEmiAmount();
                    equipGet.equipGot[5] = true;
                }
            }
        }
    }
}
