using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectBtn : MonoBehaviour
{
    public GameObject[] stageSelectBtn = null;
    public Image silhouette;
    public Button[] arrow;
    public GameObject flash;
    public int stageClear;
    public void OnEnable()
    {
        foreach(var num in stageSelectBtn)
        {

            if (num.GetComponent<StageSelectBtnState>().clearstate == StageSceleBtnStateEnum.Clear)
            {
                if (stageClear>=4)
                {
                    silhouette.sprite = null;
                }
                else
                {
                    stageClear++;
                    silhouette.fillAmount -= 0.25f;
                }

            }
            else
                flash.GetComponent<RectTransform>().LookAt(num.gameObject.transform);
        }
    }
}
