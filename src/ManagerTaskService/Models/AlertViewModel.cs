using System.Collections.Generic;

namespace ManagerTaskService.Models
{
    public class AlertViewModel
    {
        public List<DriverCheckAlert> Alerts { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }

    public class PagingInfo
    {
        public int CurrentPage { get; set; }

        public int Pages { get; set; }

        public int PageSpan { get; set; }
    }
}