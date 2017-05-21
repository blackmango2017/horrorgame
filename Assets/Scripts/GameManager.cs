using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager> {

    private Player _player = null;

    private Inventory _inventory = null;
    private GameObject _joystick = null;

    private List<GameObject> _objects = new List<GameObject>();

    private void Update() {
        _objects.Sort(compare);
        for (int i = 0; i < _objects.Count; ++i) {
            ((SpriteRenderer)_objects[i].GetComponent(typeof(SpriteRenderer))).sortingOrder = _objects.Count - i;
        }
    }

    public void InitSetup() {
        GameObject canvas = GameObject.Find("Canvas");

        if (_inventory == null) {
            GameObject obj = Instantiate(Resources.Load("Prefabs/Inventory"), canvas.transform) as GameObject;
            obj.name = "Inventory";
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.Euler(Vector3.zero);
            obj.transform.localScale = Vector3.one;
            _inventory = (Inventory)obj.GetComponent(typeof(Inventory));
        } else {
            _inventory.transform.parent = canvas.transform;
        }

        if (_player == null) {
            GameObject obj = Instantiate(Resources.Load("Prefabs/Player")) as GameObject;
            obj.name = "Player";
            obj.transform.position = GameObject.Find("StartPosition").transform.position;
            obj.transform.rotation = Quaternion.Euler(Vector3.zero);
            obj.transform.localScale = Vector3.one;
            _player = (Player)obj.GetComponent(typeof(Player));
            _player.SendMessage("SetInventory", _inventory);
            DontDestroyOnLoad(obj);
        }

        if (_joystick == null) {
            _joystick = Instantiate(Resources.Load("Prefabs/Joystick"), canvas.transform) as GameObject;
            _joystick.name = "Joystick";
            _joystick.transform.position = GameObject.Find("JoystickPosition").transform.position;
            _joystick.transform.localRotation = Quaternion.Euler(Vector3.zero);
            _joystick.transform.localScale = Vector3.one;
        } else {
            _joystick.transform.parent = canvas.transform;
        }

        GameObject inventoryBtn = GameObject.Find("InventoryButton");
        ((Button)inventoryBtn.GetComponent(typeof(Button))).onClick.AddListener(_inventory.OnClick);

        _objects.AddRange(GameObject.FindGameObjectsWithTag("Object"));
    }

    public void Clear() {
        _objects.Clear();
    }

    public int compare(GameObject v1, GameObject v2) {
        return v1.transform.FindChild("Pivot").position.y.CompareTo(v2.transform.FindChild("Pivot").position.y);
    }
}
