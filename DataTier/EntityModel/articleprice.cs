
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
    
public partial class articleprice
{

    public int IdArticlePrices { get; set; }

    public decimal UnitCost { get; set; }

    public int IdCertificateArticles { get; set; }

    public int IdPriceList { get; set; }



    public virtual pricelist pricelist { get; set; }

    public virtual certificatearticle certificatearticle { get; set; }

}

}
