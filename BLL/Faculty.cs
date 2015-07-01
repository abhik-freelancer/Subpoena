using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ;

namespace BLL
{
   public static class Faculty
    {
        #region Faculty
        
        public static IEnumerable<LINQ.Faculty> Get()
        {
            AccreditationDataContext objDB = new AccreditationDataContext();
            IEnumerable<LINQ.Faculty> Faculties = from f in objDB.Faculties orderby f.FacultyName select f;
            return Faculties;
        }
       
        /// <summary>
        /// Edit the Faculty
        /// </summary>
        /// <param name="FacultyId"></param>
        /// <param name="FacultyName"></param>
        /// <param name="Description"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        public static bool Update(int FacultyId, string FacultyName, string Description, out string Message)
        {
            AccreditationDataContext objDB = new AccreditationDataContext();
            try
            {
                LINQ.Faculty faculty = objDB.Faculties.First(F => F.FacultyId == FacultyId);

                faculty.FacultyName = FacultyName;
                faculty.Description = Description;

                objDB.SubmitChanges();
                Message = "Updated successfully";
                return true;
            }
            catch (Exception ex)
            {
                Message = "Cannot Update";
                return false;
            }
        }
        #endregion

        /// <summary>
        /// Populating all faculty in DropDownList
        /// </summary>
        /// <param name="facultyDropDownListId"></param>
        /// <returns></returns>
        public static IEnumerable<LINQ.Faculty> PopulateFacultyInDropDown()
        {
            AccreditationDataContext objDB = new AccreditationDataContext();
            IEnumerable<LINQ.Faculty> objFaculty = (from faculty in objDB.Faculties
                                                    select faculty);
            return objFaculty;
        }
    }
}
