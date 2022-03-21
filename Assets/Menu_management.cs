using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Menu_management : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Transform pnj = this.gameObject.transform.Find("PanelJouer");
        Transform pnc = this.gameObject.transform.Find("PanelCollectables");
        
        for (int i = 0; i < pnj.GetChild(1).childCount -1; i++)
        { pnj.GetChild(1).GetChild(i).GetComponent<Button>().interactable = false; }

           //remplacer 1 par GameManager.Instance.PlayerData.Niveau mais la sauvegarde marche pas bien
        for (int i = 0; i < 1; i++)
        { pnj.GetChild(1).GetChild(i).GetComponent<Button>().interactable = true; }
        string text = "";
        foreach (string hat in GameManager.Instance.PlayerData.ListeChapeauDecouverts)
        { text+= "vous avez le chapeau " + hat+"\n"; }
        pnc.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
