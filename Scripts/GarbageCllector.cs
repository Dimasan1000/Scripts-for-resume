using UnityEngine;

public class GarbageCllector : MonoBehaviour
{
    [SerializeField] private MoveAcselorometr _speedUp;
    public Renderer[] _obstInvis;
    public bool Fool=false;

    private void OnTriggerStay(Collider other)
    {
        if (this.gameObject.tag == "GarbageCollector")
        {
            switch (other.gameObject.tag)
            {
                case "Coin": Renderer _coin = other.gameObject.GetComponent<Renderer>();
                    if (_coin.material.color.a > 0.01)
                    {
                        Color _countColorMesh = new Color(_coin.material.color.r, _coin.material.color.g,
                                                          _coin.material.color.b, _coin.material.color.a - 0.08f);
                        _coin.material.color = _countColorMesh;
                    }
                    break;
                case "Oxygen": Renderer _oxy = other.gameObject.GetComponent<Renderer>();
                    Dissappears(_oxy);
                    break;
                case "Wall": Renderer _wall = other.gameObject.GetComponent<Renderer>();
                    if (Fool == false)
                    {
                        _obstInvis = new Renderer[_wall.transform.parent.childCount];
                        Fool = true;
                    }
                    foreach (Renderer r in _wall.transform.parent.GetComponentsInChildren<Renderer>())
                    {  
                        _obstInvis[r.transform.GetSiblingIndex()] = r;
                    }
                    DissappearWall(_obstInvis);
                    break;                
            }
        }
    }
    private void Dissappears(Renderer mesh)
    {
        if (mesh.material.color.a > 0.01)
        {
            Color _countColorMesh = new Color(mesh.material.color.r, mesh.material.color.g,mesh.material.color.b, mesh.material.color.a - 0.08f);
            mesh.material.color = _countColorMesh;
            Renderer _child = mesh.transform.GetChild(0).GetComponent<Renderer>();
            _child.materials[0].color =  new Color(_child.materials[0].color.r, _child.materials[0].color.g,_child.materials[0].color.b, mesh.material.color.a);
            _child.materials[1].color = new Color(_child.materials[1].color.r, _child.materials[1].color.g,_child.materials[1].color.b, mesh.material.color.a);
        }
    }
    private void DissappearWall(Renderer[] mesh)
    {
        if (mesh[0].material.color.a > 0.01)
        {
            Color _countColorMesh = new Color(mesh[0].material.color.r, mesh[0].material.color.g,mesh[0].material.color.b, mesh[0].material.color.a - 0.08f);
            mesh[0].material.color = _countColorMesh;
        }
        else Fool = false;
        foreach (Renderer r in mesh)
        {
            r.material.color = new Color(r.material.color.r, r.material.color.g, r.material.color.b, mesh[0].material.color.a);
        }
    }
}
