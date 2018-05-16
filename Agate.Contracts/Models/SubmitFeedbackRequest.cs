using System;
using System.Collections.Generic;
using System.Text;

namespace Agate.Contracts.Models
{
    public class SubmitFeedbackRequest
    {
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
