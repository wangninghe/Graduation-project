//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace YAConpay.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Staff()
        {
            this.Sendpeople = new HashSet<Sendpeople>();
        }
    
        public int StaffID { get; set; }
        public string StaffName { get; set; }
        public string StaffSex { get; set; }
        public Nullable<int> StaffAge { get; set; }
        public string StaffPhone { get; set; }
        public Nullable<int> StaffPost { get; set; }
        public Nullable<int> StaffDorm { get; set; }
    
        public virtual Dorm Dorm { get; set; }
        public virtual Post Post { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sendpeople> Sendpeople { get; set; }
    }
}
