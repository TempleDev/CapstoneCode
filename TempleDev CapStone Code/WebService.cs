//    __                     __
//   /  /___________________ \  \
//  /  / |   ____    ____   | \  \
// /  /  |___|   |   |   |__|  \  \
///  /           |   |          \  \
//\  \           |   |          /  /
// \  \          |   |         /  /
//  \  \      _  |   |  _     /  /
//   \__\    | |_|   |_| |   /__/
//           |___________|   
//This code was collected and complied for the use oF the Temple University 
//Capstone 2 teams and the CE Systems Development team.
//    Authors: Kyler Love, Robert Zahorchak
//    Project Title: WebService
//    Description: 
// This is a helper class for Web Service requests
//----------------------------------------------------------------------------------------------------
// Example of Use
//
//      TempleLDAPEntry result = WebService.getLDAPEntryByAccessnet("tue71468");
//     or
//      TempleLDAPEntry result = WebService.getLDAPEntryByTUID("915006167");
//
// The 'result' variable will contain all info listed in the Web Services document on BB
//----------------------------------------------------------------------------------------------------
// Get the user's listed email address:
//
//      string emailAddress = result.mail;
//----------------------------------------------------------------------------------------------------
//                    

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TempleDev_CapStone_Code
{ 
 

public static class WebService
{
    private static string webServiceUsername = WSInfo.webServiceUsername;
    private static string webServicePassword = WSInfo.webServicePassword;


    // Takes a 9-digit TUID (like '915006167')
    // Returns a TempleLDAPEntry object
    public static TempleLDAPEntry getLDAPEntryByTUID(string tuID)
    {
        // Create the WebService proxy, send the search request and receive the TempleLDAPEntry object
        WS_LDAPSearch.LDAP_Search ldapProxy = new WS_LDAPSearch.LDAP_Search();
        WS_LDAPSearch.TempleLDAPEntry[] results = new WS_LDAPSearch.TempleLDAPEntry[1];
        results = ldapProxy.Search(webServiceUsername, webServicePassword, "templeEduTUID", tuID);
        WS_LDAPSearch.TempleLDAPEntry resultEntry = results[0];

        // Check if request was successful
        if (resultEntry.result == null) // Success
        {
            // Create our TempleLDAPEntry object to be returned
            TempleLDAPEntry personLDAPEntry = new TempleLDAPEntry();
            personLDAPEntry.templeEduID = resultEntry.templeEduTUID;
            personLDAPEntry.uID = resultEntry.uid;
            personLDAPEntry.cn = resultEntry.cn;
            personLDAPEntry.givenName = resultEntry.givenName;
            personLDAPEntry.sn = resultEntry.sn;
            personLDAPEntry.eduPersonAffiliation = resultEntry.eduPersonAffiliation;
            personLDAPEntry.eduPersonPrimaryAffiliation = resultEntry.eduPersonPrimaryAffiliation;
            personLDAPEntry.mail = resultEntry.mail;
            personLDAPEntry.title = resultEntry.title;
            return personLDAPEntry;
        }
        else // Something went wrong..
        {
            return null;
        }
    }

    // Takes an AccessNet ID (like 'tue71468')
    // Returns a TempleLDAPEntry object
    public static TempleLDAPEntry getLDAPEntryByAccessnet(string accessnetID)
    {
        // Create the WebService proxy, send the search request and receive the TempleLDAPEntry object
        WS_LDAPSearch.LDAP_Search ldapProxy = new WS_LDAPSearch.LDAP_Search();
        WS_LDAPSearch.TempleLDAPEntry[] results = new WS_LDAPSearch.TempleLDAPEntry[1];
        results = ldapProxy.Search(webServiceUsername, webServicePassword, "uid", accessnetID);
        WS_LDAPSearch.TempleLDAPEntry resultEntry = results[0];

        // Check if request was successful
        if (resultEntry.result == null) // Success
        {
            // Create our TempleLDAPEntry object to be returned
            TempleLDAPEntry personLDAPEntry = new TempleLDAPEntry();
            personLDAPEntry.templeEduID = resultEntry.templeEduTUID;
            personLDAPEntry.uID = resultEntry.uid;
            personLDAPEntry.cn = resultEntry.cn;
            personLDAPEntry.givenName = resultEntry.givenName;
            personLDAPEntry.sn = resultEntry.sn;
            personLDAPEntry.eduPersonAffiliation = resultEntry.eduPersonAffiliation;
            personLDAPEntry.eduPersonPrimaryAffiliation = resultEntry.eduPersonPrimaryAffiliation;
            personLDAPEntry.mail = resultEntry.mail;
            personLDAPEntry.title = resultEntry.title;
            return personLDAPEntry;
        }
        else // Something went wrong..
        {
            return null;
        }
    }

    // Takes an email alias (like ryan.hughes@temple.edu)
    // Returns a TempleLDAPEntry object for the person associated with the email alias
    public static TempleLDAPEntry getLDAPEntryByEmailAlias(string emailAlias)
    {
        // Split the email address and get the contents before the @
        string[] splitEmailAlias = emailAlias.Split('@');
        string templeEduTUNA = splitEmailAlias[0];

        // Create the WebService proxy, send the search request and receive the TempleLDAPEntry object
        WS_LDAPSearch.LDAP_Search ldapProxy = new WS_LDAPSearch.LDAP_Search();
        WS_LDAPSearch.TempleLDAPEntry[] results = new WS_LDAPSearch.TempleLDAPEntry[1];
        results = ldapProxy.Search(webServiceUsername, webServicePassword, "templeEduTUNA", templeEduTUNA);
        WS_LDAPSearch.TempleLDAPEntry resultEntry = results[0];

        // Check if request was successful
        if (resultEntry.result == null) // Success
        {
            // Create our TempleLDAPEntry object to be returned
            TempleLDAPEntry personLDAPEntry = new TempleLDAPEntry();
            personLDAPEntry.templeEduID = resultEntry.templeEduTUID;
            personLDAPEntry.uID = resultEntry.uid;
            personLDAPEntry.cn = resultEntry.cn;
            personLDAPEntry.givenName = resultEntry.givenName;
            personLDAPEntry.sn = resultEntry.sn;
            personLDAPEntry.eduPersonAffiliation = resultEntry.eduPersonAffiliation;
            personLDAPEntry.eduPersonPrimaryAffiliation = resultEntry.eduPersonPrimaryAffiliation;
            personLDAPEntry.mail = resultEntry.mail;
            personLDAPEntry.title = resultEntry.title;
            return personLDAPEntry;
        }
        else // Something went wrong..
        {
            return null;
        }
    }

    // Takes nothing
    // Returns a term object that contains all term data
    // Returns null if an error occurred
    public static Term getCurrentTerm()
    {
        WS_StudentSearch.WS_Student studentProxy = new WS_StudentSearch.WS_Student();
        WS_StudentSearch.Result results = new WS_StudentSearch.Result();
        results = studentProxy.GetCurrentTerm(webServiceUsername, webServicePassword);

        // Check if request was successful
        if (results.Status == "OK") // Success
        {
            Term returnTerm = new Term();
            WS_StudentSearch.Term[] t = results.Terms;
            returnTerm.termCode = t[0].code;
            returnTerm.termName = t[0].name;
            returnTerm.startDate = t[0].startDate;
            returnTerm.endDate = t[0].endDate;

            return returnTerm;
        }
        else // Something went wrong...
        {
            return null;

        }
    }

    // Takes a term code (4 digit year followed by 2 digit week)
    // Returns a term object that contains all term data
    public static Term getTermByTermCode(string termCode)
    {
        WS_StudentSearch.WS_Student studentProxy = new WS_StudentSearch.WS_Student();
        WS_StudentSearch.Result results = new WS_StudentSearch.Result();
        results = studentProxy.GetTermByTermCode(webServiceUsername, webServicePassword, termCode);

        // Check if request was successful
        if (results.Status == "OK") // Success
        {
            Term returnTerm = new Term();
            WS_StudentSearch.Term[] t = results.Terms;
            returnTerm.termCode = t[0].code;
            returnTerm.termName = t[0].name;
            returnTerm.startDate = DateTime.Parse(t[0].startDate).ToShortDateString().ToString();
            returnTerm.endDate = DateTime.Parse(t[0].endDate).ToShortDateString().ToString();
            return returnTerm;
        }
        else // Something went wrong...
        {
            return null;

        }
    }

    // Takes a date (can be MM/DD/YYYY, YYYY/MM/DD, MM/DD/YY)
    // Returns a term object that contains all term data
    public static Term GetTermByDate(string date)
    {
        WS_StudentSearch.WS_Student studentProxy = new WS_StudentSearch.WS_Student();
        WS_StudentSearch.Result results = new WS_StudentSearch.Result();
        results = studentProxy.GetTermByDate(webServiceUsername, webServicePassword, date);

        // Check if request was successful
        if (results.Status == "OK") // Success
        {
            Term returnTerm = new Term();
            WS_StudentSearch.Term[] t = results.Terms;
            returnTerm.termCode = t[0].code;
            returnTerm.termName = t[0].name;
            returnTerm.startDate = t[0].startDate;
            returnTerm.endDate = t[0].endDate;

            return returnTerm;
        }
        else // Something went wrong...
        {
            return null;

        }
    }

    // Takes a student's TUID
    // Returns true if student is eligible for Merit Scholar Stipends
    // Returns false if student is not eligible
    public static bool isEligibleMeritScholar(string TUID)
    {
        WS_StudentSearch.WS_Student studentProxy = new WS_StudentSearch.WS_Student();
        WS_StudentSearch.Result results = new WS_StudentSearch.Result();
        results = studentProxy.CheckMeritScholarEligibilityByTUID(webServiceUsername, webServicePassword, TUID);

        // Check if request was successful
        if (results.Status == "OK") // Success
        {
            WS_StudentSearch.MeritScholarEntry[] m = results.MeritScholar;

            if (m[0].eligibility.ToString() == "True") // Student is eligible
            {
                return true;
            }
            else // Student is not eligible
            {
                return false;
            }
        }
        else // Something went wrong...
        {
            return false;
        }
    }

    public static College[] getAllColleges()
    {
        try
        {
            WS_ProgramsAndDegrees.ProgramsAndDegrees programsProxy = new WS_ProgramsAndDegrees.ProgramsAndDegrees();
            WS_ProgramsAndDegrees.ProgramsAndDegreesEntry[] results = new WS_ProgramsAndDegrees.ProgramsAndDegreesEntry[30];
            results = programsProxy.GetAllColleges(webServiceUsername, webServicePassword);

            College[] colleges = new College[results.Length];

            for (int i = 0; i < results.Length; i++)
            {
                College c = new College();
                c.collegeName = results[i].college.ToString();
                c.collegeCode = results[i].collegeCode.ToString();
                colleges[i] = c;
            }

            return colleges;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    // Takes a college code
    // Returns the cooresponding college name per the Web Service
    public static string getCollegeNameByCollegeCode(string collegeCode)
    {
        try
        {
            WS_ProgramsAndDegrees.ProgramsAndDegrees programsProxy = new WS_ProgramsAndDegrees.ProgramsAndDegrees();
            WS_ProgramsAndDegrees.ProgramsAndDegreesEntry[] results = new WS_ProgramsAndDegrees.ProgramsAndDegreesEntry[30];
            results = programsProxy.GetAllColleges(webServiceUsername, webServicePassword);

            foreach (WS_ProgramsAndDegrees.ProgramsAndDegreesEntry entry in results)
            {
                if (entry.collegeCode.Equals(collegeCode))
                {
                    return entry.college;
                }
            }
        }
        catch (Exception ex)
        {
            return null;
        }

        return null;
    }

    // Does two web service calls
    // Gives all information for a student in the StudentObj object
    public static StudentObj getStudentInfo(string TUID)
    {
        //////// Get LDAP Info
        StudentObj student = new StudentObj();
        TempleLDAPEntry entry = getLDAPEntryByTUID(TUID);

        if (entry != null)
        {
            String[] name = entry.cn.Split(null); // splits 'cn' into first, middle, last

            if (name.Length == 2) // No middle initial
            {
                student.firstName = name[0];
                student.middleInit = "";
                student.lastName = name[1];
            }
            else if (name.Length == 3) // Has middle initial
            {
                student.firstName = name[0];
                student.middleInit = name[1];
                student.lastName = name[2];
            }
            else if (name.Length == 4) // Special case for people with 4 part names
            {
                student.firstName = name[0];
                student.middleInit = name[1] + " " + name[2];
                student.lastName = name[3];
            }

            student.email = entry.mail;
            student.tuid = entry.templeEduID;

            //////// Get Academic Info
            WS_StudentSearch.WS_Student studentProxy = new WS_StudentSearch.WS_Student();
            WS_StudentSearch.Result results = new WS_StudentSearch.Result();
            results = studentProxy.GetAcademicInfoByTUID(webServiceUsername, webServicePassword, TUID);

            // Check if request was successful
            if (results.Status == "OK") // Success
            {
                WS_StudentSearch.Student[] s = results.Students;
                student.major1 = s[0].major1;
                student.major2 = s[0].major2;
                student.school = s[0].collegeCode;

            }
            else // Something went wrong...
            {
                return null;
            }
        }

        return student;
    }

    // Takes a TUID
    // Returns the 'title' if person is a faculty member
    // Returns null if there was an error, or the person is not faculty
    public static String getFacultyTitleByTUID(string TUID)
    {
        // Create the WebService proxy, send the search request and receive the TempleLDAPEntry object
        WS_LDAPSearch.LDAP_Search ldapProxy = new WS_LDAPSearch.LDAP_Search();
        WS_LDAPSearch.TempleLDAPEntry[] results = new WS_LDAPSearch.TempleLDAPEntry[1];
        results = ldapProxy.Search(webServiceUsername, webServicePassword, "templeEduTUID", TUID);
        WS_LDAPSearch.TempleLDAPEntry resultEntry = results[0];

        // Check if request was successful
        if (resultEntry.result == null) // Success
        {
            string[] affiliations = resultEntry.eduPersonAffiliation.Split(',');
            foreach (string s in affiliations)
            {
                if (s.Equals("faculty"))
                {
                    return resultEntry.title;
                }
            }

            return null;
        }
        else // Something went wrong..
        {
            return null;
        }
    }

    // Returns an ArrayList of StudentObj with all merit scholars
    // Returns null if an error occured
    public static ArrayList getAllMeritScholars()
    {
        WS_LDAPSearch.LDAP_Search ldapProxy = new WS_LDAPSearch.LDAP_Search();
        WS_LDAPSearch.TempleLDAPEntry[] ldapResults = new WS_LDAPSearch.TempleLDAPEntry[1];
        WS_StudentSearch.WS_Student studentProxy = new WS_StudentSearch.WS_Student();
        WS_StudentSearch.Result results = new WS_StudentSearch.Result();
        results = studentProxy.GetMeritScholarEligibleStudents(webServiceUsername, webServicePassword);

        // Check if request was successful
        if (results.Status == "OK") // Success
        {
            // Get the array of all eligible students
            WS_StudentSearch.MeritScholarEntry[] students = results.MeritScholar;

            // Create the arraylist we will return
            ArrayList eligibleStudents = new ArrayList();

            // Check each student (i hope this doesn't crash anything)
            foreach (WS_StudentSearch.MeritScholarEntry m in students)
            {
                StudentObj s = WebService.getStudentInfo(m.tuid);

                if (s.school != null)
                {
                    eligibleStudents.Add(s);
                }
            }

            return eligibleStudents;
        }
        else // Something went wrong...
        {
            return null;
        }
    }

    // Takes a college code (MUST use the official Temple college codes from web service)
    // Returns an ArrayList of StudentObj with all merit scholars in a college
    // Returns null if an error occured (usually will be related to incorrect college name)
    public static ArrayList getMeritScholarsByCollege(string collegeCode)
    {
        WS_LDAPSearch.LDAP_Search ldapProxy = new WS_LDAPSearch.LDAP_Search();
        WS_LDAPSearch.TempleLDAPEntry[] ldapResults = new WS_LDAPSearch.TempleLDAPEntry[1];
        WS_StudentSearch.WS_Student studentProxy = new WS_StudentSearch.WS_Student();
        WS_StudentSearch.Result results = new WS_StudentSearch.Result();
        results = studentProxy.GetMeritScholarEligibleStudents(webServiceUsername, webServicePassword);

        // Check if request was successful
        if (results.Status == "OK") // Success
        {
            // Get the array of all eligible students
            WS_StudentSearch.MeritScholarEntry[] students = results.MeritScholar;

            // Create the arraylist we will return
            ArrayList eligibleStudentsInCollege = new ArrayList();

            // Check each student (i hope this doesn't crash anything)
            foreach (WS_StudentSearch.MeritScholarEntry m in students)
            {
                StudentObj s = WebService.getStudentInfo(m.tuid);

                if (s != null)
                {
                    if (s.school != null)
                    {
                        if (s.school.Equals(collegeCode))
                        {
                            // Student is in the college, add to ArrayList
                            eligibleStudentsInCollege.Add(s);
                        }
                    }
                }
            }

            return eligibleStudentsInCollege;
        }
        else // Something went wrong...
        {
            return null;
        }
    }
}
}