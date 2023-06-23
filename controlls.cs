using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;


public class controlls : MonoBehaviour
{
    
    [SerializeField]
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            animator.SetTrigger("attack_sword");
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            animator.SetTrigger("attack_spell");
        }
    }


    void CoolDownTime() 
    {
    
    }
}
