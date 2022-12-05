using UnityEngine;

public class ClearingLine : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    private GameObject goCentr;
    private float dis;
    private Ray ray;

    private void OnEnable()
    {
        goCentr = GameObject.FindGameObjectWithTag(ConstValue.TagCentr);
        dis = Vector3.Distance(transform.position, goCentr.transform.position);
        ray = new Ray(transform.position, (goCentr.transform.position - transform.position).normalized * dis);
        var fd = Physics.RaycastAll(ray, dis, _layerMask);
        foreach (var item in fd)
        {
            Destroy(item.collider.gameObject);
        }
    }
}
