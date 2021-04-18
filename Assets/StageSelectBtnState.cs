using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectBtnState : MonoBehaviour
{
    public enum StageSceleBtnStateEnum
    {
        Clear,
        NotClear
    }
    public int StageClear=0;
    private void OnEnable()
    {
        Debug.Log("hello");
        GetComponent<Button>().onClick.AddListener(GameStart);
    }
    public void GameStart()
    {
        SceneManager.LoadScene(2);
    }
}
