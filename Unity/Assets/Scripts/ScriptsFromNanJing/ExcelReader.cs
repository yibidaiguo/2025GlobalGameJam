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


    public static List<ExcelData> ReadExcel(string _filePath)//Excel文件读取
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, _filePath);
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"File not found: {filePath}");//文件不存在

            
        List<ExcelData> excelData = new List<ExcelData>();
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);  //注册编码提供程序
        using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))    //创建一个文件流
        {
            using (var reader = ExcelReaderFactory.CreateReader(stream))    //创建一个Excel读取器
            {
                do
                {
                    while (reader.Read())//逐行读取，如果遇到空行会自动跳过
                    {
                        ExcelData data = new ExcelData();
                        data.speaker = reader.GetString(0);     //读取第一列的数据,说话者姓名
                        data.content = reader.GetString(1);     //读取第二列的数据，对话内容
                        excelData.Add(data);
                    }
                } while (reader.NextResult());//如果有多个表，逐个读取
            }
            return excelData;
        }
    }
}
*/