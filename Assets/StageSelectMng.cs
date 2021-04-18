using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectMng : MonoBehaviour
{
    public Sprite[] stageSelectImg=null;
    public Sprite[] stageSelectSprite = null;
    public List<GameObject> bgPrbList=null;
    [HideInInspector]
    public GameObject bgImgPrb = null;
    [HideInInspector]
    public GameObject canvas=null;
    public void Awake()
    {
        stageSelectImg=Resources.LoadAll<Sprite>("StageMapImg");
        stageSelectSprite = Resources.LoadAll<Sprite>("Stage_Stars_new");
        foreach (var num in stageSelectImg)
        {
            Vector3 canvasPos = new Vector3(canvas.transform.position.x + bgPrbList.Count* canvas.transform.position.x*2, canvas.transform.position.y, canvas.transform.position.z);
            GameObject bgImgInst= Instantiate(bgImgPrb, canvasPos, Quaternion.identity, canvas.transform);
            bgImgInst.GetComponent<Image>().sprite = num;
            bgPrbList.Add(bgImgInst);
        }
    }
    public void LoadStageData()
    {
        for (int i = 0; i <bgPrbList.Count;i++)
        {
           int clearNum= bgPrbList[i].GetComponent<StageSelectBtn>().stageSelectBtn[i].GetComponent<StageSelectBtnState>().StageClear;
            if(clearNum!=0)
            {//
                bgPrbList[i].GetComponent<StageSelectBtn>().stageSelectBtn[0].GetComponent<StageSelectBtnState>();
            }
        }
    }
    public void Arrow(int arrow_dir)
    {
        StartCoroutine("MoveStage",arrow_dir);
    }
    public IEnumerator MoveStage(int dir)
    {
        int Count = 0;
        Debug.Log(dir);
        while (Count<306)
        {
            foreach (var num in bgPrbList)
                num.transform.position = new Vector3(num.transform.position.x + 1 * dir, num.transform.position.y, num.transform.position.z);
            Count++;
            yield return null;
        }
    }

}
