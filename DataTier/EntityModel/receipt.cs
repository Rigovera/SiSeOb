
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
    
public partial class receipt
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public receipt()
    {

        this.receiptdetails = new HashSet<receiptdetail>();

    }


    public int IdReceipt { get; set; }

    public decimal TotalCost { get; set; }

    public System.DateTime Date { get; set; }

    public string Description { get; set; }

    public string ReceiptNumber { get; set; }

    public int IdWork { get; set; }



    public virtual work work { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<receiptdetail> receiptdetails { get; set; }

}

}
