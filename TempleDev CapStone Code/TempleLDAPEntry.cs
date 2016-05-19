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
//    Project Title: TempleLDAPEntry
//    Description: This is a LDAP object class to use with the LDAP login entries
//                    


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TempleDev_CapStone_Code
{
    public class TempleLDAPEntry
    {
        public string templeEduID;
        public string uID;
        public string cn;
        public string givenName;
        public string sn;
        public string eduPersonAffiliation;
        public string eduPersonPrimaryAffiliation;
        public string mail;
        public string title;
    }
}