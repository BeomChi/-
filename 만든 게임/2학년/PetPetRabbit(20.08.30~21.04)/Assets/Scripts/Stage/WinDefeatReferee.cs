using System.Collections;
using UnityEngine;

namespace Rabbit
{
    public class WinDefeatReferee : MonoBehaviour
    {
        [SerializeField] private NoteHandler noteHandler;
        
        [SerializeField] private GameTime gameTime;
        [SerializeField] private GameHealth gameHealth;

        [Header("승리할 시 Enable 될 UI Object")]
        [SerializeField] private GameObject gameWinUI;
        [Header("패배할 시 Enable 될 UI Object")]
        [SerializeField] private GameObject gameDefeatUI;

        private Coroutine winJudgeRoutine;
        private Coroutine defeatJudgeRoutine;

        private void Start()
        {
            winJudgeRoutine = StartCoroutine(WinJudge());
            defeatJudgeRoutine = StartCoroutine(DefeatJudge());
        }

        private IEnumerator WinJudge()
        {
            yield return new WaitUntil(() => 
                !noteHandler.IsNoteExist && StageManager.GameState == StageState.Start);
            EndJudgeProcess();
            
            StopCoroutine(defeatJudgeRoutine);

            if (StageManager.CurrentLevel == StageManager.MaxLevelIndex) {
                // TODO: SceneFadeOut
                SceneLoader.LoadScene("CreditScene");
            }
            else {
                gameWinUI.SetActive(true);   
            }
        }

        private IEnumerator DefeatJudge()
        {
            yield return new WaitUntil(() => 
                (gameHealth.Health <= 0.0f || gameTime.IsTimeOver) && StageManager.GameState == StageState.Start);
            EndJudgeProcess();

            StopCoroutine(winJudgeRoutine);
            
            gameDefeatUI.SetActive(true);
        }

        private void EndJudgeProcess()
        {
            StageManager.SetStageState(StageState.End);
            gameTime.StopTimer();
        }
    }
}