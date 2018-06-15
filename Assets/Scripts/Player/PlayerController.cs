using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.AI;

interface IDamageable
{
    void TakeDamage(float damageDealt);
}

public class PlayerController : MonoBehaviour, IDamageable
{
    float speed = 5;
    float velocity;

    Vector3 move;

    public bool isMove = false;
    public bool isSprint = false;

    public bool canMove = true;
    public bool canDash;

    //GameObject sword;
    GameObject arrow;

    GameObject _3dSword;
    GameObject _3dPivot;
    public GameObject exclamationPoint;

    Rigidbody rb;

    public float maxHealth = 10;
    public float health;

    public Image hp;
    public Text healthAmountText;
    public Text maxHealthText;

    public float maxCP = 10;
    public float cosmicPower;

    public Image cp;
    public Text cpAmountText;
    public Text maxCPText;

    float cpRegenerateTimer = 1;

    public Text emiAmount;
    public int  emiNumber;

    public NavMeshAgent nMA;

    Emi emi;

    EquipLoaded eQ;

    public bool isClimbing;

    float kinematicTimer = .1f;
    float kTimeReset = .1f;

    // Use this for initialization
    void Start()
    {
        arrow = GameObject.Find("ArrowPivot");
        _3dSword = GameObject.Find("3DBlade");
        _3dPivot = GameObject.Find("3DPivot");

        rb = GetComponent<Rigidbody>();

        //exclamationPoint is Sprite's child
        exclamationPoint = this.gameObject.transform.GetChild(0).GetChild(1).gameObject;
        exclamationPoint.SetActive(false);

        health = maxHealth;
        hp = GameObject.FindGameObjectWithTag("HP").GetComponent<Image>();
        SetHealthAmount();

        cosmicPower = maxCP;
        cp = GameObject.FindGameObjectWithTag("CP").GetComponent<Image>();
        SetCosmicPowerAmount();
        
        emiNumber = 0;
        SetEmiAmount();

        emi = (Emi)AssetDatabase.LoadAssetAtPath("Assets/Prefab/Drops/1Emi.prefab", typeof(Emi));

        eQ = FindObjectOfType<EquipLoaded>();

        nMA = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //sword.SetActive(false);
        _3dSword.SetActive(false);

        velocity = speed * Time.deltaTime;

        move.x = Input.GetAxis("Horizontal") * velocity;
        move.z = Input.GetAxis("Vertical") * velocity;

        if(canMove)
        { 
            // Player Sprinting
            if (Input.GetKey(KeyCode.LeftShift))
                isSprint = true;
            else
                isSprint = false;

            if(!isClimbing)
            { 
                if(isSprint == true)
                    transform.Translate(new Vector3(move.x * 1.5f, 0, move.z * 1.5f));
                else
                    transform.Translate(new Vector3(move.x, 0, move.z));
            }
            else if (isClimbing)
            {
                transform.Translate(new Vector3(move.x * .5f, move.z * .5f, 0));
            }

            // Player Attacking
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Z) || Input.GetAxis("Fire1Stick") != 0)
            {
                _3dSword.SetActive(true);
            }
            else
            {
                _3dSword.SetActive(false);
            }

            // Player consuming Cosmic Power

            if(Input.GetKeyDown(KeyCode.Mouse1))
            {
                cosmicPower -= 2;

                SetCosmicPowerAmount();
            }

            if (cosmicPower <= 0)
            {
                cosmicPower = 0;
                cpRegenerateTimer -= Time.deltaTime;

                SetCosmicPowerAmount();
            }

            if (cosmicPower > 0)
            {
                cosmicPower += Time.deltaTime;
                SetCosmicPowerAmount();
            }

            if(cpRegenerateTimer <= 0)
            {
                cpRegenerateTimer = 1;
                cosmicPower += Time.deltaTime;
            }

            //Player facing direction
            if (Input.GetAxisRaw("Vertical") > 0 && !isMove)
            { 
                arrow.transform.up = Vector3.up;
                _3dPivot.transform.up = Vector3.up;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0 && !isMove)
            { 
                arrow.transform.up = Vector3.left;
                _3dPivot.transform.forward = Vector3.left;
            }
            else if (Input.GetAxisRaw("Vertical") < 0 && !isMove)
            { 
                arrow.transform.up = Vector3.down;
                _3dPivot.transform.right = Vector3.left;
            }
            else if (Input.GetAxisRaw("Horizontal") > 0 && !isMove)
            { 
                arrow.transform.up = Vector3.right;
                _3dPivot.transform.forward = Vector3.right;
            }

            // If the player is moving in a direction, it should stay in that direction if there are other buttons pressed
            if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Vertical") < 0)
                isMove = true;
            else
                isMove = false;
        }

        hp.fillAmount = health / maxHealth;
        cp.fillAmount = cosmicPower / maxCP;

        if(Input.GetKeyDown(KeyCode.F1))
        {
            health -= 1;
            SetHealthAmount();

            if (health <= 0)
                Death();
        }

        if(rb.isKinematic == false)
        {
            kinematicTimer -= Time.deltaTime;
        }
        if (kinematicTimer <= 0)
            ResetKTimer();
    }

    void OnTriggerStay(Collider trigger)
    {
        if (trigger.tag == "ClimbableWall" && eQ.canClimb == true)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                isClimbing = true;
                nMA.enabled = false;
                rb.useGravity = false;
                rb.isKinematic = false;
            }
            else
            { 
                isClimbing = false;
                //nMA.enabled = true;
                rb.useGravity = true;
            }
        }
    }
    void OnTriggerExit(Collider trigger)
    {
        if(trigger.tag == "ClimbableWall")
        {
            isClimbing = false;
            nMA.enabled = true;
            rb.useGravity = true;
            rb.isKinematic = true;
        }
    }
    public void SetHealthAmount()
    {
        if (health >= maxHealth)
            health = maxHealth;

        healthAmountText.text = health.ToString();
        maxHealthText.text = "/ " + maxHealth.ToString();
    }

    public void SetCosmicPowerAmount()
    {
        if (cosmicPower >= maxCP)
            cosmicPower = maxCP;

        cpAmountText.text = cosmicPower.ToString();
        maxCPText.text = "/ " + maxCP.ToString();
    }

    public void SetEmiAmount()
    {
        emiAmount.text = "x " + emiNumber.ToString();
    }

    public void TakeDamage(float damageDealt)
    {
        health -= damageDealt;
        SetHealthAmount();

        if(health <= 0)
        {
            Death();
        }
    }

    void ResetKTimer()
    {
        rb.isKinematic = true;
        kinematicTimer = kTimeReset;
    }

    public void Death()
    {
        Time.timeScale = 0;
    }
}
