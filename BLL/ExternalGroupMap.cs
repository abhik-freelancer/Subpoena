using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ;

namespace BLL
{
   public class ExternalGroupMap
    {
        public static void AddExternalGroupMap(List<LINQ.ExternalGroupMap> externalGroupMapcollection)
        {
            AccreditationDataContext objdb = new AccreditationDataContext();
            IEnumerable<LINQ.ExternalGroupMap> externalGroups = (from e in objdb.ExternalGroupMaps where e.ExternalGroupName.Equals(externalGroupMapcollection[0].ExternalGroupName) select e);
            bool flag = true;
            if (externalGroups.Any())
            {
                foreach (LINQ.ExternalGroupMap ws in externalGroupMapcollection)
                {
                    flag = true;
                    foreach (LINQ.ExternalGroupMap g in externalGroups)
                    {
                        if (g.AMSGroupName.Equals(ws.AMSGroupName))
                        {
                            flag = false;
                        }
                    }
                    if (flag)
                    {
                        objdb.ExternalGroupMaps.InsertOnSubmit(ws);
                    }
                }
                flag = true;
                foreach (LINQ.ExternalGroupMap g in externalGroups)
                {
                    flag = true;
                    foreach (LINQ.ExternalGroupMap ws in externalGroupMapcollection)
                    {
                        if (g.AMSGroupName.Equals(ws.AMSGroupName))
                        {
                            flag = false;
                        }
                    }
                    if (flag)
                    {
                        objdb.ExternalGroupMaps.DeleteOnSubmit(g);
                    }
                }
            }
            else
            {
                objdb.ExternalGroupMaps.InsertAllOnSubmit(externalGroupMapcollection);
            }
            objdb.SubmitChanges();
        }
        public static IEnumerable<string> ShowexternalGroupMap()
        {
            AccreditationDataContext objdb = new AccreditationDataContext();
            return (from f in objdb.ExternalGroupMaps select f.ExternalGroupName).Distinct();
        }
        public static IEnumerable<LINQ.ExternalGroupMap> ShoweGroupMap()
        {
            AccreditationDataContext objdb = new AccreditationDataContext();
            return (from f in objdb.ExternalGroupMaps select f);
        }
        public static List<LINQ.ExternalGroupMap> Get(string[] role)
        {
            AccreditationDataContext objdb = new AccreditationDataContext();
            return (from f in objdb.ExternalGroupMaps where role.Contains(f.ExternalGroupName) select f).ToList();
        }
    }
}
