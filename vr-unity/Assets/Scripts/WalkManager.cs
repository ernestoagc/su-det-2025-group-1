using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkManager : MonoBehaviour
{
    public float speed = 0.5f;
    private Animator playerAnim;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.enableWalk)
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
        WaitTransitation();
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public void StopWalking()
    {
        speed = 0f;
        playerAnim.SetFloat("f_speed", speed);
        WaitTransitation();
    }
    
    
    public void WaitTransitation()
    {
        StartCoroutine(SomeCoroutine());
    }

    private IEnumerator SomeCoroutine()
    {
        yield return new WaitForSeconds (2);
    }
    
}
