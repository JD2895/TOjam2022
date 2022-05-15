using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    //public Dictionary<string, string> itemReponse = new Dictionary<string, string>();

    [System.Serializable]
    public struct ItemResponse
    {
        public GameObject item;
        public string response;
    }

    public ItemResponse[] itemResponses;

    public string GetResponse(GameObject checkItem)
    {
        foreach (ItemResponse _ir in itemResponses)
        {
            if (_ir.item == checkItem)
                return _ir.response;
        }

        return null;
    }
}
