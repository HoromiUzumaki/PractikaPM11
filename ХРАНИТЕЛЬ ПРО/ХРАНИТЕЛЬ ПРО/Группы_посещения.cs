//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ХРАНИТЕЛЬ_ПРО
{
    using System;
    using System.Collections.Generic;
    
    public partial class Группы_посещения
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Группы_посещения()
        {
            this.Групповое_посещение = new HashSet<Групповое_посещение>();
        }
    
        public int Код_группы { get; set; }
        public string Название_группы { get; set; }
        public string Код_пользователя { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Групповое_посещение> Групповое_посещение { get; set; }
    }
}
