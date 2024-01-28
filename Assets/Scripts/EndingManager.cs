using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingManager : MonoBehaviour
{
    public enum Ending_t
    {
        KING_WIN = 0,
        KING_LOSE = 1,
        NOBILLITY_WIN = 2,
        NOBILLITY_LOSE = 3,
        JESTER_WIN = 4,
        JESTER_LOSE = 5,
        MAX = 6
    }
    
    [SerializeField] private Sprite[] king_win;
    [SerializeField] private Sprite[] king_lose;
    [SerializeField] private Sprite[] nobillity_win;
    [SerializeField] private Sprite[] nobillity_lose;
    [SerializeField] private Sprite[] jester_lose;
    [SerializeField] private Sprite[] jester_win;
    [SerializeField] private Sprite errSpr;
    [SerializeField] private Image endingPanel;
    [SerializeField] private GameObject bg1; 
    [SerializeField] private GameObject bg2;
    private bool ended;

    public void showEnding(Ending_t ending)
    {
        if (ended) return;
        StartCoroutine(slideshow(ending));
    }

    private IEnumerator slideshow(Ending_t ending)
    {
        Sprite[] endingas = ending switch
        {
            Ending_t.KING_WIN => king_win,
            Ending_t.KING_LOSE => king_lose,
            Ending_t.NOBILLITY_WIN => nobillity_win,
            Ending_t.NOBILLITY_LOSE => nobillity_lose,
            Ending_t.JESTER_WIN => jester_win,
            Ending_t.JESTER_LOSE => jester_lose,
            _ => new [] {errSpr}
        };

        if (ending == Ending_t.JESTER_LOSE)
        {
            bg1.SetActive(false);
            bg2.SetActive(false);
        }
        else
        {
            bg1.SetActive(true);
            bg2.SetActive(true);
        }
        
        for (int i = 0; i < endingas.Length; i++)
        {
            endingPanel.sprite = endingas[i];
            yield return new WaitForSeconds(2);
            if (i == endingas.Length - 1 && ending == Ending_t.JESTER_LOSE)
            {
                yield return new WaitForSeconds(2);
                GameManager.instance.audioSource.clip = GameManager.instance.sounds[1];
                GameManager.instance.audioSource.loop = true;
                GameManager.instance.audioSource.Play();
            }
        }

        ended = true;
        yield return null;
    }
}
