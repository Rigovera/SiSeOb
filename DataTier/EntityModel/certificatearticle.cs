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
    
    public partial class certificatearticle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public certificatearticle()
        {
            this.articleprices = new HashSet<articleprice>();
            this.certificatedetails = new HashSet<certificatedetail>();
        }
    
        public int IdCertificateArticles { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdMeasurementUnit { get; set; }
        public int IdCertificateArticleItem { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<articleprice> articleprices { get; set; }
        public virtual certificatearticleitem certificatearticleitem { get; set; }
        public virtual measurementunit measurementunit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<certificatedetail> certificatedetails { get; set; }
    }
}
