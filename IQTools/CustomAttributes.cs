using System;
using System.Collections.Generic;
using System.Text;

namespace IQChartMerge
{

    // The AuthorAttribute class is a user-defined attribute class.
    // It can be applied to classes and struct declarations only.
    // It takes one unnamed string argument (the author's name).
    // It has one optional named argument Version, which is of type int.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct,AllowMultiple=true)]
    public class AuthorAttribute : Attribute
    {
        // This constructor specifies the unnamed arguments to the attribute class.
        public AuthorAttribute(string name)
        {
            this.name = name;
            this.version = 0;
        }

        // This property is readonly (it has no set accessor)
        // so it cannot be used as a named argument to this attribute.
        public string Name
        {
            get
            {
                return name;
            }
        }

        // This property is read-write (it has a set accessor)
        // so it can be used as a named argument when using this
        // class as an attribute class.
        public int Version
        {
            get
            {
                return version;
            }
            set
            {
                version = value;
            }
        }

        public override string ToString()
        {
            string value = "Author : " + Name;
            if (version != 0)
            {
                value += " Version : " + Version.ToString();
            }
            return value;
        }

        private string name;
        private int version;
    }


    [AttributeUsage(AttributeTargets.All,AllowMultiple=false)]
    public class IsTestedAttribute : Attribute
    {
        public override string ToString()
        {
            return "Is Tested";
        }
    }

    /// <summary>
    /// Custom attribute class which encapsulates a bug or it's respective
    /// resolution
    /// </summary>
    [AttributeUsage(AttributeTargets.All,AllowMultiple=true)]
    public class Bug: System.Attribute
    {
        private string m_defect;
        private string m_resolution;
        private DateTime m_datefixed;
        private DateTime m_datereported;
        private AuthorAttribute m_author;

        public Bug() { }

        public Bug(string Defect, DateTime DateReportd)
        {
            m_datereported = DateReportd;
            m_defect = Defect;
        }

        public Bug(string Defect, AuthorAttribute Author,DateTime DateReported)
        {
            m_author = Author;
            m_defect = Defect;
            m_datereported = DateReported;
        }

        public Bug(string Defect, string Resolution, DateTime DateReported, DateTime DateFixed)
        {
            m_defect = Defect;
            m_datereported = DateReported;
            m_resolution = Resolution;
            m_datefixed = DateFixed;
        }

        public DateTime DateFixed
        {
            get { return m_datefixed; }
            set { m_datefixed = value; }
        }

        public AuthorAttribute Author
        {
            get { return m_author; }
            set { m_author = value; }
        }

        public DateTime DateReported
        {
            get { return m_datereported; }
            set { m_datereported = value; }
        }


        public string Defect
        {
            get { return m_defect; }
            set { m_defect = value; }
        }
        /// <summary>
        /// Get/set resolution property
        /// </summary>
        public string Resolution
        {
            get { return m_resolution; }
            set { m_resolution = value; }
        }
    }
}
