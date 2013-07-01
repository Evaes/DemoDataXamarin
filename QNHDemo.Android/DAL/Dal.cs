using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using QNHDemo.Data.Entities;

namespace QNHDemo.Data.DAL
{
    /// <summary>
    /// Class for serialization of data
    /// </summary>
    public class Dal
    {
		//DO NOT CHANGE, LINKED WITH OTHER PROJECTS

        /// <summary>
        /// Serialize the user
        /// </summary>
        /// <returns>the xml format</returns>
        public static string SerializeUser(Gebruiker gebruiker)
        {
            StringBuilder builder = new StringBuilder();

            XmlWriter writer = XmlWriter.Create(builder);

            XmlSerializer serializer = new XmlSerializer(typeof(Entities.Gebruiker));
            serializer.Serialize(writer, gebruiker);

            return builder.ToString();
        }

        /// <summary>
        /// Dersializes xmldocument to user
        /// </summary>
        /// <param name="xml">the xml containing user info</param>
        /// <returns>Gebruiker object</returns>
        public static Gebruiker DeSerializeUser(string xml)
        {
            StringReader reader = new StringReader(xml);
            XmlReader xmlReader = XmlReader.Create(reader);

            XmlSerializer serializer = new XmlSerializer(typeof(Entities.Gebruiker));
            
            return (Gebruiker) serializer.Deserialize(xmlReader);
        }

        public static T DeSerialize<T>(string xml)
        {
            StringReader reader = new StringReader(xml);
            XmlReader xmlReader = XmlReader.Create(reader);

            XmlSerializer serializer = new XmlSerializer(typeof(T));

            return (T)serializer.Deserialize(xmlReader);
        }

        /// <summary>
        /// Serialize object to xml
        /// </summary>
        /// <typeparam name="T">Generic object T</typeparam>
        /// <param name="obj">object of type T</param>
        /// <returns>xml</returns>
        public static string SerializeObject<T>(T obj)
        {
            StringBuilder builder = new StringBuilder();

            XmlWriter writer = XmlWriter.Create(builder);

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(writer, obj);

            return builder.ToString();
        }
    }
}
