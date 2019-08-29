using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;

namespace WF_DiagramBuilder
{
    
    public class Node
    {
        [XmlElement(Type = typeof(XmlColor))]
        public Color color;
        public string name;
        public int value;
        public Node() { }
        public Node(string nodeName, int nodeValue, Color nodeColor) {
            this.name = nodeName;
            this.value = nodeValue;
            this.color = nodeColor; }
    }

    [XmlInclude(typeof(Node))]
    public class DiagramData
    {
        public string diagramName;
        public string diagramType;
        public List<Node> data;
        public DiagramData()
        {
            this.data = new List<Node>();
        }

        public void Clear()
        {
            diagramName = diagramType = "";
            data.Clear();
        }
    }

    class modelData
    {
        public DiagramData data;

        #region Singleton
        private static modelData instance;

        public modelData()
        {
            data = new DiagramData();
        }
        /// <summary>
        /// Возвращает модель для дальнейшей работы с данными
        /// </summary>
        public static modelData getInstance()
        {
            if (instance == null)
                instance = new modelData();
            return instance;
        }

        public void SaveToXML()
        {
            XmlSerializer xmlF = new XmlSerializer(typeof(DiagramData));
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML-File(*.xml) | *.xml";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Stream fs = File.Create(sfd.FileName);
                xmlF.Serialize(fs, modelData.getInstance().data);
                fs.Close();
            }
        }

        public void LoadFromXML()
        {
            //DiagramData temp = null;
            XmlSerializer xmlFormat = new XmlSerializer(typeof(DiagramData));
            OpenFileDialog open = new OpenFileDialog
            {
                Filter = "All Files(*.*)|*.*|Doc Files(*.xml) | *.xml || ",
                FilterIndex = 1
            };
            if (open.ShowDialog() == DialogResult.OK)
            {
                Stream fStream = File.OpenRead(open.FileName);
                getInstance().data = new DiagramData();
                //.Clear();
                // getInstance().data = (DiagramData)xmlFormat.Deserialize(fStream);
                DiagramData d = (DiagramData)xmlFormat.Deserialize(fStream);
                getInstance().data = d;
                //string tempText1 = open.FileName.TrimEnd(".xml".ToCharArray());
                //f.textBox1.Text = tempText1;
                fStream.Close();
                //modelData.setInstance(temp);
                //f.textBox2.Text = modelData.getInstance().data.data.ElementAt(0).elementType;
                //f.textBox3.Text = modelData.getInstance().data.data.ElementAt(0).unit;
                //if (f.listBox1.Items.Count > 0)
                //    f.listBox1.Items.Clear();
                
                
            }
        }

        #endregion
    }

    public class XmlColor
    {
        private Color color_ = Color.Black;

        public XmlColor() { }
        public XmlColor(Color c) { color_ = c; }


        public Color ToColor()
        {
            return color_;
        }

        public void FromColor(Color c)
        {
            color_ = c;
        }

        public static implicit operator Color(XmlColor x)
        {
            return x.ToColor();
        }

        public static implicit operator XmlColor(Color c)
        {
            return new XmlColor(c);
        }

        [XmlAttribute]
        public string Web
        {
            get { return ColorTranslator.ToHtml(color_); }
            set
            {
                try
                {
                    if (Alpha == 0xFF) // preserve named color value if possible
                        color_ = ColorTranslator.FromHtml(value);
                    else
                        color_ = Color.FromArgb(Alpha, ColorTranslator.FromHtml(value));
                }
                catch (Exception)
                {
                    color_ = Color.Black;
                }
            }
        }

        [XmlAttribute]
        public byte Alpha
        {
            get { return color_.A; }
            set
            {
                if (value != color_.A) // avoid hammering named color if no alpha change
                    color_ = Color.FromArgb(value, color_);
            }
        }

        public bool ShouldSerializeAlpha() { return Alpha < 0xFF; }
    }

}
