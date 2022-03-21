using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    /// <summary>
    /// Décrit si l'entité est invulnérable
    /// </summary>
    private bool _invulnerable = false;
    /// <summary>
    /// Réfère à l'animator du GO
    /// </summary>
    private Animator _animator;
    /// <summary>
    /// Représente le moment où l'invulnaribilité a commencé
    /// </summary>
    private float _tempsDebutInvulnerabilite;

    private void Start()
    {
        _animator = this.gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Time.fixedTime > _tempsDebutInvulnerabilite + SnakeEnnemyBehaviour.DelaisInvulnerabilite && Time.fixedTime > _tempsDebutInvulnerabilite + BatEnnemyBehaviour.DelaisInvulnerabilite)
            _invulnerable = false;
    }

    public void CallEnnemyCollision()
    {
        if (!_invulnerable)
        {
            _animator.SetTrigger("DegatActif");
            GameManager.Instance.PlayerData.DecrEnergie();
            _tempsDebutInvulnerabilite = Time.fixedTime;
            _invulnerable = true;
        }
    }

    public void CallNewHat(Sprite sp) 
    {
        GameObject player_hat = this.gameObject.transform.GetChild(0).gameObject;
        player_hat.GetComponent<SpriteRenderer>().sprite = sp;
        player_hat.transform.localScale = new Vector3((float)0.12, (float)0.12, (float)0);
        player_hat.transform.localPosition = new Vector3((float)0.2, (float)0.3, (float)0.1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tilemap Water"))
        {
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            GameObject.Destroy(this.gameObject);
            GameManager.Instance.PlayerData.DecrVie();
        }
    }
}
