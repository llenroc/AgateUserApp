using System;
using System.Collections.Generic;
using System.Text;

namespace OpalApp.Services
{
    public interface ILocalPath
    {
        string GetWebRoot();
        string GetLocalStorage(); // todo : remove it if not used
    }    
}
