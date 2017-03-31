using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TargetSystem.Account.Service
{
    public interface IMyEmailService
    {
        void SendEmail(string personalEmail, string serviceEmail, string password);
        
    }
}