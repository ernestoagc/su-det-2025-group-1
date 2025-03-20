using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkManager : MonoBehaviour
{
    public float speed = 0.5f;
    private Animator playerAnim;
    private bool enableWalk;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.enableWalk)
        {
            StartWalking();
        }
        else
        {
            StopWalking();
        }

    }
    
    private void OnCollisionEnter(Collision other)
    {
       if (!other.gameObject.CompareTag("Ground"))
       {
           ChangeWalkingRotation();
       }
    }

    public void ChangeWalkingRotation()
    {
       transform.Rotate(0 , 50f ,0);
    }

    public void StartWalking()
    {
        speed = 0.5f;
        playerAnim.SetFloat("f_speed", speed);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public void StopWalking()
    {
        speed = 0f;
        playerAnim.SetFloat("f_speed", speed);
    }
    
    public void ChangeWalkingMode()
    {
        speed = 0f;
        playerAnim.SetFloat("f_speed", speed);
    }
}
