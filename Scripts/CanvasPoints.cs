using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasPoints : MonoBehaviour
{
    bool site;
    bool a;
    TextMeshProUGUI canvasText;
    void Start()
    {
        canvasText = gameObject.GetComponents<TextMeshProUGUI>()[0];
        new WaitForEndOfFrame();
        switch (gameObject.name)
        {
            case "AC_Points":
                site = true;
                canvasText.text = $" Anti cuerpo {(Static.playerBloodType.Contains('A') ? 'B' : 'A' )} : {Static.scores[0]}";
                    break;
            case "AR_Points": 
                site = false;
                canvasText.text = $" Anti cuerpo Rh : {Static.scores[1]}";
                break;
            case "BloodType":
                a = true;
                canvasText.text = $"Tipo de sangre: {Static.playerBloodType}";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        new WaitForEndOfFrame();
        if (a) return;
        if (site) { 
            canvasText.text = $" Anti cuerpo {(Static.playerBloodType.Contains('A') ? 'B' : 'A' )} : {Static.scores[0]}";
            return;
        }
        canvasText.text = $" Anti cuerpo Rh : {Static.scores[1]}";
    }
}
