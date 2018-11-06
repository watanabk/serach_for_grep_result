using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace grep
{
    class Program
    {
        private static string filePathRegex = @"^C:\\.+[.][a-z]+(?=[(])";
        private static string nodeRegex = @"^.*<SQLDesc>.*</SQLDesc>";
        static void Main(string[] args)
        {
            List<string> pathList = new List<string>();
            using (FileStream fileStream = new FileStream("grepfile.txt", FileMode.Open)){
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string line = "";
                    while((line = reader.ReadLine()) != null)  
                    {  
                        Match matchedObject = Regex.Match(line, filePathRegex);
                        string value = matchedObject.Value;
                        if(value != ""){
                            pathList.Add(matchedObject.Value);
                        }
                    }
                }
            }

            List<string> nodeList = new List<string>();
            foreach(string path in pathList) {
                Console.WriteLine("Read [" + path + "]");
                using (FileStream fileStream = new FileStream(path, FileMode.Open)){
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string line = "";
                        while((line = reader.ReadLine()) != null)  
                        {  
                            Match matchedObject = Regex.Match(line, nodeRegex);
                            string value = matchedObject.Value;
                            if(value != ""){
                                nodeList.Add(matchedObject.Value);
                            }
                        }
                    }   
                }
            }

            foreach(string node in nodeList) {
                Console.WriteLine(node);
            }
        }
    }
}
