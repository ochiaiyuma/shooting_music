using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;


public class GameManager : MonoBehaviour
{
    public void OnRetry()
    {
        SceneManager.LoadScene("Main");
        
    }
}
