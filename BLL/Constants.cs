using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class Constants
    {
        #region Common messages used in entire solution.
        public const string Delete = "Deleted successfully";
        public const string Update = "Updated successfully";
        public const string Insert = "Inserted successfully";
        public const string NotInserted = "Unable to Insert";
        public const string NotUpdated = "Unable to Update";
        public const string NotDeleted = "Unable to Delete";
        public const string RegistrationFail = "Unable to Register";
        public const string BlankField = "Fields Cannot be Blank";
        public const string BadData = "Bad Data";
        public const string DataBaseTransacFailed = "Database transaction failed";
        public const string RelationExists = "Cannot delete. It has another relation/s.";
        public const string RecordNotFound = "No record found";
        public const string NoValueEntered = "Please Enter some Value";
        public const string NoOptionSeleted = "Please Select an Option";
        public const string InsuffData = "Insufficient Data";
        public const string FileExist = "File Already Exists";
        public const string FileAdded = "File added successfully";
        public const string SelectFile = "Select a file please";
        public const string Exists = "Exists";
        public const string none = "None";
        public const string successfully = "Successfully";
        public const string DepartmentNotPresent = "Department Not Present";
        public const string RecordNotPresent = "No record Present";
        public const string requestAdmin = "Logged in User Can't be Deleted";
        public const string requestDeleteAdmin = "Admin can't be deleted";
        public const string NoInstructorInformation = "Please Enter some Value to save Instructor profile information";
        public const string DuplicateValue = "Value already pre sent ";
        #endregion

        #region Department

        public const string UnableToCreateDepartement = "Unable to create departement. Department already exists.";
        public const string groupName = "User must be under a Group";
        #endregion

        #region Group

        public const string UnableToCreateGroup = "Unable to create Group. Group already exists.";
        // public const string groupName = "User must be under a Group";
        #endregion
        #region Email
        public const string UnableToCreateEmail = "Unable to create E-mail . E-Mail address already exists.";
        // public const string groupName = "User must be under a Group";
        public const string PasswordChnaged = "Password Updated already ";
        #endregion
        #region Email
        public const string UnableToChangePassword = "Password and Re-enter Password Values are not same!!!.";
        // public const string groupName = "User must be under a Group";
        public const string NoRecordToExport = "No Records to Export";
        public const string ExcelFileCreated = "Excel File Created in the D:\\ImportExcelFromDatabase folder";

        public const string EmailNotification = "Saved successfully and 6 digits tempurary password already sent to your email";
        #endregion


        #region UserHome

        public const string PwdMismatch = "Password mismatch";
        public const string WrongUserNamePwd = "Invalid ID or password";
        public const string UserNameValue = "User name must contain only alphanumeric characters & special characters (@,_).";
        public const string UserNameExists = "User name exists. Choose another user name";
        public const string UserNameRequired = "User name should not be blank";
        public const string FrmatMailId = "Email Address is not in correct format(id@domain.com)";
        public const string FirstNameRequired = "First name should not be blank";
        public const string FirseNameValue = "First name should not contain numeric values";
        public const string LastNameRequired = "Last name should not be blank";
        public const string LastNameValue = "Last name should not contain numeric values";
        public const string DepartmentRequired = "You must add a department to the user.";
        public const string MailIdRequired = "Email Address should not be blank";
        public const string ActiveFromDate = "'Active From' should not be blank";
        public const string ActiveUpToDate = "'Active To' should not be blank";
        public const string DateFrmFrmat = "'Active From' Format is not valid";
        public const string DateToFrmat = "'Active To' Format is not valid";
        public const string InActiveUser = "Inactive User";
        public const string OldPasswordRequired = "Old password field should not be blank";
        public const string PasswordRequired = "Password field should not be blank";
        public const string RePasswordRequired = "Re-type password field should not be blank";
        public const string PasswordRePasswordMismMatch = "Password and Re-type password mismatch";
        public const string InvalidPasswordLength = "Password must be at least 7 characters long with at least 1 digit and one special (non-alphanumeric) character";
        public const string InvalidPassword = "Password must contain at least 1 digit and one special (non-alphanumeric) character";
        public const string UserRegistration = "User registration successfully completed";
        public const string UpdateRegistration = "User update successfully complete";
        public const string ChangePassword = "Your password has been successfully changed and sent to your mail account";
        public const string Importuser = "Importuser";
        public const string EmailExist = "Email already exist";
        public const string PasswordQuestion = "Subpoena user?";
        public const string PasswordAnswer = "YES";
        public const string GroupRequired = "Select atleast one group";
        public const string ProfessionalRequired = "Select Professional status";
        public const string InactiveUserPassword = "@ams123";
        public const string NewPasswordSend = "Your new password successfully send to your email";
        public const string UserNameSecAnsRequired = "User name and security answer should not be blank";
        public const string PageLoadError = "Error In Page Loading";
        public const string ErrorUpload = "Error in file upload.try again";
        public const string FormatError = "CSV File contaning courses does not have right format";
        public const string DateFromTo = "Active Upto Date should greater that Active From Date";
        //Added by Joydeep
        public const string FromDateGreaterThanUptoDate = "Active From Date should be smaller than Active Upto Date";
        //
        public const string UsersuccessfulPassChanged = "User's Password successfully Changed";
        public const string UserOldPassword = "Old Password didn't match";

        public const string UserRegistrationFailed = "Sorry !!! User Registration Failed,Try again later.";

        #endregion

        #region UserProfile
        public const string UpldCV = "CV uploaded successfully";
        public const string NotUpldCV = "Cannot upload CV";
        public const string CVblank = "This file is blank";
        public const string FileXtnsn = "Upload Only doc, .rtf, .txt files";
        public const string FirstSelectCV = "Please select your CV first";
        public const string NoFile = "File Not found in the Server";
        public const string InstructorAdded = "No Instructor currently added with that course";
        public const string InfoAdded = "Please fill up all necessary information before adding new record";
        public const string UploadDenied = "Permission to upload file denied";
        #endregion

        #region Category
        public const string CatExists = "Category already exists";

        public const string CategoryMATH = "MATH";
        public const string CategoryNATSCI = "NAT SCI";
        public const string CategoryCSOPT = "CSOPT";
        public const string CategoryENGSCI = "ENGSCI";
        public const string CategoryENGDES = "ENGDES";
        public const string CategoryTOTAL = "TOTAL";
        #endregion

        #region Course
        public const string SelectExcelFile = "Please provide an EXCEL file";
        public const string CourseExists = "Course already exists";
        public const string CourseTitleExists = "Course title or number already exists";
        public const string CourseInserted = "Courses inserted successfully";
        public const string NoCourseFound = "No course found";
        public const string SelectCourse = "Select course";
        public const string DeptNotPresent = "Department is not present";
        public const string DoubleValNotNull = "Double value must not be NULL";
        public const string courseselection = "Problem in course in course selection";
        #endregion

        #region Modify
        public const string FileNotUploaded = "You Cannot Upload this File";
        public const string NewCourse = "Add New Course";
        public const string AUCatVal = "Enter maximum of 3 category values and each AU value should be greater than 25% of the total";
        public const string AUValueReq = "AU value should not be blank";
        public const string AUValueDouble = "AU value should be numeric and upto 2 decimal places";
        public const string TeachngAssntHours = "Teaching Assistant Hours should be numeric";
        public const string FailureRate = "Failure Rate should be numeric";
        public const string AvgGrd = "Average Grade should be numeric";
        public const string TeachngAssntCount = "Teaching Assistant Count should be numeric";
        public const string InsHr = "Instructor Hours Per Week should be numeric";
        public const string LecCount = "Lec count should be numeric";
        public const string SemCount = "Sem count should be numeric";
        public const string LabCount = "Lab count should be numeric";
        public const string LecMaxStudnt = "Lec max student should be greater than min student";
        public const string LecNumeric = "Lec max student should be numeric";
        public const string LecMinNumeric = "Lec min student should be numeric";
        public const string SemMaxStudnt = "Sem max student should be greater than min student";
        public const string SemNumeric = "Sem max student should be numeric";
        public const string SemMinNumeric = "Sem min students should be numeric";
        public const string LabMaxStudnt = "Lab max student should be greater than min student";
        public const string LabNumeric = "Lab max student should be numeric";
        public const string LabMinNumeric = "Lab min student should be numeric";
        public const string ISBNNoNotValid = "The ISBN number provided is not valid";
        public const string CourseTitleReq = "Course Title required";
        public const string CourseNoReq = "Course Number required";
        public const string SelectDept = "Select Department";
        public const string SelectFac = "Select faculty";
        public const string SelectAbbre = "Select Abbreviation";
        public const string CourseNumberReq = "Course Number Required";
        public const string CourseNumberNumeric = "Course Number Should Be Numeric";
        public const string NoDirectry = "Directory Not Found";
        public const string SelctEviType = "Please Select the Evidence Type";
        public const string NoPermission = "User Does Not Have Permission To Add Any Course";
        public const string ModeAdd = "Add";
        public const string ModeEdit = "Edit";
        public const string FileDeleted = "File Physically Deleted from Server";
        #endregion

        #region ImportCourseFromCSV
        public const string OptionImportCourse = "Please select one of the options to import Course";
        public const string ReadFile = "Read sucessfully";
        public const string UnableToRead = "Unable to read from CSV";
        public const string ExceptionMsg = "The size of the file was 0 bytes indicating it likely does not exist";
        public const string NoNewCourse = "No new course to import";
        #endregion

        #region AddInstruc
        public const string CannotAddRelatn = "Unable to add a Relation";
        public const string InstructrCourseRelatn = "These Instructors are not mapped with Course";
        public const string CannotUpdateRelatn = "Unable to update this relation";
        public const string CannotDelRelatn = "Unable to delete the relation";
        public const string RelDeletd = "Relation already deleted";
        public const string TaggedInsCourse = "Instructor and course tagged successfully";
        public const string RelExists = "This relation already exists";
        #endregion

        #region InstituteInformation
        public const string NoSubSectn = "No Subsection Present";
        public const string Emailpresent = "Email already present";

        #endregion

        #region Forget Password,User,Groups,EvidenceRecord
        public const string UserInactive = "SUser is Inactivated";
        public const string UserNotPresent = "No such user present";
        public const string TryAgain = "Cannot send Email";
        public const string InvalidID = "Cannot send Email. This is Not A Valid Email Address";
        public const string NewAMSPwd = "New Accredition Management password";
        public const string GroupNameExist = "Group Name Already Exists";
        public const string GroupAdded = "Group Added Successfully";
        public const string GroupUpdated = "One Group Updated Successfully";
        public const string NoEvidnce = "No Evidence Found";
        public const string NoEviAttchd = "No Evidence is Attached";
        public const string PhysicalCVNotFound = "CV Missing";
        public const string LoginFail = "Login Failed";
        public const string PwdUpdted = "Password Successfully Updated";
        public const string UserProfilenotUpdted = "Unable to Update User Profile";
        public const string UserNamePresent = "This User Name is already present for other users. Please specify another Username";
        public const string EmailIdPresent = "This E-Mail Address is already present for other users. Please specify another E-Mail";
        public const string EviAdded = "Evidence added successfully";
        public const string EviPresnt = "Evidence already present";
        public const string EviNotAdded = "Unable to add evidence";
        public const string Upload = "Uploaded Successfully";
        public const string NotUploaded = "Upload Unsuccessful";
        public const string FileNotExists = "File Physically Deleted from Server";
        #endregion

        #region Login
        public const string LoginFailureText = "Please select correct choice";
        public const string FailedAuthentication = "Authentication did not succeed. Check user name and password.";
        public const string AuthenError = "Error authenticating";
        #endregion

        #region ProgramsHome,Program
        public const string GiveAnotherName = "This name already exists. Please provide a different name.";
        public const string ProgCopy = "Program copied successfully";
        public const string NotCopied = "Cannot copy";
        public const string OneCourseOnly = "Select atleast one course";
        public const string CourseAddedIntoProgram = "Course added with program successfully";
        public const string CourseNotAddedIntoProgram = "Course could not be added with program";
        public const string UpdateCourseConstant = "Updated successfully";
        public const string NotUpdateCourseConstant = "Please try later";
        public const string departmentattach = "No course is currently attached with that department";
        public const string AvgWeekReq = "Avg. No. of week required";
        public const string ProgramNameRequired = "Program name should not be blank";
        public const string ProgramNameNotNumeric = "Program name should not contain only numeric value";
        public const string ProgramOptionRequired = "Program Option should not be blank";
        public const string ProgramOptionNotNumeric = "Program option should not contain only numeric value";
        public const string ProgramOptionAll = "Program option should not be 'All'";
        public const string ProgramOptionExists = "Program option exists. Choose another name or option";
        public const string ProgramExists = "Program name exists. Choose another name";
        public const string AvgWeekNumeric = "Avg. No. of week should be numeric and upto 2 decimal places";
        public const string ProgramNotAdd = "Can not Add program";
        #endregion

        #region Permission
        public const string SetPermission = "Permission Granted Successfully";
        public const string NotSetPermission = "Permission was not Successfully Granted";
        public const string SelectParameter = "Please select any";
        #endregion

        #region Faculty
        public const string FacultyNameDescReq = "Faculty Name and Faculty Decription both are required";
        public const string FacDeptRel = "This Faculty has Department under it";
        #endregion

        #region Exam
        public const string Exam = "Please create Sections to Upload Exam papers";
        #endregion

        public const string Nodatafound = "No Data Found";

        #region Expenditure TeachingOfficeSupplies

        public const string TeachingOfficeSupplies = "TeachingOfficeSupplies";
        public const string OperatingExpenditures = "OperatingExpenditures";

        #endregion

        #region Enum AMSQueryString

        public enum AMSQueryString
        {
            UserId
        }
        #endregion

        #region Enum ProgramConstrainType
        public enum ProgramConstrainType
        {
            All,
            CommonCore,
            Compulsory,
            Electives
        }
        #endregion

        #region Enum AMSSessionValues
        public enum AMSSessionValues
        {
            userId,
            firstName,
            userName,
            group,
            accessGroup,
            programId,
            programOption,
            courseId,
            topics,
            courseIdQueryString,
            checkFirstLogInForAdmin,
            passwordForAdmin,
            checkFirstLogInForIns,
            passwordForIns,
            checkRefreshSubmit,
            checkRefresh,
            NotAnInstructor,
            UserInfo,
            SavePath
        }
        #endregion

        #region Enum Role

        public enum Role
        {
            INSTRUCTOR,
            PROGRAMMANAGER
        }
        #endregion

        #region Enum Status

        public enum Status
        {
            NEW,
            YES,
            NO,
            MAYBE
        }
        #endregion

        #region Enum Operation

        public enum Operation
        {
            Add,
            Delete,
            Insert
        }
        #endregion

        #region Enum Term
        public enum TermNames
        {
            Winter,
            Summer,
            Fall,
            Spring
        }
        #endregion

        #region Term
        public const string NoTermSelected = "Please select a Term";
        #endregion

        #region Section

        public const string SectionName = "Section Name is required";
        public const string SectionYear = "A year must be selected";
        public const string SectionExists = "Duplicate Section already exists";
        public const string SectionTerm = "A term must be selected";
        public const string SectionTypeReq = "A Section Type must be selected";

        #endregion

        #region Book

        public const string AuthorNameReq = "Author name should not be blank";
        public const string AuthorNotNumeric = "Author Name should not contain only numeric value";
        public const string ISBNReq = "ISBN should not be blank";
        public const string ISBNFormat = "Incorrect ISBN format." + "Must be 10 or 13 digits";
        public const string YearReq = "Year should not be blank";
        public const string YearNemeric = "Year should be numeric";
        public const string YearLength = "Year should be formated by " + "yyyy";
        public const string BookTitleReq = "Book title should not be blank";
        public const string EditionReq = "Edition should not be blank";

        #endregion

        #region Scenario

        public const string ScenarioDeleted = "Scenario has been deleted Successfully";
        public const string ScenarioDeleteError = "Cannot delete Scenario";
        public const string SelectScenerio = "Please select a scenario clicking on the 'Load Scenario' Button below";

        #endregion

        #region SectionInstructorMap
        public const string SectionInstructorMapAdded = "Instructor Section  Map Added Successfully";
        public const string SectionInstructorMapExists = "Instructor with Section  Map already Exists";
        public const string SectionInstructorMapNotInserted = "Unable to Insert";
        #endregion

        #region Enum ExamPaperType
        public enum ExamPaperTypes
        {
            Final,
            MidTerm,
            Quiz,
            All
        }
        #endregion

        #region  Expenditures
        public enum ExpendituresType
        {
            SalariesAndBenefits,
            OperatingExpenditures,
            EquipmentExpenditures,
            OtherExpendituresOrAcquisitions
        }

        //public enum OperatingExpenditureType

        public enum SalariesAndBenefits
        {
            ContinuingAcademic,
            SessionalAcademics,
            TeachingAssistants,
            SupportStaff,
            Benefits
        }
        #endregion

        #region EvedencyType
        public enum EvidenceType
        {
            CourseOutline,
            Assignments,
            Exams,
            Other
        }

        #endregion

        #region SectionType
        public enum SectionType
        {
            LAB,
            LEC,
            SEM
        }

        #endregion

    }
}
