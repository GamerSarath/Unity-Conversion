using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LuckyCards_HistoryItems : MonoBehaviour
{
  //  public TextMeshProUGUI itemtext;
  public static LuckyCards_HistoryItems Instance;
    public GameObject HistoryPrefabs;
    public RectTransform content;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   /* public void Storage(string value)
    {
        itemtext.text = value;
    }*/

    public void UpdateWinner(List<Sprite> spriteList)
    {
        foreach(Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }
        foreach(Sprite sprite in spriteList)
        {
            GameObject newImageGameObject = Instantiate(HistoryPrefabs, content);
            /*UnityEngine.UI.Image newImage = newImageGameObject.GetComponent<UnityEngine.UI.Image>();
            // newImage.sprite = sprite;*/
            SpriteRenderer newSprite = newImageGameObject.GetComponent<SpriteRenderer>();
            newSprite.sprite = sprite;



        }
    }

   
    
    
}
public class ResponseData
{

    public float balance;
    public int current_Time;
    public string player_Id;
    public string game_Id;
    public int win_Amount;


}
