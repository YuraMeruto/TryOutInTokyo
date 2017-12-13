using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSelect : MonoBehaviour {

    [SerializeField]
    GameObject panelPrefab;

    [SerializeField]
    GameObject btnPrefab;

    [SerializeField]
    List<AudioClip> ac = new List<AudioClip>();

    AudioSource asrc;

    // Use this for initialization =
    void Start () {
        asrc = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void stageBtnClick()
    {
        var pInstance = Instantiate(panelPrefab);
        pInstance.transform.SetParent(gameObject.transform, false);

        PlaySE(0);

        var bIns = Instantiate(btnPrefab);
        bIns.transform.SetParent(pInstance.transform, false);
        //ButtonManager bm = new ButtonManager();
        //bm.ToGameScene();
    }

    public void PlaySE(int num)
    {
        asrc.PlayOneShot(ac[num]);
    }
}
