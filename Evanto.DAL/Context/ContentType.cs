
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Evanto.DAL.Context
{

using System;
    using System.Collections.Generic;
    
public partial class ContentType
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public ContentType()
    {

        this.File = new HashSet<File>();

    }


    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public Nullable<System.DateTime> CreatedDate { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<File> File { get; set; }

}

}
