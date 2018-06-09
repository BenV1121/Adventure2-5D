using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenItem : MonoBehaviour
{
    public PlayerController playerController;

    TextAsset theText;

    public int startLine;
    public int endLine;

    public TextBoxManager theTextBox;

    public bool requireButtonPress;
    private bool waitForPress;

    public bool destroyWhenActivated;
    public bool disableWhenActivated;

    public string[] theDialogues;
    int theDialoguesIdx;

    // Use this for initialization
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();

        theTextBox = FindObjectOfType<TextBoxManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForPress && Input.GetKeyDown(KeyCode.Space))
        {
            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine; //theDialoguesIdx
            theTextBox.endAtLine = endLine; // theDialoguesIdx.length
            theTextBox.EnableTextBox();

            playerController.emiNumber += 50;
            playerController.SetEmiAmount();

            if (destroyWhenActivated)
            {
                playerController.exclamationPoint.SetActive(false);
                Destroy(gameObject);
            }

            if (disableWhenActivated)
            {
                gameObject.SetActive(false);

                Debug.Log("Yo");

                startLine += 1;

                if (startLine > endLine)
                {
                    gameObject.SetActive(true);
                    Debug.Log("Hello");
                }
            }
            theTextBox.stopPlayerMovement = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            playerController.exclamationPoint.SetActive(true);

            if (requireButtonPress)
            {
                waitForPress = true;
                return;
            }

            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableTextBox();

            if (destroyWhenActivated)
            {
                playerController.exclamationPoint.SetActive(false);
                Destroy(gameObject);
            }

            if (disableWhenActivated)
            {
                gameObject.SetActive(false);

                startLine += 1;

                if (startLine > endLine)
                {
                    gameObject.SetActive(true);
                    Debug.Log("Hello");
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            playerController.exclamationPoint.SetActive(false);
            waitForPress = false;
        }
    }
}
