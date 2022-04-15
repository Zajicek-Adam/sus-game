using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Enter()
    {
        animator.SetBool("mouseOver", true);
        animator.SetBool("mouseExit", false);
    }
    public void Exit()
    {
        animator.SetBool("mouseOver", false);
        animator.SetBool("mouseExit", true);
    }
}
