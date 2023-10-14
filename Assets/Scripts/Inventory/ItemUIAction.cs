using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class ItemUIAction : MonoBehaviour
{
    public ItemUInstance.Settings settings;
    public ItemActionSO itemActionSO;
    [SerializeField]
    private Button button;

    [Inject]
    public void Construct(ItemUInstance.Settings settings)
    {
        this.settings = settings;
    }

    public void Start()
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() =>
        {
            if (itemActionSO.Execute(settings.Item))
            {
                gameObject.SetActive(false);
            }
        });
    }
}