using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject triggerBox;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        triggerBox.SetActive(false); //set active after 5 objects are collected
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("open", true);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("open", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("open", true);
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("open", false); 
    }
}
