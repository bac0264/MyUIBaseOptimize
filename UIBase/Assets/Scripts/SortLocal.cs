using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SortLocal 
{
    public static void swap(Item itemA, Item itemB)
    {
        Item item = new Item();
        item.id = itemA.id;
        item.type = itemA.type;
        item.value = itemA.value;
        item.level = itemA.level;
        item.levelUpgrade = itemA.levelUpgrade;
        item.isEquip = itemA.isEquip;
        item.itemIndex = itemA.itemIndex;

        itemA.id = itemB.id;
        itemA.type = itemB.type;
        itemA.value = itemB.value;
        itemA.level = itemB.level;
        itemA.levelUpgrade = itemB.levelUpgrade;
        itemA.isEquip = itemB.isEquip;
        itemA.itemIndex = itemB.itemIndex;

        itemB.id = item.id;
        itemB.type = item.type;
        itemB.value = item.value;
        itemB.level = item.level;
        itemB.levelUpgrade = item.levelUpgrade;
        itemB.isEquip = item.isEquip;
        itemB.itemIndex = item.itemIndex;
    }
    public static void selectionSort(List<Item> arr, int n)
    {
        int i, j, min_idx;

        // One by one move boundary of unsorted subarray  
        for (i = 0; i < n - 1; i++)
        {
            // Find the minimum element in unsorted array  
            min_idx = i;
            for (j = i + 1; j < n; j++)
                if (arr[j].levelUpgrade > arr[min_idx].levelUpgrade)
                    min_idx = j;

            // Swap the found minimum element with the first element  
            swap(arr[min_idx], arr[i]);
        }
    }
}
