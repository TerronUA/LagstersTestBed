using UnityEngine;
using System.Collections;

public class CarCamera : MonoBehaviour
{
    [SerializeField]
    private float distanceAway;
    [SerializeField]
    private float distanceUp;
    [SerializeField]
    private float smooth;
    [SerializeField]
    private Transform follow;
    [SerializeField]
    private Vector3 offset = new Vector3(0f, 1.5f, 0f);
    
	private Vector3 lookDir;
	private Vector3 targetPosition;

    // Use this for initialization
    void Start()
    {
        follow = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    /// <summary>
	/// Debugging information should be put here.
	/// </summary>
	void OnDrawGizmos ()
	{	
		//if (EditorApplication.isPlaying && !EditorApplication.isPaused)
		//{			
		//	DebugDraw.DrawDebugFrustum(viewFrustum);
		//}
	}

    // Update is called once per frame
    void LateUpdate()
    {
        targetPosition = follow.position + follow.up * distanceUp - follow.forward * distanceAway;
        //Debug.DrawRay(follow.position, Vector3.up * distanceUp, Color.red);
        //Debug.DrawRay(follow.position, -1f * follow.forward * distanceAway, Color.blue);
        Debug.DrawRay(follow.position, targetPosition, Color.magenta);

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);

        transform.LookAt(follow);
    }
}
