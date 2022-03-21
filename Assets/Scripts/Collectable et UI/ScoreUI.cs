using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreUI : MonoBehaviour
{
    /// <summary>
    /// Référence à la composante TextMesh du GO
    /// </summary>
    private TextMeshProUGUI _text;
    
    void Start()
    {
        _text = this.gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        Debug.Log(GameManager.Instance);
        Debug.Log(GameManager.Instance.PlayerData);
        Debug.Log(GameManager.Instance.PlayerData.Score);
        _text.text = GameManager.Instance.PlayerData.Score.ToString();
    }
}
