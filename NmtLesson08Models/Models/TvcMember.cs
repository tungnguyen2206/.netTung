using System.ComponentModel;

namespace NMTLesson.Models
{
    public class NMTMember
    {
        public string NMTMemberId { get; set; }
        public string NMTUserName { get;set; }
        public string NMTPassword { get; set; }

        [DisplayName("Họ và tên")]
        public string NMTFullName { get; set; }
        public string NMTEmail { get; set; }
    }

}
