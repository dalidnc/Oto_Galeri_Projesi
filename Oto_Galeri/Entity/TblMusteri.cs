//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Oto_Galeri.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblMusteri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblMusteri()
        {
            this.TblAracBilgileri = new HashSet<TblAracBilgileri>();
        }
    
        public int MusteriID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public Nullable<long> Telefon { get; set; }
        public Nullable<int> Arac { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblAracBilgileri> TblAracBilgileri { get; set; }
        public virtual TblAracBilgileri TblAracBilgileri1 { get; set; }
    }
}
