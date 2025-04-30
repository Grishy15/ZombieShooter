using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimChar : MonoBehaviour
{
    private Animator charAnim;
    
    private void Awake()
    {
        charAnim = GetComponent<Animator>();
    }
    
    public void MoveAnim(float horizontal)
    {
        charAnim.SetFloat("MoveX", Mathf.Abs(horizontal));
    }

    public void SlideAnim(bool isSlide)
    {
        charAnim.SetBool("IsSliding", isSlide);
    }

    public void DeadAnim()
    {

    }
    
    public void JumpAnim(bool isJump)
    {
        charAnim.SetBool("IsJump", isJump);
    }
}