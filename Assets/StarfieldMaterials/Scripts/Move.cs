using UnityEngine; 
using System.Collections;

// Visuals for star background on Level Select scene
public class Move : MonoBehaviour
{
    float Target;

	void Update()
	{
        Target += Time.deltaTime / 125;

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, Target), 0.05f);

	}
}