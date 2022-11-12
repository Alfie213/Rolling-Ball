using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        gameManager.FinishGame();
    }
}
