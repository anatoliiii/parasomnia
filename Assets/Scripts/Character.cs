using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed = 3.0f;
    public float jumpforce = 0.5f;
    public bool OnChair;
    public float SpeedChair;
    public bool move;
    public Gun Gun;

    public Animator anim;

    public AudioSource[] CharacterSound; // нужно для включение параллельного звука 0-бег 1-прыжок 2-приземление
    public AudioClip[] ActionsSound; //сдесь находятся все нужные нам действия, работаю по одиночке, а не все сразу
    public List<string> ActionSoundsList;
    [SerializeField]
    private AudioSource ActionSoundsPlay;// включает звук определенного действия
    private bool CheckSoundDown = true;// нужно для звука падения
    private Rigidbody2D rigidbody2d;
    private bool IsGrounded = false;
    public Transform groundCheck;
    //радиус определения соприкосновения с землей
    private float groundRadius = 0.1f;
    //ссылка на слой, представляющий землю
    public LayerMask whatIsGround;


    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        move = true;
        anim = gameObject.GetComponent<Animator>();

    }
    private void Start()
    {
        Gun = Gun == null ? GetComponent<Gun>() : Gun;
    }
    private void Update()
    {
        if (Gun != null)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                Gun.NewGun();
            }
        }
    }

    private void FixedUpdate()
    {
        CheckGrund();
        if (IsGrounded && !Input.GetButton("Horizontal"))
        {
            anim.SetInteger("State", 0);
            CharacterSound[0].Stop();
        }
        if (rigidbody2d.velocity.y != 0)
        {
            anim.SetInteger("State", 1);
            CharacterSound[0].Stop();
            CheckSoundDown = false;
        }
    }

    private void CheckGrund()
    {
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        if (IsGrounded && !CheckSoundDown)
        {
            CharacterSound[2].Play();
            CheckSoundDown = true;
        }
        if (!IsGrounded)
            return;
    }

    public void Run(float _getAxisHorisontal)
    {
        if (move)
        {
            if (IsGrounded)
            {
                anim.SetInteger("State", 1);

                if (!CharacterSound[0].isPlaying && IsGrounded) CharacterSound[0].Play();
            }
            float moveX = _getAxisHorisontal;
            Vector3 direction = transform.right * _getAxisHorisontal;
            Vector2 scale = gameObject.transform.localScale;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
            if (moveX > 0)
            {
                if (scale.x < 0)
                {
                    scale.x = -scale.x;
                    gameObject.transform.localScale = scale;
                }
            }
            else if (moveX < 0)
            {
                if (scale.x > 0)
                {
                    scale.x = -scale.x;
                    gameObject.transform.localScale = scale;
                }
            }
        }


    }

    public void Chairs(float _getAxisVertical)
    {
        if (OnChair && move)
        {
            Vector3 direction = transform.up * _getAxisVertical;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, SpeedChair * Time.deltaTime);
        }
    }
    public void Jump()
    {
        if (IsGrounded && move)
        {
            anim.SetInteger("State", 1);
            CharacterSound[1].Play();
            Vector2 speedY = rigidbody2d.velocity;
            speedY.y = 0;
            rigidbody2d.velocity = speedY;
            rigidbody2d.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
        }
    }

    public void PlayAction(string action)
    {
        int actionId = ActionSoundsList.IndexOf(action);
        if (actionId != -1) ActionSoundsPlay.PlayOneShot(ActionsSound[actionId]); //проверяем есть ли такой звук
        else Debug.Log("Такого звука не найдено");
    }

}



