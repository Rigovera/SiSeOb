
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace DataTier.EntityModel
{

using System;
    using System.Collections.Generic;
    
public partial class assignedtool
{

    public int IdAssignedTool { get; set; }

    public System.DateTime DateOfAssignment { get; set; }

    public Nullable<System.DateTime> DateOfDeallocate { get; set; }

    public bool Assigned { get; set; }

    public int IdWork { get; set; }

    public int IdTool { get; set; }



    public virtual tool tool { get; set; }

    public virtual work work { get; set; }

}

}
