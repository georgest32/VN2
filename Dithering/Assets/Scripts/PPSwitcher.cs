using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PPSwitcher : MonoBehaviour
{
    public PostProcessProfile normProfile;
    public PostProcessProfile ampProfile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GetComponent<PostProcessVolume>().profile = normProfile;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GetComponent<PostProcessVolume>().profile = ampProfile;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<ImageEffect>().enabled = !FindObjectOfType<ImageEffect>().enabled;
        }
    }
}
