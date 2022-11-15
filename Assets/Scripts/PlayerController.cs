using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool playerCreated;

    public float speed = 5.0f;
    public const string HORIZONTAL = "Horizontal", VERTICAL = "Vertical";
    private float inputTol = 0.2f; // Tol es lo mucho que presionas la tecla. La tolerancia va del 0 a uno
    private float xInput, YInput;
   
    public bool canMove = true;

    private bool isWalking;
    private bool isTalking;
    public Vector2 lastDirection;
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    public string nextUuid;

    public AudioClip Speak;
    private AudioSource playerAudioSource;

    private bool isAttacking;
    [SerializeField] private float attackTime;
    private float attackTimeCounter;
    // Start is called before the first frame update
    void Start()
    {
        playerCreated = true;
        playerAudioSource = GetComponent<AudioSource>();
        lastDirection = Vector2.down;
    }
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw(HORIZONTAL);
        isWalking = false;
        if (!canMove)
        {
            return;
        }
        if (isAttacking)
        {
            attackTimeCounter -= Time.deltaTime;
            if (attackTimeCounter < 0)
            {
                isAttacking = false;
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            isAttacking = true;
            attackTimeCounter = attackTime;
        }
        isTalking = false;
        //Horizontal Movement
        if (Mathf.Abs(xInput) > inputTol)
        {
            _rigidbody.velocity = new Vector2(xInput * speed,0);
           // Vector3 translation = new Vector3(xInput * speed * Time.deltaTime, 0, 0);
            //transform.Translate(translation);
            isWalking = true;
            lastDirection = new Vector2(xInput, 0);
        }

        YInput = Input.GetAxisRaw(VERTICAL);
        if (Mathf.Abs(YInput) > inputTol)
        {
            _rigidbody.velocity = new Vector2(0, YInput * speed);
            //Vector3 translation = new Vector3(0,YInput * speed * Time.deltaTime, 0);
           // transform.Translate(translation);
            isWalking = true;
            lastDirection = new Vector2(0, YInput);
        }
       if (Input.GetKeyUp(KeyCode.Space))
        {
            playerAudioSource.Stop();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            isTalking = true;
            playerAudioSource.PlayOneShot(Speak, 1);
        } 
            
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 7;
            _animator.speed = 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 5;
            _animator.speed = 1;
        }
    }

    private void LateUpdate()
    {
        _animator.SetFloat(HORIZONTAL, xInput);
        _animator.SetFloat(VERTICAL, YInput);
        _animator.SetFloat("LastHorizontal", lastDirection.x);
        _animator.SetFloat("LastVertical", lastDirection.y);
        _animator.SetBool("IsWalking", isWalking);
        _animator.SetBool("IsTalking", isTalking);
        _animator.SetBool("IsAttacking", isAttacking);

        if (!isWalking|| isAttacking)
        {
            _rigidbody.velocity = Vector2.zero;
        }
            
    }
}
