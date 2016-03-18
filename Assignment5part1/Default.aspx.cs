using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;


namespace Assignment5part1
{
    public class userInfo
    {
        public string _name;
        public string _email;
        public userInfo(string name, string email)
        {
            _name = name;
            _email = email;
        }
    }
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            userInfo aUser1;
            HttpCookie myCookies = Request.Cookies["myCookieId"];
            if (myCookies == null || myCookies["Name"] == "")
            {
                nameLabel.Text = "Welcome, new user";
                emailLabel.Text = "";

            }
            else
            {
                nameLabel.Text = "Welcome, " + myCookies["Name"];
                emailLabel.Text = "We have your email " + myCookies["Email"];
            }
            if(Session.Count!=0){
                nameTextBox.Visible = false;
                emailTextBox.Visible = false;
                submitButton.Visible = false;
                Label2.Visible = false;
                aUser1 = (userInfo)Session["user1"];
                Label1.Text = "Already have session active as "+ aUser1._name;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            requiredService.Service proxy = new requiredService.Service();
            string str = proxy.wordFilter(Convert.ToString(filterTextBox.Text));
            filterResult.Text = str;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            requiredService.Service proxy = new requiredService.Service();
            string[] strs = proxy.Top10Words(Convert.ToString(top10TextBox.Text));
            foreach (string s in strs)
            {
                top10Result.Text += s + "\n";
            }
        }
       
        protected void submitButton_Click(object sender, EventArgs e)
        {
            HttpCookie myCookies = new HttpCookie("myCookieId");
            myCookies["Name"] = nameTextBox.Text;
            myCookies["Email"] = emailTextBox.Text;
            myCookies.Expires = DateTime.Now.AddMonths(6);
            Response.Cookies.Add(myCookies);
            nameLabel.Text = "Name stored in cookies " + myCookies["Name"];
            emailLabel.Text = "Email stored in cookies " + myCookies["Email"];
            userInfo aUser1 = new userInfo(nameTextBox.Text,emailTextBox.Text);
            string num = Convert.ToString(Session.Count + 1);
            string catalogKey = "user" + num;
            Session[catalogKey] = aUser1;
            nameTextBox.Visible = false;
            emailTextBox.Visible = false;
            submitButton.Visible = false;
            Label2.Visible = false;
            aUser1 = (userInfo)Session["user1"];
            Label1.Text = "Session is active as " + aUser1._name;
        }
        protected List<string> search(string xmlURL, string key)
        {
            string keyCorrect = char.ToUpper(key[0]) + key.Substring(1);
            List<string> contentList = new List<string>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlURL);
            XmlNodeList nodes = xmlDoc.GetElementsByTagName(keyCorrect);
            foreach (XmlNode x in nodes)
            {
                contentList.Add(x.InnerText);

            }

            List<string> attributeList = findAttribute(xmlURL, keyCorrect);
            foreach (string s in attributeList)
            {
                contentList.Add(s);
            }
            return contentList;
        }
        private List<string> findAttribute(string xmlURL, string attributeName)
        {
            XDocument document = XDocument.Load(xmlURL);
            List<string> attributeList = document.Descendants().Attributes(attributeName).Select(x => x.Value).ToList();
            return attributeList;
        }

        protected void submitButton2_Click(object sender, EventArgs e)
        {
            string username = userNameTxtBox.Text;
            string password = passwordTxtBox.Text;
            if (username == "")
            {
                resultLbl.Text = "Please enter Username.";
            }
            else if (password == "")
            {
                resultLbl.Text = "Please enter Password.";

            }
            else 
            { 
            List<string> findElementList = new List<string>();
            string fLocation = Path.Combine(Request.PhysicalApplicationPath, @"App_Data\Member.xml");
            findElementList = search(fLocation, "Username");
            FileStream fS = null;
            if (File.Exists(fLocation))
            {
                if (!findElementList.Contains(username))
                {
                    XDocument doc = XDocument.Load(fLocation);
                    XElement root = doc.Element("Members");
                    IEnumerable<XElement> rows = root.Descendants("Member");
                    XElement firstRow = rows.First();
                    firstRow.AddBeforeSelf(new XElement("Member", new XElement("Username", username), new XElement("Password", password)));
                    doc.Save(fLocation);
                    resultLbl.Text = "Information has been saved into Member.xml";

                }
                else
                {
                    resultLbl.Text = "Username already exists.";
                }
            }
            else
            {
                try
                {
                    fS = new FileStream(fLocation, FileMode.CreateNew);
                    XmlTextWriter writer = new XmlTextWriter(fS, System.Text.Encoding.Unicode);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Members");
                    writer.WriteStartElement("Member");
                    writer.WriteElementString("Username", username);
                    writer.WriteElementString("Password", password);
                    if (username.CompareTo(userNameTxtBox.Text) != 0)
                    {
                        writer.WriteEndElement();
                        writer.WriteStartElement("Member");
                        writer.WriteElementString("Username", userNameTxtBox.Text);
                        writer.WriteElementString("Password", passwordTxtBox.Text);
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Close();
                    fS.Close();
                    resultLbl.Text = "Information has been saved into Member.xml";

                }

                finally
                {
                    fS.Close();
                }
            }
            }            
        }
    }
}