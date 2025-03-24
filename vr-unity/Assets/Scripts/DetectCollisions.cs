using UnityEngine;
using UnityEngine.SceneManagement;
public class DetectCollisions : MonoBehaviour
{   
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }
    
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("======OnCollisionEnter: "+ other.gameObject.tag);
        
        if (other.gameObject.CompareTag("Person"))
        {   
            GameManager.Instance.SendVibration();
            GameManager.Instance.SendVibrationRight();
          
        }
    }
}