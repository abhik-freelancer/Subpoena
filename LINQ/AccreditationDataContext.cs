using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace LINQ
{
   public  partial class  AccreditationDataContext
    {
        public bool FlagFixtures = false;
        public bool FlagFixture
        {
            get { return FlagFixture; }
            set { FlagFixture = value; }
        }
        public override void SubmitChanges(ConflictMode failureMode)
        {
            if (FlagFixtures == false)
            {

                // #region audited Department information
                // this.AuditInsert<LINQ.Department>(p => p.DepartmentId, "Department Added");
                // t/his.AuditUpdate<LINQ.Department>(p => p.DepartmentId, "Department Modified");
                //this.AuditDelete<LINQ.Department>(p => p.DepartmentId, "Department Deleted");
                //#endregion

            }
            base.SubmitChanges(failureMode);
        }
    }
}
