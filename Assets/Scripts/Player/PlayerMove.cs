using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerMove : MonoBehaviour
{
    
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float walkSpeed=6f;
    private float currentSpeed;
    [SerializeField] private float jump = 5f;
    [SerializeField] private float crouchHeight = 2f;
   
   
    public float mouseSensitivity = 100f;
    public Transform player;
    float xOnRotation;

    PlayerHealth playerHP;
    private CharacterController m_characterController;
   
    private Vector3 move_Direction;

   
    public bool canClimb = false;
    public float speed = 2;
    public GameObject ladderUI;

    public bool isJumping = false;
    public float m_gravity = 9f;

    private float m_vertical_Velocity;


    private float m_OriginalHeight;

    private bool m_Crouch = false;

    private bool isMoving = false;
    public GameObject isStanding;
    public GameObject isSitting;

    public Slider staminaBar;
    public float currentStamina;
    public float maxStamina = 100f;
    public float staminaLoss ;

    public float changeVolume;
  // private AudioSource _audioSource;
  // public AudioClip _jump;
  // public AudioClip _walking;
  // public AudioClip _running;
  // 

    private void Start()
    {
        //_audioSource = GetComponent<AudioSource>();
        m_characterController = GetComponent<CharacterController>();
        playerHP = GetComponent<PlayerHealth>();
        currentSpeed = walkSpeed;
        m_OriginalHeight = m_characterController.height;
        isStanding.SetActive(true);
        isSitting.SetActive(false);
        currentStamina = maxStamina;
        player = GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
        ladderUI.SetActive(false);
       
    }


    private void Update()
    {
        Run();
        Jump();
        AddValue();

        if (Input.GetKeyDown(KeyCode.C))
        {

            m_Crouch = !m_Crouch;

            checkCrouch();
        }


    
    }



    void FixedUpdate()
    {
        WalkingSound();
        Gravity();
        Move();
        
        //  if (Input.GetKeyDown(KeyCode.LeftShift) && !m_Crouch && isMoving)
        //  {
        //     
        //
        //      currentSpeed = runSpeed;
        //      
        //      
        //  }
        //  
        // else if (Input.GetKeyUp(KeyCode.LeftShift))
        // {
        //     currentSpeed = walkSpeed;
        // }

        move_Direction.y += m_gravity * Time.deltaTime;
       m_characterController.Move(move_Direction * Time.deltaTime);

        if (playerHP.currentHealth <= 0)
        {
           transform.Rotate(0, -1*Time.deltaTime, -1);
            m_characterController.enabled = false;
           //transform.Rotate(Vector3.up, 20f * Time.deltaTime);
        }

      if (canClimb)
      {
            if (Input.GetKey(KeyCode.U))
            {


                
                _walkSound.Stop();
                player.Translate(new Vector3(0, 10, 0) * Time.deltaTime * speed);
                m_gravity = 0;


            }
           
             
           
      }
           
       
            
      




    }


    private void OnTriggerEnter(Collider ladder)
    {
        if (ladder.gameObject.tag == "Ladder")
        {
             
           
            canClimb = true;
            ladderUI.SetActive(true);
           // player.transform.position= (Vector3.down * Time.deltaTime * speed);
            //  playerMovee.m_gravity = 0f;
           //player.Translate= (new Vector3(0,- 0.5f, 0) * Time.deltaTime * speed);
        }
       // if (canClimb)
       //     m_gravity = 0;

    }

    private void OnTriggerExit(Collider ladder)
    {

        if (ladder.gameObject.tag == "Ladder")
        {
           

            canClimb = false;
            m_gravity = 9f;

            ladderUI.SetActive(false);

        }
    }
    void Move()
    {
       move_Direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        move_Direction = transform.TransformDirection(move_Direction).normalized;

        move_Direction *= currentSpeed * Time.deltaTime;
       
        Gravity();


        


       if ( m_characterController.Move(move_Direction)!=0)
       {
          
           isMoving = true;
           
     
       }
      
       else
       {
         isMoving = false;
           
       }
          
       
      
      

    }

    public void Gravity()
    {
        if(m_characterController.isGrounded)
        {
            m_vertical_Velocity -= m_gravity * Time.deltaTime;

            Jump();
            
        }
        else
        {
            m_vertical_Velocity -= m_gravity * Time.deltaTime;
        }
        move_Direction.y = m_vertical_Velocity*Time.deltaTime;
    }

   void Jump()
   {
        if (m_characterController.isGrounded && Input.GetKeyDown(KeyCode.Space)) 
       {
           
           m_vertical_Velocity = jump;
            _jumpSound.Play();
       }
        else
        {
           
        }


   }
       void checkCrouch()
      {
          if (m_Crouch == true)
          {
              m_characterController.height -= crouchHeight;
              isSitting.SetActive(true);
              isStanding.SetActive(false);
          }
          else
          {
              m_characterController.height = m_OriginalHeight;
             isStanding.SetActive(true);
             isSitting.SetActive(false);
          }
      }
   

    void Run()
    {


        
        if (Input.GetKey(KeyCode.LeftShift) && !m_Crouch && isMoving)
        {


            currentSpeed = runSpeed;
            currentStamina -= staminaLoss * Time.deltaTime;
            staminaBar.value = currentStamina;
            if (currentStamina <= 0)
            {
                currentStamina = 0;
               currentSpeed = walkSpeed;
            }
            

        }

        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            currentSpeed = walkSpeed;
            // InvokeRepeating("AddValue", 2, 1);
           // Invoke("AddValue", 0.3f);
           // AddValue();

        }

     //   if (currentStamina > 100)
     //   {
     //
     //       currentStamina = 100;
     //   }
        //staminaBar.value = currentStamina;
       // currentStamina = Mathf.Lerp(currentStamina, staminaBar.value, 0.2f * Time.deltaTime);
        //staminaBar.value = currentStamina;

        staminaBar.value = Mathf.Lerp(staminaBar.value, currentStamina, 6f * Time.deltaTime);
        
    }

    void AddValue()
    {
        if (!Input.GetKey(KeyCode.LeftShift))
            currentStamina += 10f * Time.deltaTime;

        if (currentStamina > 100)
        {

            currentStamina = 100;
        }
    }






    //  void Crouching()
    //  {
    //      if (Input.GetKey(KeyCode.C))
    //      {
    //          transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1, 0.6f, 1), Time.deltaTime*15 );
    //      }
    //      else
    //      {
    //          transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1, 1, 1), Time.deltaTime *15);
    //
    //      }
    //  }
    //




    void WalkingSound()
    {
        if (_walkSound && run_sound)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetButton("Horizontal"))
            { //for walk sounsd using this because suraface is not straigh			


                //				print ("unutra sam");
                if (currentSpeed == 6)
                {
                    //	print ("tu sem");
                    if (!_walkSound.isPlaying)
                    {
                        //	print ("playam hod");
                        _walkSound.Play();
                        _walkSound.volume = changeVolume;
                        run_sound.Stop();
                    }
                }
                else if (currentSpeed == 12)
                {
                    //	print ("NE tu sem");

                    if (!run_sound.isPlaying)
                    {
                        _walkSound.Stop();
                        run_sound.Play();
                    }
                }


                else
                {
                    _walkSound.Stop();
                    run_sound.Stop();
                }





            }


            else
            {
                _walkSound.Stop();
                run_sound.Stop();
            }
        }
        else
        {
            print("Missing walk and running sounds.");
        }

    }


   
    [Header("Player SOUNDS")]
    [Tooltip("Jump sound when player jumps.")]
    public AudioSource _jumpSound;
    [Tooltip("Walk sound player makes.")]
    public AudioSource _walkSound;
    [Tooltip("Run Sound player makes.")]
    public AudioSource run_sound;
   




}


































