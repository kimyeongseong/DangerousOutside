using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum StageSceleBtnStateEnum
{
    Clear,
    NotClear
}
public class StageSelectBtnState : MonoBehaviour
{
    
    public int StageClear=0;
    public StageSceleBtnStateEnum clearstate = StageSceleBtnStateEnum.NotClear;
    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(GameStart);
    }
    public void GameStart()
    {
        SceneManager.LoadScene(2);
    }
}
