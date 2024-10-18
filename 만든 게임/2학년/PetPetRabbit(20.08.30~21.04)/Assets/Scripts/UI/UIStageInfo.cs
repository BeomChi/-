using System.Collections;
using System.Collections.Generic;
using RotaryHeart.Lib.SerializableDictionary;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Rabbit
{
    public class UIStageInfo : MonoBehaviour
    {
        [System.Serializable]
        public class NoteUIInfo
        {
            public Sprite sprite;
            public string key;
        }

        [System.Serializable]
        public class NoteUIInfoSocket
        {
            public GameObject infoObject;
            public Image imageSocket;
            public TMP_Text textSocket;

            public void SetInfo(Sprite sprite, string key)
            {
                imageSocket.sprite = sprite;
                textSocket.text = key;
            }
        }
        
        [System.Serializable]
        public class NoteInfoDictionary : SerializableDictionaryBase<NoteType, NoteUIInfo> { }

        [SerializeField] private NoteInfoDictionary infoDic;
        [SerializeField] private NoteUIInfoSocket[] infoSocket;

        [SerializeField] private UnityEvent stageChangeEvent;

        private void Start()
        {
            StartCoroutine(ShowStageNoteInfo());
        }

        private void Update()
        {
            if (StageManager.GameState != StageState.ShowInfo) return;

            if (Keyboard.current.anyKey.wasPressedThisFrame) {
                stageChangeEvent.Invoke();
            }
        }

        private IEnumerator ShowStageNoteInfo()
        {
            yield return new WaitUntil(() => StageManager.GameState == StageState.ShowInfo);

            SetStageInfo(StageManager.LevelData.infoShowTypes);
        }

        private void SetStageInfo(IReadOnlyList<NoteType> types)
        {
            foreach (var socket in infoSocket) {
                socket.infoObject.SetActive(false);
            }

            for (var i = 0; i < types.Count; i++) {
                infoSocket[i].infoObject.SetActive(true);
                infoSocket[i].SetInfo(infoDic[types[i]].sprite, infoDic[types[i]].key);
            }
        }
    }
}