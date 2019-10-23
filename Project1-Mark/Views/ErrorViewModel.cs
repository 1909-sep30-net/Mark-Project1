using System;

namespace Project1_Mark.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string errorMsg { get; set; }
    }
}
