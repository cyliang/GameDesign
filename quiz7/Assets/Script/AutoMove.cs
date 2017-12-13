using UnityEngine;
using System.Collections;

public class AutoMove : MonoBehaviour {
	UnityEngine.AI.NavMeshAgent 		ball;
	public GameObject   goal;
	
	// Use this for initialization
	void Start () {
		ball = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
		goal.transform.position = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				ball.SetDestination(hit.point);
				goal.transform.position = new Vector3(hit.point.x,this.transform.position.y,hit.point.z);
			}
		}
	}
}
