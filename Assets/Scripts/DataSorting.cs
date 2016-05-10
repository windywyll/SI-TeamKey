using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataSorting : MonoBehaviour {

    private List<PlayerData> m_DataList = new List<PlayerData>();

    private List<DataType> m_DataTypeList = new List<DataType>();

    void Start()
    {
        m_DataTypeList.Add(DataType.DamagesTotal);
        m_DataTypeList.Add(DataType.Accuracy);
        m_DataTypeList.Add(DataType.PlayersRez);
        m_DataTypeList.Add(DataType.Dash);
        m_DataTypeList.Add(DataType.DamagesTaken);
        m_DataTypeList.Add(DataType.Meters);
        m_DataTypeList.Add(DataType.BulletsLaunched);
        m_DataTypeList.Add(DataType.DeathNumber);
    }

    //Add data at the start regarding of how many players
    public void AddData(PlayerData _playerData)
    {
        m_DataList.Add(_playerData);
    }

    public void SortData()
    {
        foreach(DataType _dt in m_DataTypeList)
        {

        }
    }
   
    SortMax(int _1, int _2, int _3, int _4)
    {

    }

}
