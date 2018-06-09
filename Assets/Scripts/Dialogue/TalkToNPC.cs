using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkToNPC : MonoBehaviour
{
    TextAsset theText;

    public int startLine;
    public int endLine;

    public TextBoxManager theTextBox;

    public MenuManager menuManager;

    public bool requireButtonPress;
    private bool waitForPress;

    public bool destroyWhenActivated;
    public bool disableWhenActivated;

    //public string[] theDialogues;
    //int theDialoguesIdx;

    Transform speechBubble;

    // Use this for initialization
    void Start()
    {
        theTextBox = FindObjectOfType<TextBoxManager>();
        speechBubble = this.gameObject.transform.GetChild(1);

        speechBubble.gameObject.SetActive(false);

        menuManager = FindObjectOfType<MenuManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForPress && Input.GetKeyDown(KeyCode.Space) && !menuManager.menuOn && !theTextBox.isActive)
        {
            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine; //theDialoguesIdx
            theTextBox.endAtLine = endLine; // theDialoguesIdx.length
            theTextBox.EnableTextBox();

            if (destroyWhenActivated)
            {
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
            speechBubble.gameObject.SetActive(true);

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
            speechBubble.gameObject.SetActive(false);
            waitForPress = false;
        }
    }
}
