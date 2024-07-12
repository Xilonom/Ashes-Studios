using UnityEngine;

public class GrindItem : MonoBehaviour
{
    [SerializeField] private int _durability = 5;

    [SerializeField] private bool _canBreak = false;

    [SerializeField] private GameObject _generatedOre;
    private int _generatedOresAmount;

    public int Durability
    {
        get { return _durability; }
        set { _durability = value; }
    }

    void Awake()
    {
        int minGeneratedOres = 1;
        int maxGeneratedOres = 5;

        _generatedOresAmount = Random.Range(minGeneratedOres, maxGeneratedOres);
    }

    public void BreakPart()
    {
        if (_durability > 0)
        {
            _durability -= 1;
        }
        else
        {
            BreakObject();
        }
    }

    private void BreakObject()
    {
        for (int i = 0; i < _generatedOresAmount; i++)
        {
            Instantiate(_generatedOre, transform.position, Quaternion.identity);

        }

        Destroy(gameObject);
    } 
}