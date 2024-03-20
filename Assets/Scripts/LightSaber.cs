using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaber : MonoBehaviour
{
    private GameObject blade;
    public Light baseLight;
    public Transform FiringPoint;

    public List<Material> colors;
    private List<Color> lightColors;

    public int colorChoice = 0;
    public bool Activated = false;

    private bool isActive = false;

    private GameObject currentBlade;

    // Start is called before the first frame update
    void Start()
    {
        lightColors = new List<Color>
        {
            Color.blue,
            Color.green,
            Color.magenta,
            Color.red
        };

        blade = Resources.Load<GameObject>("BladeDisk");
    }

    // Update is called once per frame
    void Update()
    {
        // if (Activated && !isActive)
        // {
        //     Debug.Log("Activated");
        //     isActive = true;

        //     GameObject Blade = Instantiate(blade, FiringPoint.position, blade.transform.rotation);
        //     Blade.transform.parent = FiringPoint;
        //     Blade.GetComponent<MeshRenderer>().material = colors[colorChoice];

        //     baseLight.enabled = true;
        //     baseLight.color = lightColors[colorChoice];
        // }
        // if(!Activated && isActive)
        // {
        //     Debug.Log("Deactivated");
        //     if(baseLight.enabled)
        //     {
        //         baseLight.enabled = false;
        //     }
        //     if(FiringPoint.childCount > 0)
        //     {
        //         Debug.Log(FiringPoint.GetChild(0).gameObject.name);
        //         Destroy(FiringPoint.GetChild(0).gameObject);
        //     }

        //     isActive = false;
        // }

        if(Activated && currentBlade == null)
        {
            StartCoroutine(ExpandBlade());
        }
        else if (!Activated && currentBlade != null)
        {
            DeactivateBlade();
        }

    }

    private void ActivateBlade()
    {
        

        
    }

    private IEnumerator ExpandBlade()
    {
        FiringPoint.position = new Vector3(FiringPoint.position.x, FiringPoint.position.y - 0.3f, FiringPoint.position.z);

        currentBlade = Instantiate(blade, FiringPoint.position, blade.transform.rotation);
        currentBlade.transform.parent = FiringPoint;
        currentBlade.GetComponent<MeshRenderer>().material = colors[colorChoice];

        baseLight.enabled = true;
        baseLight.color = lightColors[colorChoice];

        float duration = 0.5f;
        float elapsedTime = 0f;

        Vector3 initalScale = blade.transform.localScale;
        Vector3 targetScale = new Vector3(0.03f, 0.3f, 0.03f);

        currentBlade.transform.localScale = initalScale;
        Vector3 endPos = new(blade.transform.position.x, blade.transform.position.y + 0.3f, blade.transform.position.z);

        while(elapsedTime < duration)
        {
            currentBlade.transform.localPosition = Vector3.Lerp(blade.transform.position, endPos, elapsedTime/duration);
            currentBlade.transform.localScale = Vector3.Lerp(initalScale, targetScale, elapsedTime/duration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        currentBlade.transform.localPosition = endPos;
        currentBlade.transform.localScale = targetScale;
    }

    private void DeactivateBlade()
    {
        baseLight.enabled = false;
        Destroy(currentBlade);
        currentBlade = null;
    }

    // public void Activate()
    // {
    //     if(Activated)
    //     {
    //         Activated = false;
    //     }
    //     else
    //     {
    //         Activated = true;
    //     }
    // }


}
