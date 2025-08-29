namespace PrashantEle.API.PrashantEle.Domain.DTO.MenuDetail
{
    public class MenuDetailDTO
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public string HCssClass { get; set; }
        public string VCssClass { get; set; }
        public bool IsExternalLink { get; set; }
        public int ParentMenuId { get; set; }
        public bool IsVertical { get; set; }
        public bool IsHorizontal { get; set; }
        public bool IsFinYearWiseMenuLock { get; set; }
        public bool IsActive { get; set; }
    }

    public class MenuList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public string CssClass { get; set; }
        public int ParentMenuId { get; set; }
        public bool IsFinYearWiseMenuLock { get; set; }
        public bool IsActive { get; set; }
        public int Sequence { get; set; }
        public IEnumerable<MenuList> SubMenu { get; set; }   // 👈 changed here

    }
}
