using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class StageSelectMng : MonoBehaviour
{
    public Sprite[] stageSelectImg=null;
    public Sprite[] stageSelectSprite = null;
    public List<GameObject> bgPrbList=null;
    [HideInInspector]
    public GameObject bgImgPrb = null;
    [HideInInspector]
    public GameObject canvas=null;
    public float selectPlayTime=2;
    bool Delay = false;
    public int selectStageNum=0;
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
    public void Start()
    {
        LoadStageData();
    }
    public void LoadStageData()
    {
        foreach (var num in bgPrbList)
        {
            for (int i = 0; i < 5; i++)
            {
                StageSceleBtnStateEnum clearstate = num.GetComponent<StageSelectBtn>().stageSelectBtn[i].GetComponent<StageSelectBtnState>().clearstate;
                if (clearstate == StageSceleBtnStateEnum.NotClear)
                    num.GetComponent<StageSelectBtn>().stageSelectBtn[i].GetComponent<Image>().sprite = stageSelectSprite[10];
            }
        }
    }
    public void Arrow(int arrow_dir)
    {
        if(!Delay)
        StartCoroutine("MoveStage",arrow_dir);
    }
    public IEnumerator MoveStage(int dir)
    {
        if (bgPrbList.Count < selectStageNum || bgPrbList.Count >= 0)
        {
            Delay = true;
            foreach (var num in bgPrbList)
                num.transform.DOMoveX(num.transform.position.x + 310 * dir, selectPlayTime);
            selectStageNum+=dir;
            yield return new WaitForSeconds(selectPlayTime);
            Delay = false;
        yield return null;
        }
    }

}
