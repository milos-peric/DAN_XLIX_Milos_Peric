//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAN_XLIX_Milos_Peric
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblManager
    {
        public int ManagerID { get; set; }
        public Nullable<int> FloorNumber { get; set; }
        public Nullable<int> WorkExperience { get; set; }
        public string LevelOfEducation { get; set; }
        public Nullable<int> UserID { get; set; }
    
        public virtual tblUser tblUser { get; set; }
    }
}
