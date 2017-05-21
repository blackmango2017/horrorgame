using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    [SerializeField]
    private List<Item> _items = new List<Item>();
    public List<Image> _itemSlots = new List<Image>();
    private int _cursor = 0;

    private void Start() {
        for (int i = 0; i < transform.childCount; ++i) {
            _itemSlots.Add((Image)(transform.GetChild(i).FindChild("ItemImage").GetComponent(typeof(Image))));
        }

        gameObject.SetActive(false);
    }

    public Item Search(string itemName) {
        for (int i = 0; i < _items.Count; ++i) {
            if (_items[i]._name == itemName) {
                return _items[i];
            }
        }

        return null;
    } 

    public void Add(Item item) {
        if (_cursor >= _itemSlots.Count)
            return;

        _items.Add(item);
        _itemSlots[_cursor].sprite = item.image;
        _itemSlots[_cursor].enabled = true;
        ++_cursor;
    }

    public void Remove(Item item) {
        if (_items.Contains(item)) {
            _items.Remove(item);
            _itemSlots[0].sprite = null;
            _itemSlots[0].enabled = false;
        }
    }

    public void OnClick() {
        //if (_player.currentState != PlayerState.IDLE)
        //    return;

        if (gameObject.activeSelf) {
            gameObject.SetActive(false);
        } else {
            gameObject.SetActive(true);
        }
    }
}
