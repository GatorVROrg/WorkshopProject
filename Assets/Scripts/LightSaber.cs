using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaber : MonoBehaviour
{
    public GameObject blade;
    public Light baseLight;
    public Transform FiringPoint;

    public List<Material> colors;
    private List<Color> lightColors;

    public int colorChoice = 0;
    public bool Activated = false;

    private bool isActive = false;

    //private GameObject currentBlade;

    public void Start()
    {
        lightColors =  new List<Color>
        {
            Color.blue,
            Color.green,
            Color.magenta,
            Color.red
        };

        // blade = Resources.Load<GameObject>("Blade");
        // blade = Resources.Load<GameObject>("Blade Disk");

        //FiringPoint.position = new Vector3(FiringPoint.position.x, FiringPoint.position.y - 0.3f, FiringPoint.position.z);
    }

    public void Update()
    {
        if(Activated && !isActive)
        {
            Debug.Log("Activated");
            isActive = true;
            GameObject Blade = Instantiate(blade, FiringPoint.position, blade.transform.rotation);
            Blade.transform.parent = FiringPoint;
            Blade.GetComponent<MeshRenderer>().material = colors[colorChoice];
            baseLight.enabled = true;
            baseLight.color = lightColors[colorChoice];
        }
        if(!Activated && isActive)
        {
            Debug.Log("Deactivate");
            if(baseLight.enabled)
            {
                baseLight.enabled = false;
            }
            if(FiringPoint.childCount > 0)
            {
                Debug.Log(FiringPoint.GetChild(0).gameObject.name);
                Destroy(FiringPoint.GetChild(0).gameObject);
            }
            isActive = false;
        }      

        // if (Activated && currentBlade == null)
        // {
        //     ActivateBlade();
        // }
        // else if (!Activated && currentBlade != null)
        // {
        //     DeactivateBlade();
        // } 
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

    // public void Activate()
    // {
    //     Activated = !Activated;
    // }

    // private void ActivateBlade()
    // {
    //     currentBlade = Instantiate(blade, FiringPoint.position, blade.transform.rotation);
    //     currentBlade.GetComponent<MeshRenderer>().material = colors[colorChoice];
    //     currentBlade.transform.parent = FiringPoint;
    //     baseLight.enabled = true;
    //     baseLight.color = lightColors[colorChoice];
    //     StartCoroutine(ExpandBlade());
    // }

    // private void DeactivateBlade()
    // {
    //     baseLight.enabled = false;
    //     Destroy(currentBlade);
    //     currentBlade = null;
    // }

    // private IEnumerator ExpandBlade()
    // {
    //     float duration = 0.5f; // Adjust the duration of the expansion
    //     float elapsedTime = 0f;

    //     Vector3 initialScale = blade.transform.localScale; // Initial scale of the blade
    //     Vector3 targetScale = new Vector3(0.03f, 0.3f, 0.03f); // Target scale of the blade

    //     currentBlade.transform.localScale = initialScale;
    //     Vector3 endPos = new(blade.transform.position.x, blade.transform.position.y + 0.3f, blade.transform.position.z);

    //     while (elapsedTime < duration)
    //     {
    //         currentBlade.transform.localPosition = Vector3.Lerp(blade.transform.position, endPos, elapsedTime / duration);
    //         currentBlade.transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / duration);

    //         elapsedTime += Time.deltaTime;
    //         yield return null;
    //     }

    //     currentBlade.transform.localPosition = endPos; // Ensure it reaches the top
    //     currentBlade.transform.localScale = targetScale; // Ensure it reaches the full length
    // }
}
