using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressBarCircleType : MonoBehaviour {

    public Transform LoadingBar;
    public Transform TextIndicator;
    public Transform TextLoading;

    
    public Color Color_State1;
    
    public Color Color_State2;
   
    public Color Color_State3;
    
    public Color Color_State4;
   
    [SerializeField]
    private float currentAmount;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float speed_State2;
    [SerializeField]
    private float speed_State3;
    [SerializeField]
    private float speed_State4;

   


	// Use this for initialization
	void Start () {
        currentAmount = 100;
        TextLoading.GetComponent<Text>().text = "Playing";
        TextLoading.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	    if(currentAmount > 0)
        {
            currentAmount -= speed * Time.deltaTime;
            TextIndicator.GetComponent<Text>().text = ((int)currentAmount).ToString();

            if(currentAmount>75)
            {
                LoadingBar.GetComponent<Image>().color = Color_State1;
                TextLoading.GetComponent<Text>().text = "Escape!";
            }
            else if(currentAmount>50)
            {
                LoadingBar.GetComponent<Image>().color = Color_State2;
                TextLoading.GetComponent<Text>().text = "Warning";
                speed = speed_State2;
            }
            else if(currentAmount>25)
            {
                LoadingBar.GetComponent<Image>().color = Color_State3;
                speed = speed_State3;
            }
            else
            {
                LoadingBar.GetComponent<Image>().color = Color_State4;
                TextLoading.GetComponent<Text>().text = "Hurry!!!";
                speed = speed_State4;
                
            }
        }
        else
        {
            TextLoading.gameObject.SetActive(false);
            TextIndicator.GetComponent<Text>().text = "Game Over...";
            TextIndicator.GetComponent<Text>().fontSize = 35;
            CallSubFunction();
        }
        LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
	}


    void CallSubFunction()
    {

    }
}
