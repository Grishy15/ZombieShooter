using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChar : MonoBehaviour
{
    private AnimChar anim;
    private Rigidbody2D rbChar;
    private Transform trChar;
    public Transform startPoint;
    private PivotWeaponRotate wTurn;

    public float speedMove = 8;
    public float jumpForce = 8;
    public float slideSpeed = 20;
    private float inputX;
    private float timer;

    private bool isTerra = false;
    private bool isSlide = false;

    void Awake()
    {
        rbChar = GetComponent<Rigidbody2D>();
        anim = GetComponent<AnimChar>();
        trChar = GetComponent<Transform>();
        wTurn = GetComponentInChildren<PivotWeaponRotate>();
    }
    void Update()
    {
        Jumping();
        Slide();
        if(isTerra)
            {
                SlideToggle();
            }
    }
    void FixedUpdate()
    {
        Moving();
    }
    void Moving()
    {
        inputX = Input.GetAxis("Horizontal");
        float y = rbChar.velocity.y;
        rbChar.velocity = new Vector2(inputX * speedMove,y);
        anim.MoveAnim(inputX);
        Turning(inputX);
        wTurn.RotateWeapon(inputX);
    }
    void Jumping()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isTerra)
        {
            rbChar.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            anim.JumpAnim(true);
        }
        else
        {
            anim.JumpAnim(false);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        isTerra = true;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        isTerra = false;
    }
   private void Slide()
    {
        timer -= Time.deltaTime;
        isSlide = timer <= 0 ? false : true;
        anim.SlideAnim(isSlide);
        if (isSlide)
        {
            float slideDirection = Mathf.Sign(trChar.localScale.x); 
            Vector3 target = trChar.position + new Vector3(2 * slideDirection, 0, 0);
            trChar.position = Vector3.MoveTowards(trChar.position, target, slideSpeed * Time.deltaTime); 
        } 
    }
    void SlideToggle()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                isSlide = true;
                timer = 0.6f;
            }
    }
    void Turning(float inputX)
    {
        if(inputX < 0)
        {
            trChar.localScale = new Vector3(-1, 1, 1);
            startPoint.rotation = Quaternion.Euler(0, 180, 0);
        }

        else if (inputX > 0)
        {
            trChar.localScale = new Vector3(1, 1, 1);
            startPoint.rotation = Quaternion.Euler(0, 0, 0);
        }

    }
}
