using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hats : MonoBehaviour
{
    [SerializeField]
    private string hat_name;

    [SerializeField]
    private Sprite normal_sprite;
    [SerializeField]
    private Sprite empty_sprite;

    private bool taken = false;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.PlayerData.AvoirDecouverteChapeau(this.hat_name))
           this.gameObject.GetComponent<SpriteRenderer>().sprite = this.empty_sprite;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") &&  (GameManager.Instance.PlayerData.AvoirDecouverteChapeau(this.hat_name)))
        {

            PlayerBehaviour pb = collision.gameObject.GetComponent<PlayerBehaviour>();
            pb.CallNewHat(this.normal_sprite);
            this.taken = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = this.empty_sprite;

            GameManager.Instance.PlayerData.AjouterChapeauTrouver(this.hat_name);
        }
    }
}
