using System;
using System.ComponentModel.DataAnnotations;

namespace MLNotification.Domain
{
    [Serializable]
    public class UserInfo : IUserInfo
    {
        [MaxLength(50)]
        public string Group { get; set; }
        [MaxLength(50)]
        public string User { get; set; }
        [MaxLength(50)]
        public string Server { get; set; }

    }



}



