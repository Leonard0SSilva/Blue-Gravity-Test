// Update player's equipped item visuals based on changes in the player items
using UnityEngine;
using Zenject;

public class PlayerUpdateEquipment : MonoBehaviour
{
    public Sprite[] spritSides;
    public SpriteRenderer[] hatSides;

    public SignalBus signalBus;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        this.signalBus = signalBus;
    }

    private void Start()
    {
        signalBus.Subscribe<EquipItemSignal>(OnEquipItem);
        signalBus.Subscribe<UnequipItemSignal>(OnUnequipItem);
    }

    private void OnDestroy()
    {
        signalBus.Unsubscribe<EquipItemSignal>(OnEquipItem);
        signalBus.Unsubscribe<UnequipItemSignal>(OnUnequipItem);
    }

    private void OnEquipItem(EquipItemSignal signal)
    {
        if (signal.item.ItemType.GetType() == typeof(ItemEquippableAction))
        {
            spritSides = signal.item.itemSides;
            for (int i = 0; i < hatSides.Length; i++)
            {
                hatSides[i].sprite = spritSides != null && spritSides.Length > i ? spritSides[i] : null;
                hatSides[i].gameObject.SetActive(hatSides[i].sprite == null);
            }
        }
    }

    private void OnUnequipItem(UnequipItemSignal signal)
    {
        if (signal.item.ItemType.GetType() == typeof(ItemEquippableAction))
        {
            for (int i = 0; i < hatSides.Length; i++)
            {
                hatSides[i].sprite = null;
                hatSides[i].gameObject.SetActive(false);
            }
        }
    }
}