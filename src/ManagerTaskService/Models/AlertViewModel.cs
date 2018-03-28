using System.Collections.Generic;

namespace ManagerTaskService.Models
{
    /// <summary>
    /// Model class for an alert
    /// </summary>
    public class AlertViewModel
    {
        public List<DriverCheckAlert> Alerts { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }

    /// <summary>
    /// Model class for an paging info
    /// </summary>
    public class PagingInfo
    {
        public int CurrentPage { get; set; }

        public int Pages { get; set; }

        public int PageSpan { get; set; }
    }
}