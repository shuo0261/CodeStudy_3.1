using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;

namespace CodeStudy_3._1.Model.EnumTypes
{
    public enum MajorEnum
    {
        //[Display(Name = "请选择")]
        //None,
        [Display(Name = "计算机科学")]
        ComputerScience,
        [Display(Name = "电子商务")]
        ElectronicCommerce,
        [Display(Name = "数学")]
        Mathematics
    }
}
