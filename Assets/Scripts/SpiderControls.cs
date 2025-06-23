using UnityEngine;

public class SpiderControls : MonoBehaviour
{

    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("Taunt", 2f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void Taunt()
    {
        animator.SetTrigger("Taunt");
    }
}
