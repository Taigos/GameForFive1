using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //кусок колбасы
    private Transform PlayerPosition;
    public GameObject player;
    public float speed = 2f;
    public Vector2 jampForce = new Vector2(0, 20);
    public Rigidbody2D rb;
    private Vector3 RawMove;
    bool is_ground;
    bool inAir;
    private bool stop = false;
    public GameObject prefab;
    float x = -2.5f;

    //private List<Sprite> Forms {assets.Sprits}
    public Sprite Form1;
    public Sprite Form2;
    public Sprite Form3;
    private int Form = 2;
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Kusok", 0, 2);
    }
    void Kusok()
    {
         if (!stop)
        {
            Instantiate(prefab, new Vector3(x, -1f, 0), Quaternion.identity);
            if (x == -2.5f)
                x = -3f;
            else
                x = -2.5f;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerPosition = GameObject.FindWithTag("Player");
        //float h = Input.GetAxis("Horizontal");
        //Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        //RawMove = moveInput.normalized * speed;
        //player.transform.position = new Vector3(player.transform.position.x + h * speed, player.transform.position.y, player.transform.position.z);
        //switch ()
    }
    private void FixedUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.W))
        //    player.transform.position
        player.transform.position += new Vector3(Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime, 0, 0); //player.transform.position + RawMove * Time.fixedDeltaTime;
        //if (Input.GetKey(KeyCode.W) && !inAir)
        //{
        //    inAir = true;
        //    rb.AddForce(jampForce);
        //}
        if (Input.GetKeyDown(KeyCode.W) && is_ground)
        {
            rb.AddForce(jampForce);
            print("Должен прыгнуть");
        }
        if (Input.GetKeyDown(KeyCode.W) && !is_ground)
            print("Воздух");
        if (Input.GetKeyUp(KeyCode.Q))
        {
            stop = !stop;
        }
        //Смена формы
        if (Input.GetKeyUp(KeyCode.Alpha1) && Form !=1)
        {
            Form = 1;
            player.GetComponent<SpriteRenderer>().sprite = Form1;
            
        }
        if (Input.GetKeyUp(KeyCode.Alpha2) && Form != 2)
        {
            Form = 2;
            player.GetComponent<SpriteRenderer>().sprite = Form2;
            
        }
        if (Input.GetKeyUp(KeyCode.Alpha3) && Form != 3)
        {
            Form = 3;
            player.GetComponent<SpriteRenderer>().sprite = Form3;
            
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
    //        inAir = false;
    //}
    void OnTriggerStay2D(Collider2D col)
    {               //если в тригере что то есть и у обьекта тег "ground"
        if (col.tag == "Ground") is_ground = true;      //то включаем переменную "на земле"
        //print("Земля");
    }
    void OnTriggerExit2D(Collider2D col)
    {              //если из триггера что то вышло и у обьекта тег "ground"
        if (col.tag == "Ground") is_ground = false;     //то вЫключаем переменную "на земле"
        print("Где ?!");
    }

    //Методы для пустышки
    public void Enter()
    {
        if (Form == 3)
        {
            //player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            print("Тело не обычное");
        }
    }
    public void Exit()
    {
        if (Form == 3)
        {
            //player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            print("Тело обычное");
        }
    }
}
