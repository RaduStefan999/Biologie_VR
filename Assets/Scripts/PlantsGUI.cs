using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantsGUI : MonoBehaviour
{
    [SerializeField]
    public Button[] plantButons;
    
    [SerializeField]
    public TextMeshProUGUI DisplayedTitle;
    
    [SerializeField]
    public TextMeshProUGUI DisplayedText;
    
    [SerializeField]
    public RawImage DisplayedImage;
    public RawImage DisplayedSchema;
    public GameObject InfoArea;
    public RectTransform ViewPort;
    public LessonInfo Info;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < plantButons.Length; i++) {

            int index = i;

            plantButons[i].onClick.AddListener(() => {

                DisplayedTitle.text = Info.plantElements[index].Name;
                DisplayedText.text = Info.plantElements[index].Information;
                DisplayedImage.texture = Info.plantElements[index].Image;
                DisplayedSchema.texture = Info.plantElements[index].Schema;
                ViewPort.sizeDelta = new Vector2 (ViewPort.sizeDelta.x, Info.plantElements[index].Height);;

                if (!InfoArea.activeSelf) {
                    InfoArea.SetActive(true);
                } 
            });
        }
    }
}
