using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : SingletonMonoBehaviour<Emitter> {

    private List<EmitObject> emitList = new List<EmitObject>();
    private List<GameObject> instanceList = new List<GameObject>();

    [SerializeField] private GameObject playerObj = null;
    [SerializeField] private GameObject cameraObj = null;
    
    [SerializeField] private float emmitInstanceDistance = 20f;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        //生成
		if(emitList.Count > 0)
        {
            if(emitList[0].instancePos.z - playerObj.transform.position.z <= emmitInstanceDistance)
            {
                GameObject instanceObj = Instantiate(emitList[0].instanceObj) as GameObject;
                instanceObj.transform.position = emitList[0].instancePos;
                instanceObj.transform.SetParent(this.transform);
                instanceList.Add(instanceObj);
                emitList.RemoveAt(0);
            }
        }
        //削除
        if(instanceList.Count > 0)
        {
            if (instanceList[0] == null)
            {
                instanceList.RemoveAt(0);
            }
            else
            {
                if (instanceList[0].transform.position.z < cameraObj.transform.position.z)
                {
                    Destroy(instanceList[0].gameObject);
                    instanceList.RemoveAt(0);
                }
            }
        }
	}

    public void AddEmmitPrefab(EmitObject emitObj)
    {
        emitList.Add(emitObj);
    }
}

/// <summary>
/// 障害・コインオブジェクト生成用データ
/// </summary>
public class EmitObject
{
    public GameObject instanceObj = null;
    public Vector3 instancePos = Vector3.zero;
}