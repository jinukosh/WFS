
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace WFS.Db
{

using System;
    using System.Collections.Generic;
    
public partial class LogLogin
{

    public int Id { get; set; }

    public Nullable<int> UserId { get; set; }

    public Nullable<System.DateTime> LogDate { get; set; }

    public string LoginLogType { get; set; }

    public string ExceptionString { get; set; }

    public string Comment { get; set; }

    public Nullable<bool> IsDeleted { get; set; }



    public virtual User User { get; set; }

}

}
