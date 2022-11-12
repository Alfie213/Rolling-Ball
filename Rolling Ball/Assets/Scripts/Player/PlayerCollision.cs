using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            GetComponent<PlayerLogic>().enabled = false;
            Debug.Log("We hit obstacle");
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
