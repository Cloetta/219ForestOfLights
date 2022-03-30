using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New SceneStats", menuName = "SceneManager/Stats")]
public class SceneStats : ScriptableObject
{

    new public string name = "New Scene";

    //All lanterns need to be turne on in the scene.
    public int totalLanterns = 0;
    public int currentLanterns = 0;

    public int totalJars = 0;
    public int minJars = 0;
    public int currentOpenJars = 0;

    public bool isWin;
    public bool isComplete;

}
