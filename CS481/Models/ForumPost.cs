//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CS481.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ForumPost
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ForumPost()
        {
            this.ForumComments = new HashSet<ForumComment>();
        }
    
        public string postID { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public Nullable<System.DateTime> timeCreate { get; set; }
        public string score { get; set; }
        public string userID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ForumComment> ForumComments { get; set; }
        public virtual User User { get; set; }
    }
}
