using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectMng : MonoBehaviour
{
    public Sprite[] stageSelectImg=null;
    int arrow_dir=0;
    public Image bgImg = null;
    public GameObject bgImgPrb=null;
    public List<GameObject> bgPrbList=null;
    public GameObject canvas=null;
    public void Awake()
    {
        stageSelectImg=Resources.LoadAll<Sprite>("StageMapImg");
        foreach(var num in stageSelectImg)
        {
           GameObject bgPrb= Instantiate(bgImgPrb, Vector3.zero,Quaternion.identity, canvas.transform);
           bgPrbList.Add(bgPrb);
        }
    }
    public void Arrow()
    {
        
    }
}
