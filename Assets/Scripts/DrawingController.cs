using Leap;
using Leap.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingController : MonoBehaviour {

    [SerializeField]
    private GameObject LeftIndexFingerCube;

    [SerializeField]
    private GameObject LeftIndexFinger;

    [SerializeField]
    private Transform _LeapOrigin;

    private Controller _Controller;
    private bool _IsDrawing = false;

    private void Awake()
    {
        if (LeftIndexFinger == null)
            throw new System.Exception("A LeftIndexFinger must be defined");

        if (LeftIndexFingerCube == null)
            throw new System.Exception("A LeftIndexFingerCube must be defined");

        InitController();
    }

    private void InitController()
    {
        _Controller = new Controller();
        _IsDrawing = true;
    }

    private void TrackFinger(Finger finger)
    {
        Leap.Vector stabalizedPosition = finger.TipPosition;
        Vector3 unityPosition = stabalizedPosition.ToVector3()/100; //Leap.Unity.UnityVectorExtension.ToVector3(stabalizedPosition);

        unityPosition = new Vector3(unityPosition.x + _LeapOrigin.position.x, unityPosition.y + _LeapOrigin.position.y, -1 * (unityPosition.z + _LeapOrigin.position.z));
        

        //unityPosition = new Vector3(unityPosition.x, (unityPosition.y + _LeapOrigin.position.y), -1 * (unityPosition.z + _LeapOrigin.position.z));
        //Leap.Unity.UnityVectorExtension.ToVector3(stabalizedPosition);
        
        
        LeftIndexFingerCube.transform.position = unityPosition;
    }

    private void CheckDrawing()
    {
        Frame curFrame = _Controller.Frame();

        int extendedFingers = 0;

        if(curFrame.Hands.Count > 0)
        {
            List<Hand> handList = curFrame.Hands;
            Hand firstHand = handList[0];
            for(int i = 0; i < firstHand.Fingers.Count; i++)
            {
                Finger finger = firstHand.Fingers[i];
                //only allow drawing with the index finger for now
                if (finger.Type == Finger.FingerType.TYPE_INDEX)
                {
                    if (finger.IsExtended)
                    {
                    
                        //TrackFinger(finger);
                        StartDrawing();
                    }
                }
                    extendedFingers++;
            }
        }
    }

    void StartDrawing()
    {

        Vector3 moveToPosition = LeftIndexFinger.transform.position;
        LeftIndexFingerCube.transform.position = moveToPosition;

    }
	
	// Update is called once per frame
	void Update () {
        if (_IsDrawing)
        {
            if (_Controller.IsConnected)
            {
                //StartDrawing();
                CheckDrawing();
            }
        }
	}
}
