using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TravelAgency.WebApi.Models;

namespace TravelAgency.WebApi.Helpers
{
    public class XmlHelper
    {
        public static string xmlZipFilePath = "xml.zip";
        public static string xmlFolderPath = "./xml/";

        private static void CreateXmlFile(AgencyViewModel agencyViewModel)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(AgencyViewModel));
            string fileName = String.Format("{0}{1}.xml", xmlFolderPath, agencyViewModel.Name);

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, agencyViewModel);
            }
        }
        public static void CreateXmlFile(AgencyViewModel[] agencyViewModel) {

                if (File.Exists(xmlZipFilePath))
                {
                    File.Delete(xmlZipFilePath);
                }

                foreach (var item in agencyViewModel)
                {
                    CreateXmlFile(item);
                }

                ZipFile.CreateFromDirectory(xmlFolderPath, xmlZipFilePath);
        }

       
    }
}
