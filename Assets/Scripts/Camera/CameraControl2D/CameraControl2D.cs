

using UnityEngine;
using System.Collections;

// Classe que controla o movimento da camera.
[ExecuteInEditMode]
public class CameraControl2D : MonoBehaviour {

	public Transform target;

    private Vector2 targetTemp;

	public float smoothSpeedX = 2;
    public float smoothSpeedY = 2;

    public bool paused = false;

    public bool movX;
    public bool movY;

	public Vector2 offSet;
	
    //ancoras da camera
    public Transform anchorLeft;
    public Transform anchorRight;
    public Transform anchorDown;
    public Transform anchorUp;

    private Vector3 originPosition;
    public float shake_intensity;
    public float shake_decay;
    

	void Start(){

        Anchorage();
	}


	void Update () {

		if(!paused){

            originPosition = transform.position;

            Vector3 newPos = transform.position;
			newPos.z = transform.position.z;
            
            if (movY)
            {
                newPos.y = Mathf.Lerp(transform.position.y, targetTemp.y + offSet.y, smoothSpeedY * Time.deltaTime);
			}

            if(movX){
                newPos.x = Mathf.Lerp(transform.position.x, targetTemp.x + offSet.x, smoothSpeedX * Time.deltaTime);
			}
                transform.position = newPos;

            //---------------------------

            Anchorage(); // Limita movimento entre as ancoras
                
            //---------------------------

		}

        //Efeito Shake
        if (shake_intensity > 0)
        {
            transform.position = transform.position + Random.insideUnitSphere * shake_intensity;
            shake_intensity -= shake_decay;
        }


	}


    public void Shake()
    {
        originPosition = transform.position;
        shake_intensity = .2f;
        shake_decay = 0.002f;
    }


    public void SnapToTarget()
    {
        Vector3 newPos = target.position;
        newPos.z = transform.position.z;
        transform.position = newPos;
        Debug.Log("Snapped to target");
    }

    public void Track(bool track)
    {
        paused = !track;
    }

    public void Target(Transform newTarget)
    {
        target = newTarget;
    }


    public void Anchorage()
    {

        if (target != null)
        {
            targetTemp = new Vector2(target.position.x, target.position.y);

            if (anchorLeft != null)
            {
                if (target.position.x <= anchorLeft.position.x)
                {
                    targetTemp = new Vector2(anchorLeft.position.x, targetTemp.y);
                }
            }

            if (anchorRight != null)
            {
                if (target.position.x >= anchorRight.position.x)
                {
                    targetTemp = new Vector2(anchorRight.position.x, targetTemp.y);
                }
            }

            if (anchorDown != null)
            {
                if (target.position.y <= anchorDown.position.y)
                {
                    targetTemp = new Vector2(targetTemp.x, anchorDown.position.y);
                }
            }

            if (anchorUp != null)
            {
                if (target.position.y >= anchorUp.position.y)
                {
                    targetTemp = new Vector2(targetTemp.x, anchorUp.position.y);
                }
            }

        }
    }
}
