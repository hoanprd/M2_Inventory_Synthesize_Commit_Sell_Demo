using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommitController : MonoBehaviour
{
    public GameObject[] prefabCommit;
    public GameObject commitContent;
    public Transform rootCommitList;

    public static bool chooseCommit, commitOff;

    public void ChooseListCommitWood()
    {
        foreach (GameObject go in BagListController.bl)
        {
            MaterialDisplay materialDisplay = go.GetComponent<MaterialDisplay>();

            if (materialDisplay.mId == 0)
            {
                GameObject materialObject = Instantiate(prefabCommit[materialDisplay.mId], rootCommitList);

                int slotId;
                int id;
                string name;
                int star;
                string attribute;

                slotId = go.GetComponent<MaterialDisplay>().mSlotId;
                id = go.GetComponent<MaterialDisplay>().mId;
                name = go.GetComponent<MaterialDisplay>().mName;
                star = go.GetComponent<MaterialDisplay>().mStar;
                attribute = go.GetComponent<MaterialDisplay>().mAttribute;

                materialDisplay = materialObject.GetComponent<MaterialDisplay>();

                materialDisplay.mSlotId = slotId;
                materialDisplay.mId = id;
                materialDisplay.mName = name;
                materialDisplay.mStar = star;
                materialDisplay.mAttribute = attribute;

                //BagListController.commitl.Add(materialObject);
            }
        }
    }

    public void WoodCommit()
    {
        AddMaterials.WoodCommitValue = 0;

        foreach (GameObject go in BagListController.bl.ToArray())
        {
            for (int i = 0; i < AddMaterials.woodCommitArray.Length; i++)
            {
                if (AddMaterials.woodCommitArray[i] == go.GetComponent<MaterialDisplay>().mSlotId)
                {
                    BagListController.bl.Remove(go);
                    Destroy(go);
                }
            }
        }

        commitOff = true;
    }
}
