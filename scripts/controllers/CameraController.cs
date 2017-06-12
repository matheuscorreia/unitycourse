using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    protected Camera camera;
    private static CameraController instance;

    public void Awake(){
        CameraController.instance = this;
		this.camera = (Camera) gameObject.GetComponent<Camera>();
	}

	public static CameraController GetInstance(){
        return CameraController.instance;
	}

	public int isVerticallyOut(Vector2 pos){
		Vector3 posViewport = this.camera.WorldToViewportPoint(pos);
		if(posViewport.y < 0)
			return -1;
		else if(posViewport.y >= 0 && posViewport.y <= 1)
			return 0;
		else
			return 1;
	}

	public int isHorizontallyOut(Vector2 pos){
		Vector3 posViewport = this.camera.WorldToViewportPoint(pos);
		if(posViewport.x < 0)
			return -1;
		else if(posViewport.x >= 0 && posViewport.x <= 1)
			return 0;
		else
			return 1;
	}
}
