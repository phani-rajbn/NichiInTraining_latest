using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
namespace SampleConApp
{
  //Serialization is an ability of saving the state of the object to a storage device like Disc, file or memory and retrive it back to the same object from which it was serialized. Similar to File IO, except File IO is all about data, whereas serialization is also about the state of the object which includes the class details, Assembly details and many more.  In Serialization, its either the complete object or nothing. 
  //In .NET, serialization can be done in 3 ways: Binary(Bin Files), XML(XML files), and SOAP(Web services). Binary is used when U R working with the same OS(Windows), for cross platform use XML serialization, across web environment, use SOAP(Simple object Access protocol). 
  //Any serialization, there are 3 points: What to serialize(Objects of the .NET Classes with an attribute called Serializable), Where to serialize(File IO or memory or any of the stream objects) and how to serialize(Format of Serialization). 
  //.NET Classes that are marked with attribute called Serializable can be serialized. 
  //In XML serialization, U should have the class whose object is being serialized as public. 
  //Serializable is not required for XML serialization. The Clas for performing XML formatting is XmlSerializer available in System.Xml.Serialization. U should have the reference of the dll called System.Xml. 
  [Serializable]
  public class TouristInfo
  {
    public int TourID { get; set; }
    public string Place { get; set; }
    public int Distance { get; set; }
    public string[] PlacesOfInterest { get; set; }

    public override string ToString()
    {
      StringBuilder strb = new StringBuilder();
      string content = string.Format($"Place:{Place}\nDistance:{Distance}\nPlaces of Interest:");
      strb.Append(content);
      foreach (string place in PlacesOfInterest)
        strb.Append(place + ",");
      strb = strb.Remove(strb.Length - 1, 1);
      return strb.ToString();
    }
  }
  class SerializationDemo
  {
    static void Main(string[] args)
    {
      //What to serialize?
      //binarySerialize();
      //extractData();
      //xmlSerialize();
      readXmlData();
    }

    private static void readXmlData()
    {
      //Where to serialize:
      FileStream fs = new FileStream("TourInfo.xml", FileMode.OpenOrCreate, FileAccess.Read);
      //How to serialize:
      XmlSerializer fm = new XmlSerializer(typeof(TouristInfo));//typeof defines the schema of the XML file that U R creating...
      TouristInfo info = fm.Deserialize(fs) as TouristInfo;
      Console.WriteLine(info);
    }

    private static void xmlSerialize()
    {
      //What to serialize:
      TouristInfo info = new TouristInfo
      {
        TourID = 2,
        Place = "Mysore",
        Distance = 130,
        PlacesOfInterest = new string[] { "Zoo", "Chamundi Hills", "Srirangapatna", "KRS" }
      };
      //Where to serialize:
      FileStream fs = new FileStream("TourInfo.xml", FileMode.OpenOrCreate, FileAccess.Write);
      //How to serialize:
      XmlSerializer fm = new XmlSerializer(typeof(TouristInfo));//typeof defines the schema of the XML file that U R creating...
      fm.Serialize(fs, info);
      fs.Close();
    }

    private static void extractData()
    {
      FileStream fs = new FileStream("Details.Bin", FileMode.Open, FileAccess.Read);
      BinaryFormatter fm = new BinaryFormatter();

      TouristInfo info = fm.Deserialize(fs) as TouristInfo;
      fs.Close();
      if(info == null)
      {
        Console.WriteLine("Failed to get the serialized object");
        return; 
      }
      Console.WriteLine(info);
    }

    private static void binarySerialize()
    {
      TouristInfo details = new TouristInfo
      {
        TourID = 1,
        Place = "Hassan",
        Distance = 200,
        PlacesOfInterest = new string[] { "Belur", "Halebedu", "Shravanabelagola", "HeritageVillage" }
      };
      //Where to serialize?
      FileStream fs = new FileStream("Details.Bin", FileMode.OpenOrCreate, FileAccess.Write);
      //How to serialize(Binary Format)
      BinaryFormatter fm = new BinaryFormatter();
      fm.Serialize(fs, details);
      fs.Close();
    }
  }
}