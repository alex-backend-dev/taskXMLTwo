using System.IO;
using System.Text;
using System.Xml.Linq;

namespace taskTwoXML
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] content = File.ReadAllLines("Inlet.in.txt", Encoding.Default);

            XDocument xDoc = new XDocument();

            XElement root = new XElement("root");
            XElement line = new XElement("line");

            for (int i = 0; i < content.Length; i++)
            {
                if (content[i].StartsWith("data:"))
                {
                    root.Add(new XProcessingInstruction("instr", content[i].Substring(5)));
                    continue;
                }

                line.Add(content[i]);
                root.Add(line);

                line = new XElement("line");
            }

            xDoc.Add(root);
            xDoc.Save("resultFile.xml");
        }
    }
}
