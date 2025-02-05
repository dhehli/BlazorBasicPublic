namespace NetliveComponents.Models;
public class NetliveBreadcrumbItem
    {
        public string Text { get; set; } // Display text for the breadcrumb
        public string Link { get; set; } // URL for the breadcrumb
        public bool IsActive { get; set; } // Whether this is the current/active breadcrumb
    }
