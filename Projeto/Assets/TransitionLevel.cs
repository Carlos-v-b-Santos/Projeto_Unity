using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionLevel : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        animator = GetComponent<Animator>();
    }

    public void TransitionLevelAnim(int index)
    {
        StartCoroutine(LoadScene(index));
    }

    IEnumerator LoadScene(int index)
    {
        animator.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(index);
        animator.SetTrigger("Start");
    }
}
