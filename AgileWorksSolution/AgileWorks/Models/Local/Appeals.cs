//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AgileWorks.Models.Local
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Appeals
    {
        [Required]
        public int Appeal_Id { get; set; }
        [Required]
        [DisplayName("Appeal description")]
        public string Description { get; set; }
        [Required]
        [DisplayName("Appeal entry datetime")]
        public System.DateTime Entry_DateTime { get; set; }
        [Required]
        [DisplayName("Appeal deadline datetime")]
        public System.DateTime DeadLine_DateTime { get; set; }
    }
}
