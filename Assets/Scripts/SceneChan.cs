using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChan : MonoBehaviour
{

    public string sc;
    public Animator fade;
    private bool time = false;
    public float duration;
    public void change()
    {
        fade.SetTrigger("fadeO");
        time = true;

    }
    public void changeNoAnim()
    {
        SceneManager.LoadScene(sc);

    }

    private void Update()
    {
        if (time) {
            if (duration <= 0) {
                SceneManager.LoadScene(sc);
                time = false;
            }
            duration -=Time.deltaTime;
        }
    }
    public IEnumerator chan(string stc)
    {
        yield return new WaitForSeconds(0.30f);
        SceneManager.LoadScene(stc);
    }
}
