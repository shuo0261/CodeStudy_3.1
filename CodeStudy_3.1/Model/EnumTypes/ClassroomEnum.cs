using System.ComponentModel.DataAnnotations;

namespace CodeStudy_3._1.Model.EnumTypes
{
    public enum ClassroomEnum
    {
        //[Display(Name = "请选择")]
        //None,
        [Display(Name = "一年级")]
        FreshmanYear,
        [Display(Name = "二年级")]
        SecondGrade,
        [Display(Name = "三年级")]
        JuniorClass
    }
}
