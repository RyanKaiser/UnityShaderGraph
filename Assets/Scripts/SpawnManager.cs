using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject target;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit h;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out h, 1000f))
            {
                Vector3 direction = Camera.main.transform.position - h.point;
                direction.y = 0;
                Quaternion rotation = Quaternion.LookRotation(direction);
                
                Instantiate(target, h.point, rotation);
            }
        }    
    }
}

