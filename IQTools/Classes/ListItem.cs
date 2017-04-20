using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IQTools
{
  public class ListItem
  {
    #region Class Variables
    private string m_Text;
    private object m_Value;
    #endregion

    #region Public Properties
    public object Value
    {
      get
      {
        return m_Value;
      }
      set
      {
        this.m_Value = value;
      }
    }

    public string Text
    {
      get
      {
        return this.m_Text;
      }
      set
      {
        this.m_Text = value;
      }
    }
    #endregion

    public override string ToString ( )
    {
      return this.m_Text;
    }

    public class ListItemCollection : List<ListItem>
    {
    }
  }
}
