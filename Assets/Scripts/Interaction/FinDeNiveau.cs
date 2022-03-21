using UnityEngine;
using UnityEngine.SceneManagement;

public class FinDeNiveau : MonoBehaviour
{
    [SerializeField]
    private string next;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Félicitation, le niveau est terminé.");
            GameManager.Instance.PlayerData.IncrNiveau();
            GameManager.Instance.SaveData();
            SceneManager.LoadScene(this.next);
            
        }
    }
}
