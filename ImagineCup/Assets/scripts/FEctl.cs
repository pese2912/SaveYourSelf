using UnityEngine;
using System.Collections;

public class FEctl : MonoBehaviour {

    public enum FEstate{zero, first, second, third, forth, fifth, last};
    private Animator animator;
    public FEstate festate;

    public GameObject Clip;
    public GameObject Line;

    public bool isOperateState;
    public bool isObjectSelected;
    public bool isSwitchON;
    public bool isLineUp;

    [HideInInspector]
    public bool selectedClip;

    [HideInInspector]
    public bool selectedLine;

    [HideInInspector]
    public bool selectedLineDown;

    [HideInInspector]
    public bool selectedButton;

    [HideInInspector]
    public bool selectedButtonDown;

    [HideInInspector]
    public bool readySelectClip;

	// Use this for initialization
	void Start () {
        isOperateState = false;
        isObjectSelected = false;
        isSwitchON = false;
        isLineUp = false;

        animator = gameObject.GetComponent<Animator>();
        festate = FEstate.zero;
        readySelectClip = false;
        selectedClip = false;
        selectedLine = false;
        selectedLineDown = false;
        selectedButton = false;
        selectedButtonDown = false;

        //Clip.SetActive(false);
        StartCoroutine(this.CheckFEState());
        StartCoroutine(this.FEAction());
	}
	
	// Update is called once per frame
	void Update () {
        
        //print(festate);
	}

    IEnumerator CheckFEState()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.2f);
           
            if(selectedButtonDown) 
            {
                festate = FEstate.fifth;
            }
            else if(selectedButton)
            {
                festate = FEstate.last;
            }
            else if(selectedLineDown)
            {
                festate = FEstate.forth;
            }
            else if (selectedLine)
            {
                isLineUp = true;
                festate = FEstate.third;
            }
            else if (selectedClip)
            {

                festate = FEstate.second;
            }
        }
    }

    IEnumerator FEAction()
    {
        while (true)
        {
            switch (festate)
            {
                case FEstate.zero : //초기
                    if (isOperateState)
                        festate = FEstate.first;
                    break;
                case FEstate.first: // 물체 선택
                    readySelectClip = true;
                    break;
                case FEstate.second: // 핀 뽑음
                    readySelectClip = false;
                    animator.SetBool("selectClip", true);
                    selectedClip = true;
                    break;
                case FEstate.third: // 호스 클릭
                    animator.SetBool("downLine", false);
                    animator.SetBool("selectClip", false);
                    animator.SetBool("setLine", true);
                    break;

                case FEstate.forth: //호스 다운
                    animator.SetBool("setLine", false);
                    animator.SetBool("downLine", true);
                    animator.SetBool("selectClip", true);
                    break;
                case FEstate.fifth: // 손잡이 다운
                    animator.SetBool("selectButton", false);
                    animator.SetBool("downLine", false);
                    animator.SetBool("selectClip", false);
                    animator.SetBool("buttonOff", true);
                    break;
                case FEstate.last: //손잡이 클릭
                    animator.SetBool("buttonOff", false);
                    animator.SetBool("selectButton", true);
                    
                    break;
            }

            yield return null;
        }
    }


}
