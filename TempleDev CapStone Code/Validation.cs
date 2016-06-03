
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
//    Project Title: Validation class
//    Description: This class can be used to validate the contents of textboxes.
//                 These methods will return boolean values based on the string returned to them
//                    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace TempleDev_CapStone_Code
{
    public class Validation
    {

        //Validates for a valid phone number 
        public bool ValidatePhoneNumber(string PhoneNumber)
        {
            Regex regexPhoneNumber = new Regex(@"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$");
            return (regexPhoneNumber.IsMatch(PhoneNumber));
        }

        //Check for a box to have a value
        public bool IsBlank(string FormString)
        {
            return (String.IsNullOrEmpty(FormString) || String.IsNullOrWhiteSpace(FormString));
        }

        //Validate a 5 digit zipcode
        public bool ValidateZipCode(string ZipCode)
        {
            Regex regexZipCode = new Regex(@"^(\d{5}-\d{4}|\d{5}|\d{9})$|^([a-zA-Z]\d[a-zA-Z] \d[a-zA-Z]\d)$");
            return (regexZipCode.IsMatch(ZipCode));

        }

        //Validate for a non-negative number
        public bool ValidateNonNegativeNumber(string nonNegativeNumber)
        {
            Regex NonNegativeNumber = new Regex(@"^\d+$");
            return (NonNegativeNumber.IsMatch(nonNegativeNumber));

        }

        //validate for currency
        public bool ValidateCurrency(string validCurrency)
        {
            Regex ValidCurrency = new Regex(@"^\d*\.?\d*$");
            return (ValidCurrency.IsMatch(validCurrency));

        }


        //Validate date
        public bool ValidateDate(string date)
        {
            DateTime res;
            return (DateTime.TryParse(date, out res));
        }


        //Validate for a temple email address.  This also checks for the Temple Hospital emails
        public bool ValidateTempleEmail(string Email)
        {
            Regex regexTempleEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return ((regexTempleEmail.IsMatch(Email)) && (Email.EndsWith("@temple.edu") || Email.EndsWith("@tuhs.temple.edu")));
        }

        // Validate that it is a potentially vialid email address
        public bool ValidateAnyEmail(string Email)
        {
            Regex regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return (regexEmail.IsMatch(Email));
        }


    //Validate a 9 didgit TUid
        public bool ValidateTUID(string TUID)
        {
            Regex regexTUID = new Regex(@"^\d{9}$");
            return (regexTUID.IsMatch(TUID));
        }


        //Validate for a 4 digit acedemic year
        public bool ValidateAcademicYear(string academicYear)
        {
            Regex regex = new Regex(@"^\d{4}[-]\d{4}$");
            return (regex.IsMatch(academicYear));
        }


        //Validate length of string in a text box
        public bool ValidateLength(string tbox, int length)
        {
            return tbox.Length == length;
        }


        //Validate word count in a text field
        public bool ValidateWordCount(string tbox, int count)
        {
            return tbox.Length <= (count * 10);
        }

        public bool ValidateNumberValue(string num, double maxNum)
        {
            if (!String.IsNullOrEmpty(num))
            {
                return Int64.Parse(num) <= maxNum;
            }
            else
                return false;
        }

        ////This can inly be used with access to Temple univesity LDAP Webservice
        ////it will check for an email against all faculty email, and alias emails
        //public bool ValidateTempleFacultyEmail(string emailAlias)
        //{
        //    TempleLDAPEntry result = WebService.getLDAPEntryByEmailAlias(emailAlias);

        //    if (result == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}


        //// Validates a TUID and returns whether or not they are a full time faculty

        ///// <summary>
        ///// Validates the full time faculty.
        ///// </summary>
        ///// <param name="TUID">The tuid.</param>
        ///// <returns></returns>
        //public bool ValidateFullTimeFaculty(string TUID)
        //{
        //    TempleLDAPEntry faculty = WebService.getLDAPEntryByTUID(TUID);

        //    if (faculty != null)
        //    {
        //        string[] title = faculty.title.Split();
        //        foreach (string s in title)
        //        {
        //            if (s.ToLower().Equals("adjunct"))
        //            {
        //                return false;
        //            }
        //        }

        //        string[] affiliations = faculty.eduPersonAffiliation.Split(',');
        //        foreach (string s in affiliations)
        //        {
        //            if (s.ToLower().Equals("faculty"))
        //            {
        //                return false;
        //            }
        //        }

        //        // If person is not primarily an employee
        //        if (!faculty.eduPersonPrimaryAffiliation.ToLower().Equals("employee"))
        //        {
        //            return false;
        //        }


        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}

    }
}
