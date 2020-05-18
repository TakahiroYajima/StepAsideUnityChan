using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {
    public GameObject carPrefab;

    public GameObject coinPrefab;

    public GameObject conePrefab;

    private int startPos = -160;
    private int goalPos = 120;
    private float posRange = 3.4f;

	// Use this for initialization
	void Start () {
		for(int i = startPos; i < goalPos; i+= 15)
        {
            int num = Random.Range(1, 11);
            if(num <= 2)
            {
                for(float j = -1; j <= 1; j+= 0.4f)
                {
                    EmitObject emit = new EmitObject();
                    emit.instanceObj = conePrefab;
                    emit.instancePos = new Vector3(4 * j, conePrefab.transform.position.y, i);
                    Emitter.Instance.AddEmmitPrefab(emit);
                }
            }
            else
            {
                for(int j = -1; j <= 1; j++)
                {
                    int item = Random.Range(1, 11);
                    int offsetZ = Random.Range(-5, 6);
                    if(1 <= item && item <= 6)
                    {
                        EmitObject emit = new EmitObject();
                        emit.instanceObj = coinPrefab;
                        emit.instancePos = new Vector3(posRange * j, coinPrefab.transform.position.y, i + offsetZ);
                        Emitter.Instance.AddEmmitPrefab(emit);
                    }
                    else if(7 <= item && item <= 9)
                    {
                        EmitObject emit = new EmitObject();
                        emit.instanceObj = carPrefab;
                        emit.instancePos = new Vector3(posRange * j, carPrefab.transform.position.y, i + offsetZ);
                        Emitter.Instance.AddEmmitPrefab(emit);
                    }
                }
            }
        }
	}
}
