
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
    
public partial class CommonUserType
{

    public CommonUserType()
    {

        this.User = new HashSet<User>();

    }


    public int Id { get; set; }

    public string Name { get; set; }

    public Nullable<bool> IsDeleted { get; set; }



    public virtual ICollection<User> User { get; set; }

}

}
