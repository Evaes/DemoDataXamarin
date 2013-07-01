using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;

namespace QNHDemo.Data
{
	/// <summary>
	/// Class for the caseload data
	/// </summary>
	public class CaseLoad
	{
		public static List<QNHDemo.Data.Entities.Jeugdige> GetJeugdigen(string xml, string token)
		{
			var result = new List<QNHDemo.Data.Entities.Jeugdige>();

			if (xml == null)
			{
				result = Web.CaseLoadWeb.GetCaseLoad(token);
			}
			else
			{
				result = QNHDemo.Data.DAL.Dal.DeSerialize<List<QNHDemo.Data.Entities.Jeugdige>>(xml);
			}

			return result;
		}
	}
}
