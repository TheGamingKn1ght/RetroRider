using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IChannel
{
    public Rigidbody rb;
    Vector3 playerPos;
    Vector3 startingPos;

    public static RigidbodyConstraints OGconstraints;

    public bool powerActive = false;
    [SerializeField] public Transform orientationCam;
    [SerializeField] public GameObject FollowTarget;
    public float boostMultiplier = 1f;
    public float puddleMultiplier = 1f;

    [SerializeField] private float lerpSpeed = 0.5f;
    [SerializeField] public int moveSpeed = 2;
    [SerializeField] private int jumpMultiplier = 200;
    float time;

    [SerializeField] public List<GameObject> DamageableObjects = new List<GameObject>();
    [SerializeField] private GameObject Explosions;

    #region Singleton
    public static PlayerController Singleton;

    public void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    private void OnEnable()
    {
        ActivateMovement();
    }

    private void OnDisable()
    {
        DeactivateMovement();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        OGconstraints = rb.constraints;
        playerPos = rb.transform.position;
        startingPos = rb.transform.position;
        HealthSystem.Singleton.AddObserver(this);
        //newPos = new Vector3(rb.position.x, rb.position.y, rb.position.z);
    }

    private void Update()
    {
        //Get player position and lock it horizontally to the map
        CalculateTimePassed();

        Vector3 movement = orientationCam.transform.forward * moveSpeed * GetTimeMultiplier() * boostMultiplier * puddleMultiplier;
        movement.y = rb.velocity.y;
        rb.velocity = movement;

        //Debug.Log(GetTimeMultiplier());
        float tempF = Mathf.Lerp(rb.position.x, playerPos.x, lerpSpeed);
        rb.position = new Vector3(tempF, rb.position.y, rb.position.z);
    }

    public void Updates(int health)
    {
        if (health <= 0)
        {
            Death();
        }
    }

    private float GetTimeMultiplier()
    {
        float result;
        if (time < 45)
        {
            result = time / 10;
            if (result < 1)
            {
                return 1;
            }
        }
        else
        {
            if (time < 65)
            {
                result = 2.25f + time / 20;
                lerpSpeed = 0.035f;
            }
            else
            {
                result = 3.33f + time / 30;
                lerpSpeed = 0.04f;
            }
        }

        if (result > 7)
        {
            lerpSpeed = 0.05f;
            return 7;
        }

        return result;
    }
    public float CalculateTimePassed()
    {
        time = Time.time;
        return time;
    }

    private void MoveLeft()
    {
        if (playerPos.x - 14 < startingPos.x - 16)
        {
            return;
        }
        else
        {
            playerPos.x -= 14;
            //rb.MovePosition(playerPos);
        }
    }

    private void MoveRight()
    {
        if(playerPos.x + 14 > startingPos.x + 16)
        {
            return;
        }
        else
        {
            playerPos.x += 14;
            //rb.MovePosition(playerPos);
        }
    }

    private void Jump()
    {
        if (JumpBar.Singleton.barFull)
        {
            //Jump
            rb.constraints -= RigidbodyConstraints.FreezePositionY;
            AudioManager.instance.PlaySFX("JumpBoost");
            this.GetComponent<Animator>().Play("JumpAnimation");
            rb.AddForce(rb.transform.up * jumpMultiplier, ForceMode.Impulse);
            JumpBar.Singleton.AddPower(-100);
        }
    }

    private void Death()
    {
        FollowTarget.transform.parent = null;

        DeactivateMovement();

        rb.constraints -= RigidbodyConstraints.None;

        Destroy(this.transform.Find("Collider").gameObject);

        Explosions.SetActive(true);
        
    }

    public void ActivateMovement()
    {
        InputManager.OnLeftInput += MoveLeft;
        InputManager.OnRightInput += MoveRight;
        InputManager.OnJumpInput += Jump;
    }

    public void DeactivateMovement()
    {
        InputManager.OnLeftInput -= MoveLeft;
        InputManager.OnRightInput -= MoveRight;
        InputManager.OnJumpInput -= Jump;
    }
}
