using UnityEditor;
using UnityEngine;

[CustomEditor (typeof(DetectingPlayer))]
public class RangeField : Editor
{

     //move this to the scripts folder when you need it for the demo
    private void OnSceneGUI()
    {
        DetectingPlayer stealth = (DetectingPlayer)target;
        Handles.color = new Color(1, 0, 0, 0.25f);
        Vector3 positionOnGround = new Vector3(stealth.transform.position.x, 0, stealth.transform.position.z);

        Handles.DrawSolidArc(positionOnGround, Vector3.up, stealth.FromVector, stealth.angle, stealth.radius);
    }
}
