using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace testTools
{
  internal class testData
  {
    public string key;
    public string value1;
    public string value2;
    public string value3;
    public string value4;
    public string value5;
    public string value6;
    public string value7;
    public string value8;
    public string value9;
    public string value10;
    public string value11;
    public string value12;
    public string value13;
    public string value14;
    public string value15;
    public string value16;
    public string value17;


    public testData(long i)
    {
      key = i.ToString();
      int j = 0;
      string strdt = System.DateTime.Now.ToString("yyyyMMdd-HHmiss");
      value1 = String.Format("{0}-{1}-{2}", strdt, i, j++);
      value2 = String.Format("{0}-{1}-{2}", strdt, i, j++);
      value3 = String.Format("{0}-{1}-{2}", strdt, i, j++);
      value4 = String.Format("{0}-{1}-{2}", strdt, i, j++);
      value5 = String.Format("{0}-{1}-{2}", strdt, i, j++);
      value6 = String.Format("{0}-{1}-{2}", strdt, i, j++);
      value7 = String.Format("{0}-{1}-{2}", strdt, i, j++);
      value8 = String.Format("{0}-{1}-{2}", strdt, i, j++);
      value9 = String.Format("{0}-{1}-{2}", strdt, i, j++);
      value10 = String.Format("{0}-{1}-{2}", strdt, i, j++);
      value11 = String.Format("{0}-{1}-{2}", strdt, i, j++);
      value12 = String.Format("{0}-{1}-{2}", strdt, i, j++);
      value13 = String.Format("{0}-{1}-{2}", strdt, i, j++);
      value14 = String.Format("{0}-{1}-{2}", strdt, i, j++);
      value15 = String.Format("{0}-{1}-{2}", strdt, i, j++);
      value16 = String.Format("{0}-{1}-{2}", strdt, i, j++);
      value17 = String.Format("{0}-{1}-{2}", strdt, i, j++);
    }

    public override string ToString()
    {
      var options = new JsonSerializerOptions { IncludeFields = true };
      return System.Text.Json.JsonSerializer.Serialize(this,options);
        }


  }
}
