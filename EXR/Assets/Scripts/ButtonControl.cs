using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    public int SceneChangeIndex;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void teacherScene()
    {
        SceneManager.LoadScene(SceneChangeIndex);
    }
   // public void studentScene()
   // {
   //     SceneManager.LoadScene(2);
   // }
    
}