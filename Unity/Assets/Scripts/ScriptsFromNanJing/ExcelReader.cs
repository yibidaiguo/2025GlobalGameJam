using System.Collections.Generic;
using System.IO;
//using ExcelDataReader;
using System.Text;
using UnityEngine;

/*
using static ExcelReader;

public class ExcelReader
{
    public struct ExcelData
    {
        public string speaker;
        public string content;
    }


    public static List<ExcelData> ReadExcel(string _filePath)//Excel�ļ���ȡ
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, _filePath);
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"File not found: {filePath}");//�ļ�������

            
        List<ExcelData> excelData = new List<ExcelData>();
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);  //ע������ṩ����
        using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))    //����һ���ļ���
        {
            using (var reader = ExcelReaderFactory.CreateReader(stream))    //����һ��Excel��ȡ��
            {
                do
                {
                    while (reader.Read())//���ж�ȡ������������л��Զ�����
                    {
                        ExcelData data = new ExcelData();
                        data.speaker = reader.GetString(0);     //��ȡ��һ�е�����,˵��������
                        data.content = reader.GetString(1);     //��ȡ�ڶ��е����ݣ��Ի�����
                        excelData.Add(data);
                    }
                } while (reader.NextResult());//����ж���������ȡ
            }
            return excelData;
        }
    }
}
*/