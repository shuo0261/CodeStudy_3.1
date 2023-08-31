using CodeStudy_3._1.Model.EnumTypes;
using System.ComponentModel.DataAnnotations;

namespace CodeStudy_3._1.Model
{
    public class Student
    {
        public int Id { get; set; }
        [Display(Name="名字")]
        [Required(ErrorMessage ="请输入名字，它不能为空"),MaxLength(20,ErrorMessage ="名字的长度不能超过20个字符")] //Required可以使字段成为必填项
        public string Name { get; set; }
        [Display(Name ="班级")]
        [Required(ErrorMessage ="请选择班级")]
        public ClassroomEnum Calssroom { get; set; }
        [Display(Name = "专业")]
        [Required(ErrorMessage = "请选择专业")]
        public MajorEnum? Major { get; set; }
        [Display(Name = "邮箱")]
        [RegularExpression(@"^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*\.[a-zA-Z0-9]{2,6}$",ErrorMessage ="邮箱的格式不正确")]
        [Required(ErrorMessage = "请输入邮箱，它不能为空")]
        public string Email { get; set; }
    }
}
