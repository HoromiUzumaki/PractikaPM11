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
    
    public partial class Групповое_посещение
    {
        public string Логин { get; set; }
        public string Пароль { get; set; }
        public string Назначение { get; set; }
        public Nullable<int> Код_пропуска { get; set; }
        public Nullable<int> Код_группы { get; set; }
        public Nullable<int> Код_пользователя { get; set; }
    
        public virtual Группы_посещения Группы_посещения { get; set; }
        public virtual Пропуск Пропуск { get; set; }
    }
}
