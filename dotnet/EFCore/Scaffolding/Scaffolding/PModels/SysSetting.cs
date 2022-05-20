using System;
using System.Collections.Generic;

namespace Scaffolding.PModels
{
    public partial class SysSetting
    {
        public string Settingkey { get; set; } = null!;
        public string? Settingdesc { get; set; }
        public string? Settingvalue { get; set; }
        public DateTime? Modifydate { get; set; }
        public string? Modifyuser { get; set; }
    }
}
